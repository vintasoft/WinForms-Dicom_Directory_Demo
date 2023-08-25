
namespace DicomDirectoryDemo
{
    partial class MainForm
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
            Vintasoft.Imaging.Utils.WinFormsSystemClipboard winFormsSystemClipboard1 = new Vintasoft.Imaging.Utils.WinFormsSystemClipboard();
            Vintasoft.Imaging.Codecs.Decoders.RenderingSettings renderingSettings1 = new Vintasoft.Imaging.Codecs.Decoders.RenderingSettings();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDicomDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeDicomDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageViewerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.counterclockwiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dicomDirectoryTreeControl1 = new DicomDirectoryDemo.DicomDirectoryTreeControl();
            this.imageViewer1 = new Vintasoft.Imaging.UI.ImageViewer();
            this.openDicomDirectoryDialog = new System.Windows.Forms.OpenFileDialog();
            this.imageViewerToolStrip1 = new DemosCommonCode.Imaging.ImageViewerToolStrip();
            this.menuStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(952, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openDicomDirectoryToolStripMenuItem,
            this.closeDicomDirectoryToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openDicomDirectoryToolStripMenuItem
            // 
            this.openDicomDirectoryToolStripMenuItem.Name = "openDicomDirectoryToolStripMenuItem";
            this.openDicomDirectoryToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.openDicomDirectoryToolStripMenuItem.Text = "Open DICOM Directory...";
            this.openDicomDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDICOMDirectoryToolStripMenuItem_Click);
            // 
            // closeDicomDirectoryToolStripMenuItem
            // 
            this.closeDicomDirectoryToolStripMenuItem.Name = "closeDicomDirectoryToolStripMenuItem";
            this.closeDicomDirectoryToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.closeDicomDirectoryToolStripMenuItem.Text = "Close DICOM Directory";
            this.closeDicomDirectoryToolStripMenuItem.Click += new System.EventHandler(this.closeDICOMDirectoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(202, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageViewerSettingsToolStripMenuItem,
            this.rotateViewToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // imageViewerSettingsToolStripMenuItem
            // 
            this.imageViewerSettingsToolStripMenuItem.Name = "imageViewerSettingsToolStripMenuItem";
            this.imageViewerSettingsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.imageViewerSettingsToolStripMenuItem.Text = "Image Viewer Settings...";
            this.imageViewerSettingsToolStripMenuItem.Click += new System.EventHandler(this.imageViewerSettingsToolStripMenuItem_Click);
            // 
            // rotateViewToolStripMenuItem
            // 
            this.rotateViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clockwiseToolStripMenuItem,
            this.counterclockwiseToolStripMenuItem});
            this.rotateViewToolStripMenuItem.Name = "rotateViewToolStripMenuItem";
            this.rotateViewToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.rotateViewToolStripMenuItem.Text = "Rotate View";
            // 
            // clockwiseToolStripMenuItem
            // 
            this.clockwiseToolStripMenuItem.Name = "clockwiseToolStripMenuItem";
            this.clockwiseToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Ctrl+Plus";
            this.clockwiseToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.clockwiseToolStripMenuItem.Text = "Clockwise";
            this.clockwiseToolStripMenuItem.Click += new System.EventHandler(this.clockwiseToolStripMenuItem_Click);
            // 
            // counterclockwiseToolStripMenuItem
            // 
            this.counterclockwiseToolStripMenuItem.Name = "counterclockwiseToolStripMenuItem";
            this.counterclockwiseToolStripMenuItem.ShortcutKeyDisplayString = "Shift+Ctrl+Minus";
            this.counterclockwiseToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.counterclockwiseToolStripMenuItem.Text = "Counterclockwise";
            this.counterclockwiseToolStripMenuItem.Click += new System.EventHandler(this.counterclockwiseToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dicomDirectoryTreeControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.imageViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(952, 615);
            this.splitContainer1.SplitterDistance = 385;
            this.splitContainer1.TabIndex = 2;
            // 
            // dicomDirectoryTreeControl1
            // 
            this.dicomDirectoryTreeControl1.DicomDirectory = null;
            this.dicomDirectoryTreeControl1.DicomDirectoryFilePath = "";
            this.dicomDirectoryTreeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dicomDirectoryTreeControl1.Location = new System.Drawing.Point(0, 0);
            this.dicomDirectoryTreeControl1.Name = "dicomDirectoryTreeControl1";
            this.dicomDirectoryTreeControl1.Size = new System.Drawing.Size(385, 615);
            this.dicomDirectoryTreeControl1.TabIndex = 0;
            // 
            // imageViewer1
            // 
            this.imageViewer1.BackColor = System.Drawing.Color.Black;
            this.imageViewer1.Clipboard = winFormsSystemClipboard1;
            this.imageViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageViewer1.FocusPointAnchor = Vintasoft.Imaging.AnchorType.None;
            this.imageViewer1.ImageRenderingSettings = renderingSettings1;
            this.imageViewer1.ImageRotationAngle = 0;
            this.imageViewer1.IsFocusPointFixed = false;
            this.imageViewer1.IsKeyboardNavigationEnabled = true;
            this.imageViewer1.Location = new System.Drawing.Point(0, 0);
            this.imageViewer1.Name = "imageViewer1";
            this.imageViewer1.ShortcutCopy = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutCut = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutDelete = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutInsert = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.ShortcutSelectAll = System.Windows.Forms.Shortcut.None;
            this.imageViewer1.Size = new System.Drawing.Size(563, 615);
            this.imageViewer1.SizeMode = Vintasoft.Imaging.UI.ImageSizeMode.BestFit;
            this.imageViewer1.TabIndex = 0;
            this.imageViewer1.Text = "imageViewer1";
            // 
            // openDicomDirectoryDialog
            // 
            this.openDicomDirectoryDialog.Filter = "DICOM directory|DICOMDIR;DICOMDIR.dcm;DICOMDIR.dic;DICOMDIR.acr|All files|*.*";
            // 
            // imageViewerToolStrip1
            // 
            this.imageViewerToolStrip1.AssociatedZoomTrackBar = null;
            this.imageViewerToolStrip1.CanPrint = false;
            this.imageViewerToolStrip1.CanSaveFile = false;
            this.imageViewerToolStrip1.ImageViewer = this.imageViewer1;
            this.imageViewerToolStrip1.ScanButtonEnabled = true;
            this.imageViewerToolStrip1.Location = new System.Drawing.Point(0, 24);
            this.imageViewerToolStrip1.Name = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.PageCount = 0;
            this.imageViewerToolStrip1.PrintButtonEnabled = false;
            this.imageViewerToolStrip1.SaveButtonEnabled = false;
            this.imageViewerToolStrip1.Size = new System.Drawing.Size(952, 25);
            this.imageViewerToolStrip1.TabIndex = 3;
            this.imageViewerToolStrip1.Text = "imageViewerToolStrip1";
            this.imageViewerToolStrip1.UseImageViewerImages = true;
            this.imageViewerToolStrip1.OpenFile += new System.EventHandler(this.imageViewerToolStrip1_OpenFile);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 664);
            this.Controls.Add(this.imageViewerToolStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dicom Directory Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DicomDirectoryTreeControl dicomDirectoryTreeControl1;
        private Vintasoft.Imaging.UI.ImageViewer imageViewer1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDicomDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openDicomDirectoryDialog;
        private DemosCommonCode.Imaging.ImageViewerToolStrip imageViewerToolStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageViewerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateViewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem counterclockwiseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeDicomDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}