using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class TifTests
{
    [TestMethod]
    public void ConvertPDFToMultipageTif()
    {
        string pdfPath = lib.directoryHelper.RelativeToHome("temp/Macworld_01_Premier_Issue.pdf");
        string outTifPath = lib.directoryHelper.RelativeToHome("temp/Macworld_01_Premier_Issue.tif");
        
        nac.OCR.Tesseract.repositories.pdfToTifRepo.ConvertPdfToMultipageTif(pdfFilePath: pdfPath,
            outputFilePath: outTifPath);

        var pdfFileInfo = new System.IO.FileInfo(pdfPath);
        var outFileInfo = new System.IO.FileInfo(outTifPath);
        
        Assert.IsTrue(outFileInfo != null &&
                      outFileInfo.Exists == true, $"Tif File didn't exist at path {outTifPath}");
        
        Assert.IsTrue(outFileInfo.Length > pdfFileInfo.Length, $"Tif file {outFileInfo.Length} bytes was smaller than original PDF bytes {pdfFileInfo.Length}");
    }
    
    
    
    
}