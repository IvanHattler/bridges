using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
using ITS.Core.Bridges.Helpers;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.MapObjects.BridgesMapObject.Controls;
using ITS.MapObjects.BridgesMapObject.IViews;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ITS.MapObjects.BridgesMapObject.Helpers.EditViewHelper;

namespace ITS.MapObjects.BridgesMapObject.Views
{
    public partial class DefectEditView : BaseView, IDefectEditView
    {
        Defect _defect;
        IDefectTypeManager _defectTypeManager;
        IDefectScrollSectionManager _defectScrollSectionManager;
        IList<DefectType> _defectTypes;

        public DefectEditView(Defect defect, IDefectTypeManager defectTypeManager,
            IDefectScrollSectionManager defectScrollSectionManager)
        {
            _defectTypeManager = defectTypeManager;
            _defectScrollSectionManager = defectScrollSectionManager;
            InitializeComponent();
            DefectTypes = _defectTypeManager.GetAll();

            //var collection = new AutoCompleteStringCollection();
            //collection.AddRange(_defectTypes.Select(d => d.Name).ToArray());
            //tbSearch.AutoCompleteCustomSource = collection;

            lbxSections.DataSource = _defectScrollSectionManager.GetAll();
            if (defect.Type != null)
            {
                FillControls(defect.PatternRules);
            }
            Entity = defect;
        }

        public Defect Entity
        {
            get
            {
                _defect.Location = tbLocation.Text;
                _defect.Type = GetObject<DefectType>(lbxType)
                    ?? lbxType.Items[0] as DefectType;
                _defect.Params = Params;
                _defect.Category = tbCategory.Text;
                _defect.Notes = tbNotes.Text;
                return _defect;
            }
            set
            {
                _defect = value;
                if (_defect != null)
                {
                    tbLocation.Text = _defect.Location;
                    SetObject(lbxSections, _defect.Type?.Section);
                    SetObject(lbxType, _defect.Type);
                    Params = _defect.Params;
                    tbCategory.Text = _defect.Category;
                    tbNotes.Text = _defect.Notes;
                }
            }
        }
        private string Params
        {
            get
            {
                var values = _defect.PatternRules;
                if (values != null)
                {
                    var a = new Dictionary<string, string>();
                    foreach (var val in values)
                    {
                        var control = Controls.Find(val.Key, true).First(c => !(c is Label));
                        a.Add(control.Name, control.Text);
                    }
                    return DefectParamsParser.Box(a);
                }
                return "";
            }
            set
            {
                _defect.Params = value;
                if (value != null)
                {
                    var values = _defect.ParamsValues;
                    if (!(values is null))
                    {
                        foreach (var val in values)
                        {
                            var controls = Controls.Find(val.Key, true);
                            if (controls.Length > 0)
                            {
                                var control = controls.First(c => !(c is Label));
                                control.Text = val.Value;
                            }
                        }
                    }
                }
            }
        }
        private IList<DefectType> DefectTypes
        {
            set
            {
                _defectTypes = value;
                lbxType.DataSource = _defectTypes;
            }
            get => _defectTypes;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            CloseView();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            CloseView();
        }
        private void FillControls(Dictionary<string, string> rules)
        {
            if (rules != null)
            {
                int x = 3, y = 15;
                foreach (var item in rules)
                {
                    Label l1 = new Label()
                    {
                        AutoSize = false,
                        Text = item.Key,
                        Name = item.Key,
                        Width = 70,
                        Location = new Point(x, y),
                        Size = new Size(150, 50),
                    };
                    l1.Text += $" - {DefectsHelper.GetParamDescription(item.Key)}";
                    toolTip1.SetToolTip(l1, l1.Text);
                    TextBox tb1 = new TextBox()
                    {
                        Size = new Size(65, 30),
                        Text = "0",
                        Name = item.Key,
                        Location = new Point(x + l1.Size.Width + 3, y),
                    };
                    tb1.KeyPress += tbField_KeyPress;
                    y += l1.Height;
                    pnParams.Controls.Add(l1);
                    pnParams.Controls.Add(tb1);
                }
            }
        }
        private void lbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = (sender as ListBox).SelectedItem as DefectType;
            if (selectedItem != null)
            {
                pnParams.Controls.Clear();
                var rules = selectedItem.PatternRules;
                FillControls(rules);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbxSearchResults.Items.Clear();
            lbxSearchResults.Items.AddRange(
                _defectTypes.Where(dt=>
                dt.Name.IndexOf(tbSearch.Text, StringComparison.OrdinalIgnoreCase) != -1)
                .ToArray());
            lbxSearchResults.SelectedIndexChanged += (s, ea) =>
            {
                var text = ((s as ListBox).SelectedItem as DefectType).Name;
                var type = _defectTypes
                    .FirstOrDefault(x => x.Name == text);
                if (type != null)
                {
                    lbxSections.SelectedItem =
                        (lbxSections.DataSource as IList<DefectScrollSection>)
                        .FirstOrDefault(dss => dss.Name == type.Section.Name);
                    lbxType.SelectedItem = type;
                }
            };
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbSearch.Clear();
        }

        private void lbxSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((sender as ListBox).SelectedItem is DefectScrollSection section)//встроенная проверка на null
            {
                lbxType.DataSource = _defectTypes.Where(dt => dt.Section.Name == section.Name).ToList();
                lbSection.Text = section.FullName.Replace("//", "\r\n");
            }
        }

        private void tbField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar) || e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == (char)Keys.Back))
                e.Handled = true;
        }
    }
}