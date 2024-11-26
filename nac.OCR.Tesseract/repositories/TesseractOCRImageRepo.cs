using System;
using tess=Tesseract;

namespace nac.OCR.Tesseract.repositories;

public class TesseractOCRImageRepo : IDisposable
{
    private readonly tess.IResultRenderer renderer;
    private readonly tess.TesseractEngine engine;

    public TesseractOCRImageRepo(string tessDataPath,
        string languageCode,
        string outputPDFPath)
    {
        this.renderer = tess.PdfResultRenderer.CreatePdfRenderer(outputFilename: outputPDFPath,
            fontDirectory: tessDataPath,
            textonly: false);
        this.engine = new tess.TesseractEngine(datapath: tessDataPath,
            language: languageCode,
            engineMode: tess.EngineMode.TesseractAndLstm);
    }

    public void AddImage(byte[] imageBytes)
    {
        using (var img = tess.Pix.LoadFromMemory(imageBytes))
        {
            using (var page = engine.Process(img, tess.PageSegMode.Auto))
            {
                renderer.AddPage(page);
            }
        }
    }
    
    
    public void Dispose()
    {
        renderer.Dispose();
        engine.Dispose();
    }
}