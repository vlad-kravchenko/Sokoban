namespace Sokoban2Players
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.btnStart = new System.Windows.Forms.Button();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.radioServer = new System.Windows.Forms.RadioButton();
            this.radioClient = new System.Windows.Forms.RadioButton();
            this.lbHost = new System.Windows.Forms.Label();
            this.lbPort = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(538, 49);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(159, 73);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Начать игру";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbHost
            // 
            this.tbHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHost.Location = new System.Drawing.Point(171, 38);
            this.tbHost.Multiline = true;
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(135, 23);
            this.tbHost.TabIndex = 1;
            this.tbHost.Text = "127.0.0.1";
            this.tbHost.Visible = false;
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.Location = new System.Drawing.Point(171, 11);
            this.tbPort.Multiline = true;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(135, 23);
            this.tbPort.TabIndex = 2;
            this.tbPort.Text = "8000";
            this.tbPort.Visible = false;
            // 
            // radioServer
            // 
            this.radioServer.AutoSize = true;
            this.radioServer.BackColor = System.Drawing.Color.Transparent;
            this.radioServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioServer.Location = new System.Drawing.Point(12, 12);
            this.radioServer.Name = "radioServer";
            this.radioServer.Size = new System.Drawing.Size(89, 24);
            this.radioServer.TabIndex = 3;
            this.radioServer.TabStop = true;
            this.radioServer.Text = "Сервер";
            this.radioServer.UseVisualStyleBackColor = false;
            this.radioServer.CheckedChanged += new System.EventHandler(this.radioServer_CheckedChanged);
            // 
            // radioClient
            // 
            this.radioClient.AutoSize = true;
            this.radioClient.BackColor = System.Drawing.Color.Transparent;
            this.radioClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioClient.Location = new System.Drawing.Point(12, 39);
            this.radioClient.Name = "radioClient";
            this.radioClient.Size = new System.Drawing.Size(89, 24);
            this.radioClient.TabIndex = 4;
            this.radioClient.TabStop = true;
            this.radioClient.Text = "Клиент";
            this.radioClient.UseVisualStyleBackColor = false;
            this.radioClient.CheckedChanged += new System.EventHandler(this.radioClient_CheckedChanged);
            // 
            // lbHost
            // 
            this.lbHost.AutoSize = true;
            this.lbHost.BackColor = System.Drawing.Color.Transparent;
            this.lbHost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHost.Location = new System.Drawing.Point(107, 41);
            this.lbHost.Name = "lbHost";
            this.lbHost.Size = new System.Drawing.Size(52, 20);
            this.lbHost.TabIndex = 5;
            this.lbHost.Text = "Host:";
            this.lbHost.Visible = false;
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.BackColor = System.Drawing.Color.Transparent;
            this.lbPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPort.Location = new System.Drawing.Point(107, 14);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(47, 20);
            this.lbPort.TabIndex = 6;
            this.lbPort.Text = "Port:";
            this.lbPort.Visible = false;
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(709, 534);
            this.Controls.Add(this.lbPort);
            this.Controls.Add(this.lbHost);
            this.Controls.Add(this.radioClient);
            this.Controls.Add(this.radioServer);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "WelcomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Интеллектуальная игра Sokoban2Players";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.RadioButton radioServer;
        private System.Windows.Forms.RadioButton radioClient;
        private System.Windows.Forms.Label lbHost;
        private System.Windows.Forms.Label lbPort;
    }
}

