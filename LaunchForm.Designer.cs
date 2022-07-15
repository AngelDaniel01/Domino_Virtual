namespace Domino_Virtual
{
    partial class LaunchForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ajustesBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ajustesBtn
            // 
            this.ajustesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ajustesBtn.Location = new System.Drawing.Point(116, 232);
            this.ajustesBtn.Margin = new System.Windows.Forms.Padding(6);
            this.ajustesBtn.Name = "ajustesBtn";
            this.ajustesBtn.Size = new System.Drawing.Size(139, 49);
            this.ajustesBtn.TabIndex = 0;
            this.ajustesBtn.Text = "Ajustes";
            this.ajustesBtn.UseVisualStyleBackColor = true;
            this.ajustesBtn.Click += new System.EventHandler(this.ajustesBtn_Click_1);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(116, 86);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 49);
            this.button2.TabIndex = 1;
            this.button2.Text = "Jugar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 356);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ajustesBtn);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "LaunchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.LaunchForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button ajustesBtn;
        private Button button2;
    }
}