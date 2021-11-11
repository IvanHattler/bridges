using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Domain.FeatureObjects;
using ITS.Core.Enums;
using ITS.Core.Domain.Organizations;
using ITS.Core.Domain.Photos;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.Helpers;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Основной класс мостового сооружения
    /// </summary>
    [Serializable]
    public class Bridge : DomainObject<long>, IPhotoable
    {
        #region Constructors

        /// <summary>
        /// Конструктор по-умолчанию
        /// </summary>
        public Bridge() { }

        #endregion

        #region Data Properties

        #region Код сооружения
        /// <summary>
        /// Находится ли мостовое сооружение левее ещё одного мостового сооружения
        /// </summary>
        public bool? IsLeft { get; set; } = null;
        /// <summary>
        /// Находится ли путепровод (только для путепроводов) над дорогой, к которой приписан
        /// </summary>
        public bool IsOverTheRoad { get; set; }
        /// <summary>
        /// Код мостового сооружения
        /// </summary>
        public string BridgeCode
        {
            get
            {
                return GetCode(RoadCode, IsOverTheRoad, ConstructionType, Kilometer, IsLeft);
            }
        }
        #endregion

        #region Сооружение
        /// <summary>
        /// Название мостового сооружения
        /// </summary>
        public string ConstructionName { get; set; }
        /// <summary>
        /// Тип мостового сооружения
        /// </summary>
        public BridgeType ConstructionType { get; set; } = BridgeType.Bridge;
        /// <summary>
        /// Сооружение в виде строки, содержит тип и название мостового сооружения
        /// </summary>
        public string ConstructionAsString =>
            $"{ConstructionTypeAsString} {ConstructionName}";
        #endregion

        #region Пересекаемые препятствия
        /// <summary>
        /// Пересекаемые препятствия
        /// </summary>
        public IList<BridgeObstacle> Obstacles { get; set; }
        /// <summary>
        /// Пересекаемые препятствия в виде строки
        /// </summary>
        public string ObstaclesAsString
        {
            get
            {
                if (Obstacles != null && Obstacles.Count > 0)
                {
                    return string.Join(", ", Obstacles);
                }
                return "Нет данных";
            }
        }
        #endregion

        /// <summary>
        /// Название дороги
        /// </summary>
        public string RoadName { get; set; }

        #region Расширенный код дороги
        //Сделать отдельную таблицу с кодами округов
        /// <summary>
        /// Код субъекта РФ
        /// </summary>
        public short SubjectCode { get; set; }
        /// <summary>
        /// Код территориального дорожного управления или дирекция автомобильной дороги
        /// </summary>
        public int TerritorialRoadControlCode { get; set; }
        /// <summary>
        /// Код автомобильной дороги по кодификатору
        /// </summary>
        public int RoadCode { get; set; }
        /// <summary>
        /// Расширенный код дороги
        /// </summary>
        public string ExpandedRoadCode =>
            $"{SubjectCode}.{TerritorialRoadControlCode}.{RoadCode.ToString("D4")}";
        #endregion

        #region Километр
        /// <summary>
        /// Километр
        /// </summary>
        public int Kilometer { get; set; }
        /// <summary>
        /// Километр в виде строки
        /// </summary>
        public string KilometerAsString
            => $"{Kilometer / 1000}+{Kilometer % 1000}";
        /// <summary>
        /// Территория
        /// </summary>
        public Territory Territory { get; set; }
        #endregion

        #region Категория дороги
        /// <summary>
        /// Категория дороги
        /// </summary>
        public RoadCategory RoadCategory { get; set; }
        /// <summary>
        /// Количество полос на мосту
        /// </summary>
        public int QuantityLineBridge { get; set; }
        /// <summary>
        /// Количество полос на подходе
        /// </summary>
        public int QuantityLineApproach { get; set; }
        /// <summary>
        /// Количество полос на мостовом сооружении и на подходах в виде строки
        /// </summary>
        public string QuantityLineAsString
            => $"{QuantityLineBridge}/{QuantityLineApproach}";
        /// <summary>
        /// Наличие разметки
        /// </summary>
        public bool Markup { get; set; }
        /// <summary>
        /// Наличие разметки в виде строки
        /// </summary>
        public string MarkupAsString
            => Markup ? "1" : "0";
        #endregion

        /// <summary>
        /// Ближайший населенный пункт
        /// </summary>
        public string NearestVillage { get; set; }
        /// <summary>
        /// Расстояние до ближайшего населенного пункта
        /// </summary>
        public float DistanceToVillage { get; set; }

        #region Характеристики пересекаемого препятствия
        /// <summary>
        /// Ширина зеркала воды
        /// </summary>
        public float CharactObstacleB { get; set; }
        /// <summary>
        /// Глубина реки
        /// </summary>
        public float CharactObstacleH { get; set; }
        /// <summary>
        /// Скорость течения в м/с
        /// </summary>
        public float CharactObstacleV { get; set; }
        /// <summary>
        /// Направление течения реки, true - слева направо(1), false - справа налево (-1)
        /// </summary>
        public bool CharactObstacleDirectionOfFlow { get; set; }
        /// <summary>
        /// Дополнительная информация по пересекаемым препятствиям, для путепроводов
        /// - число полос движения или число железнодорожных путей, если пересекаемая 
        /// железная дорога электрифицирована, это также отмечают
        /// </summary>
        public string CharactObstacleAddInfo { get; set; }
        /// <summary>
        /// Направление течения реки в виде строки
        /// </summary>
        public string CharactObstacleDirectionFlowAsString
            => CharactObstacleDirectionOfFlow ? "1" : "-1";
        /// <summary>
        /// Характеристики пересекаемого препятствия в виде строки
        /// </summary>
        public string CharactObstacleAsString
        {
            get
            {
                var sb = new StringBuilder();
                bool isSomethingWrited = false;
                if (CharactObstacleB > 1e-5)
                {
                    sb.Append($"B={CharactObstacleB.ToString("F")}; ");
                    isSomethingWrited = true;
                }
                if (CharactObstacleH > 1e-5)
                {
                    sb.Append($"H={CharactObstacleH.ToString("F")}; ");
                    isSomethingWrited = true;
                } 
                if (CharactObstacleV > 1e-5)
                {
                    sb.Append($"V={CharactObstacleV.ToString("F")}; ");
                    isSomethingWrited = true;
                }
                if (!string.IsNullOrEmpty(CharactObstacleAddInfo))
                {
                    sb.Append(CharactObstacleAddInfo);
                    isSomethingWrited = true;
                }
                if (isSomethingWrited)
                {
                    return sb.ToString();
                }
                return "Нет данных";
            }
        }
        #endregion

        /// <summary>
        /// Подмостовой габарит по всем пролётным строениям
        /// </summary>
        public string UnderbridgeClearance
        {
            get
            {
                if (SpanStructures != null && SpanStructures.Count > 0)
                {
                    //todo: не оптимально
                    if (SpanStructures.Select(sp => sp.UnderbridgeClearance).Distinct().Count() == 1)
                    {
                        return SpanStructures[0].UnderbridgeClearance.ToString("F");
                    }
                    var sortedSpanStructures = SpanStructures.OrderBy(sp => sp.Number).ToArray();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < sortedSpanStructures.Length; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append($"; Пр.{sortedSpanStructures[i].Number} - {sortedSpanStructures[i].UnderbridgeClearance.ToString("F")}");
                        }
                        else
                        {
                            sb.Append($"Пр.{sortedSpanStructures[i].Number} - {sortedSpanStructures[i].UnderbridgeClearance.ToString("F")}");
                        }
                    }
                    return sb.ToString();
                }
                return "Нет данных";
            }
        }
        /// <summary>
        /// Длина мостового сооружения
        /// </summary>
        public float Length { get; set; }
        /// <summary>
        /// Отверстие, только для мостов
        /// </summary>
        public float Hole { get; set; }

        #region Габарит по высоте
        /// <summary>
        /// Габарит по высоте, null - габарит не ограничен
        /// </summary>
        public float? HeightDimension { get; set; }
        /// <summary>
        /// Габарит по высоте в виде строки
        /// </summary>
        public string HeightDimensionAsString =>
            HeightDimension == null ?
            "Не ограничен" : HeightDimension.Value.ToString("F");
        #endregion

        #region Габарит по ширине
        /// <summary>
        /// Полная ширина мостового сооружения
        /// </summary>
        public float WidthDimensionB { get; set; }
        /// <summary>
        /// Ширина левого тротуара
        /// </summary>
        public float WidthDimensionT1 { get; set; }
        /// <summary>
        /// Ширина правого тротуара
        /// </summary>
        public float WidthDimensionT2 { get; set; }
        /// <summary>
        /// Ширина разделительной полосы
        /// </summary>
        public float WidthDimensionC { get; set; }
        /// <summary>
        /// Ширина левого ограждения безопасности
        /// </summary>
        public float WidthDimensionC1 { get; set; }
        /// <summary>
        /// Ширина правого ограждения безопасности
        /// </summary>
        public float WidthDimensionC2 { get; set; }
        /// <summary>
        /// Количество проездов с ограждениями
        /// </summary>
        public int WidthDimensionBrivewayCount { get; set; } = 1;
        /// <summary>
        /// Расстояние между ограждениями проезда
        /// </summary>
        public float WidthDimensionG { get; set; }
        /// <summary>
        /// Габарит по ширине в виде строки
        /// </summary>
        public string WidthDimensionAsString
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append($"B={WidthDimensionB.ToString("F")}; ");
                if (WidthDimensionBrivewayCount > 1)
                {
                    stringBuilder.Append(WidthDimensionBrivewayCount);
                }
                stringBuilder.Append($"Г={WidthDimensionG.ToString("F")}");
                if (WidthDimensionT1 > 0)
                {
                    stringBuilder.Append($"; T1={WidthDimensionT1.ToString("F")}");
                }
                if (WidthDimensionT2 > 0)
                {
                    stringBuilder.Append($"; T2={WidthDimensionT2.ToString("F")}");
                }
                if (WidthDimensionC > 0)
                {
                    stringBuilder.Append($"; C={WidthDimensionC.ToString("F")}");
                }
                if (WidthDimensionC1 > 0)
                {
                    stringBuilder.Append($"; C1={WidthDimensionC1.ToString("F")}");
                }
                if (WidthDimensionC2 > 0)
                {
                    stringBuilder.Append($"; C2={WidthDimensionC2.ToString("F")}");
                }
                return stringBuilder.ToString();
            }
        }
        #endregion

        /// <summary>
        /// Дата постройки
        /// </summary>
        public DateTime ConstructionDate { get; set; }
        /// <summary>
        /// Дата реконструкции
        /// </summary>
        public DateTime ReconstructionDate =>
            InfoOfRepairsForReport == null ? DateTime.MinValue : InfoOfRepairsForReport.Date;
        /// <summary>
        /// Дата ремонта
        /// </summary>
        public DateTime RepairsDate { get; set; }
        /// <summary>
        /// Проектные нагрузки
        /// </summary>
        public string DesignBurden { get; set; }
        
        #region Продольная схема
        /// <summary>
        /// Длина максимального расчётного пролёта
        /// </summary>
        public float LongitudeSchemeLm { get; set; }
        /// <summary>
        /// Продольная схема
        /// </summary>
        public string LongitudeScheme
        {
            get
            {
                return GetLongitudeScheme(SpanStructures, LongitudeSchemeLm);
            }
        }
        #endregion

        /// <summary>
        /// Угол косины, в градусах
        /// </summary>
        public float ObliqueAngle { get; set; }
        /// <summary>
        /// Расположение в плане
        /// </summary>
        public LocationInPlan LocationInPlan { get; set; }

        #region Уклоны

        /// <summary>
        /// Уклон продольный в виде строки для паспорта
        /// </summary>
        public string SlopeLongitudinalForReport
        {
            get
            {
                if (SpanStructures != null && SpanStructures.Count > 0)
                {
                    //todo: не оптимально
                    if (SpanStructures.Select(sp => sp.SlopeLongitudinalForReport).Distinct().Count() == 1)
                    {
                        return SpanStructures[0].SlopeLongitudinalForReport;
                    }
                    var sortedSpanStructures = SpanStructures.OrderBy(sp => sp.Number).ToArray();
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < sortedSpanStructures.Length; i++)
                    {
                        if (i != 0)
                        {
                            sb.Append($"; Пр.{sortedSpanStructures[i].Number} - {sortedSpanStructures[i].SlopeLongitudinalForReport}");
                        }
                        else
                        {
                            sb.Append($"Пр.{sortedSpanStructures[i].Number} - {sortedSpanStructures[i].SlopeLongitudinalForReport}");
                        }
                    }
                    return sb.ToString();
                }
                return "Нет данных";
            }
        }
        
        /// <summary>
        /// Уклон поперечный, %
        /// </summary>
        public float SlopeLateral { get; set; }
        /// <summary>
        /// Профиль поперечного уклона
        /// </summary>
        public SlopeProfile SlopeLateralProfile { get; set; }
        /// <summary>
        /// Поперечный уклон в виде строки для паспорта
        /// </summary>
        public string SlopeLateralForReport
        {
            get
            {
                if (SlopeLateral < 1e-5)
                {
                    return "Нет данных";
                }
                return $"{SlopeProfileStrings.Instance.GetName(SlopeLateralProfile)}{SlopeLateral.ToString("F")}%";
            }
        }
        #endregion

        /// <summary>
        /// Дорожное покрытие
        /// </summary>
        public CoverType CoverType { get; set; }
        /// <summary>
        /// Тип водоотвода
        /// </summary>
        public DrainageType DrainageType { get; set; }
        /// <summary>
        /// Тип деформационных швов
        /// </summary>
        public string ExpansionJointsTypes
        {
            get
            {
                return GetExpansionJointTypesString(SpanStructures);
            }
        }

        /// <summary>
        /// Ограждения безопасности на мостовом сооружении
        /// </summary>
        public Protection ProtectionOnBridge { get; set; }
        /// <summary>
        /// Ограждения безопасности на подходах
        /// </summary>
        public Protection ProtectionOnApproach { get; set; }
        /// <summary>
        /// Тип тротуара
        /// </summary>
        public SidewalkType Sidewalks { get; set; }

        #region Перила (тип, высота)
        /// <summary>
        /// Тип перил
        /// </summary>
        public RailingsType RailingsType { get; set; }
        /// <summary>
        /// Высота перил
        /// </summary>
        public float RailingsHeight { get; set; }
        /// <summary>
        /// Перила
        /// </summary>
        public string RailingsUserAsString =>
            RailingsType == RailingsType.None || RailingsType == RailingsType.NoData ?
            RailingsTypeAsString :
            $"{RailingsTypeAsString} {RailingsHeight} м";
        #endregion

        #region Подход перед мостом
        /// <summary>
        /// Ширина проезжей части
        /// </summary>
        public float CarriagewayWidthBefore { get; set; }
        /// <summary>
        /// Продольный уклон
        /// </summary>
        public float SlopeLongitudinalBefore { get; set; }
        /// <summary>
        /// Профиль продольного уклона перед мостом
        /// </summary>
        public SlopeProfile SlopeLongitudinalProfileBefore { get; set; }
        /// <summary>
        /// Продольный уклон перед мостом в виде строки
        /// </summary>
        public string SlopeLongitudinalBeforeAsString
        {
            get
            {
                if (SlopeLongitudinalBefore < 1e-5)
                {
                    return "";
                }
                return SlopeLongitudinalProfileBeforeAsString +
                    " " + SlopeLongitudinalBefore.ToString("F");
            }
        }
            
        /// <summary>
        /// Высота насыпи
        /// </summary>
        public float EmbankmentHeightBefore { get; set; }
        #endregion

        #region Подход за мостом
        /// <summary>
        /// Ширина проезжей части
        /// </summary>
        public float CarriagewayWidthAfter { get; set; }
        /// <summary>
        /// Продольный уклон
        /// </summary>
        public float SlopeLongitudinalAfter { get; set; }
        /// <summary>
        /// Профиль продольного уклона за мостом
        /// </summary>
        public SlopeProfile SlopeLongitudinalProfileAfter { get; set; }
        /// <summary>
        /// Продольный уклон за мостом в виде строки
        /// </summary>
        public string SlopeLongitudinalAfterAsString
        {
            get
            {
                if (SlopeLongitudinalAfter < 1e-5)
                {
                    return "";
                }
                return SlopeLongitudinalProfileAfterAsString + 
                    " " + SlopeLongitudinalAfter.ToString("F");
            }
        }
           
        /// <summary>
        /// Высота насыпи
        /// </summary>
        public float EmbankmentHeightAfter { get; set; }
        #endregion

        /// <summary>
        /// Регуляционные сооружения
        /// </summary>
        public RegulatoryStructures RegulatoryStructures { get; set; } = RegulatoryStructures.None;
        /// <summary>
        /// Укрепление конусов
        /// </summary>
        public Strenghtening ConesStrengthening { get; set; }

        #region Переходные плиты
        /// <summary>
        /// Переходные плиты
        /// </summary>
        public AdapterPlatesAvailability AdapterPlatesAvailability { get; set; }
        /// <summary>
        /// Переходные плиты в виде строки
        /// </summary>
        public string AdapterPlatesAvailabilityAsString
            => AdapterPlatesAvailabilityStrings.Instance.GetName(AdapterPlatesAvailability);
        /// <summary>
        /// Длина переходных плит
        /// </summary>
        public float? AdapterPlatesLength { get; set; }
        /// <summary>
        /// Переходные плиты в виде строки для паспорта
        /// </summary>
        public string AdapterPlatesAsString
        {
            get
            {
                if (AdapterPlatesAvailability == AdapterPlatesAvailability.Yes && AdapterPlatesLength != null)
                {
                    return $"{(byte)AdapterPlatesAvailability} ({AdapterPlatesLength.Value.ToString("F")})";
                }
                else if(AdapterPlatesAvailability == AdapterPlatesAvailability.Yes)
                {
                    return $"{(byte)AdapterPlatesAvailability} (по длине нет данных)";
                }
                else
                {
                    return $"{(byte)AdapterPlatesAvailability}";
                }
            }
        }
        #endregion

        /// <summary>
        /// Проектная организация
        /// </summary>
        public Organization ProjectOrganization { get; set; }
        /// <summary>
        /// Строительная организация
        /// </summary>  
        public Organization BuildingOrganization { get; set; }
        /// <summary>
        /// Эксплуатирующая организация
        /// </summary>
        public Organization ExploitOrganization { get; set; }
        ///// <summary>
        ///// Дорожные знаки перед мостовым сооружением
        ///// </summary>
        public string RoadSignsBefore { get; set; }
        ///// <summary>
        ///// Дорожные знаки за мостовым сооружением
        ///// </summary>
        public string RoadSignsAfter { get; set; }
        /// <summary>
        /// Сведения о реконструкциях, ремонтах
        /// </summary>
        public IList<InfoOfRepairs> InfoOfRepairs { get; set; }
        //todo: /// не реализовано место размещения
        /// <summary>
        /// Коммуникации
        /// </summary>
        public Communications Communications { get; set; } = Communications.None;
        //todo: /// не реализовано место размещения
        /// <summary>
        /// Обустройства
        /// </summary>
        public Arrangements Arrangements { get; set; } = Arrangements.None;
        /// <summary>
        /// Дата обследования
        /// </summary>
        public DateTime DateView { get; set; }
        /// <summary>
        /// Примечания
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Опоры
        /// </summary>
        public IList<BridgeSupport> Supports { get; set; }
        /// <summary>
        /// Пролётные строения
        /// </summary>
        public IList<SpanStructure> SpanStructures { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public BridgeStatus Status { get; set; }
        /// <summary>
        /// Геометрия
        /// </summary>
        public FeatureObject FeatureObject { get; set; }

        /// <summary>
        /// Качество мостового сооружения
        /// </summary>
        public Quality QualityBridgeType { get; set; }
        /// <summary>
        /// Тип движения
        /// </summary>
        public MoveType MoveType { get; set; } = MoveType.Car;
        /// <summary>
        /// Номер уровня высоты
        /// </summary>
        public int HeightLevelNumber { get; set; } = 1;
        
        /// <summary>
        /// Дефекты
        /// </summary>
        public IList<Defect> Defects { get; set; }
        /// <summary>
        /// Дефекты
        /// </summary>
        public IList<DocumentationInfo> Documentations { get; set; }

        /// <summary>
        /// Инвертировано ли начало мостового сооружения (false - мост начинается с нулевой точки геометрии, true - с последней)
        /// </summary>
        public bool InversedStartOfBridge { get; set; } = false;
        #endregion

        #region Display Properties
        /// <summary>
        /// Информация о ремонтах для отчёта
        /// </summary>
        public InfoOfRepairs InfoOfRepairsForReport
        {
            get
            {
                if (InfoOfRepairs != null && InfoOfRepairs.Count > 0)
                {
                    //todo: можно оптимизировать
                    return InfoOfRepairs.OrderBy(info => info.Date).Last();
                }
                return null;
            }
        }

        /// <summary>
        /// Тип движения в виде строки
        /// </summary>
        public string MoveTypeAsString
            => MoveTypeStrings.Instance.GetName(MoveType);
        /// <summary>
        /// Коммуникации в виде строки
        /// </summary>
        public string CommunicationsAsString
            => CommunicationsStrings.Instance.GetName(Communications);
        /// <summary>
        /// Обустройства в виде строки
        /// </summary>
        public string ArrangementsAsString
            => ArrangementsStrings.Instance.GetName(Arrangements);
        /// <summary>
        /// Категория дороги в виде строки
        /// </summary>
        public string RoadCategoryAsString
            => RoadCategoryStrings.Instance.GetName(RoadCategory);
        /// <summary>
        /// Расположение в плане в виде строки
        /// </summary>
        public string LocationInPlanAsString
            => LocationInPlanStrings.Instance.GetName(LocationInPlan);
        /// <summary>
        /// Тип тротуара в виде строки
        /// </summary>
        public string SidewalksAsString
            => SidewalkTypeStrings.Instance.GetName(Sidewalks);
        /// <summary>
        /// Тип перил в виде строки
        /// </summary>
        public string RailingsTypeAsString
            => RailingsTypeStrings.Instance.GetName(RailingsType);
        /// <summary>
        /// Регуляционные сооружения в виде строки
        /// </summary>
        public string RegulatoryStructuresAsString
            => RegulatoryStructuresStrings.Instance.GetName(RegulatoryStructures);
        /// <summary>
        /// Укрепление конусов в виде строки
        /// </summary>
        public string ConesStrengtheningAsString
            => StrenghteningStrings.Instance.GetName(ConesStrengthening);
        /// <summary>
        /// Дорожное покрытие в виде строки
        /// </summary>
        public string CoverTypeAsString
            => CoverTypeStrings.Instance.GetName(CoverType);
        /// <summary>
        /// Профиль продольного уклона за мостов в виде строки
        /// </summary>
        public string SlopeLongitudinalProfileAfterAsString
            => SlopeProfileUserStrings.Instance.GetName(SlopeLongitudinalProfileAfter);
        /// <summary>
        /// Профиль продольного уклона перед мостов в виде строки
        /// </summary>
        public string SlopeLongitudinalProfileBeforeAsString
            => SlopeProfileUserStrings.Instance.GetName(SlopeLongitudinalProfileBefore);
        /// <summary>
        /// Тип мостового сооружения в виде строки
        /// </summary>
        public string ConstructionTypeAsString
            => BridgeTypeStrings.Instance.GetName(ConstructionType);
        /// <summary>
        /// Профиль поперечного уклона в виде строки
        /// </summary>
        public string SlopeLateralProfileAsString
            => SlopeProfileUserStrings.Instance.GetName(SlopeLateralProfile);
        /// <summary>
        /// Тип водоотвода в виде строки
        /// </summary>
        public string DrainageTypeAsString
            => DrainageTypeStrings.Instance.GetName(DrainageType);

        /// <summary>
        /// Качество мостового сооружения в виде строки
        /// </summary>
        public string QualityBridgeTypeAsString
            => QualityStrings.Instance.GetName(QualityBridgeType);
        /// <summary>
        /// Статус в виде строки
        /// </summary>
        public string StatusAsString
            => BridgeStatusStrings.Instance.GetName(Status);
        #endregion

        #region Члены IPhotoable
        /// <summary>
        /// Тип
        /// </summary>
        public string PhotoableType 
            => nameof(Bridge);
        /// <summary>
        /// Фотографии мостового сооружения
        /// </summary>
        public IList<Photo> Photos { get; set; }
        #endregion

        public static string GetLongitudeScheme(IList<SpanStructure> spanStructures, float lm)
        {
            if (spanStructures != null && spanStructures.Count > 0)
            {
                var sortedSchemes = spanStructures.OrderBy(st => st.Number)
                    .Select(st => st.LongitudeScheme);
                string res = string.Join("+", sortedSchemes);
                if (lm > 1e-5)
                {
                    res += $"\\Lm = {lm.ToString("F")}";
                }
                return res;
            }
            return "Нет данных";
        }

        public static string GetExpansionJointTypesString(IList<SpanStructure> spanStructures)
        {
            if (spanStructures != null && spanStructures.Count > 0)
            {
                var tmp = spanStructures
                    .Select(st => st.ExpansionJointTypeAsString)
                    .Distinct();
                return string.Join(", ", tmp);
            }
            return "Нет данных";
        }

        /// <summary>
        /// Метод для получения кода сооружения
        /// </summary>
        /// <param name="roadCode"></param>
        /// <param name="isOverTheRoad"></param>
        /// <param name="constructionType"></param>
        /// <param name="kilometer"></param>
        /// <param name="isLeft"></param>
        /// <returns></returns>
        public static string GetCode(int roadCode, bool isOverTheRoad, BridgeType constructionType,
            int kilometer, bool? isLeft)
        {
            StringBuilder sb = new StringBuilder(roadCode.ToString("D4"));
            if (isOverTheRoad && constructionType == BridgeType.Overpass)
            {
                sb.Append("&");
            }
            sb.Append('/');
            sb.Append(((int)Math.Round(kilometer / 1000f)).ToString("D4"));
            if (isLeft.HasValue)
            {
                if (isLeft.Value)
                {
                    sb.Append("-Л");
                }
                else
                {
                    sb.Append("-П");
                }
            }
            return sb.ToString();
        }

        #region Overrides of DomainObject<long>
        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {
            if (T is Bridge obj)
            {
                IsLeft = obj.IsLeft;
                IsOverTheRoad = obj.IsOverTheRoad;
                ConstructionName = obj.ConstructionName;
                ConstructionType = obj.ConstructionType;
                Obstacles = GetCopiedList(obj.Obstacles);
                RoadName = obj.RoadName;
                SubjectCode = obj.SubjectCode;
                TerritorialRoadControlCode = obj.TerritorialRoadControlCode;
                RoadCode = obj.RoadCode;
                Kilometer = obj.Kilometer;
                Territory = obj.Territory;
                RoadCategory = obj.RoadCategory;
                QuantityLineBridge = obj.QuantityLineBridge;
                QuantityLineApproach = obj.QuantityLineApproach;
                Markup = obj.Markup;
                NearestVillage = obj.NearestVillage;
                DistanceToVillage = obj.DistanceToVillage;
                CharactObstacleB = obj.CharactObstacleB;
                CharactObstacleH = obj.CharactObstacleH;
                CharactObstacleV = obj.CharactObstacleV;
                CharactObstacleDirectionOfFlow = obj.CharactObstacleDirectionOfFlow;
                Length = obj.Length;
                Hole = obj.Hole;
                HeightDimension = obj.HeightDimension;
                WidthDimensionB = obj.WidthDimensionB;
                WidthDimensionT1 = obj.WidthDimensionT1;
                WidthDimensionT2 = obj.WidthDimensionT2;
                WidthDimensionC = obj.WidthDimensionC;
                WidthDimensionC1 = obj.WidthDimensionC1;
                WidthDimensionC2 = obj.WidthDimensionC2;
                WidthDimensionBrivewayCount = obj.WidthDimensionBrivewayCount;
                WidthDimensionG = obj.WidthDimensionG;
                ConstructionDate = obj.ConstructionDate;
                RepairsDate = obj.RepairsDate;
                DesignBurden = obj.DesignBurden;
                ObliqueAngle = obj.ObliqueAngle;
                LocationInPlan = obj.LocationInPlan;
                SlopeLateral = obj.SlopeLateral;
                SlopeLateralProfile = obj.SlopeLateralProfile;
                CoverType = obj.CoverType;
                DrainageType = obj.DrainageType;
                ProtectionOnBridge = obj.ProtectionOnBridge;
                ProtectionOnApproach = obj.ProtectionOnApproach;
                Sidewalks = obj.Sidewalks;
                RailingsType = obj.RailingsType;
                RailingsHeight = obj.RailingsHeight;
                CarriagewayWidthBefore = obj.CarriagewayWidthBefore;
                SlopeLongitudinalBefore = obj.SlopeLongitudinalBefore;
                SlopeLongitudinalProfileBefore = obj.SlopeLongitudinalProfileBefore;
                EmbankmentHeightBefore = obj.EmbankmentHeightBefore;
                CarriagewayWidthAfter = obj.CarriagewayWidthAfter;
                SlopeLongitudinalAfter = obj.SlopeLongitudinalAfter;
                SlopeLongitudinalProfileAfter = obj.SlopeLongitudinalProfileAfter;
                EmbankmentHeightAfter = obj.EmbankmentHeightAfter;
                RegulatoryStructures = obj.RegulatoryStructures;
                ConesStrengthening = obj.ConesStrengthening;
                AdapterPlatesAvailability = obj.AdapterPlatesAvailability;
                AdapterPlatesLength = obj.AdapterPlatesLength;
                ProjectOrganization = obj.ProjectOrganization;
                BuildingOrganization = obj.BuildingOrganization;
                ExploitOrganization = obj.ExploitOrganization;
                RoadSignsBefore = obj.RoadSignsBefore;
                RoadSignsAfter = obj.RoadSignsAfter;
                InfoOfRepairs = GetCopiedList(obj.InfoOfRepairs);
                Communications = obj.Communications;
                Arrangements = obj.Arrangements;
                DateView = obj.DateView;
                Notes = obj.Notes;
                Supports = GetCopiedList(obj.Supports);
                SpanStructures = GetCopiedList(obj.SpanStructures);
                Status = obj.Status;
                QualityBridgeType = obj.QualityBridgeType;
                MoveType = obj.MoveType;
                HeightLevelNumber = obj.HeightLevelNumber;
                Defects = GetCopiedList(obj.Defects);
                InversedStartOfBridge = obj.InversedStartOfBridge;
                CharactObstacleAddInfo = obj.CharactObstacleAddInfo;
            }
        }

        /// <summary>
        /// Получает глубокую копию IList of <typeparamref name="T"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        protected List<T> GetCopiedList<T>(IList<T> list)
            where T : DomainObject<long>, IBridgeReferenceable, new()
        {
            var res = new List<T>(list.Count);
            foreach (var item in list)
            {
                var tmp = new T();
                tmp.CopyFrom(item);
                tmp.Bridge = this;
                res.Add(tmp);
            }
            return res;
        }

        /// <summary>
		/// Играет роль хэш-функции для определенного типа.
		/// </summary>
		/// <returns>
		/// Хэш-код для текущего объекта <see cref="T:System.Object"/>.
		/// </returns>
		/// <filterpriority>2</filterpriority>
		public override int GetHashCode()
        {
            var hashCode = 1207920698;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ConstructionName);
            hashCode = hashCode * -1521134295 + ConstructionType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<BridgeObstacle>>.Default.GetHashCode(Obstacles);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RoadName);
            hashCode = hashCode * -1521134295 + SubjectCode.GetHashCode();
            hashCode = hashCode * -1521134295 + TerritorialRoadControlCode.GetHashCode();
            hashCode = hashCode * -1521134295 + RoadCode.GetHashCode();
            hashCode = hashCode * -1521134295 + Kilometer.GetHashCode();
            hashCode = hashCode * -1521134295 + RoadCategory.GetHashCode();
            hashCode = hashCode * -1521134295 + QuantityLineBridge.GetHashCode();
            hashCode = hashCode * -1521134295 + QuantityLineApproach.GetHashCode();
            hashCode = hashCode * -1521134295 + Markup.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(NearestVillage);
            hashCode = hashCode * -1521134295 + DistanceToVillage.GetHashCode();
            hashCode = hashCode * -1521134295 + CharactObstacleB.GetHashCode();
            hashCode = hashCode * -1521134295 + CharactObstacleH.GetHashCode();
            hashCode = hashCode * -1521134295 + CharactObstacleV.GetHashCode();
            hashCode = hashCode * -1521134295 + CharactObstacleDirectionOfFlow.GetHashCode();
            hashCode = hashCode * -1521134295 + UnderbridgeClearance.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + Hole.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(HeightDimension);
            hashCode = hashCode * -1521134295 + WidthDimensionB.GetHashCode();
            hashCode = hashCode * -1521134295 + WidthDimensionT1.GetHashCode();
            hashCode = hashCode * -1521134295 + WidthDimensionT2.GetHashCode();
            hashCode = hashCode * -1521134295 + WidthDimensionC.GetHashCode();
            hashCode = hashCode * -1521134295 + WidthDimensionC1.GetHashCode();
            hashCode = hashCode * -1521134295 + WidthDimensionC2.GetHashCode();
            hashCode = hashCode * -1521134295 + WidthDimensionBrivewayCount.GetHashCode();
            hashCode = hashCode * -1521134295 + WidthDimensionG.GetHashCode();
            hashCode = hashCode * -1521134295 + ConstructionDate.GetHashCode();
            hashCode = hashCode * -1521134295 + ReconstructionDate.GetHashCode();
            hashCode = hashCode * -1521134295 + RepairsDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DesignBurden);
            hashCode = hashCode * -1521134295 + ObliqueAngle.GetHashCode();
            hashCode = hashCode * -1521134295 + LocationInPlan.GetHashCode();
            hashCode = hashCode * -1521134295 + SlopeLateral.GetHashCode();
            hashCode = hashCode * -1521134295 + SlopeLateralProfile.GetHashCode();
            hashCode = hashCode * -1521134295 + CoverType.GetHashCode();
            hashCode = hashCode * -1521134295 + DrainageType.GetHashCode();
            hashCode = hashCode * -1521134295 + ExpansionJointsTypes.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Protection>.Default.GetHashCode(ProtectionOnBridge);
            hashCode = hashCode * -1521134295 + EqualityComparer<Protection>.Default.GetHashCode(ProtectionOnApproach);
            hashCode = hashCode * -1521134295 + Sidewalks.GetHashCode();
            hashCode = hashCode * -1521134295 + RailingsType.GetHashCode();
            hashCode = hashCode * -1521134295 + RailingsHeight.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(RailingsUserAsString);
            hashCode = hashCode * -1521134295 + CarriagewayWidthBefore.GetHashCode();
            hashCode = hashCode * -1521134295 + SlopeLongitudinalBefore.GetHashCode();
            hashCode = hashCode * -1521134295 + SlopeLongitudinalProfileBefore.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SlopeLongitudinalBeforeAsString);
            hashCode = hashCode * -1521134295 + EmbankmentHeightBefore.GetHashCode();
            hashCode = hashCode * -1521134295 + CarriagewayWidthAfter.GetHashCode();
            hashCode = hashCode * -1521134295 + SlopeLongitudinalAfter.GetHashCode();
            hashCode = hashCode * -1521134295 + SlopeLongitudinalProfileAfter.GetHashCode();
            hashCode = hashCode * -1521134295 + EmbankmentHeightAfter.GetHashCode();
            hashCode = hashCode * -1521134295 + RegulatoryStructures.GetHashCode();
            hashCode = hashCode * -1521134295 + ConesStrengthening.GetHashCode();
            hashCode = hashCode * -1521134295 + AdapterPlatesAvailability.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(AdapterPlatesLength);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AdapterPlatesAsString);
            hashCode = hashCode * -1521134295 + EqualityComparer<Organization>.Default.GetHashCode(ProjectOrganization);
            hashCode = hashCode * -1521134295 + EqualityComparer<Organization>.Default.GetHashCode(BuildingOrganization);
            hashCode = hashCode * -1521134295 + EqualityComparer<Organization>.Default.GetHashCode(ExploitOrganization);
            hashCode = hashCode * -1521134295 + RoadSignsBefore.GetHashCode();
            hashCode = hashCode * -1521134295 + RoadSignsAfter.GetHashCode();
            if (InfoOfRepairs != null)
            {
                hashCode = hashCode * -1521134295 + InfoOfRepairs.GetHashCode();
            }
            hashCode = hashCode * -1521134295 + Communications.GetHashCode();
            hashCode = hashCode * -1521134295 + Arrangements.GetHashCode();
            hashCode = hashCode * -1521134295 + DateView.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<BridgeSupport>>.Default.GetHashCode(Supports);
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<SpanStructure>>.Default.GetHashCode(SpanStructures);
            hashCode = hashCode * -1521134295 + Status.GetHashCode();
            hashCode = hashCode * -1521134295 + QualityBridgeType.GetHashCode();
            hashCode = hashCode * -1521134295 + MoveType.GetHashCode();
            hashCode = hashCode * -1521134295 + HeightLevelNumber.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<IList<Defect>>.Default.GetHashCode(Defects);
            hashCode = hashCode * -1521134295 + InversedStartOfBridge.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CharactObstacleAddInfo);
            return hashCode;
        }

        public string GetShortDescription()
        {
            if (!string.IsNullOrEmpty(BridgeCode))
            {
                return $"{ConstructionAsString} ({BridgeCode})";
            }
            return $"{ConstructionAsString}";
        }

        public override string ToString()
        {
            return $"{ConstructionAsString}, Код сооружения:{BridgeCode} Расширенный код дороги:{ExpandedRoadCode}, Дата постройки:{ConstructionDate}";
        }
        #endregion
    }
}