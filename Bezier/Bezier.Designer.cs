namespace lab05
{
    partial class Bezier
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
            this.imageToDrawBox = new System.Windows.Forms.PictureBox();
            this.ClearListButton = new System.Windows.Forms.Button();
            this.drawingGroupBox = new System.Windows.Forms.GroupBox();
            this.DeleteRadioButton = new System.Windows.Forms.RadioButton();
            this.MoveRadioButton = new System.Windows.Forms.RadioButton();
            this.CreateRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageToDrawBox)).BeginInit();
            this.drawingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageToDrawBox
            // 
            this.imageToDrawBox.Location = new System.Drawing.Point(218, 10);
            this.imageToDrawBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.imageToDrawBox.Name = "imageToDrawBox";
            this.imageToDrawBox.Size = new System.Drawing.Size(796, 659);
            this.imageToDrawBox.TabIndex = 8;
            this.imageToDrawBox.TabStop = false;
            this.imageToDrawBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.imageToDrawBox_MouseClick);
            this.imageToDrawBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageToDrawBox_MouseDown);
            this.imageToDrawBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageToDrawBox_MouseUp);
            // 
            // ClearListButton
            // 
            this.ClearListButton.Location = new System.Drawing.Point(11, 117);
            this.ClearListButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ClearListButton.Name = "ClearListButton";
            this.ClearListButton.Size = new System.Drawing.Size(194, 72);
            this.ClearListButton.TabIndex = 9;
            this.ClearListButton.Text = "Очистить";
            this.ClearListButton.UseVisualStyleBackColor = true;
            this.ClearListButton.Click += new System.EventHandler(this.ClearListButton_Click);
            // 
            // drawingGroupBox
            // 
            this.drawingGroupBox.Controls.Add(this.DeleteRadioButton);
            this.drawingGroupBox.Controls.Add(this.MoveRadioButton);
            this.drawingGroupBox.Controls.Add(this.CreateRadioButton);
            this.drawingGroupBox.Location = new System.Drawing.Point(3, 10);
            this.drawingGroupBox.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.drawingGroupBox.Name = "drawingGroupBox";
            this.drawingGroupBox.Padding = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.drawingGroupBox.Size = new System.Drawing.Size(211, 94);
            this.drawingGroupBox.TabIndex = 10;
            this.drawingGroupBox.TabStop = false;
            this.drawingGroupBox.Text = "Режим";
            // 
            // DeleteRadioButton
            // 
            this.DeleteRadioButton.AutoSize = true;
            this.DeleteRadioButton.Location = new System.Drawing.Point(16, 66);
            this.DeleteRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DeleteRadioButton.Name = "DeleteRadioButton";
            this.DeleteRadioButton.Size = new System.Drawing.Size(75, 17);
            this.DeleteRadioButton.TabIndex = 4;
            this.DeleteRadioButton.TabStop = true;
            this.DeleteRadioButton.Text = "Удаление";
            this.DeleteRadioButton.UseVisualStyleBackColor = true;
            // 
            // MoveRadioButton
            // 
            this.MoveRadioButton.AutoSize = true;
            this.MoveRadioButton.Location = new System.Drawing.Point(16, 45);
            this.MoveRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MoveRadioButton.Name = "MoveRadioButton";
            this.MoveRadioButton.Size = new System.Drawing.Size(101, 17);
            this.MoveRadioButton.TabIndex = 3;
            this.MoveRadioButton.Text = "Перемещение";
            this.MoveRadioButton.UseVisualStyleBackColor = true;
            // 
            // CreateRadioButton
            // 
            this.CreateRadioButton.AutoSize = true;
            this.CreateRadioButton.Checked = true;
            this.CreateRadioButton.Location = new System.Drawing.Point(16, 23);
            this.CreateRadioButton.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.CreateRadioButton.Name = "CreateRadioButton";
            this.CreateRadioButton.Size = new System.Drawing.Size(76, 17);
            this.CreateRadioButton.TabIndex = 2;
            this.CreateRadioButton.TabStop = true;
            this.CreateRadioButton.Text = "Создание";
            this.CreateRadioButton.UseVisualStyleBackColor = true;
            // 
            // Bezier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 679);
            this.Controls.Add(this.drawingGroupBox);
            this.Controls.Add(this.ClearListButton);
            this.Controls.Add(this.imageToDrawBox);
            this.Name = "Bezier";
            this.Text = "Bezier";
            ((System.ComponentModel.ISupportInitialize)(this.imageToDrawBox)).EndInit();
            this.drawingGroupBox.ResumeLayout(false);
            this.drawingGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox imageToDrawBox;
        private System.Windows.Forms.Button ClearListButton;
        private System.Windows.Forms.GroupBox drawingGroupBox;
        private System.Windows.Forms.RadioButton DeleteRadioButton;
        private System.Windows.Forms.RadioButton MoveRadioButton;
        private System.Windows.Forms.RadioButton CreateRadioButton;
    }
}