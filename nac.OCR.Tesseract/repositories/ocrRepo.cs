using System.Threading.Tasks;

namespace nac.OCR.Tesseract.repositories;

public static class ocrRepo
{
    private static repositories.Logger log = new();

    public static async Task ocrPDF(string inputPDFPath, model.TesseractSetupParameters tessOptions)
    {
        await Task.Run(() =>
        {
            
        });
    }
}