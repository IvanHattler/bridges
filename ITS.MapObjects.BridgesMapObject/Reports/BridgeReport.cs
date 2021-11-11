using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using ITS.Common.RtfWriter;
using ITS.Core.Bridges.Domain;
using Microsoft.Practices.Unity;
using VerticalAlignment = ITS.Common.RtfWriter.VerticalAlignment;
using ITS.MapObjects.BridgesMapObject.Helpers;

namespace ITS.MapObjects.BridgesMapObject.Reports
{
    public static class BridgeReport
    {
        /// <summary>
        /// Размер шрифта заголовка.
        /// </summary>
        private static float titleFontSize = 14;

        #region Отчёт по сводной ведомости
        /// <summary>
        /// Отчет из плагина
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="bridges"></param>
        /// <param name="sectionFontSize"></param>
        /// <param name="paperOrientation"></param>
        public static void ReportMake(string fileName, IList<Bridge> bridges,
            float sectionFontSize = 8.5f, PaperOrientation paperOrientation = PaperOrientation.Portrait)
        {
            var doc = new RtfDocument(PaperSize.A4, paperOrientation, Lcid.Russian);
            var font = doc.CreateFont("Courier New");

            //doc.AddImage(Properties.Resources.ITSGIS_Icon.ToBitmap());
            CreateDocumentTitle(doc, font, 16);
            CreateData(doc, bridges, font, sectionFontSize);
            doc.Save(fileName);
        }

        private static void CreateDocumentTitle(RtfDocument doc, FontDescriptor font, float fontSize, 
            FontStyleFlag fontStyleFlag = FontStyleFlag.Bold)
        {
            RTFWorkingProvider.AddTextToDocument(doc, fontSize, HorizontalAlignment.Center, font,
                fontStyleFlag,
                $"СВОДНАЯ ВЕДОМОСТЬ МОСТОВЫХ СООРУЖЕНИЙ");
            RTFWorkingProvider.DocumentMargins(doc, 1.5f, 1.5f, 1.5f, 1.5f);
            RTFWorkingProvider.AddEmptyLine(doc, titleFontSize, HorizontalAlignment.Left);
            RTFWorkingProvider.AddNumeration(doc);
        }

