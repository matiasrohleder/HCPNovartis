namespace BusinessLayer.PDFEngine;

/// <summary>
/// Service to read pdf files
/// </summary>
public interface IPdfReadService
{
    /// <summary>
    /// Extract text from a pdf file
    /// </summary>
    string ExtractTextFromPdf(byte[] pdfBytes);
}