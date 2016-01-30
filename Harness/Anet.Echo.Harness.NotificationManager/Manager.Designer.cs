namespace Anet.Echo.Harness.NotificationManager
{
    partial class Manager
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
            this.btnPushWebHookNotification = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPushWebHookNotification
            // 
            this.btnPushWebHookNotification.Location = new System.Drawing.Point(22, 88);
            this.btnPushWebHookNotification.Name = "btnPushWebHookNotification";
            this.btnPushWebHookNotification.Size = new System.Drawing.Size(234, 23);
            this.btnPushWebHookNotification.TabIndex = 0;
            this.btnPushWebHookNotification.Text = "Push Web Hook Notification";
            this.btnPushWebHookNotification.UseVisualStyleBackColor = true;
            this.btnPushWebHookNotification.Click += new System.EventHandler(this.btnPushWebHookNotification_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.btnPushWebHookNotification);
            this.Name = "Manager";
            this.Text = "Notification Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPushWebHookNotification;
    }
}

