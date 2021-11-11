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
    /// Опора моста
    /// </summary>
    [Serializable]
#pragma warning disable CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
    public class BridgeSupport : DomainObject<long>, INumberable, IEquatable<BridgeSupport>, IBridgeReferenceable
#pragma warning restore CS0660 // Тип определяет оператор == или оператор !=, но не переопределяет Object.Equals(object o)
    {
        /// <summary>
        /// Порядковый номер опоры
        /// </summary>
        public int Number { get; set; }
        #region Тип опоры
        /// <summary>
        /// Является ли опора береговой (true - береговая, false - промежуточная)
        /// </summary>
        public bool IsShore { get; set; }
        /// <summary>
        /// Тип береговой опоры
        /// </summary>
        public ShoreSupportType ShoreType { get; set; }
        /// <summary>
        /// Тип промежуточной опоры
        /// </summary>
        public IntermediateSupportType IntermediateType { get; set; }
        /// <summary>
        /// Дополнительная информация по конструкции опоры
        /// </summary>
        public string SupportTypeAdditionalInfo { get; set; }
        #endregion

        /// <summary>
        /// Тип фундамента
        /// </summary>
        public FoundationType FoundationType { get; set; }
        /// <summary>
        /// Материал надфундаментной части опоры
        /// </summary>
        public Material Material { get; set; }

        #region Высота опоры
        /// <summary>
        /// Высоты опор
        /// </summary>
        public float[] Heights { get; set; }
        /// <summary>
        /// Высоты опор в виде строки
        /// </summary>
        public string HeightsAsString
        {
            get
            {
                if (Heights != null && Heights.Length > 0)
                {
                    var heigths = Heights.Select(h => h.ToString("F"));
                    return string.Join("; ", heigths);
                }
                return "Нет данных";
            }
        }
        #endregion

        /// <summary>
        /// Глубина заложения фундамента
        /// </summary>
        public float LayingDepth { get; set; }
        /// <summary>
        /// Типовой проект
        /// </summary>
        public TypicalProject TypicalProject { get; set; }

        #region Размеры массивной части опоры
        /// <summary>
        /// Длина вдоль сооружения
        /// </summary>
        public float? MassivePartSizeAlong { get; set; }
        /// <summary>
        /// Ширина поперёк сооружения
        /// </summary>
        public float? MassivePartSizeAcross { get; set; }
        /// <summary>
        /// Размеры массивной части опоры в виде строки
        /// </summary>
        public string MassivePartAsString
        {
            get
            {
                if (MassivePartSizeAlong == null && MassivePartSizeAcross == null)
                    return "Нет данных";
                else if (MassivePartSizeAlong == null || MassivePartSizeAcross == null)
                    return "(Д)";
                else
                    return $"{MassivePartSizeAlong.Value.ToString("F")}x{MassivePartSizeAcross.Value.ToString("F")}";
            }
        }
        #endregion

        /// <summary>
        /// Количество свай (стоек, столбов)
        /// </summary>
        public int PileCount { get; set; }
        /// <summary>
        /// Максимальное расстояние между смежными осями
        /// </summary>
        public float MaxDistanceBetweenAxis
        {
            get
            {
                if (SchemePileDistances != null)
                {
                    if (SchemePileDistances.Length > 1)
                        return SchemePileDistances.Max();
                    else if (SchemePileDistances.Length > 0)
                        return SchemePileDistances[0];
                }
                return 0;
            }
        }

        #region Схема опоры
        /// <summary>
        /// Длина левой консоли
        /// </summary>
        public float SchemeKLeft { get; set; }
        /// <summary>
        /// Длина правой консоли
        /// </summary>
        public float SchemeKRight { get; set; }
        /// <summary>
        /// Расстояния по осям между стойками
        /// </summary>
        public float[] SchemePileDistances { get; set; }
        /// <summary>
        /// Расстояния по осям между стойками в виде строки
        /// </summary>
        public string SchemePileDistancesAsString
        {
            get
            {
                if (SchemePileDistances != null && SchemePileDistances.Length > 0)
                {
                    var distances = SchemePileDistances.Select(d => d.ToString("F"));
                    return string.Join("; ", distances);
                }
                return "Нет данных";
            }
        }
        /// <summary>
        /// Расстояние по осям между первым и вторым рядом стоек слева направо
        /// </summary>
        public float? SchemePileRowDistance1 { get; set; }
        /// <summary>
        /// Расстояние по осям между вторым и третьим рядом стоек слева направо
        /// </summary>
        public float? SchemePileRowDistance2 { get; set; }
        /// <summary>
        /// Схема опоры
        /// </summary>
        public string Scheme
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (SchemePileRowDistance1 != null)
                {
                    sb.Append("{");
                    sb.Append(SchemePileRowDistance1.Value.ToString("F"));
                    if (SchemePileRowDistance2 != null)
                    {
                        sb.Append("+");
                        sb.Append(SchemePileRowDistance2.Value.ToString("F"));
                    }
                    sb.Append("}(");
                }
                if (SchemePileDistances != null && SchemePileDistances.Length > 0)
                {
                    if (SchemePileDistances.Max() - SchemePileDistances.Min() <= 0.1)
                    {
                        sb.Append($"К{SchemeKLeft.ToString("F")}+{SchemePileDistances.Average().ToString("F")}"
                            + $"x{SchemePileDistances.Length}+К{SchemeKRight.ToString("F")}");
                    }
                    else
                    {
                        sb.Append($"К{SchemeKLeft.ToString("F")}");
                        foreach (var distance in SchemePileDistances)
                        {
                            sb.Append($"+{distance.ToString("F")}");
                        }
                        sb.Append($"+К{SchemeKRight.ToString("F")}");
                    }
                }
                if (SchemePileRowDistance1 != null)
                {
                    sb.Append(")");
                }
                return sb.ToString();
            }
        }
        #endregion

        #region Сечение и длина ригеля
        /// <summary>
        /// Ширина (размер вдоль мостового сооружения) ригеля
        /// </summary>
        public float CrossbarWidth { get; set; }
        /// <summary>
        /// Высота ригеля
        /// </summary>
        public float CrossbarHeight { get; set; }
        /// <summary>
        /// Длина ригеля
        /// </summary>
        public float CrossbarLength { get; set; }
        #endregion

        #region Сечение сваи
        /// <summary>
        /// Размер вдоль мостового сооружения
        /// </summary>
        public float PileCrossSectionWidth { get; set; }
        /// <summary>
        /// Размер поперек мостового сооружения, если null, то ширина считается диаметром
        /// </summary>
        public float? PileCrossSectionHeight { get; set; }
        /// <summary>
        /// Сечение сваи в виде строки
        /// </summary>
        public string PileCrossSection
            => PileCrossSectionHeight == null ?
            //\u2300 = ⌀, \u00D8 = Ø(не отображается в отчёте правильно)
            $"⌀{PileCrossSectionWidth}" :
            $"{PileCrossSectionWidth}x{PileCrossSectionHeight}";
        #endregion

        /// <summary>
        /// Примечания (сведения о конструктивных особенностях опор, которые не отражены в других свойствах)
        /// </summary>
        public string Notes { get; set; }
        /// <summary>
        /// Мост, к которому относится опора
        /// </summary>
        public Bridge Bridge { get; set; }

        /// <summary>
        /// Тип фундамента в виде строки
        /// </summary>
        public string FoundationTypeAsString =>
            FoundationTypeStrings.Instance.GetName(FoundationType);
        /// <summary>
        /// Тип береговой опоры в виде строки
        /// </summary>
        public string ShoreSupportTypeAsString =>
            ShoreSupportTypeStrings.Instance.GetName(ShoreType);
        /// <summary>
        /// Тип промежуточной опоры в виде строки
        /// </summary>
        public string IntermediateSupportTypeAsString =>
            IntermediateSupportTypeStrings.Instance.GetName(IntermediateType);

        public BridgeSupport()
        {

        }
        /// <summary>
        /// Сравнение без учёта номера, ID
        /// </summary>
        /// <param name="supp1">Первая опора</param>
        /// <param name="supp2">Вторая опора</param>
        /// <returns></returns>
        public static bool operator ==(BridgeSupport supp1, BridgeSupport supp2)
        {
            return (supp1 is null && supp2 is null) ||
                (!(supp1 is null) && !(supp2 is null) &&
            supp1.IsShore == supp2.IsShore &&
            //сравнение только нужного типа
            (supp1.IsShore ? 
            supp1.ShoreType == supp2.ShoreType :
            supp1.IntermediateType == supp2.IntermediateType) &&
            supp1.SupportTypeAdditionalInfo == supp2.SupportTypeAdditionalInfo &&
            supp1.FoundationType == supp2.FoundationType &&
            EqualityComparer<Material>.Default.Equals(supp1.Material, supp2.Material) &&
            CompareHelper.Compare(supp1.Heights, supp2.Heights) &&
            supp1.LayingDepth == supp2.LayingDepth &&
            EqualityComparer<TypicalProject>.Default.Equals(supp1.TypicalProject, supp2.TypicalProject) &&
            EqualityComparer<float?>.Default.Equals(supp1.MassivePartSizeAlong, supp2.MassivePartSizeAlong) &&
            EqualityComparer<float?>.Default.Equals(supp1.MassivePartSizeAcross, supp2.MassivePartSizeAcross) &&
            supp1.PileCount == supp2.PileCount &&
            supp1.SchemeKLeft == supp2.SchemeKLeft &&
            supp1.SchemeKRight == supp2.SchemeKRight &&
            CompareHelper.Compare(supp1.SchemePileDistances, supp2.SchemePileDistances) &&
            EqualityComparer<float?>.Default.Equals(supp1.SchemePileRowDistance1, supp2.SchemePileRowDistance1) &&
            EqualityComparer<float?>.Default.Equals(supp1.SchemePileRowDistance2, supp2.SchemePileRowDistance2) &&
            supp1.CrossbarWidth == supp2.CrossbarWidth &&
            supp1.CrossbarHeight == supp2.CrossbarHeight &&
            supp1.CrossbarLength == supp2.CrossbarLength &&
            supp1.PileCrossSectionWidth == supp2.PileCrossSectionWidth &&
            EqualityComparer<float?>.Default.Equals(supp1.PileCrossSectionHeight, supp2.PileCrossSectionHeight) &&
            supp1.Notes == supp2.Notes);
        }
        /// <summary>
        /// Сравнение без учёта номера, ID
        /// </summary>
        /// <param name="supp1"></param>
        /// <param name="supp2"></param>
        /// <returns></returns>
        public static bool operator !=(BridgeSupport supp1, BridgeSupport supp2)
        {
            //медленно
            return !(supp1 == supp2);
            //есть возможность для оптимизации, поставить часто отличающиеся свойства в начало
        }

        /// <summary>
		/// Копирование в текущий объект из объекта <paramref name="T"/>.
		/// </summary>
		/// <param name="T">Объект, из которого будет производиться копирование</param>
		public override void CopyFrom(DomainObject<long> T)
        {
            var obst = T as BridgeSupport;
            if (obst is null) return;
        
            Number = obst.Number;
            IsShore = obst.IsShore;
            ShoreType = obst.ShoreType;
            IntermediateType = obst.IntermediateType;
            SupportTypeAdditionalInfo = obst.SupportTypeAdditionalInfo;
            FoundationType = obst.FoundationType;
            Material = obst.Material;
            Heights = obst.Heights;
            LayingDepth = obst.LayingDepth;
            TypicalProject = obst.TypicalProject;
            MassivePartSizeAlong = obst.MassivePartSizeAlong;
            MassivePartSizeAcross = obst.MassivePartSizeAcross;
            PileCount = obst.PileCount;
            SchemeKLeft = obst.SchemeKLeft;
            SchemeKRight = obst.SchemeKRight;
            SchemePileDistances = obst.SchemePileDistances;
            SchemePileRowDistance1 = obst.SchemePileRowDistance1;
            SchemePileRowDistance2 = obst.SchemePileRowDistance2;
            CrossbarWidth = obst.CrossbarWidth;
            CrossbarHeight = obst.CrossbarHeight;
            CrossbarLength = obst.CrossbarLength;
            PileCrossSectionWidth = obst.PileCrossSectionWidth;
            PileCrossSectionHeight = obst.PileCrossSectionHeight;
            Notes = obst.Notes;
            Bridge = obst.Bridge;
        }
        public override string ToString()
        {
            string res = $"Номер: {Number}, Тип опоры:";
            if (IsShore)
                res += ShoreSupportTypeAsString;
            else
                res += IntermediateSupportTypeAsString;
            res += $", Схема:{Scheme}, Сечение:{PileCrossSection}";
            //res += $", Доп. инфо:{SupportTypeAdditionalInfo}, Тип фундамента:{FoundationTypeAsString}, " +
            //    $"Материал:{Material}, Высоты:{HeightsAsString}, Глубина заложения фундамента:{LayingDepth.ToString("F")}, " +
            //    $"Типовой проект:{TypicalProject}, Размеры массивной части опоры:{MassivePartAsString}, " +
            //    $"Число свай:{PileCount}, Максимальное расстояние между сваями:{MaxDistanceBetweenAxis}, " +
            //    $"Схема:{Scheme}, Ширина ригеля:{CrossbarWidth}, Высота ригеля:{CrossbarHeight}, Длина ригеля:{CrossbarLength}, " +
            //    $"Сечение:{PileCrossSection}, Примечания:{Notes}";
            return res;
        }


        public bool Equals(BridgeSupport other)
        {
            return this == other;
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
            var hashCode = 802894725;
            hashCode = hashCode * -1521134295 + IsShore.GetHashCode();
            if (IsShore)
            {
                hashCode = hashCode * -1521134295 + ShoreType.GetHashCode();
            }
            else
            {
                hashCode = hashCode * -1521134295 + IntermediateType.GetHashCode();
            }
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SupportTypeAdditionalInfo);
            hashCode = hashCode * -1521134295 + FoundationType.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Material>.Default.GetHashCode(Material);
            hashCode = hashCode * -1521134295 + EqualityComparer<float[]>.Default.GetHashCode(Heights);
            hashCode = hashCode * -1521134295 + LayingDepth.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<TypicalProject>.Default.GetHashCode(TypicalProject);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(MassivePartSizeAlong);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(MassivePartSizeAcross);
            hashCode = hashCode * -1521134295 + PileCount.GetHashCode();
            hashCode = hashCode * -1521134295 + SchemeKLeft.GetHashCode();
            hashCode = hashCode * -1521134295 + SchemeKRight.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<float[]>.Default.GetHashCode(SchemePileDistances);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(SchemePileRowDistance1);
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(SchemePileRowDistance2);
            hashCode = hashCode * -1521134295 + CrossbarWidth.GetHashCode();
            hashCode = hashCode * -1521134295 + CrossbarHeight.GetHashCode();
            hashCode = hashCode * -1521134295 + CrossbarLength.GetHashCode();
            hashCode = hashCode * -1521134295 + PileCrossSectionWidth.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<float?>.Default.GetHashCode(PileCrossSectionHeight);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Notes);
            return hashCode;
        }
    }
}
