using System.Threading.Tasks;

namespace nac.OCR.Tesseract.repositories;

public static class ocrRepo
{
    private static repositories.Logger log = new();

    public static async Task ocrPDF(string inputPDFPath, model.TesseractSetupParameters tessOptions)
    {
        log.Info($"OCR Input PDF: {inputPDFPath}");
        await Task.Run(() =>
        {
            using (var tesseractWorker = new repositories.TesseractOCRImageRepo(tessOptions))
            {
                using (var pdfImageReader = new repositories.PDFDocImageReader(pdfFilePath: inputPDFPath))
                {
                    log.Info($"PDF has {pdfImageReader.PageCount} pages");
                    for (int pageIndex = 0; pageIndex <= pdfImageReader.PageCount; pageIndex++)
                    {
                        log.Info($"Reading page {pageIndex}");
                        byte[] pageImage = pdfImageReader.getPageAsImage(pageIndex);
                        log.Info($"Page {pageIndex} is {pageImage.Length} bytes");
                        
                        tesseractWorker.AddImage(pageImage);
                    }
                }
            }
        });
    }
}