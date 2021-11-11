using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Domain;
using ITS.MapObjects.BridgesMapObject.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ITS.Core.ManagerInterfaces;
using ITS.Core.Bridges.Domain.Base;
using System.Drawing;

namespace ITS.MapObjects.BridgesMapObject.Helpers
{
    public static class EditViewHelper
    {
        /// <summary>
        /// Заполняет ComboBox значениями из перечисления T через DataSource
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        public static void FillEnumValues<T, TStrings>(ComboBox cb, bool sorting = false)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var converter = new TStrings();
            if (!sorting)
            {
                cb.DataSource = Enum.GetValues(typeof(T)).Cast<T>()
                .Select(t => converter.GetName(t)).ToArray();
            }
            else
            {
                cb.DataSource = Enum.GetValues(typeof(T)).Cast<T>()
                .Select(t => converter.GetName(t)).OrderBy(x => x).ToArray();
            }
        }
        /// <summary>
        /// Заполняет CheckedListBox значениями из перечисления T
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        /// <param name="clb"></param>
        /// <param name="noDataAtTheEnd"></param>
        public static void FillEnumValues<T, TStrings>(CheckedListBox clb, bool noDataAtTheEnd = false)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var converter = new TStrings();
            clb.Items.AddRange(Enum.GetValues(typeof(T)).Cast<T>()
                .Select(t => converter.GetName(t)).ToArray());
            if (noDataAtTheEnd)//Нет данных - в конец списка
            {
                clb.Items.Add(clb.Items[0]);
                clb.Items.RemoveAt(0);
            }
        }
        /// <summary>
        /// Заполняет FlowLayoutPanel значениями из перечисления T и устанавливает Checked у нулевого элемента
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        public static void FillEnumValues<T, TStrings>(FlowLayoutPanel flp)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var converter = new TStrings();
            flp.Controls.AddRange(Enum.GetValues(typeof(T)).Cast<T>()
                .Select(t => new RadioButton()
                {
                    Text = converter.GetName(t),
                    Margin = new Padding(2, 0, 0, 0),
                    Padding = Padding.Empty,
                    AutoSize = true,
                }).ToArray());
            (flp.Controls[0] as RadioButton).Checked = true;
        }
        /// <summary>
        /// Заполняет FlowLayoutPanel значениями из перечисления T с подсказками ToolTip и устанавливает Checked у нулевого элемента
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        /// <param name="flp"></param>
        /// <param name="toolTip"></param>
        public static void FillEnumValues<T, TStrings>(FlowLayoutPanel flp, ToolTip toolTip)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var converter = new TStrings();
            flp.Controls.AddRange(Enum.GetValues(typeof(T)).Cast<T>()
                .Select(t => 
                {
                    var text = converter.GetName(t);
                    var btn = new RadioButton()
                    {
                        Text = text,
                        Margin = new Padding(2, 0, 0, 0),
                        Padding = Padding.Empty,
                        AutoSize = true,
                    };
                    toolTip.SetToolTip(btn, text);
                    return btn;
                }).ToArray());
            (flp.Controls[0] as RadioButton).Checked = true;
        }
        /// <summary>
        /// Заполняет FlowLayoutPanel значениями из перечисления T с переданным обработчиком checkedChanged и устанавливает Checked у нулевого элемента
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        /// <param name="flp"></param>
        /// <param name="checkedChangedHandler"></param>
        public static void FillEnumValues<T, TStrings>(FlowLayoutPanel flp, EventHandler checkedChangedHandler)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var converter = new TStrings();
            flp.Controls.AddRange(Enum.GetValues(typeof(T)).Cast<T>()
                .Select(t =>
                {
                    var rb = new RadioButton()
                    {
                        Text = converter.GetName(t),
                        Margin = new Padding(2, 0, 0, 0),
                        Padding = Padding.Empty,
                        AutoSize = true,
                    };
                    rb.CheckedChanged += checkedChangedHandler;
                    return rb;
                }).ToArray());
            (flp.Controls[0] as RadioButton).Checked = true;
        }
        /// <summary>
        /// Заполняет FlowLayoutPanel значениями из перечисления T c подсказками ToolTip, переданным обработчиком checkedChanged и устанавливает Checked у нулевого элемента
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        /// <param name="flp"></param>
        /// <param name="checkedChangedHandler"></param>
        /// <param name="toolTip"></param>
        public static void FillEnumValues<T, TStrings>(FlowLayoutPanel flp, EventHandler checkedChangedHandler, ToolTip toolTip)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var converter = new TStrings();
            flp.Controls.AddRange(Enum.GetValues(typeof(T)).Cast<T>()
                .Select(t =>
                {
                    var text = converter.GetName(t);
                    var rb = new RadioButton()
                    {
                        Text = text,
                        Margin = new Padding(2, 0, 0, 0),
                        Padding = Padding.Empty,
                        AutoSize = true,
                    };
                    toolTip.SetToolTip(rb, text);
                    rb.CheckedChanged += checkedChangedHandler;
                    return rb;
                }).ToArray());
            (flp.Controls[0] as RadioButton).Checked = true;
        }
        /// <summary>
        /// Заполняет FlowLayoutPanel значениями из перечисления T и устанавливает Checked у нулевого элемента, использует для конвертации в строку функцию convert
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        public static void FillEnumValues<T>(FlowLayoutPanel flp, Func<T, string> convert)
            where T : struct, IConvertible
        {
            flp.Controls.AddRange(Enum.GetValues(typeof(T)).Cast<T>()
                .Select(t => new RadioButton()
                {
                    Text = convert(t),
                    Margin = new Padding(2, 0, 0, 0),
                    Padding = Padding.Empty,
                    AutoSize = true,
                }).ToArray());
            (flp.Controls[0] as RadioButton).Checked = true;
        }
        /// <summary>
        /// Заполняет FlowLayoutPanel значениями из массива элементов перечисления и устанавливает Checked у нулевого элемента
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        /// <param name="flp"></param>
        /// <param name="allowedTypes"></param>
        public static void FillEnumValues<T, TStrings>(FlowLayoutPanel flp, T[] allowedTypes)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var converter = new TStrings();
            flp.Controls.AddRange(allowedTypes
                .Select(t => new RadioButton()
                {
                    Text = converter.GetName(t),
                    Margin = new Padding(2, 0, 0, 0),
                    Padding = Padding.Empty,
                    AutoSize = true,
                }).ToArray());
            (flp.Controls[0] as RadioButton).Checked = true;
        }
        /// <summary>
        /// Получает элемент перечисления Flags по выделенным галочкам в CheckedListBox
        /// </summary>
        /// <param name="clb"></param>
        public static T GetSelected<T, TStrings>(CheckedListBox clb)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var noData = default(T);
            if (clb.CheckedItems.Count == 0)
            {
                return noData;
            }
            var selectedElements = clb.CheckedItems.Cast<string>()
               .Select(s => new TStrings().GetElement(s));
            if (selectedElements.Contains(noData))
            {
                return noData;
            }
            return selectedElements.Aggregate((c1, c2) => (dynamic)c1 | (dynamic)c2);
        }
        /// <summary>
        /// Получает выделенный элемент перечисления из GroupBox состоящего из RadioButton-ов
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        /// <param name="groupBox"></param>
        /// <returns></returns>
        public static T GetSelected<T, TStrings>(GroupBox groupBox)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            int i = 0;
            var buttons = groupBox.Controls.OfType<RadioButton>();
            var radioButton = buttons.ElementAt(0);
            while (!radioButton.Checked)
            {
                radioButton = buttons.ElementAt(i);
                i++;
            }
            return new TStrings().GetElement(radioButton.Text);
        }
        /// <summary>
        /// Получает выделенный элемент перечисления из ComboBox
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        public static T GetSelected<T, TStrings>(ComboBox comboBox)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            return new TStrings().GetElement(comboBox.SelectedItem as string);
        }
        /// <summary>
        /// Получает выделенный элемент перечисления из ComboBox, используя convert для преобразования из строки
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        public static T GetSelected<T>(ComboBox comboBox, Func<string, T> convert)
            where T : struct, IConvertible
        {
            return convert(comboBox.SelectedItem as string);
        }
        /// <summary>
        /// Получает выделенный элемент перечисления из ComboBox, используя convert для преобразования из строки
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        public static T GetSelected<T>(FlowLayoutPanel flp, Func<string, T> convert)
            where T : struct, IConvertible
        {
            int i = 0;
            var buttons = flp.Controls.OfType<RadioButton>();
            var radioButton = buttons.ElementAt(0);
            while (!radioButton.Checked)
            {
                radioButton = buttons.ElementAt(i);
                i++;
            }
            return convert(radioButton.Text);
        }
        /// <summary>
        /// Возвращает выделенный элемент из TreeView
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TStrings"></typeparam>
        /// <param name="treeView"></param>
        /// <returns></returns>
        public static T GetSelected<T, TStrings>(TreeView treeView)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            return new TStrings().GetElement(treeView.SelectedNode.Text);
        }
        /// <summary>
        /// Получает выделенный элемент перечисления из FlowLayoutPanel
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        public static T GetSelected<T, TStrings>(FlowLayoutPanel flp)
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            int i = 0;
            var buttons = flp.Controls.OfType<RadioButton>();
            var radioButton = buttons.ElementAt(0);
            while (!radioButton.Checked)
            {
                radioButton = buttons.ElementAt(i);
                i++;
            }
            return new TStrings().GetElement(radioButton.Text);
        }
        /// <summary>
        /// Устанавливает свойство Checked у кнопки с указанным текстом
        /// </summary>
        /// <param name="valueAsString">указанный текст</param>
        /// <param name="groupBox">контейнер с кнопками</param>
        public static void SelectEnumElement(string valueAsString, GroupBox groupBox)
        {
            int i = 0;
            var buttons = groupBox.Controls.OfType<RadioButton>();
            var radioButton = buttons.ElementAt(0);
            while (radioButton.Text != valueAsString && i < buttons.Count())
            {
                radioButton = buttons.ElementAt(i);
                i++;
            }
            radioButton.Checked = true;
        }
        /// <summary>
        /// Устанавливает свойство Checked у CheckBox-а с указанным текстом
        /// </summary>
        /// <param name="valueAsString">указанный текст</param>
        /// <param name="groupBox">контейнер с кнопками</param>
        public static void SelectEnumElementCB(string valueAsString, GroupBox groupBox)
        {
            int i = 0;
            var cbs = groupBox.Controls.OfType<CheckBox>();
            var cb = cbs.ElementAt(0);
            while (cb.Text != valueAsString && i < cbs.Count())
            {
                cb = cbs.ElementAt(i);
                i++;
            }
            cb.Checked = true;
        }
        /// <summary>
        /// Устанавливает свойство Checked у кнопки с указанным текстом
        /// </summary>
        /// <param name="valueAsString">указанный текст</param>
        /// <param name="flp">контейнер с кнопками</param>
        public static void SelectEnumElement(string valueAsString, FlowLayoutPanel flp)
        {
            int i = 0;
            IEnumerable<RadioButton> buttons = GetRadioButtons(flp);
            var radioButton = buttons.ElementAt(0);
            while (radioButton.Text != valueAsString && i < buttons.Count())
            {
                radioButton = buttons.ElementAt(i);
                i++;
            }
            radioButton.Checked = true;
        }
        /// <summary>
        /// Выбирает элемент из списка ComboBox
        /// </summary>
        /// <param name="valueAsString">указанный текст</param>
        /// <param name="comboBox">контейнер с кнопками</param>
        public static void SelectEnumElement(string valueAsString, ComboBox comboBox)
        {
            comboBox.SelectedItem = valueAsString;
        }
        /// <summary>
        /// Устанавливает галочки в CheckedListBox, согласно входной строке
        /// </summary>
        /// <param name="valueAsString">Строка перечисления</param>
        /// <param name="clb"></param>
        public static void SelectEnumElement(string valueAsString, CheckedListBox clb)
        {
            var tmp = valueAsString.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            var items = clb.Items.Cast<string>();
            for (int i = 0; i < items.Count(); i++)
            {
                if (tmp.Contains(items.ElementAt(i)))
                {
                    clb.SetItemChecked(i, true);
                }
            }
        }
        /// <summary>
        /// Выделяет узел TreeView с заданным текстом
        /// </summary>
        /// <param name="elementAsString"></param>
        /// <param name="treeView"></param>
        /// <returns></returns>
        public static void SelectEnumElement(string elementAsString, TreeView treeView)
        {
            TreeNode itemNode = null;
            foreach (TreeNode node in treeView.Nodes)
            {
                itemNode = RecursiveFind(elementAsString, node);
                if (itemNode != null) break;
            }
            treeView.SelectedNode = itemNode;
        }
        /// <summary>
        /// Получение int значения из GroupBox, состоящего из RadioButton-ов c текстом int значения (например, "123")
        /// </summary>
        /// <param name="groupBox"></param>
        /// <returns></returns>
        public static int GetSelectedInt(GroupBox groupBox)
        {
            int i = 0;
            var radioButtons = GetRadioButtons(groupBox);
            var radioButton = radioButtons.ElementAt(0);
            while (!radioButton.Checked)
            {
                radioButton = radioButtons.ElementAt(i);
                i++;
            }
            return Convert.ToInt32(radioButton.Text);
        }
        /// <summary>
        /// Получение даты из View
        /// </summary>
        /// <param name="dtp"></param>
        /// <returns></returns>
        public static DateTime GetDate(DateTimePicker dtp)
        {
            if (dtp.Checked)
            {
                return dtp.Value;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
        /// <summary>
        /// Установка даты на View
        /// </summary>
        /// <param name="dtp"></param>
        /// <param name="dateTime"></param>
        public static void SetDate(DateTimePicker dtp, DateTime dateTime)
        {
            if (dateTime != DateTime.MinValue)
            {
                dtp.Value = dateTime;
                dtp.Checked = true;
            }
        }
        /// <summary>
        /// Получает список объектов типа T из AddableListBox
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alb"></param>
        /// <returns></returns>
        public static IList<T> GetObjects<T>(AddableListBox alb)
        {
            var res = new List<T>();
            if (alb.Items.Count > 0)
            {
                foreach (var item in alb.Items)
                {
                    res.Add((T)item);
                }
            }
            return res;
        }
        /// <summary>
        /// Получает список объектов типа T из  из AddableTreeView
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="atv"></param>
        /// <returns></returns>
        public static IList<T> GetObjects<T>(AddableTreeView atv)
            where T : class, INumberable
        {
            var res = new List<T>();
            if (atv.Items.Count > 0)
            {
                foreach (var item in atv.Items)
                {
                    res.Add(item as T);
                }
            }
            return res;
        }
        /// <summary>
        /// Заполняет AddableListBox из списка list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="alb"></param>
        public static void SetObjects<T>(IList<T> list, AddableListBox alb)
        {
            if (list != null)
            {
                if (alb.Items.Count > 0)
                {
                    alb.Items.Clear();
                }
                foreach (var item in list)
                {
                    alb.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// Заполняет AddableListBox из списка list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="atv"></param>
        public static void SetObjects<T>(IList<T> list, AddableTreeView atv)
            where T : INumberable
        {
            if (list != null)
            {
                if (atv.Items.Count > 0)
                {
                    atv.Clear();
                }
                var l = list.OrderBy(bs => bs.Number).ToList();
                for (int i = 0; i < l.Count; i++)
                {
                    atv.Add(l[i]);
                }
            }
        }
        /// <summary>
        /// Получает значение типа T (ValueType) из NumericUpDown
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="numericUpDown"></param>
        /// <param name="checkBox"></param>
        /// <returns></returns>
        public static T? GetNullable<T>(NumericUpDown numericUpDown, CheckBox checkBox)
            where T : struct
        {
            if (checkBox.Checked)
                return (T?)(dynamic)numericUpDown.Value;
            else
                return null;
        }
        /// <summary>
        /// Устанавливает значение типа T (ValueType) в NumericUpDown
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="numericUpDown"></param>
        /// <param name="checkBox"></param>
        public static void SetNullable<T>(T? value, NumericUpDown numericUpDown, CheckBox checkBox)
            where T : struct
        {
            if (value == null)
            {
                checkBox.Checked = false;
            }
            else
            {
                numericUpDown.Value = (decimal)(dynamic)value;
                checkBox.Checked = true;
            }
        }
        /// <summary>
        /// Подписывает на событие ElementRemoving в AddableListBox удаление объекта из базы данных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="alb"></param>
        /// <param name="manager">Менеджер, позволяющий удалить объект</param>
        public static void SubscribeOnElementRemoving<T>(AddableListBox alb, IManager<T, long> manager)
            where T : DomainObject<long>
        {
            alb.ElementRemoving +=
                (obj) => RemoveObject(obj as T, manager);
        }
        /// <summary>
        /// Подписывает на событие ElementRemoving в AddableTreeView удаление объекта из базы данных
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="atv"></param>
        /// <param name="manager">Менеджер, позволяющий удалить объект</param>
        public static void SubscribeOnElementRemoving<T>(AddableTreeView atv, IManager<T, long> manager)
            where T : DomainObject<long>
        {
            atv.ElementRemoving +=
                (obj) => RemoveObject(obj as T, manager);
        }
        /// <summary>
        /// Метод для удаления объекта, используется при обработке события ElementRemoving в AddableTreeView
        /// </summary>
        /// <typeparam name="T">Тип объекта</typeparam>
        /// <param name="obj">Объект</param>
        /// <param name="manager">Менеджер, позволяющий удалить объект</param>
        private static void RemoveObject<T>(T obj, IManager<T, long> manager)
            where T : DomainObject<long>
        {
            if (obj is T typedObj && !typedObj.IsTransient())
            {
                manager.Delete(typedObj);
            }
        }
        /// <summary>
        /// Обработчик события копирования
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ElementCopying<T>(object obj)
            where T : DomainObject<long>, new()
        {
            T a = new T();
            a.CopyFrom(obj as T);
            return a;
        }
        /// <summary>
        /// Обработчик события нажатия на CheckBox, устанавливает Enabled всех элементов в GroupBox равным Checked, CheckBox должен находиться в GroupBox
        /// </summary>
        /// <param name="sender">CheckBox</param>
        /// <param name="e"></param>
        public static void NullableClassCheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            GroupBox parent = checkBox.Parent as GroupBox;
            foreach (var item in parent.Controls)
            {
                if (!(item is CheckBox))
                {
                    (item as Control).Enabled = checkBox.Checked;
                }
            }
        }
        private static IEnumerable<RadioButton> GetRadioButtons(FlowLayoutPanel flp)
        {
            return flp.Controls.OfType<RadioButton>();
        }
        private static IEnumerable<RadioButton> GetRadioButtons(GroupBox groupBox)
        {
            return groupBox.Controls.OfType<RadioButton>();
        }
        private static TreeNode RecursiveFind(string itemText, TreeNode rootNode)
        {
            foreach (TreeNode node in rootNode.Nodes)
            {
                if (node.Text.Equals(itemText)) return node;
                TreeNode next = RecursiveFind(itemText, node);
                if (next != null) return next;
            }
            return null;
        }
        /// <summary>
        /// Получает выделенный объект из ComboBox и преобразовывает к T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static T GetObject<T>(ComboBox cb)
        {
            return (T)cb.SelectedItem;
        }
        /// <summary>
        /// Получает выделенный объект из ListBox и преобразовывает к T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lbx"></param>
        /// <returns></returns>
        public static T GetObject<T>(ListBox lbx)
        {
            return (T)lbx.SelectedItem;
        }
        /// <summary>
        /// Выделяет объект obj в ComboBox
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cb"></param>
        /// <param name="obj"></param>
        public static void SetObject<T>(ComboBox cb, T obj)
        {
            cb.SelectedItem = obj;
        }
        /// <summary>
        /// Выделяет объект obj в ListBox
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="lbx"></param>
        /// <param name="obj"></param>
        public static void SetObject<T>(ListBox lbx, T obj)
        {
            lbx.SelectedItem = obj;
        }
        /// <summary>
        /// Обработчик события ItemCheck для CheckedListBox, снимает все отметки при выборе элемента "Нет данных",
        /// предполагается, что элемент "Нет данных" находится в списке на последнем месте
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void clbFlagsWithNoData_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox checkedListBox = sender as CheckedListBox;
            if (e.Index != checkedListBox.Items.Count - 1 &&e.NewValue == CheckState.Checked)
            {
                checkedListBox.SetItemCheckState(checkedListBox.Items.Count - 1, CheckState.Unchecked);
            }
            else if (e.NewValue == CheckState.Checked)
            {
                //если индекс == checkedListBox.Items.Count - 1, снять все остальные отметки
                for (int i = 0; i < checkedListBox.Items.Count - 1; i++)
                {
                    checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
                }
            }
        }
        /// <summary>
        /// Обработчик события ItemCheck для CheckedListBox, снимает все отметки при выборе элемента "Нет данных" и "Нет"
        /// предполагается, что элемент "Нет данных" находится в списке на последнем месте а элемент "Отсутствуют" на первом
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void clbFlagsWithNoneAndNoData_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            CheckedListBox checkedListBox = sender as CheckedListBox;
            if (e.Index != checkedListBox.Items.Count - 1 &&
                e.Index != 0 && e.NewValue == CheckState.Checked)
            {
                checkedListBox.SetItemCheckState(checkedListBox.Items.Count - 1, CheckState.Unchecked);
                checkedListBox.SetItemCheckState(0, CheckState.Unchecked);
            }
            else if (e.NewValue == CheckState.Checked)
            {
                if (e.Index == checkedListBox.Items.Count - 1)
                {
                    //если индекс == checkedListBox.Items.Count - 1, снять все остальные отметки
                    for (int i = 0; i < checkedListBox.Items.Count - 1; i++)
                    {
                        checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
                else
                {
                    //если индекс == 0, снять все остальные отметки
                    for (int i = 1; i < checkedListBox.Items.Count; i++)
                    {
                        checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
        }
        public static bool? CheckStateToNullableBool(CheckState checkState)
        {
            switch (checkState)
            {
                case CheckState.Unchecked:
                    return false;
                case CheckState.Checked:
                    return true;
                case CheckState.Indeterminate:
                    return null;
            }
            return null;
        }
        public static CheckState NullableBoolToCheckState(bool? value)
        {
            switch (value)
            {
                case true:
                    return CheckState.Checked;
                case false:
                    return CheckState.Unchecked;
                case null:
                    return CheckState.Indeterminate;
            }
            return CheckState.Indeterminate;
        }
        /// <summary>
        /// Меняет местами значения в двух NumericUpDown
        /// </summary>
        /// <param name="nud1"></param>
        /// <param name="nud2"></param>
        public static void SwapNumbers(NumericUpDown nud1, NumericUpDown nud2)
        {
            var tmp = nud1.Value;
            nud1.Value = nud2.Value;
            nud2.Value = tmp;
        }
        /// <summary>
        /// Получает картинку на заданный тип перечисления из ресурсов, название ресурса строится из префикса и названия элемента перечисления
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <typeparam name="TStrings">Класс-преобразователь перечисления</typeparam>
        /// <param name="elementAsString"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static Bitmap GetImageFromResourses<T,TStrings>(string elementAsString, string prefix = "")
            where T : struct, IConvertible
            where TStrings : EnumStrings<T>, new()
        {
            var converter = new TStrings();
            string name = prefix + converter.GetElement(elementAsString).ToString();
            var obj = Properties.Resources.ResourceManager.GetObject(name);
            return (Bitmap)obj;
        }
    }
}
