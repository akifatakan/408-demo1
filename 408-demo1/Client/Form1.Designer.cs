
namespace Client
{
    partial class Form1
    {
         
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hostLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.TextBox();
            this.hostText = new System.Windows.Forms.TextBox();
            this.PortText = new System.Windows.Forms.TextBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.clientAction = new System.Windows.Forms.RichTextBox();
            this.IF100Label = new System.Windows.Forms.Label();
            this.IFsubscribe = new System.Windows.Forms.Button();
            this.IFunsubscribe = new System.Windows.Forms.Button();
            this.SPSLabel = new System.Windows.Forms.Label();
            this.SPSsubscribe = new System.Windows.Forms.Button();
            this.SPSunsubscribe = new System.Windows.Forms.Button();
            this.IF100sendtext = new System.Windows.Forms.TextBox();
            this.if100SendButton = new System.Windows.Forms.Button();
            this.SPS101richText = new System.Windows.Forms.RichTextBox();
            this.SPS101sendtext = new System.Windows.Forms.TextBox();
            this.SPS101sendbutton = new System.Windows.Forms.Button();
            this.IF100richText = new System.Windows.Forms.RichTextBox();
            this.disconnect_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(12, 9);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(41, 17);
            this.hostLabel.TabIndex = 0;
            this.hostLabel.Text = "Host:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(12, 36);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(38, 17);
            this.PortLabel.TabIndex = 1;
            this.PortLabel.Text = "Port:";
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(12, 64);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(77, 17);
            this.UsernameLabel.TabIndex = 2;
            this.UsernameLabel.Text = "Username:";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // NameText
            // 
            this.NameText.Location = new System.Drawing.Point(95, 64);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(155, 22);
            this.NameText.TabIndex = 3;
            // 
            // hostText
            // 
            this.hostText.Location = new System.Drawing.Point(95, 6);
            this.hostText.Name = "hostText";
            this.hostText.Size = new System.Drawing.Size(155, 22);
            this.hostText.TabIndex = 4;
            // 
            // PortText
            // 
            this.PortText.Location = new System.Drawing.Point(95, 33);
            this.PortText.Name = "PortText";
            this.PortText.Size = new System.Drawing.Size(155, 22);
            this.PortText.TabIndex = 5;
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 92);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(138, 25);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "Connect to Server";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // clientAction
            // 
            this.clientAction.Location = new System.Drawing.Point(314, 9);
            this.clientAction.Name = "clientAction";
            this.clientAction.Size = new System.Drawing.Size(321, 96);
            this.clientAction.TabIndex = 7;
            this.clientAction.Text = "";
            // 
            // IF100Label
            // 
            this.IF100Label.AutoSize = true;
            this.IF100Label.Location = new System.Drawing.Point(12, 157);
            this.IF100Label.Name = "IF100Label";
            this.IF100Label.Size = new System.Drawing.Size(99, 17);
            this.IF100Label.TabIndex = 8;
            this.IF100Label.Text = "IF100 Channel";
            // 
            // IFsubscribe
            // 
            this.IFsubscribe.Enabled = false;
            this.IFsubscribe.Location = new System.Drawing.Point(129, 152);
            this.IFsubscribe.Name = "IFsubscribe";
            this.IFsubscribe.Size = new System.Drawing.Size(98, 27);
            this.IFsubscribe.TabIndex = 9;
            this.IFsubscribe.Text = "subscribe";
            this.IFsubscribe.UseVisualStyleBackColor = true;
            this.IFsubscribe.Click += new System.EventHandler(this.IFsubscribe_Click);
            // 
            // IFunsubscribe
            // 
            this.IFunsubscribe.Enabled = false;
            this.IFunsubscribe.Location = new System.Drawing.Point(233, 152);
            this.IFunsubscribe.Name = "IFunsubscribe";
            this.IFunsubscribe.Size = new System.Drawing.Size(98, 27);
            this.IFunsubscribe.TabIndex = 10;
            this.IFunsubscribe.Text = "unsubscribe";
            this.IFunsubscribe.UseVisualStyleBackColor = true;
            this.IFunsubscribe.Click += new System.EventHandler(this.IFunsubscribe_Click);
            // 
            // SPSLabel
            // 
            this.SPSLabel.AutoSize = true;
            this.SPSLabel.Location = new System.Drawing.Point(397, 157);
            this.SPSLabel.Name = "SPSLabel";
            this.SPSLabel.Size = new System.Drawing.Size(115, 17);
            this.SPSLabel.TabIndex = 11;
            this.SPSLabel.Text = "SPS101 Channel";
            // 
            // SPSsubscribe
            // 
            this.SPSsubscribe.Location = new System.Drawing.Point(537, 152);
            this.SPSsubscribe.Name = "SPSsubscribe";
            this.SPSsubscribe.Size = new System.Drawing.Size(98, 27);
            this.SPSsubscribe.TabIndex = 12;
            this.SPSsubscribe.Text = "subscribe";
            this.SPSsubscribe.UseVisualStyleBackColor = true;
            this.SPSsubscribe.Click += new System.EventHandler(this.SPSsubscribe_Click);
            // 
            // SPSunsubscribe
            // 
            this.SPSunsubscribe.Location = new System.Drawing.Point(641, 152);
            this.SPSunsubscribe.Name = "SPSunsubscribe";
            this.SPSunsubscribe.Size = new System.Drawing.Size(98, 27);
            this.SPSunsubscribe.TabIndex = 13;
            this.SPSunsubscribe.Text = "unsubscribe";
            this.SPSunsubscribe.UseVisualStyleBackColor = true;
            this.SPSunsubscribe.Click += new System.EventHandler(this.SPSunsubscribe_Click);
            // 
            // IF100sendtext
            // 
            this.IF100sendtext.Location = new System.Drawing.Point(28, 373);
            this.IF100sendtext.Name = "IF100sendtext";
            this.IF100sendtext.Size = new System.Drawing.Size(270, 22);
            this.IF100sendtext.TabIndex = 15;
            // 
            // if100SendButton
            // 
            this.if100SendButton.Location = new System.Drawing.Point(59, 412);
            this.if100SendButton.Name = "if100SendButton";
            this.if100SendButton.Size = new System.Drawing.Size(191, 26);
            this.if100SendButton.TabIndex = 16;
            this.if100SendButton.Text = "Send Message";
            this.if100SendButton.UseVisualStyleBackColor = true;
            this.if100SendButton.Click += new System.EventHandler(this.if100SendButton_Click);
            // 
            // SPS101richText
            // 
            this.SPS101richText.Location = new System.Drawing.Point(430, 185);
            this.SPS101richText.Name = "SPS101richText";
            this.SPS101richText.Size = new System.Drawing.Size(270, 171);
            this.SPS101richText.TabIndex = 17;
            this.SPS101richText.Text = "";
            // 
            // SPS101sendtext
            // 
            this.SPS101sendtext.Location = new System.Drawing.Point(430, 373);
            this.SPS101sendtext.Name = "SPS101sendtext";
            this.SPS101sendtext.Size = new System.Drawing.Size(270, 22);
            this.SPS101sendtext.TabIndex = 18;
            // 
            // SPS101sendbutton
            // 
            this.SPS101sendbutton.Location = new System.Drawing.Point(467, 412);
            this.SPS101sendbutton.Name = "SPS101sendbutton";
            this.SPS101sendbutton.Size = new System.Drawing.Size(191, 26);
            this.SPS101sendbutton.TabIndex = 19;
            this.SPS101sendbutton.Text = "Send Message";
            this.SPS101sendbutton.UseVisualStyleBackColor = true;
            this.SPS101sendbutton.Click += new System.EventHandler(this.SPS101sendbutton_Click);
            // 
            // IF100richText
            // 
            this.IF100richText.Location = new System.Drawing.Point(28, 185);
            this.IF100richText.Name = "IF100richText";
            this.IF100richText.Size = new System.Drawing.Size(270, 171);
            this.IF100richText.TabIndex = 20;
            this.IF100richText.Text = "";
            // 
            // disconnect_button
            // 
            this.disconnect_button.Enabled = false;
            this.disconnect_button.Location = new System.Drawing.Point(156, 92);
            this.disconnect_button.Name = "disconnect_button";
            this.disconnect_button.Size = new System.Drawing.Size(152, 25);
            this.disconnect_button.TabIndex = 21;
            this.disconnect_button.Text = "Disconnect";
            this.disconnect_button.UseVisualStyleBackColor = true;
            this.disconnect_button.Click += new System.EventHandler(this.disconnect_button_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.disconnect_button);
            this.Controls.Add(this.IF100richText);
            this.Controls.Add(this.SPS101sendbutton);
            this.Controls.Add(this.SPS101sendtext);
            this.Controls.Add(this.SPS101richText);
            this.Controls.Add(this.if100SendButton);
            this.Controls.Add(this.IF100sendtext);
            this.Controls.Add(this.SPSunsubscribe);
            this.Controls.Add(this.SPSsubscribe);
            this.Controls.Add(this.SPSLabel);
            this.Controls.Add(this.IFunsubscribe);
            this.Controls.Add(this.IFsubscribe);
            this.Controls.Add(this.IF100Label);
            this.Controls.Add(this.clientAction);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.PortText);
            this.Controls.Add(this.hostText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.UsernameLabel);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.hostLabel);
            this.Name = "Form1";
            this.Text = "DiSUcord";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.TextBox NameText;
        private System.Windows.Forms.TextBox hostText;
        private System.Windows.Forms.TextBox PortText;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.RichTextBox clientAction;
        private System.Windows.Forms.Label IF100Label;
        private System.Windows.Forms.Button IFsubscribe;
        private System.Windows.Forms.Button IFunsubscribe;
        private System.Windows.Forms.Label SPSLabel;
        private System.Windows.Forms.Button SPSsubscribe;
        private System.Windows.Forms.Button SPSunsubscribe;
        private System.Windows.Forms.TextBox IF100sendtext;
        private System.Windows.Forms.Button if100SendButton;
        private System.Windows.Forms.RichTextBox SPS101richText;
        private System.Windows.Forms.TextBox SPS101sendtext;
        private System.Windows.Forms.Button SPS101sendbutton;
        private System.Windows.Forms.RichTextBox IF100richText;
        private System.Windows.Forms.Button disconnect_button;
    }
}