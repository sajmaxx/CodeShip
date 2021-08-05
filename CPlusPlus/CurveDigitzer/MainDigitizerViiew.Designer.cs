
namespace CurveDigitzer
{
    partial class MainDigitizerViiew
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
            this.picboxDigitizer = new System.Windows.Forms.PictureBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picboxDigitizer)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picboxDigitizer
            // 
            this.picboxDigitizer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxDigitizer.Location = new System.Drawing.Point(24, 25);
            this.picboxDigitizer.Name = "picboxDigitizer";
            this.picboxDigitizer.Size = new System.Drawing.Size(430, 430);
            this.picboxDigitizer.TabIndex = 0;
            this.picboxDigitizer.TabStop = false;
            this.picboxDigitizer.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.picboxDigitizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.picboxDigitizer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(323, 17);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Location = new System.Drawing.Point(24, 471);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(430, 58);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Left Mouse Click, Drag to desired radius and release click";
            // 
            // MainDigitizerViiew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 538);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picboxDigitizer);
            this.Name = "MainDigitizerViiew";
            this.Text = "Circle Digitizer 2021";
            this.Load += new System.EventHandler(this.MainDigitizerViiew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxDigitizer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxDigitizer;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

