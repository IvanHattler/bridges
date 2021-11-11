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
    public partial class AddableListBox : UserControl
    {
        public override string Text
        {
            get => mainGroupBox.Text;
            set => mainGroupBox.Text = value;
        }
        public ListBox.ObjectCollection Items
            => mainListBox.Items;
        public delegate object GetObject(object obj);
        public delegate object CopyObject(object obj);
        public delegate void RemoveObject(object obj);
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
        /// <summary>
        /// Событие изменения коллекции элементов
        /// </summary>
        public event Action ItemsChanged;
        public AddableListBox()
        {
            InitializeComponent();
            mainListBox.MouseDoubleClick += MainListBox_MouseDoubleClick;
        }

        private void MainListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var element = ElementAdding?.Invoke(null);
            if (element != null)
            {
                if (element is IEnumerable<object> list)
                {
                    foreach (var item in list)
                    {
                        mainListBox.Items.Add(item);
                    }
                }
                else
                    mainListBox.Items.Add(element);
                ItemsChanged?.Invoke();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (mainListBox.SelectedIndex != -1)
            {
                var ind = mainListBox.SelectedIndex;
                ElementRemoving?.Invoke(mainListBox.SelectedItem);
                mainListBox.Items.Remove(mainListBox.SelectedItem);
                ItemsChanged?.Invoke();
                //if (ind < mainListBox.Items.Count)
                //{
                //    mainListBox.SelectedItem = ind;
                //}
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (mainListBox.SelectedIndex != -1)
            {
                var element = ElementCopying?.Invoke(mainListBox.SelectedItem);
                if (element != null)
                {
                    mainListBox.Items.Add(element);
                    ItemsChanged?.Invoke();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (mainListBox.SelectedIndex != -1)
            {
                var element = ElementAdding?.Invoke(mainListBox.SelectedItem);
                if (element != null)
                {
                    if (element is IEnumerable<object> list)
                    {
                        bool first = true;
                        var ind = mainListBox.SelectedIndex;
                        foreach (var item in list)
                        {
                            if (first)
                            {
                                mainListBox.Items.Remove(mainListBox.SelectedItem);
                                first = false;
                            }
                            mainListBox.Items.Insert(ind, item);
                            if (!first)
                            {
                                ind++;
                            }
                        }
                        mainListBox.SelectedIndex = --ind;
                    }
                    else
                    {
                        var ind = mainListBox.SelectedIndex;
                        mainListBox.Items.Remove(mainListBox.SelectedItem);
                        mainListBox.Items.Insert(ind, element);
                        mainListBox.SelectedIndex = ind;
                    }
                    ItemsChanged?.Invoke();
                }
            }
        }
    }
}
