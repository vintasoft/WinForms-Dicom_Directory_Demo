using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Forms;

using DemosCommonCode;
using DemosCommonCode.Imaging;

using Vintasoft.Imaging;
using Vintasoft.Imaging.Codecs;
using Vintasoft.Imaging.Codecs.ImageFiles.Dicom;

namespace DicomDirectoryDemo
{
    /// <summary>
    /// Main form of DICOM directory demo.
    /// </summary>
    public partial class MainForm : Form
    {

        #region Fields

        /// <summary>
        /// Template of the application title.
        /// </summary>
        string _titlePrefix = "VintaSoft DICOM Directory Demo v" + ImagingGlobalSettings.ProductVersion + " - {0}";

        /// <summary>
        /// Stream from which DICOM directory was loaded.
        /// </summary>
        Stream _dicomDirectoryStream = null;

        /// <summary>
        /// Current DICOM directory.
        /// </summary>
        DicomFile _dicomDirectoryFile = null;

        /// <summary>
        /// A value indicating whether the application form is closing.
        /// </summary> 
        bool _isFormClosing = false;

        #endregion



        #region Constructors

        public MainForm()
        {
            // register the evaluation license for VintaSoft Imaging .NET SDK
            Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");

            InitializeComponent();

            this.Text = string.Format(_titlePrefix, "(Untitled)");

            MoveDicomCodecToFirstPosition();

            Jpeg2000AssemblyLoader.Load();

            // set the initial directory in open dicom directory dialog
            DemosTools.SetTestFilesFolder(openDicomDirectoryDialog);

            dicomDirectoryTreeControl1.OpenFile += new EventHandler<OpenFileEventArgs>(DicomDirectoryTree_OpenFile);

            UpdateUI();
        }

        #endregion



        #region Properties

        bool _isDicomFileOpening = false;
        /// <summary>
        /// Gets or sets a value indicating whether the DICOM file is opening.
        /// </summary>
        bool IsDicomFileOpening
        {
            get
            {
                return _isDicomFileOpening;
            }
            set
            {
                _isDicomFileOpening = value;

                if (InvokeRequired)
                    InvokeUpdateUI();
                else
                    UpdateUI();
            }
        }

        #endregion



        #region Methods

        #region PROTECTED

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message" />,
        /// passed by reference, that represents the window message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values
        /// that represents the key to process.</param>
        /// <returns>
        /// <b>true</b> if the character was processed by the control; otherwise, <b>false</b>.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Shift | Keys.Control | Keys.Add))
            {
                RotateViewClockwise();
                return true;
            }

            if (keyData == (Keys.Shift | Keys.Control | Keys.Subtract))
            {
                RotateViewCounterClockwise();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion


        #region PRIVATE

        #region UI

        /// <summary>
        /// Handles the FormClosing event of MainForm object.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _isFormClosing = true;
        }

        #endregion


        #region UI state

        /// <summary>
        /// Updates UI safely.
        /// </summary>
        private void InvokeUpdateUI()
        {
            if (InvokeRequired)
                Invoke(new UpdateUIDelegate(UpdateUI));
            else
                UpdateUI();
        }

        /// <summary>
        /// Updates the user interface of this form.
        /// </summary>
        private void UpdateUI()
        {
            // if application is closing
            if (_isFormClosing)
                // exit
                return;

            bool isDicomDirectoryFileLoaded = _dicomDirectoryFile != null;
            bool isDicomFileOpening = _isDicomFileOpening;
            bool isFileOpening = IsDicomFileOpening;


            // 'File' menu
            //
            openDicomDirectoryToolStripMenuItem.Enabled = !isDicomFileOpening && !isFileOpening;
            closeDicomDirectoryToolStripMenuItem.Enabled = isDicomDirectoryFileLoaded && !isDicomFileOpening && !isFileOpening;
        }

        #endregion


        #region 'File' menu

        /// <summary>
        /// Handles the Click event of openDICOMDirectoryToolStripMenuItem object.
        /// </summary>
        private void openDICOMDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDicomDirectory();
        }

