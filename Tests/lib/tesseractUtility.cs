namespace Tests.lib;

public static class tesseractUtility
{

    public static nac.OCR.Tesseract.model.TesseractSetupParameters BuildTesseractSetupParameters(
        string outputPDFFilePath)
    {
        // tesseract training data is available here: https://github.com/tesseract-ocr/tessdata/
        string tessDataPath = lib.directoryHelper.RelativeToHome("temp/ocr/tessdata");

        return new nac.OCR.Tesseract.model.TesseractSetupParameters
        {
            TessDataPath = tessDataPath,
            outputPDFPath = lib.directoryHelper.RelativeToHome(outputPDFFilePath),
            Language = "eng"
        };
    }
    
}