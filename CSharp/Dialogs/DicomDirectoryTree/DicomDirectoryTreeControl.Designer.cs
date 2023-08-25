namespace DicomDirectoryDemo
{
    partial class DicomDirectoryTreeControl
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

         #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TreeView = new System.Windows.Forms.TreeView();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.GroupNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ElementData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(350, 297);
            this.TreeView.TabIndex = 0;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            this.splitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.TreeView);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.DataGridView);
            this.splitContainerMain.Size = new System.Drawing.Size(350, 448);
            this.splitContainerMain.SplitterDistance = 297;
            this.splitContainerMain.TabIndex = 2;
            // 
            // DataGridView
            // 
            this.DataGridView.AllowUserToAddRows = false;
            this.DataGridView.AllowUserToDeleteRows = false;
            this.DataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupNumber,
            this.ElementNumber,
            this.ElementName,
            this.ElementData});
            this.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridView.Location = new System.Drawing.Point(0, 0);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.ReadOnly = true;
            this.DataGridView.RowHeadersVisible = false;
            this.DataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView.Size = new System.Drawing.Size(350, 147);
            this.DataGridView.TabIndex = 0;
            // 
            // GroupNumber
            // 
            this.GroupNumber.Frozen = true;
            this.GroupNumber.HeaderText = "Group Number";
            this.GroupNumber.Name = "GroupNumber";
            this.GroupNumber.ReadOnly = true;
            this.GroupNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GroupNumber.Width = 50;
            // 
            // ElementNumber
            // 
            this.ElementNumber.Frozen = true;
            this.ElementNumber.HeaderText = "Element Number";
            this.ElementNumber.Name = "ElementNumber";
            this.ElementNumber.ReadOnly = true;
            this.ElementNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ElementNumber.Width = 50;
            // 
            // ElementName
            // 
            this.ElementName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ElementName.HeaderText = "Name";
            this.ElementName.Name = "ElementName";
            this.ElementName.ReadOnly = true;
            this.ElementName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ElementData
            // 
            this.ElementData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ElementData.HeaderText = "Data";
            this.ElementData.Name = "ElementData";
            this.ElementData.ReadOnly = true;
            this.ElementData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DicomDirectoryTree
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "DicomDirectoryTree";
            this.Size = new System.Drawing.Size(350, 448);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel2.ResumeLayout(false);
            this.splitContainerMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ElementData;
    }
}