        /// <summary>
        /// Handles the Click event of closeDICOMDirectoryToolStripMenuItem object.
        /// </summary>
        private void closeDICOMDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close the previously opened DICOM directory
            ClosePreviouslyOpenedFiles();
        }

        /// <summary>
        /// Handles the Click event of exitToolStripMenuItem object.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


        #region 'View' menu

        /// <summary>
        /// Handles the Click event of imageViewerSettingsToolStripMenuItem object.
        /// </summary>
        private void imageViewerSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ImageViewerSettingsForm dlg = new ImageViewerSettingsForm(imageViewer1))
            {
                dlg.CanEditMultipageSettings = false;
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the Click event of clockwiseToolStripMenuItem object.
        /// </summary>
        private void clockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewClockwise();
        }

        /// <summary>
        /// Handles the Click event of counterclockwiseToolStripMenuItem object.
        /// </summary>
        private void counterclockwiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotateViewCounterClockwise();
        }

        #endregion


        #region 'Help' menu

        /// <summary>
        /// Handles the Click event of aboutToolStripMenuItem object.
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutBoxForm dlg = new AboutBoxForm())
            {
                dlg.ShowDialog();
            }
        }

        #endregion


        #region Image Viewer Tool Strip

        /// <summary>
        /// Handles the OpenFile event of imageViewerToolStrip1 object.
        /// </summary>
        private void imageViewerToolStrip1_OpenFile(object sender, EventArgs e)
        {
            OpenDicomDirectory();
        }

        #endregion


        #region  File manipulation

        /// <summary>
        /// Opens a DICOM directory.
        /// </summary>
        private void OpenDicomDirectory()
        {
            // specify that only one file can be selected
            openDicomDirectoryDialog.Multiselect = false;
            // show the open file dialog
            if (openDicomDirectoryDialog.ShowDialog() == DialogResult.OK)
            {
                // close the previously opened DICOM files
                ClosePreviouslyOpenedFiles();

                // open DICOM directory
                OpenDirectory(openDicomDirectoryDialog.FileName);
            }
        }

        /// <summary>
        /// Opens a DICOM directory.
        /// </summary>
        /// <param name="filePath">File path.</param>
        private void OpenDirectory(string filePath)
        {
            Stream sourceStream = null;
            DicomFile dicomFile = null;

            try
            {
                // create file stream
                sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                // create DICOM file
                dicomFile = DicomFileController.OpenDicomFile(sourceStream);

                // if DICOM file is not directory
                if (!IsDicomDirectory(dicomFile))
                {
                    string message = string.Format("File \"{0}\" is not DICOM directory.", Path.GetFileName(filePath));
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                // if DICOM file is opened
                if (dicomFile != null)
                {
                    // close DICOM file
                    DicomFileController.CloseDicomFile(dicomFile);
                    dicomFile = null;
                }

                // if stream of DICOM file is opened
                if (sourceStream != null)
                {
                    // close stream
                    sourceStream.Close();

                    // release stream
                    sourceStream.Dispose();
                    sourceStream = null;
                }

                // show error message
                DemosTools.ShowErrorMessage(ex);
            }

            // if DICOM file is not opened
            if (dicomFile == null)
                return;

            try
            {
                // close previously opened DICOM directory
                CloseDicomDirectory();

                IsDicomFileOpening = true;

                // save directory stream
                _dicomDirectoryStream = sourceStream;
                // save directory
                _dicomDirectoryFile = dicomFile;
                // update directory tree
                dicomDirectoryTreeControl1.DicomDirectoryFilePath = filePath;
                dicomDirectoryTreeControl1.DicomDirectory = dicomFile;

                this.Text = string.Format(_titlePrefix, Path.GetFileName(filePath));

                UpdateUI();
            }
            catch (Exception ex)
            {
                // close directory
                CloseDicomDirectory();
                // show error message
                DemosTools.ShowErrorMessage(ex);
            }
            finally
            {
                if (!_isFormClosing)
                {
                    // update the UI
                    IsDicomFileOpening = false;
                }
            }
        }

        /// <summary>
        /// Closes the previously opened DICOM files.
        /// </summary>
        private void ClosePreviouslyOpenedFiles()
        {
            // close the previously opened DICOM file
            imageViewer1.Images.ClearAndDisposeItems();

            // if DICOM directory is opened
            if (_dicomDirectoryFile != null)
            {
                // close previously opened DICOM directory
                CloseDicomDirectory();
            }
        }

        /// <summary>
        /// Opens the DICOM file.
        /// </summary>
        /// <param name="filePath">A path to the DICOM file.</param>
        private void OpenDicomFile(string filePath)
        {
            // close DICOM series
            CloseDicomFile();

            try
            {
                imageViewer1.Update();

                try
                {
                    IsDicomFileOpening = true;

                    // add images from file to the image viewer
                    imageViewer1.Images.Add(filePath);

                    // update header of form
                    this.Text = string.Format(_titlePrefix, Path.GetFileName(filePath));
                }
                catch (Exception ex)
                {
                    DemosTools.ShowErrorMessage(ex);

                    CloseDicomFile();
                }

                if (imageViewer1.Images.Count == 0)
                    // show message for user
                    DemosTools.ShowInfoMessage("DICOM file does not contain image.");

                // update UI
                UpdateUI();
            }
            finally
            {
                if (!_isFormClosing)
                {
                    // update the UI
                    IsDicomFileOpening = false;
                }
            }
        }

        /// <summary>
        /// Closes the DICOM file.
        /// </summary>
        private void CloseDicomFile()
        {
            // clear image collection of image viewer and dispose all images
            imageViewer1.Images.ClearAndDisposeItems();

            this.Text = string.Format(_titlePrefix, "(Untitled)");

            // update the UI
            UpdateUI();
        }

        /// <summary>
        /// Closes DICOM directory.
        /// </summary>
        private void CloseDicomDirectory()
        {
            // if DICOM directory is open
            if (_dicomDirectoryFile != null)
            {
                dicomDirectoryTreeControl1.DicomDirectory = null;
                // dispose the DICOM directory
                DicomFileController.CloseDicomFile(_dicomDirectoryFile);
                _dicomDirectoryFile = null;
            }
            // if DICOM directory's stream is opened
            if (_dicomDirectoryStream != null)
            {
                // close the DICOM directory's stream
                _dicomDirectoryStream.Close();
                _dicomDirectoryStream = null;
            }

            UpdateUI();
        }

        /// <summary>
        /// Determines whether the specified DICOM file contains DICOM directory metadata.
        /// </summary>
        /// <param name="dicomFile">The DICOM file.</param>
        /// <returns>
        /// <returns><b>true</b> if the DICOM file contains DICOM directory metadata; 
        /// otherwise, <b>false</b>.</returns>
        /// </returns>
        private bool IsDicomDirectory(DicomFile dicomFile)
        {
            if (dicomFile.DataSet.DataElements.Contains(DicomDataElementId.DirectoryRecordSequence))
                return true;

            return false;
        }

        #endregion


        #region Dicom Directory Tree

        /// <summary>
        /// DICOM file, from DICOM directory, is opening.
        /// </summary>
        private void DicomDirectoryTree_OpenFile(object sender, OpenFileEventArgs e)
        {
            // get file path of the DICOM directory
            string filePath = e.FilePath;

            // if file exists
            if (File.Exists(filePath))
                // open file
                OpenDicomFile(filePath);
            // if file exists
            else if (File.Exists(filePath + ".dcm"))
                // open file
                OpenDicomFile(filePath + ".dcm");
            else
            {
                // show error message
                string errorMessage = String.Format("File \"{0}\" does not exist.", e.FilePath);
                DemosTools.ShowErrorMessage(errorMessage);
            }
        }

        #endregion


        #region View Rotation

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees clockwise.
        /// </summary>
        private void RotateViewClockwise()
        {
            if (imageViewer1.ImageRotationAngle != 270)
            {
                imageViewer1.ImageRotationAngle += 90;
            }
            else
            {
                imageViewer1.ImageRotationAngle = 0;
            }
        }

        /// <summary>
        /// Rotates images in both annotation viewer and thumbnail viewer by 90 degrees counterclockwise.
        /// </summary>
        private void RotateViewCounterClockwise()
        {
            if (imageViewer1.ImageRotationAngle != 0)
            {
                imageViewer1.ImageRotationAngle -= 90;
            }
            else
            {
                imageViewer1.ImageRotationAngle = 270;
            }
        }

        #endregion 

        /// <summary>
        /// Moves the DICOM codec to the first position in <see cref="AvailableCodecs"/>.
        /// </summary>
        private static void MoveDicomCodecToFirstPosition()
        {
            ReadOnlyCollection<Codec> codecs = AvailableCodecs.Codecs;

            for (int i = codecs.Count - 1; i >= 0; i--)
            {
                Codec codec = codecs[i];

                if (codec.Name.Equals("DICOM", StringComparison.InvariantCultureIgnoreCase))
                {
                    AvailableCodecs.RemoveCodec(codec);
                    AvailableCodecs.InsertCodec(0, codec);
                    break;
                }
            }
        }

        #endregion

        #endregion



        #region Delegates

        /// <summary>
        /// Represents the <see cref="UpdateUI"/> method.
        /// </summary>
        delegate void UpdateUIDelegate();

        #endregion

    }
}
