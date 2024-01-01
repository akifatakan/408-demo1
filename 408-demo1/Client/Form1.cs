using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    public partial class Form1 : Form
    {
        string localusername = " ";
        Socket clientSocket;

        bool terminating = false;
        bool connected = false;


        private const int IF100MessageType = 6;
        private const int SPS101MessageType = 7;

        public Form1()
        {

            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1Client_FormClosing);
            InitializeComponent();

        }


        private void connectButton_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string IP = hostText.Text;
            string username = NameText.Text;
            localusername = username;
            int portNum;

            if (Int32.TryParse(PortText.Text, out portNum))
            {
                try
                {
                    clientSocket.Connect(IP, portNum);
                    connectButton.Enabled = false;
                    connected = true;
                    IFsubscribe.Enabled = true;
                    SPSsubscribe.Enabled = true;

                    SendUsername(username);

                    Thread receiveThread = new Thread(Receive);
                    receiveThread.Start();

                }
                catch (Exception ex)
                {
                    clientAction.AppendText($"Could not connect to the server: {ex.Message}\n");
                }
            }
            else
            {
                clientAction.AppendText("Invalid port number\n");
            }
        }

        private void Receive()
        {
            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[1024];
                    clientSocket.Receive(buffer);

                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));

                    if (incomingMessage.Equals("Connection successful\n", StringComparison.Ordinal))

                    {
                        UpdateUI("Connected to the server!\n");
                    }
                    else if (incomingMessage.StartsWith("IF100"))
                    {
                        string messageContent = incomingMessage.Substring("IF100".Length + 1);
                        UpdateRichTextBox(IF100richText, messageContent + "\n");
                    }
                    else if (incomingMessage.StartsWith("SPS101"))
                    {
                        string messageContent = incomingMessage.Substring("SPS101".Length + 1);
                        UpdateRichTextBox(SPS101richText, messageContent + "\n");
                    }
                    else if (incomingMessage.StartsWith("SubscribedUsers"))
                    {
                        string[] users = incomingMessage.Split('\t');
                        if (users.Length >= 4)
                        {
                            string channel = users[2];
                            string subscribedUsers = users[3];
                            UpdateUI($"Users subscribed to {channel}: {subscribedUsers}\n");
                        }
                    }
                }
                catch
                {
                    if (!terminating)
                    {
                        UpdateUI("Disconnected from the server\n");
                    }
                    connected = false;
                    clientSocket.Close();
                }
            }
        }

        private void UpdateRichTextBox(RichTextBox richTextBox, string message)
        {
            if (!richTextBox.IsDisposed && richTextBox.InvokeRequired)
            {
                richTextBox.Invoke(new Action<RichTextBox, string>(UpdateRichTextBox), richTextBox, message);
            }
            else
            {
                richTextBox.AppendText(message);
            }

        }


        private void UpdateUI(string message)
        {
            // Use Invoke to update UI controls safely from a different thread
            if (clientAction.InvokeRequired)
            {
                clientAction.Invoke(new Action<string>(UpdateUI), message);
            }
            else
            {
                clientAction.AppendText(message);
            }
        }



        private void Form1Client_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connected = false;
            terminating = true;
            if (clientSocket != null && clientSocket.Connected)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }

        }





        private void SendUsername(string username)
        {

            string modifiedUsername = "1" + "\t" + localusername + "\t" + username;
            byte[] usernameBuffer = Encoding.Default.GetBytes(modifiedUsername);
            clientSocket.Send(usernameBuffer);

        }


        private void IFsubscribe_Click(object sender, EventArgs e)
        {
            string text = 2 + "\t" + localusername + "\t" + "IF100Subscribe";
            SendSubscription(text);
            clientAction.AppendText("Subscribed to IF100 channel\n");
            IFunsubscribe.Enabled = true;

        }

        private void SPSsubscribe_Click(object sender, EventArgs e)
        {
            string text = 3 + "\t" + localusername + "\t" + "SPS101Subscribe";
            SendSubscription(text);
            clientAction.AppendText("Subscribed to SPS101 channel\n");
            SPSunsubscribe.Enabled = true;
        }




        private void SendSubscription(string channel)
        {

            byte[] subscriptionBuffer = Encoding.Default.GetBytes(channel);
            clientSocket.Send(subscriptionBuffer);

        }


        private void SendunSubscription(string channel)
        {

            byte[] unsubscriptionBuffer = Encoding.Default.GetBytes(channel);
            clientSocket.Send(unsubscriptionBuffer);

        }

        private void SPSunsubscribe_Click(object sender, EventArgs e)
        {

            string text = 5 + "\t" + localusername + "\t" + "SPS101unSubscribe";
            SendunSubscription(text);

            clientAction.AppendText("Unubscribed to SPS101 channel\n");
            SPSsubscribe.Enabled = true;

        }

        private void IFunsubscribe_Click(object sender, EventArgs e)
        {
            string text = 4 + "\t" + localusername + "\t" + "IF100unSubscribe";
            SendunSubscription(text);

            clientAction.AppendText("Unsubscribed to IF100 channel\n");
            IFsubscribe.Enabled = true;
        }




        private void if100SendButton_Click(object sender, EventArgs e)
        {
            string message = IF100sendtext.Text;
            IF100sendtext.Clear();
            SendMessage(message, "IF100");
        }

        private void SPS101sendbutton_Click(object sender, EventArgs e)
        {
            string message = SPS101sendtext.Text;
            IF100sendtext.Clear();
            SendMessage(message, "SPS101");
        }

        private void SendMessage(string message, string channel)
        {
            string name = localusername;

            // Check if the client is subscribed to the channel
            if ((channel == "IF100" && IFsubscribe.Enabled) || (channel == "SPS101" && SPSsubscribe.Enabled))
            {
                UpdateUI($"You are not subscribed to {channel} channel. Cannot send message.\n");
                return;
            }

            if (message != "")
            {
                try
                {
                    string formattedMessage = $"{GetMessageType(channel)}{"\t"}{name}{"\t"}{channel}Message{"\t"}{message}";
                    byte[] messageBuffer = Encoding.Default.GetBytes(formattedMessage);
                    clientSocket.Send(messageBuffer);
                }
                catch (Exception ex)
                {
                    UpdateUI($"Error sending message: {ex.Message}\n");
                }
            }
            else
            {
                UpdateUI("Empty message");
            }
        }

        private int GetMessageType(string channel)
        {
            switch (channel)
            {
                case "IF100":
                    return IF100MessageType; // Modify with the appropriate message type for IF100
                case "SPS101":
                    return SPS101MessageType; // Modify with the appropriate message type for SPS101
                default:
                    return 0; // Default message type
            }
        }
        private void disconnect_button_Click(object sender, EventArgs e)
        {
            terminating = true;
            clientSocket.Close();
            connected = false;
            clientAction.AppendText("Successfully disconnected.\n");

            disconnect_button.Enabled = false;
            connectButton.Enabled = true;

            disconnect_button.BackColor = SystemColors.Control;
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}