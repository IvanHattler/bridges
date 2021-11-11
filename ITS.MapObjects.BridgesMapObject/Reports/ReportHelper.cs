using System;
using System.Collections.Generic;
using System.Diagnostics;
using ITS.Common.RtfWriter;
using HorizontalAlignment = ITS.Common.RtfWriter.HorizontalAlignment;

namespace ITS.MapObjects.BridgesMapObject.Reports
{
    public class ReportHelper
    {
        #region Методы для работы с отчетом

        /// <summary>
        /// Сохраняет отчет в файл RTF.
        /// </summary>
        /// <param name="pathToRtfFile">Путь к файлу.</param>
        /// <param name="rtfDocument"></param>
        public static void Save(string pathToRtfFile, RtfDocument rtfDocument)
        {
            if (rtfDocument == null) throw new Exception("Отчет для сохранения не был сгенерирован.");
            rtfDocument.Save(pathToRtfFile);
        }

        /// <summary>
        /// Открывает файл во внешнем редакторе RTF.
        /// </summary>
        /// <param name="pathToRtfFile">Путь к файлу.</param>
        public static void Open(string pathToRtfFile)
        {
            var p = new Process { StartInfo = { FileName = pathToRtfFile } };
            p.Start();
        }
        #endregion
    }

    public class RTFWorkingProvider
    {
        public static void AddNumeration(RtfDocument doc)
        {
            //doc.AddRawCode(@"{\footer\pard\qr Page \chpgn  of {\field{\*\fldinst  NUMPAGES }}\par}");
            //doc.AddRawCode(@"{\footer\pard\qr\chpgn\par}");
            //doc.Footer.AddRawCode(@"\qr\chpgn");
            var par = doc.Footer.AddParagraph();
            par.Text = "  ";
            var cf = par.AddCharFormat();
            cf.Font = doc.CreateFont("Courier New");
            cf.FontSize = 11;
            par.HorizontalAlignment = HorizontalAlignment.Right;
            par.AddControlWord(1, RtfFieldControlWord.FieldType.Page);
        }

        public static void AddPageBreak(RtfDocument doc)
        {
            //doc.AddRawCode(@"\page");
            doc.AddParagraph().StartNewPage = true;
        }

        public static void AddTextToCell(int row, int col, RtfTable table, string text)
        {
            var paragraph = table.Cell(row, col).AddParagraph();
            paragraph.Text = text;
        }

        public static RtfCharFormat AddTextToDocument(RtfDocument rtfDocument, float fontSize, HorizontalAlignment alignment,
            string text, bool startNewPage = false)
        {
            var paragraph = rtfDocument.AddParagraph();
            paragraph.HorizontalAlignment = alignment;
            paragraph.StartNewPage = startNewPage;
            var cf = paragraph.AddCharFormat();
            cf.FontSize = fontSize;
            
            paragraph.Text = text;
            return cf;
        }

        public static RtfCharFormat AddTextToDocument(RtfDocument rtfDocument, float fontSize, HorizontalAlignment alignment,
           FontDescriptor font, FontStyleFlag fontStyleFlag, string text, bool startNewPage = false)
        {
            var cf = AddTextToDocument(rtfDocument, fontSize, alignment, font, text, startNewPage);
            cf.FontStyle.AddStyle(fontStyleFlag);
            return cf;
        }

        public static RtfCharFormat AddTextToDocument(RtfDocument rtfDocument, float fontSize, HorizontalAlignment alignment,
           FontDescriptor font, string text, bool startNewPage = false)
        {
            var paragraph = rtfDocument.AddParagraph();
            paragraph.HorizontalAlignment = alignment;
            paragraph.StartNewPage = startNewPage;
            var cf = paragraph.AddCharFormat();
            cf.FontSize = fontSize;
            cf.Font = font;
            paragraph.Text = text;
            return cf;
        }

        public static void AddEmptyLine(RtfDocument rtfDocument, float fontSize, HorizontalAlignment alignment)
        {
            var paragraph = rtfDocument.AddParagraph();
            paragraph.HorizontalAlignment = alignment;
            paragraph.AddCharFormat().FontSize = fontSize;
        }

        public static void AligmentColumn(RtfTable table, int column, int row1, int row2, HorizontalAlignment alignment, int fontSize = 12)
        {
            try
            {
                for (var i = row1; i <= row2; i++)
                {
                    table.Cell(i, column).HorizontalAlignment = alignment;
                    table.Cell(i, column).DefaultCharFormat.FontSize = fontSize;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void DocumentMargins(RtfDocument doc, float top, float left, float bottom, float right)
        {
            // Границы документа:
            const float smToPt = 28.34646f;
            doc.Margins[Direction.Top] = top * smToPt;
            doc.Margins[Direction.Left] = left * smToPt;
            doc.Margins[Direction.Bottom] = bottom * smToPt;
            doc.Margins[Direction.Right] = right * smToPt;
        }
    }
}
