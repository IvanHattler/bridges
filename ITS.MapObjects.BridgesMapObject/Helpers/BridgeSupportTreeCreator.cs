using ITS.Core.Bridges.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public class BridgeSupportTreeCreator : TreeCreator
    {
        public static TreeNode GetTreeNode(BridgeSupport bridgeSupport)
        {
            var root = new TreeNode($"{bridgeSupport.Number}) Cхема:{bridgeSupport.Scheme}")
            {
                Name = bridgeSupport.Number.ToString()
            };
            AddNode(root, "Тип фундамента: " + bridgeSupport.FoundationTypeAsString);
            if (bridgeSupport.PileCount > 0)
            {
                AddNode(root, "Количество свай: " + bridgeSupport.PileCount);
            }
            if (bridgeSupport.PileCrossSectionWidth > 1e-5)
            {
                AddNode(root, "Сечение сваи: " + bridgeSupport.PileCrossSection);
            }
            if (bridgeSupport.IsShore)
            {
                AddNode(root, "Тип подвижной опоры: " + bridgeSupport.ShoreSupportTypeAsString);
            }
            else
            {
                AddNode(root, "Тип неподвижной опоры: " + bridgeSupport.IntermediateSupportTypeAsString);
            }
            if (!string.IsNullOrEmpty(bridgeSupport.SupportTypeAdditionalInfo))
            {
                AddNode(root, "Доп. инфо: " + bridgeSupport.SupportTypeAdditionalInfo);
            }
            if (bridgeSupport.Material != null)
            {
                AddNode(root, "Материал: " + bridgeSupport.Material.ToString());
            }
            var heights = bridgeSupport.HeightsAsString;
            if (!string.IsNullOrEmpty(heights))
            {
                AddNode(root, "Высоты опоры: " + heights);
            }
            if (bridgeSupport.LayingDepth > 1e-5)
            {
                AddNode(root, "Глубина заложения фундамента: " + bridgeSupport.LayingDepth);
            }
            if (bridgeSupport.TypicalProject != null)
            {
                AddNode(root, "Номер типового проекта: " + bridgeSupport.TypicalProject);
            }
            var mpas = bridgeSupport.MassivePartAsString;
            if (!string.IsNullOrEmpty(mpas))
            {
                AddNode(root, "Размер массивной части опоры: " + mpas);
            }
            if (bridgeSupport.CrossbarWidth > 1e-5 || bridgeSupport.CrossbarHeight > 1e-5 || bridgeSupport.CrossbarLength > 1e-5)
            {
                List<string> props = new List<string>(3);
                if (bridgeSupport.CrossbarWidth > 1e-5)
                {
                    props.Add("Ширина сечения: " + bridgeSupport.CrossbarWidth.ToString("F"));
                }
                if (bridgeSupport.CrossbarHeight > 1e-5)
                {
                    props.Add("Длина сечения: " + bridgeSupport.CrossbarHeight.ToString("F"));
                }
                if (bridgeSupport.CrossbarLength > 1e-5)
                {
                    props.Add("Длина: " + bridgeSupport.CrossbarLength.ToString("F"));
                }
                AddNodeWithGroup(root, "Сечение и длина ригеля", props);
            }
            if (!string.IsNullOrEmpty(bridgeSupport.Notes))
            {
                AddNode(root, "Примечания: " + bridgeSupport.Notes);
            }
            propertyNumber = 1;
            return root;
        }
    }
}
