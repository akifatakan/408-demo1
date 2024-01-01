namespace Server
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.portbutton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.serverLogTextBox = new System.Windows.Forms.RichTextBox();
            this.connectedTextBox = new System.Windows.Forms.RichTextBox();
            this.IF100TextBox = new System.Windows.Forms.RichTextBox();
            this.SPS101TextBox = new System.Windows.Forms.RichTextBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.ConnectedLabel = new System.Windows.Forms.Label();
            this.IFLabel = new System.Windows.Forms.Label();
            this.SPSLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(58, 61);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 22);
            this.textBox1.TabIndex = 0;
            // 
            // portbutton
            // 
            this.portbutton.Location = new System.Drawing.Point(78, 89);
            this.portbutton.Name = "portbutton";
            this.portbutton.Size = new System.Drawing.Size(131, 26);
            this.portbutton.TabIndex = 2;
            this.portbutton.Text = "Start Server";
            this.portbutton.UseVisualStyleBackColor = true;
            this.portbutton.Click += new System.EventHandler(this.portButton_click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(78, 121);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(131, 26);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop Server";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_click);
            // 
            // serverLogTextBox
            // 
            this.serverLogTextBox.Location = new System.Drawing.Point(265, 9);
            this.serverLogTextBox.Name = "serverLogTextBox";
            this.serverLogTextBox.Size = new System.Drawing.Size(504, 175);
            this.serverLogTextBox.TabIndex = 4;
            this.serverLogTextBox.Text = "";
            // 
            // connectedTextBox
            // 
            this.connectedTextBox.Location = new System.Drawing.Point(24, 226);
            this.connectedTextBox.Name = "connectedTextBox";
            this.connectedTextBox.Size = new System.Drawing.Size(224, 212);
            this.connectedTextBox.TabIndex = 5;
            this.connectedTextBox.Text = "";
            // 
            // IF100TextBox
            // 
            this.IF100TextBox.Location = new System.Drawing.Point(287, 226);
            this.IF100TextBox.Name = "IF100TextBox";
            this.IF100TextBox.Size = new System.Drawing.Size(205, 212);
            this.IF100TextBox.TabIndex = 6;
            this.IF100TextBox.Text = "";
            // 
            // SPS101TextBox
            // 
            this.SPS101TextBox.Location = new System.Drawing.Point(529, 226);
            this.SPS101TextBox.Name = "SPS101TextBox";
            this.SPS101TextBox.Size = new System.Drawing.Size(217, 212);
            this.SPS101TextBox.TabIndex = 7;
            this.SPS101TextBox.Text = "";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(12, 64);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(38, 17);
            this.PortLabel.TabIndex = 8;
            this.PortLabel.Text = "Port:";
            // 
            // ConnectedLabel
            // 
            this.ConnectedLabel.AutoSize = true;
            this.ConnectedLabel.Location = new System.Drawing.Point(75, 206);
            this.ConnectedLabel.Name = "ConnectedLabel";
            this.ConnectedLabel.Size = new System.Drawing.Size(122, 17);
            this.ConnectedLabel.TabIndex = 9;
            this.ConnectedLabel.Text = "Connected Clients";
            // 
            // IFLabel
            // 
            this.IFLabel.AutoSize = true;
            this.IFLabel.Location = new System.Drawing.Point(337, 206);
            this.IFLabel.Name = "IFLabel";
            this.IFLabel.Size = new System.Drawing.Size(99, 17);
            this.IFLabel.TabIndex = 10;
            this.IFLabel.Text = "IF100 Channel";
            // 
            // SPSLabel
            // 
            this.SPSLabel.AutoSize = true;
            this.SPSLabel.Location = new System.Drawing.Point(581, 206);
            this.SPSLabel.Name = "SPSLabel";
            this.SPSLabel.Size = new System.Drawing.Size(115, 17);
            this.SPSLabel.TabIndex = 11;
            this.SPSLabel.Text = "SPS101 Channel";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SPSLabel);
            this.Controls.Add(this.IFLabel);
            this.Controls.Add(this.ConnectedLabel);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.SPS101TextBox);
            this.Controls.Add(this.IF100TextBox);
            this.Controls.Add(this.connectedTextBox);
            this.Controls.Add(this.serverLogTextBox);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.portbutton);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "DiSUcord Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button portbutton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.RichTextBox serverLogTextBox;
        private System.Windows.Forms.RichTextBox connectedTextBox;
        private System.Windows.Forms.RichTextBox IF100TextBox;
        private System.Windows.Forms.RichTextBox SPS101TextBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label ConnectedLabel;
        private System.Windows.Forms.Label IFLabel;
        private System.Windows.Forms.Label SPSLabel;
    }
}