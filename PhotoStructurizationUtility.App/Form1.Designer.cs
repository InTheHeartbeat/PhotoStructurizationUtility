namespace PhotoStructurizationUtility.App
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
            this.SourceFoldersListBox = new System.Windows.Forms.ListBox();
            this.AddSourceFolderButton = new System.Windows.Forms.Button();
            this.RemoveSourceSelectedFolderButton = new System.Windows.Forms.Button();
            this.CleanSourceFoldersButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalTargetRoots = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TotalFoldersToScanLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HistoryListBox = new System.Windows.Forms.ListBox();
            this.TargetFoldersListBox = new System.Windows.Forms.ListBox();
            this.AssignFoldersButton = new System.Windows.Forms.Button();
            this.CleanTargetFoldersButton = new System.Windows.Forms.Button();
            this.RemoveTargetFolderButton = new System.Windows.Forms.Button();
            this.AddTargetFolderButton = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.CleanAssignsButton = new System.Windows.Forms.Button();
            this.RemoveAssignButton = new System.Windows.Forms.Button();
            this.AssignsListBox = new System.Windows.Forms.ListBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SourceFoldersListBox
            // 
            this.SourceFoldersListBox.Font = new System.Drawing.Font("Arial", 9F);
            this.SourceFoldersListBox.FormattingEnabled = true;
            this.SourceFoldersListBox.ItemHeight = 15;
            this.SourceFoldersListBox.Location = new System.Drawing.Point(13, 314);
            this.SourceFoldersListBox.Name = "SourceFoldersListBox";
            this.SourceFoldersListBox.Size = new System.Drawing.Size(277, 94);
            this.SourceFoldersListBox.TabIndex = 0;
            // 
            // AddSourceFolderButton
            // 
            this.AddSourceFolderButton.Font = new System.Drawing.Font("Arial", 9F);
            this.AddSourceFolderButton.Location = new System.Drawing.Point(12, 415);
            this.AddSourceFolderButton.Name = "AddSourceFolderButton";
            this.AddSourceFolderButton.Size = new System.Drawing.Size(45, 23);
            this.AddSourceFolderButton.TabIndex = 1;
            this.AddSourceFolderButton.Text = "Add folder";
            this.AddSourceFolderButton.UseVisualStyleBackColor = true;
            this.AddSourceFolderButton.Click += new System.EventHandler(this.OnAddSourceButtonClick);
            // 
            // RemoveSourceSelectedFolderButton
            // 
            this.RemoveSourceSelectedFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveSourceSelectedFolderButton.Font = new System.Drawing.Font("Arial", 9F);
            this.RemoveSourceSelectedFolderButton.Location = new System.Drawing.Point(63, 415);
            this.RemoveSourceSelectedFolderButton.Name = "RemoveSourceSelectedFolderButton";
            this.RemoveSourceSelectedFolderButton.Size = new System.Drawing.Size(74, 23);
            this.RemoveSourceSelectedFolderButton.TabIndex = 2;
            this.RemoveSourceSelectedFolderButton.Text = "Remove selected";
            this.RemoveSourceSelectedFolderButton.UseVisualStyleBackColor = true;
            this.RemoveSourceSelectedFolderButton.Click += new System.EventHandler(this.OnRemoveSourceFolderButtonClick);
            // 
            // CleanSourceFoldersButton
            // 
            this.CleanSourceFoldersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CleanSourceFoldersButton.Font = new System.Drawing.Font("Arial", 9F);
            this.CleanSourceFoldersButton.Location = new System.Drawing.Point(143, 415);
            this.CleanSourceFoldersButton.Name = "CleanSourceFoldersButton";
            this.CleanSourceFoldersButton.Size = new System.Drawing.Size(74, 23);
            this.CleanSourceFoldersButton.TabIndex = 3;
            this.CleanSourceFoldersButton.Text = "Clean";
            this.CleanSourceFoldersButton.UseVisualStyleBackColor = true;
            this.CleanSourceFoldersButton.Click += new System.EventHandler(this.OnClearSourceButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(277, 230);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Statistics";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TotalTargetRoots, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TotalFoldersToScanLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(6, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(265, 205);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // TotalTargetRoots
            // 
            this.TotalTargetRoots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalTargetRoots.Font = new System.Drawing.Font("Arial", 9F);
            this.TotalTargetRoots.Location = new System.Drawing.Point(135, 41);
            this.TotalTargetRoots.Name = "TotalTargetRoots";
            this.TotalTargetRoots.Size = new System.Drawing.Size(127, 41);
            this.TotalTargetRoots.TabIndex = 3;
            this.TotalTargetRoots.Text = "0";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 41);
            this.label2.TabIndex = 2;
            this.label2.Text = "Total target roots:";
            // 
            // TotalFoldersToScanLabel
            // 
            this.TotalFoldersToScanLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalFoldersToScanLabel.Font = new System.Drawing.Font("Arial", 9F);
            this.TotalFoldersToScanLabel.Location = new System.Drawing.Point(135, 0);
            this.TotalFoldersToScanLabel.Name = "TotalFoldersToScanLabel";
            this.TotalFoldersToScanLabel.Size = new System.Drawing.Size(127, 41);
            this.TotalFoldersToScanLabel.TabIndex = 1;
            this.TotalFoldersToScanLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total folders to scan:";
            // 
            // HistoryListBox
            // 
            this.HistoryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HistoryListBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.HistoryListBox.Font = new System.Drawing.Font("Arial", 10F);
            this.HistoryListBox.FormattingEnabled = true;
            this.HistoryListBox.HorizontalScrollbar = true;
            this.HistoryListBox.ItemHeight = 14;
            this.HistoryListBox.Location = new System.Drawing.Point(295, 14);
            this.HistoryListBox.Name = "HistoryListBox";
            this.HistoryListBox.ScrollAlwaysVisible = true;
            this.HistoryListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.HistoryListBox.Size = new System.Drawing.Size(561, 228);
            this.HistoryListBox.TabIndex = 5;
            this.HistoryListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.OnHistoryListBoxDrawItem);
            // 
            // TargetFoldersListBox
            // 
            this.TargetFoldersListBox.Font = new System.Drawing.Font("Arial", 9F);
            this.TargetFoldersListBox.FormattingEnabled = true;
            this.TargetFoldersListBox.ItemHeight = 15;
            this.TargetFoldersListBox.Location = new System.Drawing.Point(295, 314);
            this.TargetFoldersListBox.Name = "TargetFoldersListBox";
            this.TargetFoldersListBox.Size = new System.Drawing.Size(277, 94);
            this.TargetFoldersListBox.TabIndex = 6;
            // 
            // AssignFoldersButton
            // 
            this.AssignFoldersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AssignFoldersButton.Font = new System.Drawing.Font("Arial", 9F);
            this.AssignFoldersButton.Location = new System.Drawing.Point(243, 414);
            this.AssignFoldersButton.Name = "AssignFoldersButton";
            this.AssignFoldersButton.Size = new System.Drawing.Size(97, 23);
            this.AssignFoldersButton.TabIndex = 7;
            this.AssignFoldersButton.Text = "Assign folers";
            this.AssignFoldersButton.UseVisualStyleBackColor = true;
            this.AssignFoldersButton.Click += new System.EventHandler(this.OnAssignFoldersButtonClick);
            // 
            // CleanTargetFoldersButton
            // 
            this.CleanTargetFoldersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CleanTargetFoldersButton.Font = new System.Drawing.Font("Arial", 9F);
            this.CleanTargetFoldersButton.Location = new System.Drawing.Point(498, 414);
            this.CleanTargetFoldersButton.Name = "CleanTargetFoldersButton";
            this.CleanTargetFoldersButton.Size = new System.Drawing.Size(74, 23);
            this.CleanTargetFoldersButton.TabIndex = 10;
            this.CleanTargetFoldersButton.Text = "Clean";
            this.CleanTargetFoldersButton.UseVisualStyleBackColor = true;
            this.CleanTargetFoldersButton.Click += new System.EventHandler(this.OnClearTargetFoldersButtonClick);
            // 
            // RemoveTargetFolderButton
            // 
            this.RemoveTargetFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveTargetFolderButton.Font = new System.Drawing.Font("Arial", 9F);
            this.RemoveTargetFolderButton.Location = new System.Drawing.Point(418, 414);
            this.RemoveTargetFolderButton.Name = "RemoveTargetFolderButton";
            this.RemoveTargetFolderButton.Size = new System.Drawing.Size(74, 23);
            this.RemoveTargetFolderButton.TabIndex = 9;
            this.RemoveTargetFolderButton.Text = "Remove selected";
            this.RemoveTargetFolderButton.UseVisualStyleBackColor = true;
            this.RemoveTargetFolderButton.Click += new System.EventHandler(this.OnRemoveTargetFolderButtonClick);
            // 
            // AddTargetFolderButton
            // 
            this.AddTargetFolderButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.AddTargetFolderButton.Font = new System.Drawing.Font("Arial", 9F);
            this.AddTargetFolderButton.Location = new System.Drawing.Point(367, 414);
            this.AddTargetFolderButton.Name = "AddTargetFolderButton";
            this.AddTargetFolderButton.Size = new System.Drawing.Size(45, 23);
            this.AddTargetFolderButton.TabIndex = 8;
            this.AddTargetFolderButton.Text = "Add folder";
            this.AddTargetFolderButton.UseVisualStyleBackColor = true;
            this.AddTargetFolderButton.Click += new System.EventHandler(this.OnAddTargetFolderButtonClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 450);
            this.splitter1.TabIndex = 11;
            this.splitter1.TabStop = false;
            // 
            // CleanAssignsButton
            // 
            this.CleanAssignsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CleanAssignsButton.Font = new System.Drawing.Font("Arial", 9F);
            this.CleanAssignsButton.Location = new System.Drawing.Point(781, 414);
            this.CleanAssignsButton.Name = "CleanAssignsButton";
            this.CleanAssignsButton.Size = new System.Drawing.Size(74, 23);
            this.CleanAssignsButton.TabIndex = 14;
            this.CleanAssignsButton.Text = "Clean";
            this.CleanAssignsButton.UseVisualStyleBackColor = true;
            this.CleanAssignsButton.Click += new System.EventHandler(this.OnClearAssignsButtonClick);
            // 
            // RemoveAssignButton
            // 
            this.RemoveAssignButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveAssignButton.Font = new System.Drawing.Font("Arial", 9F);
            this.RemoveAssignButton.Location = new System.Drawing.Point(701, 414);
            this.RemoveAssignButton.Name = "RemoveAssignButton";
            this.RemoveAssignButton.Size = new System.Drawing.Size(74, 23);
            this.RemoveAssignButton.TabIndex = 13;
            this.RemoveAssignButton.Text = "Remove selected";
            this.RemoveAssignButton.UseVisualStyleBackColor = true;
            this.RemoveAssignButton.Click += new System.EventHandler(this.OnRemoveAssignButtonClick);
            // 
            // AssignsListBox
            // 
            this.AssignsListBox.Font = new System.Drawing.Font("Arial", 9F);
            this.AssignsListBox.FormattingEnabled = true;
            this.AssignsListBox.ItemHeight = 15;
            this.AssignsListBox.Location = new System.Drawing.Point(578, 314);
            this.AssignsListBox.Name = "AssignsListBox";
            this.AssignsListBox.Size = new System.Drawing.Size(277, 94);
            this.AssignsListBox.TabIndex = 12;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 268);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 15;
            this.StartButton.Text = "button1";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 450);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.CleanAssignsButton);
            this.Controls.Add(this.RemoveAssignButton);
            this.Controls.Add(this.AssignsListBox);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.CleanTargetFoldersButton);
            this.Controls.Add(this.RemoveTargetFolderButton);
            this.Controls.Add(this.AddTargetFolderButton);
            this.Controls.Add(this.AssignFoldersButton);
            this.Controls.Add(this.TargetFoldersListBox);
            this.Controls.Add(this.HistoryListBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CleanSourceFoldersButton);
            this.Controls.Add(this.RemoveSourceSelectedFolderButton);
            this.Controls.Add(this.AddSourceFolderButton);
            this.Controls.Add(this.SourceFoldersListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SourceFoldersListBox;
        private System.Windows.Forms.Button AddSourceFolderButton;
        private System.Windows.Forms.Button RemoveSourceSelectedFolderButton;
        private System.Windows.Forms.Button CleanSourceFoldersButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label TotalFoldersToScanLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox HistoryListBox;
        private System.Windows.Forms.ListBox TargetFoldersListBox;
        private System.Windows.Forms.Button AssignFoldersButton;
        private System.Windows.Forms.Button CleanTargetFoldersButton;
        private System.Windows.Forms.Button RemoveTargetFolderButton;
        private System.Windows.Forms.Button AddTargetFolderButton;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Label TotalTargetRoots;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CleanAssignsButton;
        private System.Windows.Forms.Button RemoveAssignButton;
        private System.Windows.Forms.ListBox AssignsListBox;
        private System.Windows.Forms.Button StartButton;
    }
}

