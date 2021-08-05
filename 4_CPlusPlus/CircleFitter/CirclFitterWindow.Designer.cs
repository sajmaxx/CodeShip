
namespace CurveDigitzer
{
    partial class CirclFitterWindow
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
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picboxDigitizer)).BeginInit();
            this.SuspendLayout();
            // 
            // picboxDigitizer
            // 
            this.picboxDigitizer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picboxDigitizer.Location = new System.Drawing.Point(52, 40);
            this.picboxDigitizer.Name = "picboxDigitizer";
            this.picboxDigitizer.Size = new System.Drawing.Size(400, 440);
            this.picboxDigitizer.TabIndex = 0;
            this.picboxDigitizer.TabStop = false;
            this.picboxDigitizer.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.picboxDigitizer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(376, 506);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(97, 23);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Location = new System.Drawing.Point(160, 506);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(97, 23);
            this.buttonGenerate.TabIndex = 2;
            this.buttonGenerate.Text = "Generate ";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(268, 506);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(97, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Clear Selection";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // CirclFitterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 541);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.picboxDigitizer);
            this.Name = "CirclFitterWindow";
            this.Text = "CircleFitter 2021";
            this.Load += new System.EventHandler(this.MainDigitizerViiew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxDigitizer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picboxDigitizer;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonClear;
    }
}

