namespace lab05
{
    partial class LSys
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
            this.fractalsArea = new System.Windows.Forms.PictureBox();
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.iterationsCountBox = new System.Windows.Forms.NumericUpDown();
            this.fileNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fractalsArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsCountBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fractalsArea
            // 
            this.fractalsArea.Location = new System.Drawing.Point(11, 52);
            this.fractalsArea.Margin = new System.Windows.Forms.Padding(2);
            this.fractalsArea.Name = "fractalsArea";
            this.fractalsArea.Size = new System.Drawing.Size(480, 370);
            this.fractalsArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.fractalsArea.TabIndex = 1;
            this.fractalsArea.TabStop = false;
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(11, 11);
            this.chooseFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(92, 27);
            this.chooseFileButton.TabIndex = 2;
            this.chooseFileButton.Text = "Выбрать файл";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Итераций:";
            // 
            // iterationsCountBox
            // 
            this.iterationsCountBox.Location = new System.Drawing.Point(435, 16);
            this.iterationsCountBox.Margin = new System.Windows.Forms.Padding(2);
            this.iterationsCountBox.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.iterationsCountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iterationsCountBox.Name = "iterationsCountBox";
            this.iterationsCountBox.Size = new System.Drawing.Size(39, 20);
            this.iterationsCountBox.TabIndex = 5;
            this.iterationsCountBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(107, 18);
            this.fileNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(0, 13);
            this.fileNameLabel.TabIndex = 6;
            // 
            // LSys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 433);
            this.Controls.Add(this.fileNameLabel);
            this.Controls.Add(this.iterationsCountBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chooseFileButton);
            this.Controls.Add(this.fractalsArea);
            this.Name = "LSys";
            this.Text = "LSys";
            ((System.ComponentModel.ISupportInitialize)(this.fractalsArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iterationsCountBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fractalsArea;
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown iterationsCountBox;
        private System.Windows.Forms.Label fileNameLabel;
    }
}