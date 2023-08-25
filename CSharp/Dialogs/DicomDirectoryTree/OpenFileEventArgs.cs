using System;


namespace DicomDirectoryDemo
{
    /// <summary>
    /// Provides data for the <see cref="DicomDirectoryTreeControl.OpenFile"/> event.
    /// </summary>
    public class OpenFileEventArgs : EventArgs
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenFileEventArgs"/> class.
        /// </summary>
        /// <param name="filePath">Opening file path.</param>
        public OpenFileEventArgs(string filePath)
        {
            _filePath = filePath;
        }

        #endregion



        #region Properties

        string _filePath;
        /// <summary>
        /// Gets the path to the opened DICOM file, which is stored in DICOM directory.
        /// </summary>
        public string FilePath
        {
            get
            {
                return _filePath;
            }
        }

        #endregion

    }
}
