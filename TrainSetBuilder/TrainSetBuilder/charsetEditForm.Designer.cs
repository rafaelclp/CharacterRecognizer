namespace TrainSetBuilder
{
    partial class charsetEditForm
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
            this.charsetLabel = new System.Windows.Forms.Label();
            this.charsetTextBox = new System.Windows.Forms.TextBox();
            this.charsetPathTextBox = new System.Windows.Forms.TextBox();
            this.charsetPathLabel = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // charsetLabel
            // 
            this.charsetLabel.AutoSize = true;
            this.charsetLabel.Location = new System.Drawing.Point(12, 9);
            this.charsetLabel.Name = "charsetLabel";
            this.charsetLabel.Size = new System.Drawing.Size(155, 17);
            this.charsetLabel.TabIndex = 0;
            this.charsetLabel.Text = "Conjunto de caracteres";
            // 
            // charsetTextBox
            // 
            this.charsetTextBox.Location = new System.Drawing.Point(12, 29);
            this.charsetTextBox.Name = "charsetTextBox";
            this.charsetTextBox.Size = new System.Drawing.Size(258, 22);
            this.charsetTextBox.TabIndex = 1;
            this.charsetTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.charsetTextBox_KeyDown);
            // 
            // charsetPathTextBox
            // 
            this.charsetPathTextBox.Location = new System.Drawing.Point(12, 74);
            this.charsetPathTextBox.Name = "charsetPathTextBox";
            this.charsetPathTextBox.Size = new System.Drawing.Size(258, 22);
            this.charsetPathTextBox.TabIndex = 3;
            this.charsetPathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.charsetPathTextBox_KeyDown);
            // 
            // charsetPathLabel
            // 
            this.charsetPathLabel.AutoSize = true;
            this.charsetPathLabel.Location = new System.Drawing.Point(12, 54);
            this.charsetPathLabel.Name = "charsetPathLabel";
            this.charsetPathLabel.Size = new System.Drawing.Size(172, 17);
            this.charsetPathLabel.TabIndex = 2;
            this.charsetPathLabel.Text = "Diretório/nome do arquivo";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(195, 102);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 26);
            this.okButton.TabIndex = 5;
            this.okButton.Text = "Aplicar";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 102);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 26);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // charsetEditForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(282, 140);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.charsetPathTextBox);
            this.Controls.Add(this.charsetPathLabel);
            this.Controls.Add(this.charsetTextBox);
            this.Controls.Add(this.charsetLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "charsetEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conjunto de caracteres";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.charsetEditForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.charsetEditForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label charsetLabel;
        private System.Windows.Forms.TextBox charsetTextBox;
        private System.Windows.Forms.TextBox charsetPathTextBox;
        private System.Windows.Forms.Label charsetPathLabel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}