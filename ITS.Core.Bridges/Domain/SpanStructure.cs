using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.Helpers;
using ITS.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITS.Core.Bridges.Domain
{
    /// <summary>
    /// Пролётное строение
    /// </summary>
    [Serializable]
#pragma warning disable CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
    public class SpanStructure : DomainObject<long>, INumberable, IEquatable<SpanStructure>, IBridgeReferenceable
#pragma warning restore CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
    {
        public SpanStructure()
        {

        }

        /// <summary>
        /// Порядковый номер пролётного строения
        /// </summary>
        public int Number { get; set; }
        /// <summary>
        /// Статическая система пролётного строения
        /// </summary>
        public SpanStructureSystem System { get; set; }
        /// <summary>
        /// Тип пролётного строения
        /// </summary>
        public SpanStructureType SpanStructureType { get; set; }
        /// <summary>
        /// Конструкция проезжей части
        /// </summary>
        public ConstructionRoadway ConstructionRoadway { get; set; }
        /// <summary>
        /// Материал главных балок
        /// </summary>
        public Material Material { get; set; }
        /// <summary>
        /// Тип стыков
        /// </summary>
        public JointType JointType { get; set; }
        /// <summary>
        /// Продольная схема
        /// </summary>
        public string LongitudeScheme { get; set; } = "0";
        /// <summary>
        /// Габарит по ширине
        /// </summary>
        public string WidthDimensionAsString =>
            Bridge?.WidthDimensionAsString;
        /// <summary>
        /// Дата изготовления
        /// </summary>
        public DateTime ConstructionDate { get; set; }
        /// <summary>
        /// Проектные нагрузки
        /// </summary>
        public string DesignBurdens
        {
            get
            {
                if (Bridge != null && !string.IsNullOrEmpty(Bridge.DesignBurden))
                {
                    return Bridge.DesignBurden;
                }
                return "Нет данных";
            }
        }
        /// <summary>
        /// Номер типового проекта
        /// </summary>
        public TypicalProject TypicalProject { get; set; }
        /// <summary>
        /// Типы опорных частей подвижные
        /// </summary>
        public BridgeMovablePartSupport SpanTypeMovable { get; set; }
        /// <summary>
        /// Типы опорных частей неподвижные
        /// </summary>
        public BridgeMotionlessPartSupport SpanTypeMotionless { get; set; }
        /// <summary>
        /// Деформационные швы
        /// </summary>
        public ExpansionJointType ExpansionJointType { get; set; }
        /// <summary>
        /// Дополнительная информация про деформационные швы
        /// </summary>
        public string ExpansionJointAddInfo { get; set; }
        /// <summary>
        /// Cпособ поперечного объединения
        /// </summary>
        public CrossJoinMethod CrossJoin { get; set; }

        #region Поперечная схема
        /// <summary>
        /// Длина левой консоли
        /// </summary>
        public float CrossSchemeKa { get; set; }
        /// <summary>
        /// Длина правой консоли
        /// </summary>
        public float CrossSchemeKb { get; set; }
        /// <summary>
        /// Расстояния между соседними главными несущими конструкциями
        /// </summary>
        public float[] CrossSchemePileDistances { get; set; }
        /// <summary>
        /// Поперечная схема
        /// </summary>
        public string CrossScheme
        {
            get
            {
                if (CrossSchemePileDistances == null)
                {
                    return "";
                }
                StringBuilder stringBuilder = new StringBuilder();
                if (CrossSchemePileDistances.Length == 1)
                {
                    if (CrossSchemeKa > 1e-5)
                    {
                        stringBuilder.Append($"К{CrossSchemeKa.ToString("F")}+");
                    }
                    stringBuilder.Append($"{CrossSchemePileDistances.Average().ToString("F")}");
                    if (CrossSchemeKb > 1e-5)
                    {
                        stringBuilder.Append($"+К{CrossSchemeKb.ToString("F")}");
                    }
                }
                else if (CrossSchemePileDistances.Max() - CrossSchemePileDistances.Min()
                    <= 0.1)
                {
                    if (CrossSchemeKa > 1e-5)
                    {
                        stringBuilder.Append($"К{CrossSchemeKa.ToString("F")}+");
                    }
                    stringBuilder.Append($"{CrossSchemePileDistances.Average().ToString("F")}x{CrossSchemePileDistances.Length}");
                    if (CrossSchemeKb > 1e-5)
                    {
                        stringBuilder.Append($"+К{CrossSchemeKb.ToString("F")}");
                    }
                }
                else
                {
                    if (CrossSchemeKa > 1e-5)
                    {
                        stringBuilder.Append($"К{CrossSchemeKa.ToString("F")}+");
                    }
                    for (int i = 0; i < CrossSchemePileDistances.Length; i++)
                    {
                        if (i==0)
                            stringBuilder.Append($"{CrossSchemePileDistances[i].ToString("F")}");
                        else
                            stringBuilder.Append($"+{CrossSchemePileDistances[i].ToString("F")}");
                    }
                    if (CrossSchemeKb > 1e-5)
                    {
                        stringBuilder.Append($"+К{CrossSchemeKb.ToString("F")}");
                    }
                }
                return stringBuilder.ToString();
            }
        }
        #endregion

        #region Плита проезжей части
        /// <summary>
        /// Толщина плиты проезжей части
        /// </summary>
        public float PlateThickness { get; set; }
        /// <summary>
        /// Материал плиты проезжей части
        /// </summary>
        public Material PlateMaterial { get; set; }
        #endregion

        #region Одежда ездового полотна
        /// <summary>
        /// Полная толщина
        /// </summary>
        public float RoadwayClothingThickness { get; set; }
        /// <summary>
        /// Толщина лишнего слоя
        /// </summary>
        public float? RoadwayClothingAddLayerThickness { get; set; }
        /// <summary>
        /// Вес лишнего слоя
        /// </summary>
        public float? RoadwayClothingAddLayerWeight { get; set; }
        /// <summary>
        /// Материал покрытия
        /// </summary>
        public string CoverTypeAsString =>
            Bridge?.CoverTypeAsString;
        #endregion

        /// <summary>
        /// Число главных балок
        /// </summary>
        public int MainPileCount { get; set; }

        #region Главная балка
        //todo: не соответствует диагностике мостов
        public float MainPileHeightSpan { get; set; }
        public float MainPileHeightSupport { get; set; }
        public float MainPileThicknessEdge { get; set; }
        #endregion

        /// <summary>
        /// Поперечная балка
        /// </summary>
        public SpanBeam CrossPile { get; set; }
        /// <summary>
        /// Продольная балка
        /// </summary>
        public SpanBeam LongitudinalPile { get; set; }
        /// <summary>
        /// Дополнительная погонная нагрузка, Н/м
        /// </summary>
        public float AdditionalLinearLoad { get; set; }
        /// <summary>
        /// Примечания
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Подмостовой габарит этого пролётного строения
        /// </summary>
        public float UnderbridgeClearance { get; set; }

        #region Продольный уклон
        /// <summary>
        /// Уклон продольный, %
        /// </summary>
        public float SlopeLongitudinal { get; set; }
        /// <summary>
        /// Профиль продольного уклона
        /// </summary>
        public SlopeProfile SlopeLongitudinalProfile { get; set; }
        /// <summary>
        /// Уклон продольный в виде строки для паспорта
        /// </summary>
        public string SlopeLongitudinalForReport
        {
            get
            {
                if (SlopeLongitudinal < 1e-5)
                {
                    return "Нет данных";
                }
                return $"{SlopeProfileStrings.Instance.GetName(SlopeLongitudinalProfile)}{SlopeLongitudinal.ToString("F")}%";
            }
        }
        #endregion

        /// <summary>
        /// Мост, к которому относится это пролётное строение
        /// </summary>
        public Bridge Bridge { get; set; }

        public string SystemAsString
            => SpanStructureSystemStrings.Instance.GetName(System);
        public string SpanStructureTypeAsString
            => SpanStructureTypeStrings.Instance.GetName(SpanStructureType);
        public string ConstructionRoadwayAsString
            => ConstructionRoadwayStrings.Instance.GetName(ConstructionRoadway);
        public string JointTypeAsString
            => JointTypeStrings.Instance.GetName(JointType);
        public string SpanTypeMovableAsString
            => BridgeMovablePartSupportStrings.Instance.GetName(SpanTypeMovable);
        public string SpanTypeMotionlessAsString
            => BridgeMotionlessPartSupportStrings.Instance.GetName(SpanTypeMotionless);
        public string ExpansionJointTypeAsString
            => ExpansionJointTypeStrings.Instance.GetName(ExpansionJointType);
        public string CrossJoinAsString
            => CrossJoinMethodStrings.Instance.GetName(CrossJoin);
        public string SlopeLongitudinalProfileAsString
            => SlopeProfileUserStrings.Instance.GetName(SlopeLongitudinalProfile);


        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {
            if (T is SpanStructure sp)
            {
                Number = sp.Number;
                System = sp.System;
                SpanStructureType = sp.SpanStructureType;
                ConstructionRoadway = sp.ConstructionRoadway;
                Material = sp.Material;
                JointType = sp.JointType;
                LongitudeScheme = sp.LongitudeScheme;
                ConstructionDate = sp.ConstructionDate;
                TypicalProject = sp.TypicalProject;
                SpanTypeMovable = sp.SpanTypeMovable;
                SpanTypeMotionless = sp.SpanTypeMotionless;
                ExpansionJointType = sp.ExpansionJointType;
                CrossJoin = sp.CrossJoin;
                CrossSchemeKa = sp.CrossSchemeKa;
                CrossSchemeKb = sp.CrossSchemeKb;
                CrossSchemePileDistances = sp.CrossSchemePileDistances;
                PlateThickness = sp.PlateThickness;
                PlateMaterial = sp.PlateMaterial;
                RoadwayClothingThickness = sp.RoadwayClothingThickness;
                RoadwayClothingAddLayerThickness = sp.RoadwayClothingAddLayerThickness;
                RoadwayClothingAddLayerWeight = sp.RoadwayClothingAddLayerWeight;
                MainPileCount = sp.MainPileCount;
                MainPileHeightSpan = sp.MainPileHeightSpan;
                MainPileHeightSupport = sp.MainPileHeightSupport;
                MainPileThicknessEdge = sp.MainPileThicknessEdge;
                CrossPile = sp.CrossPile;
                LongitudinalPile = sp.LongitudinalPile;
                AdditionalLinearLoad = sp.AdditionalLinearLoad;
                Notes = sp.Notes;
                UnderbridgeClearance = sp.UnderbridgeClearance;
                SlopeLongitudinal = sp.SlopeLongitudinal;
                SlopeLongitudinalProfile = sp.SlopeLongitudinalProfile;
                Bridge = sp.Bridge;
            }
        }

        /// <summary>
        /// Сравнение без учёта номера, ID
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator ==(SpanStructure obj1, SpanStructure obj2)
        {
            return (obj1 is null && obj2 is null) ||
                (!(obj1 is null) && !(obj2 is null) &&
            obj1.System == obj2.System &&
            obj1.SpanStructureType == obj2.SpanStructureType &&
            obj1.ConstructionRoadway == obj2.ConstructionRoadway &&
            EqualityComparer<Material>.Default.Equals(obj1.Material, obj2.Material) &&
            obj1.JointType == obj2.JointType &&
            obj1.LongitudeScheme == obj2.LongitudeScheme &&
            obj1.ConstructionDate == obj2.ConstructionDate &&
            EqualityComparer<TypicalProject>.Default.Equals(obj1.TypicalProject, obj2.TypicalProject) &&
            obj1.SpanTypeMovable == obj2.SpanTypeMovable &&
            obj1.SpanTypeMotionless == obj2.SpanTypeMotionless &&
            obj1.ExpansionJointType == obj2.ExpansionJointType &&
            obj1.CrossJoin == obj2.CrossJoin &&
            obj1.CrossSchemeKa - obj2.CrossSchemeKa < 1e-5 &&
            obj1.CrossSchemeKb - obj2.CrossSchemeKb < 1e-5 &&
            CompareHelper.Compare(obj1.CrossSchemePileDistances, obj2.CrossSchemePileDistances) &&
            obj1.PlateThickness - obj2.PlateThickness < 1e-5 &&
            EqualityComparer<Material>.Default.Equals(obj1.PlateMaterial, obj2.PlateMaterial) &&
            obj1.RoadwayClothingThickness - obj2.RoadwayClothingThickness < 1e-5 &&
            EqualityComparer<float?>.Default.Equals(obj1.RoadwayClothingAddLayerThickness, obj2.RoadwayClothingAddLayerThickness) &&
            EqualityComparer<float?>.Default.Equals(obj1.RoadwayClothingAddLayerWeight, obj2.RoadwayClothingAddLayerWeight) &&
            obj1.MainPileCount == obj2.MainPileCount &&
            obj1.MainPileHeightSpan - obj2.MainPileHeightSpan < 1e-5 &&
            obj1.MainPileHeightSupport - obj2.MainPileHeightSupport < 1e-5 &&
            obj1.MainPileThicknessEdge - obj2.MainPileThicknessEdge < 1e-5 &&
            EqualityComparer<SpanBeam>.Default.Equals(obj1.CrossPile, obj2.CrossPile) &&
            EqualityComparer<SpanBeam>.Default.Equals(obj1.LongitudinalPile, obj2.LongitudinalPile) &&
            obj1.AdditionalLinearLoad - obj2.AdditionalLinearLoad < 1e-5 &&
            obj1.Notes == obj2.Notes &&
            obj1.UnderbridgeClearance - obj2.UnderbridgeClearance < 1e-5 &&
            obj1.SlopeLongitudinal - obj2.SlopeLongitudinal < 1e-5 &&
            obj1.SlopeLongitudinalProfile == obj2.SlopeLongitudinalProfile);
        }
        /// <summary>
        /// Сравнение без учёта номера, ID
        /// </summary>
        /// <param name="obj1"></param>
        /// <param name="obj2"></param>
        /// <returns></returns>
        public static bool operator !=(SpanStructure obj1, SpanStructure obj2)
        {
            return !(obj1 == obj2);
        }

        public override string ToString()
        {
            return $"Номер:{Number}, Система:{SystemAsString}, Тип:{SpanStructureTypeAsString}";
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
            var hashCode = -2038600695;
            hashCode = hashCode * -1521134295 + System.GetHashCode();
            hashCode = hashCode * -1521134295 + SpanStructureType.GetHashCode();
            hashCode = hashCode * -1521134295 + ConstructionRoadway.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Material>.Default.GetHashCode(Material);
            hashCode = hashCode * -1521134295 + JointType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LongitudeScheme);
            hashCode = hashCode * -1521134295 + ConstructionDate.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<TypicalProject>.Default.GetHashCode(TypicalProject);
            hashCode = hashCode * -1521134295 + SpanTypeMovable.GetHashCode();
            hashCode = hashCode * -1521134295 + SpanTypeMotionless.GetHashCode();
            hashCode = hashCode * -1521134295 + ExpansionJointType.GetHashCode();
            hashCode = hashCode * -1521134295 + CrossJoin.GetHashCode();
            hashCode = hashCode * -1521134295 + CrossSchemeKa.GetHashCode();
            hashCode = hashCode * -1521134295 + CrossSchemeKb.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<float[]>.Default.GetHashCode(CrossSchemePileDistances);
            hashCode = hashCode * -1521134295 + PlateThickness.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Material>.Default.GetHashCode(PlateMaterial);
            hashCode = hashCode * -1521134295 + RoadwayClothingThickness.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(RoadwayClothingAddLayerThickness);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(RoadwayClothingAddLayerWeight);
            hashCode = hashCode * -1521134295 + MainPileCount.GetHashCode();
            hashCode = hashCode * -1521134295 + MainPileHeightSpan.GetHashCode();
            hashCode = hashCode * -1521134295 + MainPileHeightSupport.GetHashCode();
            hashCode = hashCode * -1521134295 + MainPileThicknessEdge.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<SpanBeam>.Default.GetHashCode(CrossPile);
            hashCode = hashCode * -1521134295 + EqualityComparer<SpanBeam>.Default.GetHashCode(LongitudinalPile);
            hashCode = hashCode * -1521134295 + AdditionalLinearLoad.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            hashCode = hashCode * -1521134295 + UnderbridgeClearance.GetHashCode();
            hashCode = hashCode * -1521134295 + SlopeLongitudinal.GetHashCode();
            hashCode = hashCode * -1521134295 + SlopeLongitudinalProfile.GetHashCode();
            return hashCode;
        }

        public bool Equals(SpanStructure other)
        {
            return this == other;
        }
    }
}
