using System;
using tess=Tesseract;

namespace nac.OCR.Tesseract.repositories;

public class TesseractOCRImageRepo : IDisposable
{
    private readonly tess.IResultRenderer renderer;
    private readonly tess.TesseractEngine engine;

    public TesseractOCRImageRepo(model.TesseractSetupParameters options)
    {

        if (!System.IO.Directory.Exists(options.TessDataPath))
        {
            throw new Exception($"Tesseract data path directory [path={options.TessDataPath}] does not exist.   This data path is required for tesseract to work");
        }
        
        this.renderer = tess.PdfResultRenderer.CreatePdfRenderer(outputFilename: options.outputPDFPath,
            fontDirectory: options.TessDataPath,
            textonly: false);
        this.engine = new tess.TesseractEngine(datapath: options.TessDataPath,
            language: options.Language,
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