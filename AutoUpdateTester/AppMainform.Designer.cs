
namespace AutoUpdateTester
{
    partial class AppMainform
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbCurrentAppVersion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(131, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current App Version:";
            // 
            // tbCurrentAppVersion
            // 
            this.tbCurrentAppVersion.Location = new System.Drawing.Point(130, 183);
            this.tbCurrentAppVersion.Name = "tbCurrentAppVersion";
            this.tbCurrentAppVersion.ReadOnly = true;
            this.tbCurrentAppVersion.Size = new System.Drawing.Size(228, 21);
            this.tbCurrentAppVersion.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(130, 306);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 69);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AppMainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbCurrentAppVersion);
            this.Controls.Add(this.label1);
            this.Name = "AppMainform";
            this.Text = "This is App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbCurrentAppVersion;
        private System.Windows.Forms.Button button1;
    }
}

