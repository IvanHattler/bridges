using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Domain;

namespace ITS.MapObjects.BridgesMapObject.Controls
{
    /// <summary>
    /// Для использования этого элемента нужно подписаться на события ElementAdding - для добавления и редактирования,
    /// ElementCopying - для копирования и ElementRemoving - для удаления
    /// </summary>
    public partial class AddableTreeView : UserControl
    {
        public override string Text
        {
            get => mainGroupBox.Text;
            set => mainGroupBox.Text = value;
        }
        public delegate INumberable GetObject(INumberable obj);
        public delegate INumberable CopyObject(INumberable obj);
        public delegate void RemoveObject(INumberable obj);
        public delegate TreeNode ToTreeNode(INumberable obj);
        /// <summary>
        /// Обработчик копирования выделенного объекта
        /// </summary>
        public event CopyObject ElementCopying;
        /// <summary>
        /// Обработчик добавления и редактирования объекта, нужно вернуть добавляемый объект
        /// </summary>
        public event GetObject ElementAdding;
        /// <summary>
        /// Обработчик при удалении объекта из контрола, должна осуществляться логика удаления из базы данных при необходимости
        /// </summary>
        public event RemoveObject ElementRemoving;
        public event ToTreeNode ConvertingToTreeNode;
        public List<INumberable> Items { get; } = new List<INumberable>();
        /// <summary>
        /// Событие изменения коллекции элементов
        /// </summary>
        public event Action ItemsChanged;
        INumberable selectedItem;
        bool selectedItemExpanded;
        public AddableTreeView()
        {
            InitializeComponent();
            //tvMain.MouseDoubleClick += MainTreeView_MouseDoubleClick;
        }

        //private void MainTreeView_MouseDoubleClick(object sender, MouseEventArgs e)
        //{
        //    btnEdit_Click(sender, e);
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var element = ElementAdding?.Invoke(null);
            if (element != null)
            {
                Items.Add(element);
                element.Number = Items.Count;
                selectedItem = element;
                Redraw();
                ItemsChanged?.Invoke();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode != null)
            {
                var obj = FindItem(tvMain.SelectedNode);
                Items.Remove(obj);
                var a = obj.Number;
                ElementRemoving?.Invoke(obj);
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Number > a)
                    {
                        Items[i].Number--;
                    }
                }
                Redraw();
                ItemsChanged?.Invoke();
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode != null)
            {
                var bs = FindItem(tvMain.SelectedNode);
                var element = ElementCopying?.Invoke(bs);
                if (element != null)
                {
                    Items.Add(element);
                    element.Number = Items.Count;
                    selectedItem = element;
                    Redraw();
                    ItemsChanged?.Invoke();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode != null)
            {
                if (tvMain.SelectedNode.IsExpanded)
                    selectedItemExpanded = true;
                else
                    selectedItemExpanded = false;
                var numberable = FindItem(tvMain.SelectedNode);
                var element = ElementAdding?.Invoke(numberable);
                if (element != null)
                {
                    var ind = Items.IndexOf(numberable);
                    Items.Remove(numberable);
                    Items.Insert(ind, element);
                    selectedItem = element;
                    Redraw();
                    ItemsChanged?.Invoke();
                }
            }
        }

        public void Clear()
        {
            Items.Clear();
            tvMain.Nodes.Clear();
        }
        public void Add(INumberable numberable)
        {
            Items.Add(numberable);
            tvMain.Nodes.Add(ConvertingToTreeNode?.Invoke(numberable));
        }
        public void Redraw()
        {
            tvMain.Nodes.Clear();
            TreeNode selectedNode = null;
            for (int i = 0; i < Items.Count; i++)
            {
                var node = ConvertingToTreeNode?.Invoke(Items[i]);
                tvMain.Nodes.Add(node);
                if (Items[i] == selectedItem)
                {
                    selectedNode = node;
                }
            }
            ActiveControl = tvMain;
            tvMain.SelectedNode = selectedNode;
            if (selectedItemExpanded)
            {
                selectedNode?.Expand();
            }
        }
        public INumberable FindItem(TreeNode treeNode)
        {
            var path = treeNode.Name.Split('/');
            return Items.FirstOrDefault
                    (o => o.Number.ToString() == path[0]);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode != null)
            {
                var obj = FindItem(tvMain.SelectedNode);
                if (obj != null)
                {
                    selectedItemExpanded = tvMain.SelectedNode.IsExpanded;
                    selectedItem = obj;
                    var ind = Items.FindIndex(x=>ReferenceEquals(x,obj));//Items.IndexOf(bs);
                    if (ind > 0)
                    {
                        Items[ind].Number--;
                        Items[ind - 1].Number++;

                        var tmp = Items[ind];
                        Items[ind] = Items[ind - 1];
                        Items[ind - 1] = tmp;

                        Redraw();
                        ItemsChanged?.Invoke();
                    }
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (tvMain.SelectedNode != null)
            {
                var obj = FindItem(tvMain.SelectedNode);
                if (obj != null)
                {
                    selectedItemExpanded = tvMain.SelectedNode.IsExpanded;
                    var ind = Items.FindIndex(x => ReferenceEquals(x, obj));//Items.IndexOf(bs);
                    selectedItem = obj;
                    if (ind < Items.Count - 1)
                    {
                        Items[ind].Number++;
                        Items[ind + 1].Number--;

                        var tmp = Items[ind];
                        Items[ind] = Items[ind + 1];
                        Items[ind + 1] = tmp;
                        
                        Redraw();
                        ItemsChanged?.Invoke();
                    }
                }
            }
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            tvMain.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tvMain.CollapseAll();
        }
    }
}
