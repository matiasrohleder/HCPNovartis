using System.Text;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Parser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[AllowAnonymous]
[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    [HttpPost("read-pdf")]
    public IActionResult ReadPdf(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("No file uploaded.");
        }

        try
        {
            StringBuilder extractedText = new StringBuilder();

            using (var stream = file.OpenReadStream())
            {
                using (var reader = new PdfReader(stream))
                using (var pdfDoc = new PdfDocument(reader))
                {
                    // Extract text from each page
                    for (int i = 1; i <= pdfDoc.GetNumberOfPages(); i++)
                    {
                        var page = pdfDoc.GetPage(i);
                        string text = PdfTextExtractor.GetTextFromPage(page);
                        extractedText.AppendLine(text);
                    }
                }
            }

            return Ok(new { Text = extractedText.ToString() });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error extracting text: {ex.Message}");
        }
    }
}
