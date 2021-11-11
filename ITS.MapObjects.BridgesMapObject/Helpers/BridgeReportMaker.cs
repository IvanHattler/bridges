using ITS.Core.Bridges.Domain;
using ITS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    /// <summary>
    /// Формирователь информации о мостовом сооружении
    /// </summary>
    public class BridgeReportMaker : IBridgeReportMaker
    {
        IComparerInGroups _comparer;
        Bridge _bridge;

        /// <summary>
        /// Количество строк в основной информации о мостовом сооружении
        /// </summary>
        public int BridgeRowsCount => 54;
        /// <summary>
        /// Количество строк в информации об опорах мостового сооружения
        /// </summary>
        public int SupportRowsCount => 16;
        /// <summary>
        /// Количество строк в информации о пролётных строениях мостового сооружения
        /// </summary>
        public int SpanStructureRowsCount => 40;
        /// <summary>
        /// Количество строк в информации о состоянии мостового сооружения
        /// </summary>
        public int BridgeConditionRowsCount => 14;
        //public int SpanStructuresCount => _bridge.SpanStructures.Count;
        //public int SupportsCount => _bridge.Supports.Count;
        /// <summary>
        /// Количество дефектов мостового сооружения
        /// </summary>
        public int? DefectsCount => _bridge.Defects?.Count;
        /// <summary>
        /// Количество имеющейся технической документации мостового сооружения
        /// </summary>
        public int? DocumentationsCount => _bridge.Documentations?.Count;
        /// <summary>
        /// Список из групп одинаковых пролётных строений
        /// </summary>
        public List<List<SpanStructure>> SpanStructureGroups { get; protected set; }
        /// <summary>
        /// Список из групп одинаковых опор
        /// </summary>
        public List<List<BridgeSupport>> SupportGroups { get; protected set; }

        public BridgeReportMaker(Bridge bridge, IComparerInGroups comparer)
        {
            _bridge = bridge;
            _comparer = comparer;
            Refresh();
        }

        /// <summary>
        /// Вызывать при изменении свойств Supports и/или SpanStructures связанного объекта Bridge
        /// </summary>
        public void Refresh()
        {
            SupportGroups = _comparer.CompareInGroups(_bridge.Supports);
            SpanStructureGroups = _comparer.CompareInGroups(_bridge.SpanStructures);
        }

        /// <summary>
        /// Формирует основные сведения мостового сооружения
        /// </summary>
        /// <returns></returns>
        public List<object[]> GetBridgeReport()
        {
            string protectionOnBridge = _bridge.ProtectionOnBridge == null ?
                "-" : _bridge.ProtectionOnBridge.ToString();
            string protectionOnApproach = _bridge.ProtectionOnApproach == null ?
                "-" : _bridge.ProtectionOnApproach.ToString();
            var slopeLongitudinalAfterAsString = _bridge.SlopeLongitudinalAfterAsString;
            var slopeLongitudinalBeforeAsString = _bridge.SlopeLongitudinalBeforeAsString;
            var reportData = new List<object[]>(54)
            {
                new[] { "1.", "Сооружение", _bridge.ConstructionAsString },
                new[] { "2.", "Препятствия", _bridge.ObstaclesAsString },
                new[] { "3.", "Дорога", string.IsNullOrEmpty(_bridge.RoadName) ? "Нет данных" : _bridge.RoadName },
                new[] { "", "Расширенный код дороги", _bridge.ExpandedRoadCode },
                new[] { "4.", "Километр", _bridge.KilometerAsString },
                new[] { "", "Код территории", _bridge.Territory == null ? "Нет данных" : _bridge.Territory.ToString() },
                new[] { "5.", "Категория дороги", _bridge.RoadCategoryAsString },
                new[] { "", "Число полос", _bridge.QuantityLineAsString },
                new[] { "", "Наличие разметки", _bridge.MarkupAsString },
                new[] { "6.", "Ближайший населенный пункт", string.IsNullOrEmpty(_bridge.NearestVillage) ? "Нет данных" : _bridge.NearestVillage },
                new[] { "", "Расстояние до него", _bridge.DistanceToVillage < 1e-5 ? "в населённом пункте" : _bridge.DistanceToVillage.ToString("F") },
                new[] { "7.", "Характеристики пересекаемого препятствия", _bridge.CharactObstacleAsString },
                new[] { "8.", "Подмостовой габарит", _bridge.UnderbridgeClearance },
                new[] { "9.", "Длина мостового сооружения", _bridge.Length.ToString("F") },
                new[] { "10.", "Отверстие", _bridge.Hole < 1e-5 ? "Нет данных" : _bridge.Hole.ToString("F") },
                new[] { "11.", "Габарит по высоте", _bridge.HeightDimensionAsString },
                new[] { "12.", "Габарит по ширине", _bridge.WidthDimensionAsString },
                new[] { "13.", "Дата постройки", _bridge.ConstructionDate == DateTime.MinValue ? "Нет данных" : _bridge.ConstructionDate.Year.ToString() },
                new[] { "", "Дата реконструкции", _bridge.ReconstructionDate == DateTime.MinValue ? "Нет данных" : _bridge.ReconstructionDate.Year.ToString() },
                new[] { "", "Дата ремонта", _bridge.RepairsDate == DateTime.MinValue ? "Нет данных" : _bridge.RepairsDate.Year.ToString() },
                new[] { "14.", "Проектные нагрузки", string.IsNullOrEmpty(_bridge.DesignBurden) ? "Нет данных" : _bridge.DesignBurden },
                new[] { "15.", "Продольная схема", _bridge.LongitudeScheme  },
                new[] { "16.", "Угол косины", _bridge.ObliqueAngle < 1e-5 ? "-" : _bridge.ObliqueAngle.ToString("F") },
                new[] { "", "Расположение в плане", _bridge.LocationInPlanAsString },
                new[] { "17.", "Уклоны", "" },
                new[] { "", "a) продольный", _bridge.SlopeLongitudinalForReport  },
                new[] { "", "б) поперечный", _bridge.SlopeLateralForReport },
                new[] { "18.", "Покрытие проезжей части", _bridge.CoverTypeAsString },
                new[] { "19.", "Тип водоотвода", _bridge.DrainageTypeAsString },
                new[] { "20.", "Тип деформационных швов", _bridge.ExpansionJointsTypes },
                new[] { "21.", "Ограждения безопасности на мостовом сооружении/подходах тип", $"{protectionOnBridge} / {protectionOnApproach}" },
                new[] { "22.", "Тротуары", _bridge.SidewalksAsString },
                new[] { "23.", "Перила (тип, высота)", _bridge.RailingsUserAsString },
                new[] { "24.", "Подходы", "" },
                new[] { "", "ширина проезжей части перед", _bridge.CarriagewayWidthBefore.ToString("F") },
                new[] { "", "за мостовым сооружением", _bridge.CarriagewayWidthAfter.ToString("F") },
                new[] { "", "продольный уклон перед", string.IsNullOrEmpty(slopeLongitudinalBeforeAsString) ? "-" : slopeLongitudinalBeforeAsString },
                new[] { "", "за мостовым сооружением", string.IsNullOrEmpty(slopeLongitudinalAfterAsString) ? "-" : slopeLongitudinalAfterAsString },
                new[] { "", "высота насыпи в начале", _bridge.EmbankmentHeightBefore < 1e-5 ? "-" : _bridge.EmbankmentHeightBefore.ToString("F") },
                new[] { "", "в конце мостового сооружения", _bridge.EmbankmentHeightAfter < 1e-5 ? "-" : _bridge.EmbankmentHeightAfter.ToString("F") },
                new[] { "25.", "Регуляционные сооружения", _bridge.RegulatoryStructuresAsString },
                new[] { "26.", "Укрепление конусов", _bridge.ConesStrengtheningAsString },
                new[] { "27.", "Переходные плиты (1/0)", _bridge.AdapterPlatesAsString },
                new[] { "28.", "Проектная организация", _bridge.ExploitOrganization == null ? "Нет данных" : _bridge.ExploitOrganization.ToString() },
                new[] { "29.", "Строительная организация", _bridge.BuildingOrganization == null ? "Нет данных" : _bridge.BuildingOrganization.ToString() },
                new[] { "30.", "Проектная организация", _bridge.ProjectOrganization == null ? "Нет данных" : _bridge.ProjectOrganization.ToString() },
                new[] { "31.", "Дорожные знаки: перед", string.IsNullOrEmpty(_bridge.RoadSignsBefore) ? "Нет данных" : _bridge.RoadSignsBefore },
                new[] { "", "за мостовым сооружением", string.IsNullOrEmpty(_bridge.RoadSignsAfter) ? "Нет данных" : _bridge.RoadSignsAfter },
                new[] { "32.", "Сведения о реконструкциях, ремонтах", _bridge.InfoOfRepairsForReport == null ? "Нет данных" : _bridge.InfoOfRepairsForReport.JobsAsString },
                new[] { "33.", "Коммуникации", _bridge.CommunicationsAsString },
                new[] { "34.", "Обустройства", _bridge.ArrangementsAsString },
                new[] { "35.", "Дата обследования", _bridge.DateView == DateTime.MinValue ? "Нет данных" : _bridge.DateView.ToShortDateString() },
                new[] { "36.", "Примечания", string.IsNullOrEmpty(_bridge.Notes) ? "Нет" : _bridge.Notes }
            };
            if (_bridge.Obstacles != null && _bridge.Obstacles
                .Select(o=>o.Type).Contains(Core.Bridges.Domain.Enums.ObstacleType.River))
            {
                reportData.Insert(12,
                    new string[] { "", "Направление течения", _bridge.CharactObstacleDirectionFlowAsString });
            }
            return reportData;
        }

        /// <summary>
        /// Формирует информацию о пролётных строениях, возвращает null, если нет пролётов
        /// </summary>
        /// <returns></returns>
        public List<List<object[]>> GetSpanStructuresReports()
        {
            var reports = new List<List<object[]>>(SpanStructureGroups.Count);
            if (SpanStructureGroups == null || SpanStructureGroups.Count < 1)
            {
                return reports;
            }
            for (int i = 0; i < SpanStructureGroups.Count; i++)
            {
                reports.Add(GetSpanStructureReport(SpanStructureGroups[i][0]));
            }
            return reports;
        }
        /// <summary>
        /// Формирует информацию об опорах мостового сооружения, возвращает null, если нет опор
        /// </summary>
        /// <returns></returns>
        public List<List<object[]>> GetSupportsReports()
        {
            var reports = new List<List<object[]>>(SupportGroups.Count);
            if (SupportGroups == null || SupportGroups.Count < 1)
            {
                return reports;
            }
            for (int i = 0; i < SupportGroups.Count; i++)
            {
                reports.Add(GetSupportReport(SupportGroups[i][0]));
            }
            return reports;
        }
        /// <summary>
        /// Формирует информацию о дефектах
        /// </summary>
        /// <returns></returns>
        public List<object[]> GetDefectReport()
        {
            List<object[]> reportData = null;
            if (_bridge.Defects != null)
            {
                var defs = _bridge.Defects;
                reportData = new List<object[]>(defs.Count);
                for (int i = 0; i < defs.Count; i++)
                {
                    reportData.Add(new[] { $"{i+1}.", defs[i].Location,  defs[i].Type?.Name,
                defs[i].Params.Replace(';', '\n').Trim('\n'), defs[i].Category, defs[i].Notes });
                }
            }
            return reportData;
        }
        /// <summary>
        /// Формирует прочую информацию
        /// </summary>
        /// <returns></returns>
        public List<object[]> GetOthersInfoReport()
        {
            var reportData = new List<object[]>()
            {
                new[] { "1.", "Статус", _bridge.StatusAsString},
                new[] { "2.", "Качество моста", _bridge.QualityBridgeTypeAsString},
                new[] { "3.", "Тип движения", _bridge.MoveTypeAsString},
                new[] { "4.", "Номер уровня высоты", _bridge.HeightLevelNumber.ToString()},
            };

            return reportData;
        }
        /// <summary>
        /// Формирует информацию об имеющейся технической документации
        /// </summary>
        /// <returns></returns>
        public List<object[]> GetDocumentationsReport()
        {
            List<object[]> reportData = null;
            if (_bridge.Documentations != null)
            {
                var docs = _bridge.Documentations;
                reportData = new List<object[]>(docs.Count);
                for (int i = 0; i < docs.Count; i++)
                {
                    reportData.Add(new[] { $"{docs[i].Number}.", docs[i].NameAndDate, docs[i].Creator, docs[i].Storage });
                }
            }
            return reportData;
        }

        /// <summary>
        /// Формирует информацию о пролётном строении
        /// </summary>
        /// <param name="spanStructure">Пролётное строение</param>
        /// <returns></returns>
        public List<object[]> GetSpanStructureReport(SpanStructure spanStructure)
        {
            string longitudeScheme = string.IsNullOrEmpty(spanStructure.LongitudeScheme) || 
                spanStructure.LongitudeScheme == "0" ?
                "Нет данных" : spanStructure.LongitudeScheme;
            if (_bridge.LongitudeSchemeLm > 1e-5)
            {
                longitudeScheme += $"\\Lm = {_bridge.LongitudeSchemeLm.ToString("F")}";
            }
            string expansionJoints = spanStructure.ExpansionJointTypeAsString;
            if (!string.IsNullOrEmpty(spanStructure.ExpansionJointAddInfo))
            {
                expansionJoints += ", {spanStructure.ExpansionJointAddInfo}";
            }
            string crossScheme = spanStructure.CrossScheme;
            return new List<object[]>(40)
                {
                    new[] { "1.", "Статическая система", spanStructure.SystemAsString },
                    new[] { "2.", "Пролетное строение", spanStructure.SpanStructureTypeAsString },
                    new[] { "3.", "Конструкция проезжей части", spanStructure.ConstructionRoadwayAsString },
                    new[] { "4.", "Материал главных балок", spanStructure.Material == null ? "Нет данных" : spanStructure.Material.Name },
                    new[] { "5.", "Типы стыков", spanStructure.JointTypeAsString },
                    new[] { "6.", "Продольная схема",  longitudeScheme},
                    new[] { "7.", "Параметры габарита по ширине", spanStructure.WidthDimensionAsString },
                    new[] { "8.", "Дата изготовления", spanStructure.ConstructionDate == DateTime.MinValue ? "Нет данных" : spanStructure.ConstructionDate.Year.ToString() },
                    new[] { "9.", "Проектные нагрузки", spanStructure.DesignBurdens },
                    new[] { "10.", "Номер типового проекта", spanStructure.TypicalProject == null ? "Нет данных" : spanStructure.TypicalProject.Name },
                    new[] { "11.", "Типы опорных частей подвижные", spanStructure.SpanTypeMovableAsString },
                    new[] { "", "неподвижные", spanStructure.SpanTypeMotionlessAsString },
                    new[] { "12.", "Типы деформационных швов", expansionJoints },
                    new[] { "13.", "Способ поперечного объединения", spanStructure.CrossJoinAsString },
                    new[] { "14.", "Поперечная схема", string.IsNullOrEmpty(crossScheme) ? "Нет данных" : crossScheme },
                    new[] { "15.", "Плита проезжей части", "" },
                    new[] { "", "толщина", spanStructure.PlateThickness < 1e-5 ? "Нет данных" : spanStructure.PlateThickness.ToString("F") },
                    new[] { "", "материал", spanStructure.PlateMaterial == null ? "Нет данных" : spanStructure.PlateMaterial.Name },
                    new[] { "16.", "Одежда ездового полотна", "" },
                    new[] { "", "толщина", spanStructure.RoadwayClothingThickness < 1e-5 ? "Нет данных" : spanStructure.RoadwayClothingThickness.ToString("F") },
                    new[] { "", "в том числе толщина дополнительного слоя покрытия", spanStructure.RoadwayClothingAddLayerThickness == null ? "Нет данных"
                        : spanStructure.RoadwayClothingAddLayerThickness?.ToString("F") },
                    new[] { "", "Материал покрытия", spanStructure.CoverTypeAsString },
                    new[] { "17.", "Число главных ферм (балок)", spanStructure.MainPileCount.ToString() },
                    new[] { "18.", "Высота главной фермы (балки)", "" },
                    new[] { "", "в пролете", spanStructure.MainPileHeightSpan < 1e-5 ? "Нет данных" : spanStructure.MainPileHeightSpan.ToString("F") },
                    new[] { "", "у опоры", spanStructure.MainPileHeightSupport < 1e-5 ? "Нет данных" : spanStructure.MainPileHeightSupport.ToString("F") },
                    new[] { "", "толщина ребра или стенки", spanStructure.MainPileThicknessEdge < 1e-5 ? "Нет данных" :  spanStructure.MainPileThicknessEdge.ToString("F") },
                    new[] { "19.", "Поперечные балки (диафрагмы)", spanStructure.CrossPile == null ? "Нет" : "" },
                    new[] { "", "количество в пролете", spanStructure.CrossPile?.CountInSpan.ToString() },
                    new[] { "", "высота", spanStructure.CrossPile?.Height.ToString() },
                    new[] { "", "материал", spanStructure.CrossPile?.Material?.Name },
                    new[] { "20.", "Продольные балки в панели", spanStructure.LongitudinalPile == null ? "Нет" : "" },
                    new[] { "", "тип", spanStructure.LongitudinalPile?.TypeAsString },
                    new[] { "", "количество в пролете", spanStructure.LongitudinalPile?.CountInSpan.ToString() },
                    new[] { "", "высота", spanStructure.LongitudinalPile?.Height.ToString() },
                    new[] { "", "материал", spanStructure.LongitudinalPile?.Material?.Name },
                    new[] { "21.", "Дополнительная погонная нагрузка", spanStructure.AdditionalLinearLoad < 1e-5? "Нет" : spanStructure.AdditionalLinearLoad.ToString("F") },
                    new[] { "", "(коммуникации, ограждения и т.п.)", "" },
                    new[] { "", "т/п.м. № балок, несущих дополнительную нагрузку", "" },
                    new[] { "22.", "Примечания", string.IsNullOrEmpty(spanStructure.Notes) ? "Нет" : spanStructure.Notes },
                };
        }
        /// <summary>
        /// Формирует информацию об опоре
        /// </summary>
        /// <param name="support">Опора</param>
        /// <returns></returns>
        public List<object[]> GetSupportReport(BridgeSupport support)
        {
            var scheme = support.Scheme;
            return new List<object[]>(16)
                {
                    new[] { "1.", "Тип опоры",  support.IsShore ? support.ShoreSupportTypeAsString : support.IntermediateSupportTypeAsString},
                    new[] { "2.", "Тип фундамента",  support.FoundationTypeAsString },
                    new[] { "3.", "Материал",  support.Material == null ? "Нет данных" : support.Material.Name },
                    new[] { "4.", "Высоты опор до уровня естественного грунта",  support.HeightsAsString },
                    new[] { "5.", "Глубина заложения фундаментов (свай)",  support.LayingDepth < 1e-5 ? "Нет данных" : support.LayingDepth.ToString("F") },
                    new[] { "6.", "Номер типового проекта",  support.TypicalProject == null ? "Нет данных" : support.TypicalProject.Name },
                    new[] { "7.", "Размеры массивной части опоры в уровне обреза фундамента вдоль сооружения (а)",  support.MassivePartAsString },
                    new[] { "8.", "Число свай (стоек, столбов)",  support.PileCount.ToString() },
                    new[] { "", "Максимальное расстояние между смежными осями",  support.MaxDistanceBetweenAxis < 1e-5 ? "Нет данных" : support.MaxDistanceBetweenAxis.ToString("F") },
                    new[] { "9.", "Схема опоры",  string.IsNullOrEmpty(scheme) ? "Нет" : scheme },
                    new[] { "10.", "Сечение и длина ригеля",  "" },
                    new[] { "", "ширина", support.CrossbarWidth < 1e-5 ? "Нет данных" : support.CrossbarWidth.ToString("F") },
                    new[] { "", "высота",  support.CrossbarHeight < 1e-5 ? "Нет данных" : support.CrossbarHeight.ToString("F") },
                    new[] { "", "длина",  support.CrossbarLength < 1e-5 ? "Нет данных" : support.CrossbarLength.ToString("F") },
                    new[] { "11.", "Сечение сваи (стойки, столба)",  support.PileCrossSection },
                    new[] { "12.", "Примечания",  string.IsNullOrEmpty(support.Notes) ? "Нет" : support.Notes },
                };
        }
        /// <summary>
        /// Информация о состоянии мостового сооружения
        /// </summary>
        /// <param name="formerName">Имя ответственного за исходные данные</param>
        /// <returns></returns>
        public List<object[]> GetBridgeConditionReport(string formerName)
        {
            return new List<object[]>(14)
                {
                    new[] { "1.", "Оценка состояния по ВСН 4-81", "" },
                    new[] { "2.", "Грузоподъемность (допустимая общая и осевая масса автомобиля):", "" },
                    new[] { "", "в потоке:", "" },
                    new[] { "", "в одиночном порядке:", "" },
                    new[] { "", "экспертные коэффициенты", "" },
                    new[] { "", "для автомобиля в потоке:", "Kg=" },
                    new[] { "", "то же одиночным порядком:", "Ks=" },
                    new[] { "", "на ось:", "Kp=" },
                    new[] { "", "Причина снижения оценки технического состояния моста и грузоподъёмности:", "" },
                    new[] { "3.", "Наибольщая категория дефекта:", "" },
                    new[] { "4.", "Необходимость дополнительного обследования (0-нет/1-да)", "" },
                    new[] { "5.", "Дата ввода в ЭВМ:", _bridge.DateView == DateTime.MinValue ? "Нет данных" : _bridge.DateView.ToShortDateString() },
                    new[] { "6.", "Ответственные за исходные данные:", formerName },
                    new[] { "7.", "Дополнительные сведения, рекомендации:", "-" },
                };
        }
    }
}