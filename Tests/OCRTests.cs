using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests;

[TestClass]
public class OCRTests
{

    [TestMethod]
    public async Task PDFToSearchablePDF()
    {
        var tessOptions = lib.tesseractUtility.BuildTesseractSetupParameters("temp/ocr/output/out.pdf");

        await nac.OCR.Tesseract.repositories.ocrRepo.ocrPDF(inputPDFPath: lib.directoryHelper.RelativeToHome("temp/MacWorld_01_Premier_Issue_Pictures.pdf"),
            tessOptions: tessOptions);
    }
}