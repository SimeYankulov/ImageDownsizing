namespace ImageDownsizing
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
            this.openFileDialogBtn = new System.Windows.Forms.Button();
            this.selectedFilePathL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.parallelRB = new System.Windows.Forms.RadioButton();
            this.consequentialRB = new System.Windows.Forms.RadioButton();
            this.downsizingTF = new System.Windows.Forms.TextBox();
            this.downsizeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeElapsedL = new System.Windows.Forms.Label();
            this.finishedL = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogBtn
            // 
            this.openFileDialogBtn.Location = new System.Drawing.Point(33, 22);
            this.openFileDialogBtn.Name = "openFileDialogBtn";
            this.openFileDialogBtn.Size = new System.Drawing.Size(248, 32);
            this.openFileDialogBtn.TabIndex = 0;
            this.openFileDialogBtn.Text = "Browse Files";
            this.openFileDialogBtn.UseVisualStyleBackColor = true;
            this.openFileDialogBtn.Click += new System.EventHandler(this.openFileDialogBtn_Click);
            // 
            // selectedFilePathL
            // 
            this.selectedFilePathL.AutoSize = true;
            this.selectedFilePathL.Location = new System.Drawing.Point(30, 67);
            this.selectedFilePathL.Name = "selectedFilePathL";
            this.selectedFilePathL.Size = new System.Drawing.Size(84, 16);
            this.selectedFilePathL.TabIndex = 1;
            this.selectedFilePathL.Text = "Selected file ";
            this.selectedFilePathL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Downsize factor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.parallelRB);
            this.groupBox1.Controls.Add(this.consequentialRB);
            this.groupBox1.Location = new System.Drawing.Point(33, 170);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 50);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compressing mode";
            // 
            // parallelRB
            // 
            this.parallelRB.AutoSize = true;
            this.parallelRB.Location = new System.Drawing.Point(154, 22);
            this.parallelRB.Name = "parallelRB";
            this.parallelRB.Size = new System.Drawing.Size(74, 20);
            this.parallelRB.TabIndex = 1;
            this.parallelRB.TabStop = true;
            this.parallelRB.Text = "Parallel";
            this.parallelRB.UseVisualStyleBackColor = true;
            // 
            // consequentialRB
            // 
            this.consequentialRB.AutoSize = true;
            this.consequentialRB.Location = new System.Drawing.Point(18, 22);
            this.consequentialRB.Name = "consequentialRB";
            this.consequentialRB.Size = new System.Drawing.Size(114, 20);
            this.consequentialRB.TabIndex = 0;
            this.consequentialRB.TabStop = true;
            this.consequentialRB.Text = "Consequential";
            this.consequentialRB.UseVisualStyleBackColor = true;
            // 
            // downsizingTF
            // 
            this.downsizingTF.Location = new System.Drawing.Point(148, 123);
            this.downsizingTF.Name = "downsizingTF";
            this.downsizingTF.Size = new System.Drawing.Size(100, 22);
            this.downsizingTF.TabIndex = 5;
            // 
            // downsizeBtn
            // 
            this.downsizeBtn.Location = new System.Drawing.Point(102, 285);
            this.downsizeBtn.Name = "downsizeBtn";
            this.downsizeBtn.Size = new System.Drawing.Size(90, 30);
            this.downsizeBtn.TabIndex = 6;
            this.downsizeBtn.Text = "Downsize";
            this.downsizeBtn.UseVisualStyleBackColor = true;
            this.downsizeBtn.Click += new System.EventHandler(this.downsizeBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Time elapsed (seconds)";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // timeElapsedL
            // 
            this.timeElapsedL.AutoSize = true;
            this.timeElapsedL.Location = new System.Drawing.Point(184, 241);
            this.timeElapsedL.Name = "timeElapsedL";
            this.timeElapsedL.Size = new System.Drawing.Size(38, 16);
            this.timeElapsedL.TabIndex = 8;
            this.timeElapsedL.Text = "Time";
            // 
            // finishedL
            // 
            this.finishedL.AutoSize = true;
            this.finishedL.Location = new System.Drawing.Point(121, 330);
            this.finishedL.Name = "finishedL";
            this.finishedL.Size = new System.Drawing.Size(0, 16);
            this.finishedL.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 519);
            this.Controls.Add(this.finishedL);
            this.Controls.Add(this.timeElapsedL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downsizeBtn);
            this.Controls.Add(this.downsizingTF);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.selectedFilePathL);
            this.Controls.Add(this.openFileDialogBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openFileDialogBtn;
        private System.Windows.Forms.Label selectedFilePathL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton parallelRB;
        private System.Windows.Forms.RadioButton consequentialRB;
        private System.Windows.Forms.TextBox downsizingTF;
        private System.Windows.Forms.Button downsizeBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeElapsedL;
        private System.Windows.Forms.Label finishedL;
    }
}

