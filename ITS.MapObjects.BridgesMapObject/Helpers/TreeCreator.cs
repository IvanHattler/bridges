using ITS.Core.Bridges.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public abstract class TreeCreator
    {
        protected static int propertyNumber = 1;
        protected static void AddNode(TreeNode root, string text)
        {
            var node = new TreeNode(text)
            {
                Name = $"{root.Name}/{propertyNumber++}",
            };
            root.Nodes.Add(node);
        }
        protected static void AddNodeWithGroup(TreeNode root, string text, List<string> properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }

            var node = new TreeNode(text)
            {
                Name = $"{root.Name}/{propertyNumber++}",
            };
            for (int i = 0; i < properties.Count; i++)
            {
                var chNode = new TreeNode(properties[i])
                {
                    Name = $"{root.Name}/{propertyNumber++}/{i+1}",
                };
                node.Nodes.Add(chNode);
            }
            root.Nodes.Add(node);
        }
    }
}
