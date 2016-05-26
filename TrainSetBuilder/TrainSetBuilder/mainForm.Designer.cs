namespace TrainSetBuilder
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.charsetList = new System.Windows.Forms.ListView();
            this.charsetColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.charsetAddButton = new System.Windows.Forms.Button();
            this.charsetRemoveButton = new System.Windows.Forms.Button();
            this.charsetEditButton = new System.Windows.Forms.Button();
            this.trainGenerateButton = new System.Windows.Forms.Button();
            this.fontsList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgWidthLabel = new System.Windows.Forms.Label();
            this.imgHeightLabel = new System.Windows.Forms.Label();
            this.fontSizeLabel = new System.Windows.Forms.Label();
            this.clearDirectoryButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.statusProgressLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.fontSizeUpDown = new System.Windows.Forms.NumericUpDown();
            this.adjustSizeCheckBox = new System.Windows.Forms.CheckBox();
            this.imgHeightUpDown = new System.Windows.Forms.NumericUpDown();
            this.imgWidthUpDown = new System.Windows.Forms.NumericUpDown();
            this.trainPathTextBox = new System.Windows.Forms.TextBox();
            this.configPanel = new System.Windows.Forms.Panel();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHeightUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWidthUpDown)).BeginInit();
            this.configPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // charsetList
            // 
            this.charsetList.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.charsetList.CheckBoxes = true;
            this.charsetList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.charsetColumn,
            this.pathColumn});
            this.charsetList.FullRowSelect = true;
            this.charsetList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.charsetList.HideSelection = false;
            this.charsetList.Location = new System.Drawing.Point(12, 12);
            this.charsetList.Name = "charsetList";
            this.charsetList.Size = new System.Drawing.Size(758, 128);
            this.charsetList.TabIndex = 0;
            this.charsetList.UseCompatibleStateImageBehavior = false;
            this.charsetList.View = System.Windows.Forms.View.Details;
            this.charsetList.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.charsetList_ItemSelectionChanged);
            this.charsetList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.charsetList_KeyDown);
            // 
            // charsetColumn
            // 
            this.charsetColumn.Text = "Conjunto de caracteres";
            this.charsetColumn.Width = 308;
            // 
            // pathColumn
            // 
            this.pathColumn.Text = "Diretório/nome do arquivo";
            this.pathColumn.Width = 405;
            // 
            // charsetAddButton
            // 
            this.charsetAddButton.Location = new System.Drawing.Point(12, 146);
            this.charsetAddButton.Name = "charsetAddButton";
            this.charsetAddButton.Size = new System.Drawing.Size(100, 24);
            this.charsetAddButton.TabIndex = 1;
            this.charsetAddButton.Text = "Adicionar";
            this.charsetAddButton.UseVisualStyleBackColor = true;
            this.charsetAddButton.Click += new System.EventHandler(this.charsetAddButton_Click);
            // 
            // charsetRemoveButton
            // 
            this.charsetRemoveButton.Enabled = false;
            this.charsetRemoveButton.Location = new System.Drawing.Point(121, 146);
            this.charsetRemoveButton.Name = "charsetRemoveButton";
            this.charsetRemoveButton.Size = new System.Drawing.Size(100, 24);
            this.charsetRemoveButton.TabIndex = 2;
            this.charsetRemoveButton.Text = "Remover";
            this.charsetRemoveButton.UseVisualStyleBackColor = true;
            this.charsetRemoveButton.Click += new System.EventHandler(this.charsetRemoveButton_Click);
            // 
            // charsetEditButton
            // 
            this.charsetEditButton.Enabled = false;
            this.charsetEditButton.Location = new System.Drawing.Point(670, 146);
            this.charsetEditButton.Name = "charsetEditButton";
            this.charsetEditButton.Size = new System.Drawing.Size(100, 24);
            this.charsetEditButton.TabIndex = 3;
            this.charsetEditButton.Text = "Editar";
            this.charsetEditButton.UseVisualStyleBackColor = true;
            this.charsetEditButton.Click += new System.EventHandler(this.charsetEditButton_Click);
            // 
            // trainGenerateButton
            // 
            this.trainGenerateButton.Location = new System.Drawing.Point(670, 30);
            this.trainGenerateButton.Name = "trainGenerateButton";
            this.trainGenerateButton.Size = new System.Drawing.Size(100, 24);
            this.trainGenerateButton.TabIndex = 6;
            this.trainGenerateButton.Text = "Gerar";
            this.trainGenerateButton.UseVisualStyleBackColor = true;
            this.trainGenerateButton.Click += new System.EventHandler(this.trainGenerateButton_Click);
            // 
            // fontsList
            // 
            this.fontsList.CheckBoxes = true;
            this.fontsList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.fontsList.FullRowSelect = true;
            this.fontsList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.fontsList.HideSelection = false;
            this.fontsList.Location = new System.Drawing.Point(12, 176);
            this.fontsList.Name = "fontsList";
            this.fontsList.Size = new System.Drawing.Size(758, 296);
            this.fontsList.TabIndex = 7;
            this.fontsList.UseCompatibleStateImageBehavior = false;
            this.fontsList.View = System.Windows.Forms.View.Details;
            this.fontsList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fontsList_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Fonte";
            this.columnHeader1.Width = 239;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Preview";
            this.columnHeader2.Width = 476;
            // 
            // imgWidthLabel
            // 
            this.imgWidthLabel.AutoSize = true;
            this.imgWidthLabel.Location = new System.Drawing.Point(12, 5);
            this.imgWidthLabel.Name = "imgWidthLabel";
            this.imgWidthLabel.Size = new System.Drawing.Size(86, 17);
            this.imgWidthLabel.TabIndex = 8;
            this.imgWidthLabel.Text = "Largura (px)";
            // 
            // imgHeightLabel
            // 
            this.imgHeightLabel.AutoSize = true;
            this.imgHeightLabel.Location = new System.Drawing.Point(178, 5);
            this.imgHeightLabel.Name = "imgHeightLabel";
            this.imgHeightLabel.Size = new System.Drawing.Size(73, 17);
            this.imgHeightLabel.TabIndex = 10;
            this.imgHeightLabel.Text = "Altura (px)";
            // 
            // fontSizeLabel
            // 
            this.fontSizeLabel.AutoSize = true;
            this.fontSizeLabel.Location = new System.Drawing.Point(331, 5);
            this.fontSizeLabel.Name = "fontSizeLabel";
            this.fontSizeLabel.Size = new System.Drawing.Size(124, 17);
            this.fontSizeLabel.TabIndex = 13;
            this.fontSizeLabel.Text = "Tamanho da fonte";
            // 
            // clearDirectoryButton
            // 
            this.clearDirectoryButton.Location = new System.Drawing.Point(554, 30);
            this.clearDirectoryButton.Name = "clearDirectoryButton";
            this.clearDirectoryButton.Size = new System.Drawing.Size(110, 24);
            this.clearDirectoryButton.TabIndex = 15;
            this.clearDirectoryButton.Text = "Remover tudo";
            this.clearDirectoryButton.UseVisualStyleBackColor = true;
            this.clearDirectoryButton.Click += new System.EventHandler(this.clearDirectoryButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.statusProgressBar,
            this.statusProgressLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 531);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(782, 22);
            this.statusStrip.TabIndex = 16;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(76, 20);
            this.statusLabel.Text = "Concluído";
            this.statusLabel.Visible = false;
            // 
            // statusProgressBar
            // 
            this.statusProgressBar.Name = "statusProgressBar";
            this.statusProgressBar.Size = new System.Drawing.Size(100, 19);
            this.statusProgressBar.Visible = false;
            // 
            // statusProgressLabel
            // 
            this.statusProgressLabel.Name = "statusProgressLabel";
            this.statusProgressLabel.Size = new System.Drawing.Size(45, 20);
            this.statusProgressLabel.Text = "100%";
            this.statusProgressLabel.Visible = false;
            // 
            // fontSizeUpDown
            // 
            this.fontSizeUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TrainSetBuilder.Properties.Settings.Default, "fontSize", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fontSizeUpDown.Enabled = false;
            this.fontSizeUpDown.Location = new System.Drawing.Point(461, 3);
            this.fontSizeUpDown.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.fontSizeUpDown.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.fontSizeUpDown.Name = "fontSizeUpDown";
            this.fontSizeUpDown.Size = new System.Drawing.Size(68, 22);
            this.fontSizeUpDown.TabIndex = 14;
            this.fontSizeUpDown.Value = global::TrainSetBuilder.Properties.Settings.Default.fontSize;
            // 
            // adjustSizeCheckBox
            // 
            this.adjustSizeCheckBox.AutoSize = true;
            this.adjustSizeCheckBox.Checked = global::TrainSetBuilder.Properties.Settings.Default.adjustFont;
            this.adjustSizeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.adjustSizeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::TrainSetBuilder.Properties.Settings.Default, "adjustFont", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.adjustSizeCheckBox.Location = new System.Drawing.Point(535, 4);
            this.adjustSizeCheckBox.Name = "adjustSizeCheckBox";
            this.adjustSizeCheckBox.Size = new System.Drawing.Size(222, 21);
            this.adjustSizeCheckBox.TabIndex = 12;
            this.adjustSizeCheckBox.Text = "Ajustar fonte automaticamente";
            this.adjustSizeCheckBox.UseVisualStyleBackColor = true;
            this.adjustSizeCheckBox.CheckedChanged += new System.EventHandler(this.adjustSizeCheckBox_CheckedChanged);
            // 
            // imgHeightUpDown
            // 
            this.imgHeightUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TrainSetBuilder.Properties.Settings.Default, "imgHeight", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.imgHeightUpDown.Location = new System.Drawing.Point(257, 3);
            this.imgHeightUpDown.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.imgHeightUpDown.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.imgHeightUpDown.Name = "imgHeightUpDown";
            this.imgHeightUpDown.Size = new System.Drawing.Size(68, 22);
            this.imgHeightUpDown.TabIndex = 11;
            this.imgHeightUpDown.Value = global::TrainSetBuilder.Properties.Settings.Default.imgHeight;
            // 
            // imgWidthUpDown
            // 
            this.imgWidthUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::TrainSetBuilder.Properties.Settings.Default, "imgWidth", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.imgWidthUpDown.Location = new System.Drawing.Point(104, 3);
            this.imgWidthUpDown.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.imgWidthUpDown.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.imgWidthUpDown.Name = "imgWidthUpDown";
            this.imgWidthUpDown.Size = new System.Drawing.Size(68, 22);
            this.imgWidthUpDown.TabIndex = 9;
            this.imgWidthUpDown.Value = global::TrainSetBuilder.Properties.Settings.Default.imgWidth;
            // 
            // trainPathTextBox
            // 
            this.trainPathTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::TrainSetBuilder.Properties.Settings.Default, "trainPath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.trainPathTextBox.Location = new System.Drawing.Point(12, 31);
            this.trainPathTextBox.Multiline = true;
            this.trainPathTextBox.Name = "trainPathTextBox";
            this.trainPathTextBox.Size = new System.Drawing.Size(536, 22);
            this.trainPathTextBox.TabIndex = 5;
            this.trainPathTextBox.Text = global::TrainSetBuilder.Properties.Settings.Default.trainPath;
            this.trainPathTextBox.TextChanged += new System.EventHandler(this.trainPathTextBox_TextChanged);
            this.trainPathTextBox.DoubleClick += new System.EventHandler(this.trainPathTextBox_DoubleClick);
            this.trainPathTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.trainPathTextBox_KeyDown);
            // 
            // configPanel
            // 
            this.configPanel.BackColor = System.Drawing.Color.Transparent;
            this.configPanel.Controls.Add(this.trainGenerateButton);
            this.configPanel.Controls.Add(this.imgWidthLabel);
            this.configPanel.Controls.Add(this.fontSizeLabel);
            this.configPanel.Controls.Add(this.clearDirectoryButton);
            this.configPanel.Controls.Add(this.imgHeightLabel);
            this.configPanel.Controls.Add(this.adjustSizeCheckBox);
            this.configPanel.Controls.Add(this.imgHeightUpDown);
            this.configPanel.Controls.Add(this.trainPathTextBox);
            this.configPanel.Controls.Add(this.imgWidthUpDown);
            this.configPanel.Controls.Add(this.fontSizeUpDown);
            this.configPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.configPanel.Location = new System.Drawing.Point(0, 471);
            this.configPanel.Name = "configPanel";
            this.configPanel.Size = new System.Drawing.Size(782, 60);
            this.configPanel.TabIndex = 17;
            // 
            // mainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.configPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.fontsList);
            this.Controls.Add(this.charsetEditButton);
            this.Controls.Add(this.charsetRemoveButton);
            this.Controls.Add(this.charsetAddButton);
            this.Controls.Add(this.charsetList);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "mainForm";
            this.Text = "Construtor de conjunto de treinamento";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgHeightUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgWidthUpDown)).EndInit();
            this.configPanel.ResumeLayout(false);
            this.configPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView charsetList;
        private System.Windows.Forms.ColumnHeader charsetColumn;
        private System.Windows.Forms.ColumnHeader pathColumn;
        private System.Windows.Forms.Button charsetAddButton;
        private System.Windows.Forms.Button charsetRemoveButton;
        private System.Windows.Forms.Button charsetEditButton;
        private System.Windows.Forms.TextBox trainPathTextBox;
        private System.Windows.Forms.Button trainGenerateButton;
        private System.Windows.Forms.ListView fontsList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label imgWidthLabel;
        private System.Windows.Forms.NumericUpDown imgWidthUpDown;
        private System.Windows.Forms.NumericUpDown imgHeightUpDown;
        private System.Windows.Forms.Label imgHeightLabel;
        private System.Windows.Forms.CheckBox adjustSizeCheckBox;
        private System.Windows.Forms.Label fontSizeLabel;
        private System.Windows.Forms.NumericUpDown fontSizeUpDown;
        private System.Windows.Forms.Button clearDirectoryButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel statusProgressLabel;
        private System.Windows.Forms.Panel configPanel;
    }
}

