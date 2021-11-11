using ITS.Core.Bridges.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public class SpanStructureTreeCreator : TreeCreator
    {
        public static TreeNode GetTreeNode(SpanStructure spanStructure)
        {
            var root = new TreeNode($"{spanStructure.Number}) Поперечная схема:{spanStructure.CrossScheme}")
            {
                Name = spanStructure.Number.ToString()
            };
            AddNode(root, "Статическая система: " + spanStructure.SystemAsString);
            AddNode(root, "Тип: " + spanStructure.SpanStructureTypeAsString);
            AddNode(root, "Тип проезжей части: " + spanStructure.ConstructionRoadwayAsString);
            if (spanStructure.Material != null)
            {
                AddNode(root, "Материал: " + spanStructure.Material.ToString());
            }
            AddNode(root, "Тип проезжей части: " + spanStructure.JointTypeAsString);
            var longScheme = spanStructure.LongitudeScheme;
            if (!string.IsNullOrEmpty(longScheme))
            {
                AddNode(root, "Продольная схема: " + longScheme);
            }
            if (spanStructure.ConstructionDate != DateTime.MinValue)
            {
                AddNode(root, "Дата изготовления: " + spanStructure.ConstructionDate);
            }
            if (spanStructure.TypicalProject != null)
            {
                AddNode(root, "Номер типового проекта: " + spanStructure.TypicalProject);
            }
            AddNode(root, "Тип подвижных частей: " + spanStructure.SpanTypeMovableAsString);
            AddNode(root, "Тип неподвижных частей: " + spanStructure.SpanTypeMotionlessAsString);
            AddNode(root, "Тип деформационных швов: " + spanStructure.ExpansionJointTypeAsString);
            if (!string.IsNullOrEmpty(spanStructure.ExpansionJointAddInfo))
            {
                AddNode(root, "Доп. инфо. швов: " + spanStructure.ExpansionJointAddInfo);
            }
            AddNode(root, "Способ поперечного объединения: " + spanStructure.CrossJoinAsString);
            if (spanStructure.PlateThickness > 1e-5 || spanStructure.PlateMaterial != null)
            {
                List<string> props = new List<string>(2);
                if (spanStructure.PlateThickness > 1e-5)
                {
                    props.Add("Толщина: " + spanStructure.PlateThickness.ToString("F"));
                }
                if (spanStructure.PlateMaterial != null)
                {
                    props.Add("Материал: " + spanStructure.Material.ToString());
                }
                AddNodeWithGroup(root, "Плита проезжей части", props);
            }
            if (spanStructure.RoadwayClothingThickness > 1e-5 || spanStructure.RoadwayClothingAddLayerThickness != null
                || spanStructure.RoadwayClothingAddLayerWeight != null)
            {
                List<string> props = new List<string>(3);
                if (spanStructure.RoadwayClothingThickness > 1e-5)
                {
                    props.Add("Толщина: " + spanStructure.RoadwayClothingThickness.ToString("F"));
                }
                if (spanStructure.RoadwayClothingAddLayerThickness != null)
                {
                    props.Add("Толщина лишнего слоя: " + spanStructure.RoadwayClothingAddLayerThickness.Value.ToString("F"));
                }
                if (spanStructure.RoadwayClothingAddLayerWeight != null)
                {
                    props.Add("Вес лишнего слоя: " + spanStructure.RoadwayClothingAddLayerWeight.Value.ToString("F"));
                }
                AddNodeWithGroup(root, "Одежда ездового полотна", props);
            }
            if (spanStructure.MainPileCount > 0)
            {
                AddNode(root, "Кол-во главных балок: " + spanStructure.MainPileCount);
            }
            if (spanStructure.MainPileHeightSpan > 1e-5 || spanStructure.MainPileHeightSupport > 1e-5
                || spanStructure.MainPileThicknessEdge > 1e-5)
            {
                List<string> props = new List<string>();
                if (spanStructure.MainPileHeightSpan > 1e-5)
                {
                    props.Add("В пролёте: " + spanStructure.MainPileHeightSpan.ToString("F"));
                }
                if (spanStructure.MainPileHeightSupport > 1e-5)
                {
                    props.Add("У опоры: " + spanStructure.MainPileHeightSupport.ToString("F"));
                }
                if (spanStructure.MainPileThicknessEdge > 1e-5)
                {
                    props.Add("Толщина ребра(стенки): " + spanStructure.MainPileThicknessEdge.ToString("F"));
                }
                AddNodeWithGroup(root, "Высота главной балки", props);
            }
            if (spanStructure.CrossPile != null)
            {
                List<string> props = new List<string>(4);
                if (spanStructure.CrossPile.CountInSpan > 0)
                {
                    props.Add("Количество в пролёте: " + spanStructure.CrossPile.CountInSpan);
                }
                if (spanStructure.CrossPile.Height > 1e-5)
                {
                    props.Add("Высота: " + spanStructure.CrossPile.Height);
                }
                if (spanStructure.CrossPile.Material != null)
                {
                    props.Add("Материал: " + spanStructure.CrossPile.Material);
                }
                props.Add("Тип: " + spanStructure.CrossPile.TypeAsString);
                AddNodeWithGroup(root, "Поперечная балка", props);
            }
            if (spanStructure.LongitudinalPile != null)
            {
                List<string> props = new List<string>(4);
                if (spanStructure.LongitudinalPile.CountInSpan > 0)
                {
                    props.Add("Количество в пролёте: " + spanStructure.LongitudinalPile.CountInSpan);
                }
                if (spanStructure.LongitudinalPile.Height > 1e-5)
                {
                    props.Add("Высота: " + spanStructure.LongitudinalPile.Height);
                }
                if (spanStructure.CrossPile.Material != null)
                {
                    props.Add("Материал: " + spanStructure.LongitudinalPile.Material);
                }
                props.Add("Тип: " + spanStructure.LongitudinalPile.TypeAsString);
                AddNodeWithGroup(root, "Продольная балка", props);
            }
            if (spanStructure.AdditionalLinearLoad > 1e-5)
            {
                AddNode(root, "Дополнительная погонная нагрузка: " + spanStructure.AdditionalLinearLoad.ToString("F"));
            }
            if (!string.IsNullOrEmpty(spanStructure.Notes))
            {
                AddNode(root, "Примечания: " + spanStructure.Notes);
            }
            if (spanStructure.UnderbridgeClearance > 1e-5)
            {
                AddNode(root, "Подмостовой габарит: " + spanStructure.UnderbridgeClearance);
            }
            propertyNumber = 1;
            return root;
        }
    }
}