        private static void CreateData(RtfDocument doc, IList<Bridge> bridges, FontDescriptor font, float fontSize = 8.5f)
        {
            for (int i = 0; i < bridges.Count; i++)
            {
                var reportMaker = BridgeConstants.Container.Resolve<IBridgeReportMaker>(
                    new ParameterOverride("bridge", bridges[i]));
                RTFWorkingProvider.AddTextToDocument(doc, titleFontSize, HorizontalAlignment.Center, font,
                    $"Мостовое сооружение №{i + 1}");
                RTFWorkingProvider.AddEmptyLine(doc, titleFontSize, HorizontalAlignment.Left);
                AddMainInfoTable(doc, fontSize, titleFontSize, reportMaker, font, false);
                AddSpanStructuresTables(doc, fontSize, titleFontSize, reportMaker, font, false);
                AddSupportsTables(doc, fontSize, titleFontSize,reportMaker, font, false);
                AddDocumentationsTable(doc, fontSize, titleFontSize,reportMaker, font, false);
                AddDefectsTable(doc, fontSize, titleFontSize,reportMaker, font, false);
                AddPhotosForSummary(doc, bridges[i], font, false);
                if (i != bridges.Count - 1)
                {
                    RTFWorkingProvider.AddPageBreak(doc);
                }
            }
        }
        private static void AddPhotosForSummary(RtfDocument document, Bridge bridge, FontDescriptor font, bool startNewPage = true)
        {
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Center,
                    font,
                    "\r\nФотоиллюстрации\r\n", startNewPage);
            for (int i = 0; i < bridge.Photos.Count; i++)
            {
                var img = document.AddImage(bridge.Photos[i].PhotoImage, ImageFileType.Jpg);
                if (img.Width > img.Heigth)
                {
                    img.Width = 500;
                }
                else
                {
                    img.Heigth = 250;
                }
                img.HorizontalAlignment = HorizontalAlignment.Center;
                RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Center,
                  font, $"Рисунок {i + 1} - {bridge.Photos[i].Description}.");
            }
        }
        #endregion

        #region Паспорт
        /// <summary>
        /// Создаёт паспорт моста
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="bridge"></param>
        /// <param name="sectionFontSize"></param>
        /// <param name="paperOrientation"></param>
        public static void BridgePassportMake(string fileName, Bridge bridge,
           float sectionFontSize = 8.5f, PaperOrientation paperOrientation = PaperOrientation.Portrait)
        {
            var doc = new RtfDocument(PaperSize.A4, paperOrientation, Lcid.Russian);
            var font = doc.CreateFont("Courier New");

            CreateDocumentTitleForPassport(doc, bridge, font);
            CreateDataForPassport(doc, bridge, font, sectionFontSize);
            doc.Save(fileName);
        }

        private static void CreateDocumentTitleForPassport(RtfDocument doc, Bridge bridge, FontDescriptor font)
        {
            var cf1 = RTFWorkingProvider.AddTextToDocument(doc, 14, HorizontalAlignment.Left, font,
                FontStyleFlag.Bold, @"




            443125, г. Самара, пр. Кирова, 328-67
            тел. 8(846)922-79-78, e-mail: info@its-spc.ru
            ИНН/КПП 6317074732 / 631701001
            р/с 40702810906180004449 к/с 30101810700000000955
            Банк: ФИЛИАЛ N6318 ВТБ 24 (ПАО) г. САМАРА
            БИК: 043602955

");

            RTFWorkingProvider.AddTextToDocument(doc, 37, HorizontalAlignment.Center, font,
                FontStyleFlag.Bold,
                $"ТЕХНИЧЕСКИЙ ПАСПОРТ\r\n{bridge.ConstructionAsString}");

            if(bridge.Obstacles != null && bridge.Obstacles.Count > 1)
            {
                RTFWorkingProvider.AddTextToDocument(doc, 26, HorizontalAlignment.Center, font,
                FontStyleFlag.Bold, $"\r\nчерез препятствия: {bridge.ObstaclesAsString}");
            }
            else if(bridge.Obstacles != null && bridge.Obstacles.Count > 0)
            {
                RTFWorkingProvider.AddTextToDocument(doc, 26, HorizontalAlignment.Center, font,
                FontStyleFlag.Bold, $"\r\nчерез препятствие: {bridge.ObstaclesAsString}");
            }

            RTFWorkingProvider.AddTextToDocument(doc, 18, HorizontalAlignment.Center, font,
                FontStyleFlag.Bold,
                $"на а/д \"{bridge.RoadName}\"\r\nна км {bridge.KilometerAsString}\r\n\r\n\r\n");

            RTFWorkingProvider.DocumentMargins(doc, 1.5f, 1.5f, 1.5f, 1.5f);
            doc.SetBackgroundImageForCurrentSection(Properties.Resources.ITSBackground1);

            RTFWorkingProvider.AddNumeration(doc);
            doc.Footer.AddImage(new Bitmap(Properties.Resources.ITSLogo1, new Size(150, 30)),
                ImageFileType.Png);

            var par = doc.Header.AddParagraph();
            par.Text = $"Технический паспорт\r\n{bridge.ConstructionTypeAsString}. {bridge.Territory?.Name}\r\nКод сооружения: {bridge.BridgeCode}";
            par.HorizontalAlignment = HorizontalAlignment.Center;
            par.AddCharFormat().Font = font;

            RTFWorkingProvider.AddTextToDocument(doc, 18, HorizontalAlignment.Center, font,
                FontStyleFlag.Bold, $"\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n{DateTime.Now.ToLongDateString()}\r\nСамара");
            RTFWorkingProvider.AddPageBreak(doc);
        }

        private static void CreateDataForPassport(RtfDocument document, Bridge bridge, FontDescriptor font, float fontSize = 12f)
        {
            var reportMaker = BridgeConstants.Container.Resolve<IBridgeReportMaker>(
                    new ParameterOverride("bridge", bridge));
            var formerName = Core.ApplicationService.CurrentUser is null ?
                "" : Core.ApplicationService.CurrentUser.UserName;
            AddContents(document, fontSize, font, formerName, reportMaker);
            AddMainInfoTable(document, fontSize, titleFontSize, reportMaker, font);
            AddSpanStructuresTables(document, fontSize, titleFontSize, reportMaker, font);
            AddSupportsTables(document, fontSize, titleFontSize, reportMaker, font);
            AddDocumentationsTable(document, fontSize, titleFontSize, reportMaker, font);
            AddDefectsTable(document, fontSize, titleFontSize, reportMaker, font);
            AddDefectParamsInfo(document, font, fontSize);
            AddBridgeConditionInfo(document, fontSize, titleFontSize, reportMaker, font, formerName);
            AddPhotos(document, bridge, font);
        }

        private static void AddContents(RtfDocument document, float fontSize, FontDescriptor font, string formerName, IBridgeReportMaker reportMaker)
        {
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Center,
                    font, FontStyleFlag.Bold, $"Паспорт мостового сооружения");
            RTFWorkingProvider.AddTextToDocument(document, fontSize, HorizontalAlignment.Center,
                    font, FontStyleFlag.Bold, $"Содержание                                                Число листов");
            RTFWorkingProvider.AddTextToDocument(document, fontSize, HorizontalAlignment.Left, font,
                $"\r\nТитульный лист паспорта.......................................\t1\r\n\r\n" +
                $"Форма 1. \"Общие сведения\".....................................\t2\r\n\r\n" +
                $"Форма 2. \"Пролётное строение\".................................\t?\r\n\r\n" +
                $"Форма 3. \"Опоры\"..............................................\t?\r\n\r\n" +
                $"Форма 4. \"Список технической документации\"....................\t?\r\n\r\n" +
                $"Форма 5. \"Ведомость дефектов\".................................\t?\r\n\r\n" +
                $"Форма 6. \"Состояние сооружения\"...............................\t?\r\n\r\n" +
                $"Пояснительная записка.........................................\t?\r\n\r\n" +
                $"Фотоиллюстрации...............................................\t?\r\n\r\n" +
                $"Чертежи мостового сооружения..................................\t?\r\n\r\n\r\n" +
                $"Паспорт составлен: {formerName}");
            //{reportMaker.SpanStructures.Count}
            //{(int)Math.Ceiling(reportMaker.Supports.Count/supportsInOnePage)}
        }

        private static void AddPhotos(RtfDocument document, Bridge bridge, FontDescriptor font, bool startNewPage = true)
        {
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Center,
                    font, FontStyleFlag.Bold,
                    "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nФотоиллюстрации", startNewPage);
            RTFWorkingProvider.AddPageBreak(document);
            if (bridge.Photos != null)
            {
                for (int i = 0; i < bridge.Photos.Count; i++)
                {
                    var img = document.AddImage(bridge.Photos[i].PhotoImage, ImageFileType.Jpg);
                    if (img.Width > img.Heigth)
                    {
                        img.Width = 500;
                    }
                    else
                    {
                        img.Heigth = 250;
                    }
                    img.HorizontalAlignment = HorizontalAlignment.Center;
                    RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Center,
                      font, $"Рисунок {i + 1} - {bridge.Photos[i].Description}.");
                }
            }
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Center,
                    font, FontStyleFlag.Bold,
                    "\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\nЧертежи мостового сооружения", true);
        }

        private static void AddBridgeConditionInfo(RtfDocument document, float fontSize, float fontSubTitleSize, IBridgeReportMaker reportMaker, FontDescriptor font, string formerName)
        {
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Right,
                    font, FontStyleFlag.Bold, $"Форма 6", true);
            RTFWorkingProvider.AddTextToDocument(document, fontSubTitleSize, HorizontalAlignment.Center,
                    font, FontStyleFlag.Bold, $"Состояние сооружения");
            var table = document.AddTable(reportMaker.BridgeConditionRowsCount, 3);
            SetTable(document, fontSize, table, font);
            table.SetColWidth(0, 30);
            table.SetColWidth(1, 240);
            table.SetColWidth(2, 240);
            var condReport = reportMaker.GetBridgeConditionReport(formerName);
            int i = 0;
            foreach (var r in condReport)
            {
                RTFWorkingProvider.AddTextToCell(i, 0, table, (string)r[0]);
                RTFWorkingProvider.AddTextToCell(i, 1, table, (string)r[1]);
                RTFWorkingProvider.AddTextToCell(i, 2, table, (string)r[2]);
                i++;
            }
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Right,
                    font, $"Проверил: ");
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Right,
                    font, $"Проверил чертежи и иллюстрации: ");
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Right,
                    font, $"Внесено в БД: ");
            RTFWorkingProvider.AddEmptyLine(document, titleFontSize, HorizontalAlignment.Left);
        }

        private static void AddDefectParamsInfo(RtfDocument document, FontDescriptor font, float fontSize)
        {
            RTFWorkingProvider.AddTextToDocument(document, fontSize, HorizontalAlignment.Center, font,
                            FontStyleFlag.Bold, "ОБОЗНАЧЕНИЯ ПАРАМЕТРОВ ДЕФЕКТОВ", true);
            RTFWorkingProvider.AddEmptyLine(document, fontSize, HorizontalAlignment.Center);
            RTFWorkingProvider.AddTextToDocument(document, fontSize, HorizontalAlignment.Center, font,
                FontStyleFlag.Bold, "1. Размер поражённой части элемента (детали) по направлению");
            RTFWorkingProvider.AddTextToDocument(document, fontSize, HorizontalAlignment.Left, font,
                @"
L - вдоль пролёта мостового сооружения, м
H - по высоте мостового сооружения, м
B - поперек мостового сооружения, м
F - площадь, м^2
");
            RTFWorkingProvider.AddTextToDocument(document, fontSize, HorizontalAlignment.Center, font,
                FontStyleFlag.Bold, "2. Размер дефекта по направлению");
            RTFWorkingProvider.AddTextToDocument(document, fontSize, HorizontalAlignment.Left, font,
                @"
l - по длине мостового сооружения, м
h - по высоте мостового сооружения, м
b - поперёк мостового сооружения, м
f - площадь, м^2
");
            RTFWorkingProvider.AddTextToDocument(document, fontSize, HorizontalAlignment.Center, font,
                FontStyleFlag.Bold, "3. Площадь ослабленной части сечения элемента (детали),м^2 или % от целого сечения");
            RTFWorkingProvider.AddTextToDocument(document, fontSize, HorizontalAlignment.Left, font,
                @"
A - площадь, м^2 или % от целого сечения
N - число деталей с одноимёнными дефектами
n - число дефектов одноимённых на элементе, детали
V - объём повреждения (дефекта), м^2
T - глубина дефекта, м
W - площадь выпучивания элемента (детали), м^2
X,Y,Z - Смещение деталей или элементов соответственно вдоль пролёта мостового сооружения, по высоте и поперёк мостового сооружения, м, как правило, для длинномерных элементов, расположенных вдоль оси X
axy,ayz,azx - угол поворота соответственно в плоскости XY (продольном профиле), YZ (в поперечном профиле) - кручение в вертикальной плоскости, ZX (искривление в плане - горизонтальной плоскости)
D - шаг трещин, м
С - длина трещины, щели, м
6 - величина раскрытия трещин, зазор щели, м
S - значение характеристики, указанной в ведомости дефектов (прочность, и т.д.)");
        }

        private static void AddMainInfoTable(RtfDocument document, float fontSize, float fontSubTitleSize, IBridgeReportMaker reportMaker, FontDescriptor font, bool startNewPage = true)
        {
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Right,
                    font, FontStyleFlag.Bold, $"Форма 1", startNewPage);
            RTFWorkingProvider.AddTextToDocument(document, fontSubTitleSize, HorizontalAlignment.Center,
                    font, FontStyleFlag.Bold, $"Общие сведения о мостовом сооружении");
            var table = document.AddTable(reportMaker.BridgeRowsCount + 1, 3);
            SetTable(document, fontSize, table, font);
            CreateMainInfoTitle(table);
            var bridgeReport = reportMaker.GetBridgeReport();
            int i = 1;
            foreach (var r in bridgeReport)
            {
                RTFWorkingProvider.AddTextToCell(i, 0, table, (string)r[0]);
                RTFWorkingProvider.AddTextToCell(i, 1, table, (string)r[1]);
                RTFWorkingProvider.AddTextToCell(i, 2, table, (string)r[2]);
                i++;
            }
        }

        private static void AddSpanStructuresTables(RtfDocument document, float fontSize, float fontSubTitleSize, IBridgeReportMaker reportMaker, FontDescriptor font, bool startNewPage = true)
        {
            var spanStructuresReports = reportMaker.GetSpanStructuresReports();
            if (spanStructuresReports is null)
            {
                return;
            }
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Right,
                    font, FontStyleFlag.Bold, $"Форма 2", startNewPage);
            for (int i = 0; i < spanStructuresReports.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                var num = reportMaker.SpanStructureGroups[i][0].Number;
                sb.Append(num);
                for (int j = 1; j < reportMaker.SpanStructureGroups[i].Count; j++)
                {
                    sb.Append(", ");
                    sb.Append(reportMaker.SpanStructureGroups[i][j].Number);
                }
                RTFWorkingProvider.AddTextToDocument(document, fontSubTitleSize, HorizontalAlignment.Center,
                    font, FontStyleFlag.Bold, $"Пролётное строение №{sb.ToString()}");
                var table = document.AddTable(reportMaker.SpanStructureRowsCount + 1, 3);
                SetTable(document, fontSize, table, font);
                CreateMainInfoTitle(table);
                int k = 1;
                foreach (var r in spanStructuresReports[i])
                {
                    RTFWorkingProvider.AddTextToCell(k, 0, table, (string)r[0]);
                    RTFWorkingProvider.AddTextToCell(k, 1, table, (string)r[1]);
                    RTFWorkingProvider.AddTextToCell(k, 2, table, (string)r[2]);
                    k++;
                }
            }
        }

        private static void AddSupportsTables(RtfDocument document, float fontSize, float fontSubTitleSize, IBridgeReportMaker reportMaker, FontDescriptor font, bool startNewPage = true)
        {
            var supportsReports = reportMaker.GetSupportsReports();
            if (supportsReports is null)
            {
                return;
            }
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Right,
                   font, FontStyleFlag.Bold, $"Форма 3", startNewPage);
            for (int i = 0; i < supportsReports.Count; i++)
            {
                StringBuilder sb = new StringBuilder();
                var num = reportMaker.SupportGroups[i][0].Number;
                sb.Append(num);
                for (int j = 1; j < reportMaker.SupportGroups[i].Count; j++)
                {
                    sb.Append(", ");
                    sb.Append(reportMaker.SupportGroups[i][j].Number);
                }
                RTFWorkingProvider.AddTextToDocument(document, fontSubTitleSize, HorizontalAlignment.Center,
                    font, FontStyleFlag.Bold, $"Опора №{sb.ToString()}");
                var table = document.AddTable(reportMaker.SupportRowsCount + 1, 3);              
                SetTable(document, fontSize, table, font);
                CreateMainInfoTitle(table);
                int k = 1;
                foreach (var r in supportsReports[i])
                {
                    RTFWorkingProvider.AddTextToCell(k, 0, table, (string)r[0]);
                    RTFWorkingProvider.AddTextToCell(k, 1, table, (string)r[1]);
                    RTFWorkingProvider.AddTextToCell(k, 2, table, (string)r[2]);
                    k++;
                }
            }
        }

        private static void AddDocumentationsTable(RtfDocument document, float fontSize, float fontSubTitleSize, IBridgeReportMaker reportMaker, FontDescriptor font, bool startNewPage = true)
        {
            var docsReports = reportMaker.GetDocumentationsReport();
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Right,
                   font, FontStyleFlag.Bold, $"Форма 4", startNewPage);
            RTFWorkingProvider.AddTextToDocument(document, fontSubTitleSize, HorizontalAlignment.Center,
                            font, FontStyleFlag.Bold, $"Список имеющейся технической документации");
            if (reportMaker.DocumentationsCount != null)
            {
                var table = document.AddTable(reportMaker.DocumentationsCount.Value + 1, 4);
                SetTable(document, fontSize, table, font);
                CreateDocumentationsTitle(table);
                int j = 1;
                foreach (var r in docsReports)
                {
                    RTFWorkingProvider.AddTextToCell(j, 0, table, (string)r[0]);
                    RTFWorkingProvider.AddTextToCell(j, 1, table, (string)r[1]);
                    RTFWorkingProvider.AddTextToCell(j, 2, table, (string)r[2]);
                    RTFWorkingProvider.AddTextToCell(j, 3, table, (string)r[3]);
                    j++;
                }
            }
        }

        private static void AddDefectsTable(RtfDocument document, float fontSize, float fontSubTitleSize, IBridgeReportMaker reportMaker, FontDescriptor font, bool startNewPage = true)
        {
            var defectReport = reportMaker.GetDefectReport();
            RTFWorkingProvider.AddTextToDocument(document, titleFontSize, HorizontalAlignment.Right,
                   font, FontStyleFlag.Bold, $"Форма 5", startNewPage);
            RTFWorkingProvider.AddTextToDocument(document, fontSubTitleSize, HorizontalAlignment.Center,
                            font, FontStyleFlag.Bold, $"Ведомость дефектов и повреждений");
            if (reportMaker.DefectsCount != null)
            {
                var table = document.AddTable(reportMaker.DefectsCount.Value + 1, 6);
                SetTable(document, fontSize, table, font);
                CreateDefectsTitle(table);
                int j = 1;
                foreach (var r in defectReport)
                {
                    RTFWorkingProvider.AddTextToCell(j, 0, table, (string)r[0]);
                    RTFWorkingProvider.AddTextToCell(j, 1, table, (string)r[1]);
                    RTFWorkingProvider.AddTextToCell(j, 2, table, (string)r[2]);
                    RTFWorkingProvider.AddTextToCell(j, 3, table, (string)r[3]);
                    RTFWorkingProvider.AddTextToCell(j, 4, table, (string)r[4]);
                    RTFWorkingProvider.AddTextToCell(j, 5, table, (string)r[5]);
                    j++;
                }
            }
        }
        #endregion

        #region Для паспортизатора
        public static void ReportMake(RtfDocument doc, IList<Bridge> bridges,
           float sectionFontSize = 8.5f, PaperOrientation paperOrientation = PaperOrientation.Portrait)
        {
            var font = doc.CreateFont("Times New Roman");
            doc.AddSection(PaperSize.A4, paperOrientation);
            CreateDocumentTitle(doc, font, 12, FontStyleFlag.Scaps);
            CreateDataForPassportizator(doc, bridges, font, sectionFontSize);
        }

        private static void CreateDataForPassportizator(RtfDocument doc, IList<Bridge> bridges, FontDescriptor font, float fontSize = 8.5f)
        {
            for (int i = 0; i < bridges.Count; i++)
            {
                var reportMaker = BridgeConstants.Container.Resolve<IBridgeReportMaker>(
                    new ParameterOverride("bridge", bridges[i]));
                RTFWorkingProvider.AddTextToDocument(doc, titleFontSize, HorizontalAlignment.Center, font,
                    $"Мостовое сооружение №{i + 1}");
                AddMainInfoTable(doc, fontSize, 12f, reportMaker, font, false);
                AddSpanStructuresTables(doc, fontSize, 12f, reportMaker, font, false);
                AddSupportsTables(doc, fontSize, 12f, reportMaker, font, false);
                AddDocumentationsTable(doc, fontSize, 12f, reportMaker, font, false);
                AddDefectsTable(doc, fontSize, 12f, reportMaker, font, false);
                if (i != bridges.Count - 1)
                {
                    RTFWorkingProvider.AddPageBreak(doc);
                }
            }
        }
        #endregion

        private static void CreateMainInfoTitle(RtfTable table)
        {
            for (var j = 0; j < table.ColCount; j++)
            {
                //for (var i = 0; i < 2; i++)
                //{
                //    table.Cell(i, j).DefaultCharFormat.FontStyle.AddStyle(FontStyleFlag.Bold);
                //}
                table.Cell(0, j).DefaultCharFormat.FontStyle.AddStyle(FontStyleFlag.Bold);
            }
            table.SetColWidth(0, 30);
            table.SetColWidth(1, 240);
            table.SetColWidth(2, 240);
            RTFWorkingProvider.AddTextToCell(0, 0, table, "№ п/п");
            RTFWorkingProvider.AddTextToCell(0, 1, table, "Параметр");
            RTFWorkingProvider.AddTextToCell(0, 2, table, "Значение");
        }

        private static void CreateDocumentationsTitle(RtfTable table)
        {
            for (var j = 0; j < table.ColCount; j++)
            {
                //for (var i = 0; i < 2; i++)
                //{
                //    table.Cell(i, j).DefaultCharFormat.FontStyle.AddStyle(FontStyleFlag.Bold);
                //}
                table.Cell(0, j).DefaultCharFormat.FontStyle.AddStyle(FontStyleFlag.Bold);
            }
            table.SetColWidth(0, 97);
            table.SetColWidth(1, 137);
            table.SetColWidth(2, 138);
            table.SetColWidth(3, 138);
            RTFWorkingProvider.AddTextToCell(0, 0, table, "Номер документа");
            RTFWorkingProvider.AddTextToCell(0, 1, table, "Название, год изготовления");
            RTFWorkingProvider.AddTextToCell(0, 2, table, "Изготовитель");
            RTFWorkingProvider.AddTextToCell(0, 3, table, "Место хранения");
        }

        private static void CreateDefectsTitle(RtfTable table)
        {
            for (var j = 0; j < table.ColCount; j++)
            {
                //for (var i = 0; i < 2; i++)
                //{
                //    table.Cell(i, j).DefaultCharFormat.FontStyle.AddStyle(FontStyleFlag.Bold);
                //}
                table.Cell(0, j).DefaultCharFormat.FontStyle.AddStyle(FontStyleFlag.Bold);
            }
            table.SetColWidth(0, 30);
            table.SetColWidth(1, 130);
            table.SetColWidth(2, 100);
            table.SetColWidth(3, 100);
            table.SetColWidth(4, 80);
            table.SetColWidth(5, 70);
            RTFWorkingProvider.AddTextToCell(0, 0, table, "№ п/п");
            RTFWorkingProvider.AddTextToCell(0, 1, table, "Положение дефекта: № пролетов (опор), элемент, № элемента, локализация, материал");
            RTFWorkingProvider.AddTextToCell(0, 2, table, "Тип и описание дефекта");
            RTFWorkingProvider.AddTextToCell(0, 3, table, "Параметры и их значения");
            RTFWorkingProvider.AddTextToCell(0, 4, table, "Категория по ВСН 4-81");
            RTFWorkingProvider.AddTextToCell(0, 5, table, "Примечания");
        }

        private static void SetTable(RtfDocument document, float fontSize, RtfTable table, FontDescriptor font)
        {
            table.TitleRowCount = 1;
            table.SetInnerBorder(BorderStyle.Single, 0.5f);
            table.SetOuterBorder(BorderStyle.Single, 1.5f);

            for (var i = 0; i < table.RowCount; i++)
            {
                for (var j = 0; j < table.ColCount; j++)
                {
                    var cell = table.Cell(i, j);
                    cell.HorizontalAlignment = HorizontalAlignment.Center;
                    cell.VerticalAlignment = VerticalAlignment.Middle;
                    cell.DefaultCharFormat.Font = font;
                    cell.DefaultCharFormat.AnsiFont = font;
                    cell.DefaultCharFormat.FontSize = fontSize;
                }

            }
            //table.SetRowKeepInSamePage(0, true);
            table.HorizontalAlignment = HorizontalAlignment.Distributed;

            for (var col = 0; col < table.ColCount; col++)
            {
                table.SetOuterBorder(col, 0, 1, table.RowCount, BorderStyle.Single, 1.5f);
            }
        }
    }
}
