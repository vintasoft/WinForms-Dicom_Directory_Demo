# VintaSoft WinForms DICOM Directory Demo

This C# project uses <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html">VintaSoft Imaging .NET SDK</a> and demonstrates how to view DICOM directory in WinForms:
* Open DICOM directory.
* View tree of DICOM directory.
* Preview DICOM images in DICOM directory.
* View metadata of nodes in DICOM directory.


## Screenshot
<img src="vintasoft-dicom-directory-demo.png" title="VintaSoft DICOM Directory Demo">


## Usage
1. Get the 30 day free evaluation license for <a href="https://www.vintasoft.com/vsimaging-dotnet-index.html" target="_blank">VintaSoft Imaging .NET SDK</a> as described here: <a href="https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html" target="_blank">https://www.vintasoft.com/docs/vsimaging-dotnet/Licensing-Evaluation.html</a>

2. Update the evaluation license in "CSharp\MainForm.cs" file:
   ```
   Vintasoft.Imaging.ImagingGlobalSettings.Register("REG_USER", "REG_EMAIL", "EXPIRATION_DATE", "REG_CODE");
   ```

3. Build the project ("DicomDirectoryDemo.Net8.csproj" file) in Visual Studio or using .NET CLI:
   ```
   dotnet build DicomDirectoryDemo.Net8.csproj
   ```

4. Run compiled application and try to view DICOM directory.


## Documentation
VintaSoft Imaging .NET SDK on-line User Guide and API Reference for .NET developer is available here: https://www.vintasoft.com/docs/vsimaging-dotnet/


## Support
Please visit our <a href="https://myaccount.vintasoft.com/">online support center</a> if you have any question or problem.
