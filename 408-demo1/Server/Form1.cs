using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Server
{

    public partial class Form1 : Form
    {
        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        Dictionary<string, Socket> clientSockets = new Dictionary<string, Socket>(); //to store client sockets
        Dictionary<string, Socket> connectedUsernames = new Dictionary<string, Socket>(); //to store connected users' username
        Dictionary<string, Socket> IF100Usernames = new Dictionary<string, Socket>(); //to store users that subscribed to IF100 channel
        Dictionary<string, Socket> SPS101Usernames = new Dictionary<string, Socket>(); //to store users that subscribed to SPS101 channel




        private readonly object clientSocketsLock = new object();
        private readonly object connectedUsernamesLock = new object();
        private readonly object IF100UsernamesLock = new object();
        private readonly object SPS101UsernamesLock = new object();





        bool terminating = false;
        bool listening = false;

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(Form1Server_FormClosing);
            InitializeComponent();
        }



        //server starts listening on port 
        private void portButton_click(object sender, EventArgs e)
        {
            int serverPort;

            if (Int32.TryParse(textBox1.Text, out serverPort))
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, serverPort);
                serverSocket.Bind(endPoint);
                serverSocket.Listen(3);

                listening = true;
                portbutton.Enabled = false;


                Thread acceptThread = new Thread(Accept);
                acceptThread.Start();

                serverLogTextBox.AppendText("Started listening on port: " + serverPort + "\n");

            }
            else
            {
                serverLogTextBox.AppendText("Please check port number \n");
            }

        }



        private void Accept()
        {
            while (listening)
            {
                try
                {
                    Socket newClient = serverSocket.Accept();

                    Byte[] Buffer = new Byte[1024];
                    newClient.Receive(Buffer);


                    string clientInfo = Encoding.Default.GetString(Buffer);
                    string[] dataParts = clientInfo.Split('\t');

                    string type = dataParts[0];
                    string name = dataParts[1];

                    string themessage = dataParts[2];



                    if (dataParts[0] == "1")
                    {
                        string clientName = name;


                        if (IsUsernameUnique(clientName))
                        {
                            clientSockets.Add(clientName, newClient);
                            connectedUsernames.Add(clientName, newClient);
                            serverLogTextBox.AppendText(clientName + " has connected successfully.\n");
                            SendAcknowledgment(newClient, "Connection successful\n");

                            UpdateServerLog();

                            // Start a new thread for receiving messages from this client
                            Thread receiveThread = new Thread(() => Receive(newClient));
                            receiveThread.Start();
                        }
                        else
                        {
                            SendAcknowledgment(newClient, "Username already exists. Connection failed\n");
                            newClient.Close();
                        }
                    }

                    if (dataParts[0] == "2")
                    {
                        string clientName = name;
                        Receive(newClient);
                        AddToIF100Usernames(clientName, newClient);
                        UpdateIF100Box();
                    }
                    if (dataParts[0] == "3")
                    {

                        string clientName = name;
                        AddToSPS101Usernames(clientName, newClient);
                        UpdateSPSBox();

                    }
                    if (dataParts[0] == "4")
                    {

                        string clientName = name;
                        UnsubscribeFromIF100(clientName);
                        UpdateIF100Box();

                    }
                    if (dataParts[0] == "5")
                    {

                        string clientName = name;
                        UnsubscribeFromSPS101(clientName);
                        UpdateSPSBox();

                    }
                    if (dataParts[0] == "6")
                    {

                        string clientName = name;
                        string messagetosend = "IF100" + "\t" + clientName + themessage + "\n";
                        BroadcastMessage(messagetosend, IF100Usernames[clientName]);
                    }
                    if (dataParts[0] == "7")
                    {

                        string clientName = name;
                        string messagetosend = "SPS101" + "\t" + clientName + themessage + "\n";
                        BroadcastMessage(messagetosend, SPS101Usernames[clientName]);
                    }






                }
                catch
                {
                    if (terminating)
                    {
                        listening = false;
                    }
                    else
                    {
                        serverLogTextBox.AppendText("The socket stopped working.\n");
                    }
                }
            }
        }

        private void UpdateServerLog()
        {
            connectedTextBox.Clear();

            foreach (var pair in connectedUsernames)
            {
                connectedTextBox.AppendText(pair.Key + Environment.NewLine);
            }
        }

        private void UpdateIF100Box()
        {
            IF100TextBox.Clear();
            foreach (var pair in IF100Usernames)
            {
                IF100TextBox.AppendText(pair.Key + "\n");
            }
        }

        private void UpdateSPSBox()
        {
            SPS101TextBox.Clear();
            foreach (var pair in SPS101Usernames)
            {
                SPS101TextBox.AppendText(pair.Key + "\n");
            }
        }




        private void Receive(Socket thisClient)
        {
            bool connected = true;


            while (connected && !terminating)
            {
                try
                {
                    Byte[] buffer = new Byte[1024];
                    thisClient.Receive(buffer);
                    string incomingMessage = Encoding.Default.GetString(buffer);
                    incomingMessage = incomingMessage.Substring(0, incomingMessage.IndexOf("\0"));
                    string[] dataParts = incomingMessage.Split('\t');
                    string clientUsername = dataParts[1];
                    string logMessage = incomingMessage.Substring(incomingMessage.IndexOf('\t') + 1); // Exclude the numeric prefix
                    serverLogTextBox.AppendText($"{clientUsername}: {logMessage}\n");

                }
                catch
                {
                    if (!terminating)
                    {
                        serverLogTextBox.AppendText("A client has disconnected\n");


                        // Modify to remove the client by username from the dictionary
                        var pairToRemove = connectedUsernames.FirstOrDefault(x => x.Value == thisClient);
                        if (pairToRemove.Key != null)
                        {
                            connectedUsernames.Remove(pairToRemove.Key);
                        }
                    }

                    thisClient.Close();
                    connected = false;
                }
            }
        }


        private void AddToIF100Usernames(string client_name, Socket newClient)
        {

            if (!IF100Usernames.ContainsKey(client_name))
            {
                IF100Usernames.Add(client_name, newClient);
                serverLogTextBox.AppendText(client_name + "subscribed to IF100 Channel\n");
                UpdateIF100Box();
            }
            else
            {
                serverLogTextBox.AppendText(client_name + " is alredy subscribed to IF100 Channel\n");

            }

        }
        private void AddToSPS101Usernames(string client_name, Socket newClient)
        {

            if (!SPS101Usernames.ContainsKey(client_name))
            {
                SPS101Usernames.Add(client_name, newClient);
                serverLogTextBox.AppendText(client_name + "subscribed to SPS101 Channel\n");
                UpdateSPSBox();
            }
            else
            {
                serverLogTextBox.AppendText(client_name + " is alredy subscribed to SPS101 Channel\n");
            }

        }

        private void UnsubscribeFromIF100(string clientName)
        {
            if (IF100Usernames.ContainsKey(clientName))
            {
                IF100Usernames.Remove(clientName);
                serverLogTextBox.AppendText(clientName + " unsubscribed from IF100 Channel\n");
                UpdateIF100Box();
            }
            else
            {
                serverLogTextBox.AppendText(clientName + " is not subscribed to IF100 Channel\n");
            }
        }
        private void UnsubscribeFromSPS101(string clientName)
        {
            if (SPS101Usernames.ContainsKey(clientName))
            {
                SPS101Usernames.Remove(clientName);
                serverLogTextBox.AppendText(clientName + " unsubscribed from SPS101 Channel\n");
                UpdateSPSBox();
            }
            else
            {
                serverLogTextBox.AppendText(clientName + " is not subscribed to SPS101 Channel\n");
            }
        }
        private void stopButton_click(object sender, EventArgs e)
        {
            if (listening)
            {
                listening = false;
                serverLogTextBox.AppendText("Stopped Listening \n");
                portbutton.Enabled = true;

            }
            else
            {
                serverLogTextBox.AppendText("Server is not currently listening\n");
            }
        }

        private void Form1Server_FormClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listening = false;
            terminating = true;
            Environment.Exit(0);
        }

        private bool IsUsernameUnique(string username)
        {
            return !connectedUsernames.ContainsKey(username);
        }

        private void SendAcknowledgment(Socket clientSocket, string message)
        {
            byte[] acknowledgmentBuffer = Encoding.Default.GetBytes(message);
            clientSocket.Send(acknowledgmentBuffer);
        }






        private void BroadcastMessage(string message, Socket targetSocket)
        {
            serverLogTextBox.AppendText($"Broadcasting message: {message} to target: {targetSocket}\n");

            if (targetSocket != null && targetSocket.Connected)
            {
                string channelPrefix = "";

                foreach (var pair in IF100Usernames)
                {
                    if (pair.Value == targetSocket)
                    {
                        channelPrefix = "IF100";
                        break;
                    }
                }

                if (string.IsNullOrEmpty(channelPrefix))
                {
                    foreach (var pair in SPS101Usernames)
                    {
                        if (pair.Value == targetSocket)
                        {
                            channelPrefix = "SPS101";
                            break;
                        }
                    }
                }

                if (!string.IsNullOrEmpty(channelPrefix))
                {
                    string prefixedMessage = $"{channelPrefix}{'\t'}{message}";

                    byte[] messageBuffer = Encoding.Default.GetBytes(prefixedMessage + "\0");
                    targetSocket.Send(messageBuffer);

                    serverLogTextBox.AppendText($"{channelPrefix} Message sent to {targetSocket}: {prefixedMessage}\n");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}