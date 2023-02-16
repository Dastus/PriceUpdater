using PriceUpdater.Models;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.PageSegmenter;
using UglyToad.PdfPig.DocumentLayoutAnalysis.WordExtractor;

namespace PriceUpdater.Services
{
    public static class PervijDomPriceService
    {
        public static List<PervijDomPriceRecord> GetRecords(string filePath)
        {
            var pervijDomModels = new List<PervijDomPriceRecord>();

            using (var document = PdfDocument.Open(filePath))
            {
                var pages = document.GetPages();

                foreach (var page in pages)
                {
                    var tst = page.GetWords();

                    var words = NearestNeighbourWordExtractor.Instance.GetWords(page.Letters);
                    var blocks = DefaultPageSegmenter.Instance.GetBlocks(words);

                    foreach (var block in blocks)
                    {
                        foreach (var textLine in block.TextLines)
                        {
                            foreach (var line in textLine.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                var model = PervijDomPriceRecord.Deserialize(line);

                                if (model is null)
                                {
                                    continue;
                                }

                                pervijDomModels.Add(model);
                            }
                        }
                    }
                }
            }

            return pervijDomModels;
        }

        //public static List<PervijDomPriceRecord> GetRecords(string filePath)
        //{
        //    //@"D:\work\PriceConverter\price_pdf.pdf"
        //    using PdfDocument PDF = PdfDocument.FromFile(filePath);
        //    string allText = PDF.ExtractAllText();

        //    var pervijDomModels = new List<PervijDomPriceRecord>();

        //    foreach (var line in allText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        var model = PervijDomPriceRecord.Deserialize(line);

        //        if (model is null)
        //        {
        //            continue;
        //        }

        //        pervijDomModels.Add(model);
        //    }

        //    return pervijDomModels;
        //}

    }
}
