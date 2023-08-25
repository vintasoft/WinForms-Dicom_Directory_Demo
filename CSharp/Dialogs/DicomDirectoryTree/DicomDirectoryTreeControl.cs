using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using Vintasoft.Imaging.Codecs.ImageFiles.Dicom;


namespace DicomDirectoryDemo
{
    /// <summary>
    /// A control that displays a tree of DICOM directory.
    /// </summary>
    public partial class DicomDirectoryTreeControl : UserControl
    {

        #region Fields

        /// <summary>
        /// Path to the opened DICOM file (file is a part of DICOM directory).
        /// </summary>
        string _filePath = string.Empty;

        #endregion



        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DicomDirectoryTree"/> class.
        /// </summary>
        public DicomDirectoryTreeControl()
        {
            InitializeComponent();
        }

        #endregion



        #region Properties

        DicomFile _dicomDirectory = null;
        /// <summary>
        /// Gets the current DICOM directory.
        /// </summary>
        public DicomFile DicomDirectory
        {
            get
            {
                return _dicomDirectory;
            }
            set
            {
                _dicomDirectory = value;

                if (_dicomDirectory == null)
                {
                    _filePath = string.Empty;
                    _dicomDirectoryFilePath = string.Empty;
                }

                CreateDicomDirectoryTree(value);
            }
        }

        string _dicomDirectoryFilePath = string.Empty;
        /// <summary>
        /// Get the file path of current DICOM directory.
        /// </summary>
        public string DicomDirectoryFilePath
        {
            get
            {
                return _dicomDirectoryFilePath;
            }
            set
            {
                _dicomDirectoryFilePath = value;
            }
        }

        #endregion



        #region Methods

        /// <summary>
        /// Creates a tree of DICOM directory.
        /// </summary>
        private void CreateDicomDirectoryTree(DicomFile dicomDirectory)
        {
            // clear data grid view
            if (DataGridView.Rows.Count > 0)
                DataGridView.Rows.Clear();

            if (dicomDirectory == null)
            {
                TreeView.Nodes.Clear();
                return;
            }

            DataSetTree dataSetTree = new DataSetTree(dicomDirectory);

            TreeView.BeginUpdate();

            TreeView.Nodes.Clear();
            AddChild(TreeView.Nodes, dataSetTree.Root.Children);

            TreeView.EndUpdate();
        }

        /// <summary>
        /// Adds data sets to a tree of DICOM directory control. 
        /// </summary>
        /// <param name="root">Root node.</param>
        /// <param name="dataSetTreeNodes">Data sets.</param>
        private void AddChild(
            TreeNodeCollection root,
            IEnumerable<DataSetTreeNode> dataSetTreeNodes)
        {
            // if data sets is null
            if (dataSetTreeNodes == null)
                return;

            foreach (DataSetTreeNode dataSetTreeNode in dataSetTreeNodes)
            {
                // create TreeNode
                TreeNode treeNode = CreateTreeNode(dataSetTreeNode.DataSet);
                // add child to TreeNode
                AddChild(treeNode.Nodes, dataSetTreeNode.Children);

                root.Add(treeNode);
            }
        }

        /// <summary>
        /// Creates tree node based on data set.
        /// </summary>
        /// <param name="dataSet">Data set.</param>
        /// <returns>Tree node based on data set.</returns>
        private TreeNode CreateTreeNode(DicomDataSet dataSet)
        {
            // get the data element that stores information about directory record type
            DicomDataElement directoryRecordTypeElement = dataSet.DataElements.Find(DicomDataElementId.DirectoryRecordType);
            // get the directory record type
            string directoryRecordType = (string)directoryRecordTypeElement.Data;
            directoryRecordType = directoryRecordType.ToUpperInvariant();

            // create the node name
            string nameNode = directoryRecordType;

            // get the description of data set
            DicomDataElement description = null;
            switch (directoryRecordType)
            {
                case "PATIENT":
                    description = dataSet.DataElements.Find(DicomDataElementId.PatientName);
                    break;

                case "STUDY":
                    description = dataSet.DataElements.Find(DicomDataElementId.StudyDescription);
                    break;

                case "SERIES":
                    description = dataSet.DataElements.Find(DicomDataElementId.SeriesDescription);
                    break;

                case "IMAGE":
                    description = dataSet.DataElements.Find(DicomDataElementId.ImageComments);
                    break;
            }

            // if data set description is found
            if (description != null)
            {
                string descriptionString = (string)description.Data;
                if (descriptionString != string.Empty)
                    nameNode += String.Format(": {0}", (string)description.Data);
            }

            // create tree node
            TreeNode node = new TreeNode(nameNode);
            node.Name = directoryRecordType;

            // if data set contains image
            if (directoryRecordType == "IMAGE")
            {
                DicomDataElement referencedFileId = dataSet.DataElements.Find(DicomDataElementId.ReferencedFileID);
                // get path to a DICOM file
                string filePath = GetFilePath(referencedFileId);
                // save the path to a DICOM file and reference to a collection of data elements in tree node
                node.Tag = new object[] { filePath, dataSet.DataElements };
            }
            else
            {
                // save a reference to a collection of data elements in tree node
                node.Tag = dataSet.DataElements;
            }

            return node;
        }

