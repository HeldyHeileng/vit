namespace vit
{
    partial class Settings
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
            this.gridHeightComboBox = new System.Windows.Forms.ComboBox();
            this.enemyCountComboBox = new System.Windows.Forms.ComboBox();
            this.gridWidthComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.cancelSettingsButton = new System.Windows.Forms.Button();
            this.cellSizeTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gridHeightComboBox
            // 
            this.gridHeightComboBox.FormattingEnabled = true;
            this.gridHeightComboBox.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.gridHeightComboBox.Location = new System.Drawing.Point(197, 12);
            this.gridHeightComboBox.Name = "gridHeightComboBox";
            this.gridHeightComboBox.Size = new System.Drawing.Size(61, 21);
            this.gridHeightComboBox.TabIndex = 2;
            // 
            // enemyCountComboBox
            // 
            this.enemyCountComboBox.FormattingEnabled = true;
            this.enemyCountComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.enemyCountComboBox.Location = new System.Drawing.Point(129, 39);
            this.enemyCountComboBox.Name = "enemyCountComboBox";
            this.enemyCountComboBox.Size = new System.Drawing.Size(129, 21);
            this.enemyCountComboBox.TabIndex = 3;
            // 
            // gridWidthComboBox
            // 
            this.gridWidthComboBox.FormattingEnabled = true;
            this.gridWidthComboBox.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.gridWidthComboBox.Location = new System.Drawing.Point(129, 12);
            this.gridWidthComboBox.Name = "gridWidthComboBox";
            this.gridWidthComboBox.Size = new System.Drawing.Size(61, 21);
            this.gridWidthComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Размеры поля";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Количество врагов";
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(102, 99);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.saveSettingsButton.TabIndex = 4;
            this.saveSettingsButton.Text = "Сохранить";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // cancelSettingsButton
            // 
            this.cancelSettingsButton.Location = new System.Drawing.Point(183, 99);
            this.cancelSettingsButton.Name = "cancelSettingsButton";
            this.cancelSettingsButton.Size = new System.Drawing.Size(75, 23);
            this.cancelSettingsButton.TabIndex = 5;
            this.cancelSettingsButton.Text = "Отменить";
            this.cancelSettingsButton.UseVisualStyleBackColor = true;
            this.cancelSettingsButton.Click += new System.EventHandler(this.cancelSettingsButton_Click);
            // 
            // cellSizeTextBox
            // 
            this.cellSizeTextBox.Location = new System.Drawing.Point(129, 66);
            this.cellSizeTextBox.Name = "cellSizeTextBox";
            this.cellSizeTextBox.Size = new System.Drawing.Size(61, 20);
            this.cellSizeTextBox.TabIndex = 6;
            this.cellSizeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cellSizeTextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Размер клетки";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 134);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cellSizeTextBox);
            this.Controls.Add(this.cancelSettingsButton);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridWidthComboBox);
            this.Controls.Add(this.enemyCountComboBox);
            this.Controls.Add(this.gridHeightComboBox);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox gridHeightComboBox;
        private System.Windows.Forms.ComboBox enemyCountComboBox;
        private System.Windows.Forms.ComboBox gridWidthComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button cancelSettingsButton;
        private System.Windows.Forms.TextBox cellSizeTextBox;
        private System.Windows.Forms.Label label3;
    }
}