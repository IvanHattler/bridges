using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Domain.Enums;
using ITS.Core.Bridges.Domain.EnumStrings;
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
    public partial class BridgeObstacleEditView : BaseView, IBridgeObstacleEditView
    {
        List<BridgeObstacle> _bridgeObstacles;
        Bridge _bridge;

        public BridgeObstacleEditView(List<BridgeObstacle> bridgeObstacles, Bridge bridge, ObstacleType[] obstacleTypes, string formHeader)
        {
            InitializeComponent();
            Text = formHeader;
            _bridge = bridge;

            int x = 3, y = 15;
            const int textBoxHeight = 20;
            for (int i = 0; i < obstacleTypes.Length; i++)
            {
                CheckBox cb = new CheckBox()
                {
                    Text = ObstacleTypeStrings.Instance.GetName(obstacleTypes[i]),
                    Location = new Point(x, y),
                    AutoSize = true,
                    Name = $"chb{obstacleTypes[i]}",
                };
                TextBox tb = new TextBox()
                {
                    Width = 150,
                    Height = textBoxHeight,
                    Name = $"tb{obstacleTypes[i]}",
                    Location = new Point(x, y),
                    Enabled = false,
                    MaxLength = 255,
                };
                cb.CheckedChanged += (s, e) => { tb.Enabled = cb.Checked; };
                y += textBoxHeight + 1;
                gbNames.Controls.Add(tb);
                gbTypes.Controls.Add(cb);
            }
            Entity = bridgeObstacles;
        }

        public List<BridgeObstacle> Entity
        {
            get
            {
                if (_bridgeObstacles == null)
                {
                    _bridgeObstacles = new List<BridgeObstacle>();
                }
                else
                {
                    _bridgeObstacles.Clear();
                }
                var chbs = gbTypes.Controls.OfType<CheckBox>().Where(chb => chb.Checked);
                var textBoxes = gbNames.Controls.OfType<TextBox>().Where(tb => tb.Enabled);
                foreach (var chb in chbs)
                {
                    var type = ObstacleTypeStrings.Instance.GetElement(chb.Text);
                    var name = textBoxes.First(tb => tb.Name == $"tb{type}").Text;
                    _bridgeObstacles.Add(new BridgeObstacle(type, name) { Bridge = _bridge });
                }
                return _bridgeObstacles;
            }
            set
            {
                _bridgeObstacles = value;
                if (_bridgeObstacles != null)
                {
                    
                    foreach (var item in _bridgeObstacles)
                    {
                        var textBox = gbNames.Controls.OfType<TextBox>().FirstOrDefault(tb => tb.Name == $"tb{item?.Type}");
                        if (textBox != null)
                        {
                            SelectEnumElementCB(item.TypeAsString, gbTypes);
                            textBox.Text = item.Name;
                        }
                    }
                }
            }
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
    }
}