        /// <summary>
        /// Gets a path of DICOM file.
        /// </summary>
        /// <param name="referencedFileId">DICOM data element with information about path to a file.</param>
        /// <returns>Path of DICOM file.</returns>
        private string GetFilePath(DicomDataElement referencedFileId)
        {
            if (referencedFileId == null)
                return string.Empty;

            string rootDir = Path.GetDirectoryName(_dicomDirectoryFilePath);

            // create file path
            string filePath = string.Empty;
            if (referencedFileId.Data is Array)
            {
                string[] array = (string[])referencedFileId.Data;

                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] != null && array[i].Trim().Length > 0)
                        filePath += array[i] + Path.DirectorySeparatorChar;
                }

                filePath += array[array.Length - 1];
            }
            else
            {
                filePath = referencedFileId.Data.ToString();
            }

            // return the full path of DICOM file
            return Path.Combine(rootDir, filePath);
        }

        /// <summary>
        /// Updates the data grid view.
        /// </summary>
        /// <param name="collection">Add collection to data grid view.</param>
        private void UpdateDataGridView(IEnumerable<DicomDataElement> collection)
        {
            // clear the data grid view
            DataGridView.Rows.Clear();

            // for each DICOM data element in collection
            foreach (DicomDataElement dataElement in collection)
            {
                string dataString = string.Empty;
                // if DICOM data element has data specified as array
                if (dataElement.Data is Array)
                {
                    // maximum length of array data to preview
                    int arrayMaxLength = 512;
                    // get the array
                    Array array = (Array)dataElement.Data;
                    // get length of array data to preview
                    int length = Math.Min(arrayMaxLength, array.Length);
                    // create string representation of array
                    for (int i = 0; i < length; i++)
                        dataString += array.GetValue(i).ToString() + " ";
                    // if some array data will not be previewed
                    if (length < array.Length)
                        dataString += "...";
                }
                // if DICOM data element has not empty data specified as single value
                else if (dataElement.Data != null)
                {
                    dataString = dataElement.Data.ToString();
                }

                // add information about DICOM data element into new row of data grid view
                DataGridView.Rows.Add(dataElement.GroupNumber,
                    dataElement.ElementNumber, dataElement.Name,
                    dataString);
            }
        }

        /// <summary>
        /// Selected tree node is changed in tree view.
        /// </summary>
        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // if node is empty
            if (e.Node == null)
            {
                // clear data grid view
                if (DataGridView.Rows.Count > 0)
                    DataGridView.Rows.Clear();
            }
            // if node is not empty AND node does not have reference to the data element collection
            else if (e.Node.Tag == null)
            {
                // clear data grid view
                if (DataGridView.Rows.Count > 0)
                    DataGridView.Rows.Clear();
            }
            // if node is image info
            else if (e.Node.Name == "IMAGE")
            {
                object[] info = (object[])e.Node.Tag;
                // open DICOM file
                OnOpenFile(info[0].ToString());
                // update data grid view
                UpdateDataGridView((IEnumerable<DicomDataElement>)info[1]);
            }
            else
                // update data grid view
                UpdateDataGridView((IEnumerable<DicomDataElement>)e.Node.Tag);
        }

        /// <summary>
        /// Raises the <see cref="OpenFile"/> event.
        /// </summary>
        private void OnOpenFile(string filePath)
        {
            if (_filePath != filePath && filePath != string.Empty)
            {
                OpenFile(this, new OpenFileEventArgs(filePath));
                _filePath = filePath;
            }
        }

        #endregion



        #region Events

        /// <summary>
        /// Occurs when the user opened a DICOM file (clicked on the tree node).
        /// </summary>
        public event EventHandler<OpenFileEventArgs> OpenFile;

        #endregion

    }
}
