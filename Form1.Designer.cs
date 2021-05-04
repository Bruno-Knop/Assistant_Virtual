
namespace Assistant_Virtual {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Bar_Audio = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // Bar_Audio
            // 
            this.Bar_Audio.Location = new System.Drawing.Point(12, 150);
            this.Bar_Audio.Maximum = 75;
            this.Bar_Audio.Name = "Bar_Audio";
            this.Bar_Audio.Size = new System.Drawing.Size(278, 32);
            this.Bar_Audio.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 194);
            this.Controls.Add(this.Bar_Audio);
            this.Name = "Form1";
            this.Text = "Assistant Virtual";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar Bar_Audio;
    }
}

