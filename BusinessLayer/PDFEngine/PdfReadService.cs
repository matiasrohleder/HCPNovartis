using SelectPdf;

namespace BusinessLayer.PDFEngine;

public class PdfReadService : IPdfReadService
{
    public PdfReadService()
    {
    }

    public string ExtractTextFromPdf(byte[] pdfBytes)
    {
        PdfToText pdfToText = new();
        pdfToText.Load(pdfBytes);

        int pageCount = pdfToText.GetPageCount();
        pdfToText.StartPageNumber = 1;
        pdfToText.EndPageNumber = pageCount;

        // Extract text from the PDF
        string extractedText = pdfToText.GetText();
        extractedText = extractedText.Trim();

        // Clean Select PDF watermark
        extractedText = RemoveWatermark(extractedText);

        return extractedText;
    }

    private static string RemoveWatermark(string text)
    {
        // Define the exact texts to remove
        string startText = @"===========================================================================================================

You are currently using Demo Version - Select.Pdf SDK. With the free trial version,
only the first 3 pages of the PDF document are converted to text.

===========================================================================================================
";

        string endText = "Demo Version - Select.Pdf SDK - http://selectpdf.com";

        // Remove the start text
        if (text.StartsWith(startText))
            text = text[startText.Length..];

        // Remove the end text
        if (text.EndsWith(endText))
            text = text[..^endText.Length];

        // Remove leading and trailing whitespace
        text = text.Trim();

        return text;
    }
}