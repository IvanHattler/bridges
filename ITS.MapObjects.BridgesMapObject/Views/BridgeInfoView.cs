using ITS.Client.Core.ViewInterfaces;
using ITS.Core.Bridges.Domain;
using ITS.Core.Bridges.Helpers;
using ITS.MapObjects.BridgesMapObject.IViews;
using ITS.MapObjects.BridgesMapObject.Reports;
using ITS.ProjectBase.Utils.AsyncWorking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using System.Threading;
using ITS.Core.Domain.Photos;
using ITS.Core.Bridges.ManagerInterfaces;
using ITS.MapObjects.BridgesMapObject.Helpers;

namespace ITS.MapObjects.BridgesMapObject.Views
{
    public partial class BridgeInfoView : BaseView, IBridgeInfoView
    {
        public Bridge _bridge;
        public IBridgeReportMaker _bridgeReportMaker;
        private IEditPhotoControl _photoControl;
        private IBridgeManager _bridgeManager;
        public BridgeInfoView(Bridge bridge, IBridgeManager bridgeManager, IBridgeReportMaker reportMaker, IEditPhotoControl editPhotoControl)
        {
            InitializeComponent();
            _bridge = bridge ?? throw new ArgumentNullException(nameof(bridge));
            _bridgeManager = bridgeManager ?? throw new ArgumentNullException(nameof(bridgeManager));
            Text += $" {bridge.BridgeCode}";
            _bridgeReportMaker = reportMaker;
            if (_bridgeReportMaker.SpanStructureGroups != null)
            {
                for (int i = 0; i < _bridgeReportMaker.SpanStructureGroups.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    var num = _bridgeReportMaker.SpanStructureGroups[i][0].Number;
                    sb.Append(num);
                    for (int j = 1; j < _bridgeReportMaker.SpanStructureGroups[i].Count; j++)
                    {
                        sb.Append(", ");
                        sb.Append(_bridgeReportMaker.SpanStructureGroups[i][j].Number);
                    }
                    tcMain.TabPages.Add($"tpSpanStructure{num}", $"Пролёт №{sb.ToString()}");
                    DataGridView dataGridView = GetCopiedMainGrid($"dgvSpanStructure{num}");
                    tcMain.TabPages[$"tpSpanStructure{num}"].Controls.Add(dataGridView);
                }
            }
            if (_bridgeReportMaker.SupportGroups != null)
            {
                for (int i = 0; i < _bridgeReportMaker.SupportGroups.Count; i++)
                {
                    StringBuilder sb = new StringBuilder();
                    var num = _bridgeReportMaker.SupportGroups[i][0].Number;
                    sb.Append(num);
                    for (int j = 1; j < _bridgeReportMaker.SupportGroups[i].Count; j++)
                    {
                        sb.Append(", ");
                        sb.Append(_bridgeReportMaker.SupportGroups[i][j].Number);
                    }
                    tcMain.TabPages.Add($"tpSupport{num}", $"Опора №{sb.ToString()}");
                    DataGridView dataGridView = GetCopiedMainGrid($"dgvSupport{num}");
                    tcMain.TabPages[$"tpSupport{num}"].Controls.Add(dataGridView);
                }
            }
            _photoControl = editPhotoControl;
            _photoControl.IsReadOnly = true;
            var photoControl = (Control)_photoControl;
            photoControl.Dock = DockStyle.Fill;
            tpPhotos.Controls.Add(photoControl);
            GetPhoto += () => StartLoadPhotos(_bridge);
            FillData();
        }

        private DataGridView GetCopiedMainGrid(string name)
        {
            DataGridView dataGridView = new DataGridView()
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Dock = DockStyle.Fill,
                RowHeadersVisible = false,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize,
                Name = name,
                AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    WrapMode = DataGridViewTriState.True,
                },
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToOrderColumns = false,
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
            };
            for (int j = 0; j < dgvMain.Columns.Count; j++)
            {
                var col = dgvMain.Columns[j];
                var clmn = new DataGridViewTextBoxColumn()
                {
                    Name = col.Name,
                    HeaderText = col.HeaderText,
                    FillWeight = col.FillWeight,
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                };
                dataGridView.Columns.Add(clmn);
            }
            return dataGridView;
        }

        private void FillData()
        {
            var reportBridgeData = _bridgeReportMaker.GetBridgeReport();
            for (int i = 0; i < reportBridgeData.Count; i++)
            {
                dgvMain.Rows.Add(reportBridgeData[i]);
            }
            var reportDefs = _bridgeReportMaker.GetDefectReport();
            for (int i = 0; i < reportDefs.Count; i++)
            {
                dgvDefects.Rows.Add(reportDefs[i]);
            }
            var reportDocs = _bridgeReportMaker.GetDocumentationsReport();
            for (int i = 0; i < reportDocs.Count; i++)
            {
                dgvDocumentations.Rows.Add(reportDocs[i]);
            }
            var reportsSpanStructures = _bridgeReportMaker.GetSpanStructuresReports();
            if (reportsSpanStructures != null)
            {
                for (int i = 0; i < reportsSpanStructures.Count; i++)
                {
                    var num = _bridgeReportMaker.SpanStructureGroups[i][0].Number;
                    var dataGridView = (DataGridView)tcMain.Controls.Find($"dgvSpanStructure{num}", true)[0];
                    for (int j = 0; j < reportsSpanStructures[i].Count; j++)
                    {
                        dataGridView.Rows.Add(reportsSpanStructures[i][j]);
                    }
                }
            }
            var reportsSupports = _bridgeReportMaker.GetSupportsReports();
            if (reportsSupports != null)
            {
                for (int i = 0; i < reportsSupports.Count; i++)
                {
                    var num = _bridgeReportMaker.SupportGroups[i][0].Number;
                    var dataGridView = (DataGridView)tcMain.Controls.Find($"dgvSupport{num}", true)[0];
                    for (int j = 0; j < reportsSupports[i].Count; j++)
                    {
                        dataGridView.Rows.Add(reportsSupports[i][j]);
                    }
                }
            }
            var reportsOthers = _bridgeReportMaker.GetOthersInfoReport();
            for (int i = 0; i < reportsOthers.Count; i++)
            {
                dgvOthers.Rows.Add(reportsOthers[i]);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Doc files (*.rtf)|*.rtf"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                AsyncLoaderForm.ShowMarquee((s, ee) =>
                {
                    try
                    {
                        BridgeReport.BridgePassportMake(dialog.FileName, _bridge, 12);
                        ReportHelper.Open(dialog.FileName);
                        //MessageBox.Show("Паспорт мостового сооружения успешно создан", "Создание паспорта мостового сооружения...");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Произошла ошибка создания паспорта мостового сооружения", "Создание паспорта мостового сооружения...");
                    }
                },
                    "Создание паспорта мостового сооружения...");
            }
        }

        #region Photos
        public event Action GetPhoto;
        public void StartLoadPhotos(Bridge bridge)
        {
            new Thread(() =>
            {
                var list = _bridgeManager.GetPhotosByBridge(bridge);
                SetPhotoList(list);
                bridge.Photos = list.ToList();
            }).Start();
        }
        public void SetPhotoList(IEnumerable<Photo> list)
        {
            _photoControl.SetPhotoList(list);
        }
        #endregion

        private void BridgeInfoView_Load(object sender, EventArgs e)
        {
            GetPhoto?.Invoke();
        }
    }
}
