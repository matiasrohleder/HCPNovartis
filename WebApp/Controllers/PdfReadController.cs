using BusinessLayer.PDFEngine;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class PdfReadController(IPdfReadService pdfReadService) : Controller
{
    private readonly IPdfReadService pdfReadService = pdfReadService;

    [HttpPost]
    public IActionResult Scan(IFormFile file)
    {
        // Validate the file
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded. Please upload a PDF file.");

        // Validate file type
        string[] acceptedFileTypes = [".pdf"];
        var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
        if (!acceptedFileTypes.Contains(fileExtension))
            return BadRequest("Invalid file type. Accepted types are: PDF.");

        try
        {
            using MemoryStream stream = new();
            file.CopyTo(stream);
            stream.Position = 0;

            string text = "";
            if (fileExtension == ".pdf")
                // Process the PDF
                text = pdfReadService.ExtractTextFromPdf(stream.ToArray());

            return Ok(new { ExtractedText = text });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}