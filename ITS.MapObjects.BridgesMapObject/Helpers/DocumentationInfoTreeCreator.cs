using ITS.Core.Bridges.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public class DocumentationInfoTreeCreator : TreeCreator
    {
        public static TreeNode GetTreeNode(DocumentationInfo docInfo)
        {
            var root = new TreeNode($"{docInfo.Number}) Документ: {docInfo.NameAndDate}")
            {
                Name = docInfo.Number.ToString()
            };
            if (!string.IsNullOrEmpty(docInfo.Creator))
            {
                AddNode(root, "Изготовитель: " + docInfo.Creator);
            }
            if (!string.IsNullOrEmpty(docInfo.Storage))
            {
                AddNode(root, "Место хранения: " + docInfo.Storage);
            }
            propertyNumber = 1;
            return root;
        }
    }
}
