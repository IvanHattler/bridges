namespace ITS.MapObjects.BridgesMapObject.Views
{
    partial class BridgeEditView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BridgeEditView));
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("МОСТ");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("РАЗВОДНОЙ МОСТ");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("ПУТЕПРОВОД");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("ЭСТАКАДА");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("СКОТОПРОГОН");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("ПОНТОН");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("ЗАСЫПНОГО ТИПА");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("ВИАДУК");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("АКВЕДУК");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("ЛЕТАЮЩИЙ ПАРОМ");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("ТОННЕЛЬ");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("МОСТОВЫЕ СООРУЖЕНИЯ", new System.Windows.Forms.TreeNode[] {
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17,
            treeNode18,
            treeNode19,
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23});
            this.bindingType = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lb_ConstructionType = new System.Windows.Forms.Label();
            this.tvConstructionType = new System.Windows.Forms.TreeView();
            this.albBridgeObstacles = new ITS.MapObjects.BridgesMapObject.Controls.AddableListBox();
            this.tbRoadName = new System.Windows.Forms.TextBox();
            this.gbRoadName = new System.Windows.Forms.GroupBox();
            this.tpPhotos = new System.Windows.Forms.TabPage();
            this.tpAddInfo3 = new System.Windows.Forms.TabPage();
            this.label36 = new System.Windows.Forms.Label();
            this.tbRoadSignsAfter = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tbRoadSignsBefore = new System.Windows.Forms.TextBox();
            this.dtpDateView = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.clbArrangements = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clbCommunications = new System.Windows.Forms.CheckedListBox();
            this.albInfoOfRepairs = new ITS.MapObjects.BridgesMapObject.Controls.AddableListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.llEditBuildingCompany = new System.Windows.Forms.LinkLabel();
            this.tbBuildingOrganization = new System.Windows.Forms.TextBox();
            this.llClearBuildingCompany = new System.Windows.Forms.LinkLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.llEditExploitOrganization = new System.Windows.Forms.LinkLabel();
            this.tbExploitOrganization = new System.Windows.Forms.TextBox();
            this.llClearExploitOrganization = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.llEditProjectOrganization = new System.Windows.Forms.LinkLabel();
            this.tbProjectOrganization = new System.Windows.Forms.TextBox();
            this.llClearProjectOrganization = new System.Windows.Forms.LinkLabel();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.chbAdapterPlatesLength = new System.Windows.Forms.CheckBox();
            this.nudAdapterPlatesLength = new System.Windows.Forms.NumericUpDown();
            this.label32 = new System.Windows.Forms.Label();
            this.flpAdapterPlatesAvailability = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.flpConesStrengthening = new System.Windows.Forms.FlowLayoutPanel();
            this.tpAddInfo2 = new System.Windows.Forms.TabPage();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.clbRegulatoryStructures = new System.Windows.Forms.CheckedListBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cbSlopeLongitudinalProfileAfter = new System.Windows.Forms.ComboBox();
            this.cbSlopeLongitudinalProfileBefore = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.nudEmbankmentHeightAfter = new System.Windows.Forms.NumericUpDown();
            this.nudEmbankmentHeightBefore = new System.Windows.Forms.NumericUpDown();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.nudSlopeLongitudinalAfter = new System.Windows.Forms.NumericUpDown();
            this.nudSlopeLongitudinalBefore = new System.Windows.Forms.NumericUpDown();
            this.nudCarriagewayWidthAfter = new System.Windows.Forms.NumericUpDown();
            this.nudCarriagewayWidthBefore = new System.Windows.Forms.NumericUpDown();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.nudRailingsHeight = new System.Windows.Forms.NumericUpDown();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.flpRailings = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.flpSidewalks = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.label22 = new System.Windows.Forms.Label();
            this.nudProtectionHeightOnApproach = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.flpProtectionTypeOnApproach = new System.Windows.Forms.FlowLayoutPanel();
            this.cbProtectionOnApproach = new System.Windows.Forms.CheckBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.nudProtectionHeightOnBridge = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.flpProtectionTypeOnBridge = new System.Windows.Forms.FlowLayoutPanel();
            this.cbProtectionOnBridge = new System.Windows.Forms.CheckBox();
            this.tpAddInfo1 = new System.Windows.Forms.TabPage();
            this.lbUnderbridgeClearance = new System.Windows.Forms.Label();
            this.lbHole = new System.Windows.Forms.Label();
            this.nudHole = new System.Windows.Forms.NumericUpDown();
            this.nudLength = new System.Windows.Forms.NumericUpDown();
            this.label63 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.lbSlopeLongitudinalForReport = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tbLongitudeScheme = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tbExpansionJointTypes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chbInversedStartOfBridge = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.cbDesignBurden = new System.Windows.Forms.ComboBox();
            this.cbCoverType = new System.Windows.Forms.ComboBox();
            this.lb_Cover = new System.Windows.Forms.Label();
            this.dtpConstructionDate = new System.Windows.Forms.DateTimePicker();
            this.dtpRepairsDate = new System.Windows.Forms.DateTimePicker();
            this.label50 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.chbHeightDimension = new System.Windows.Forms.CheckBox();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.nudWidthDimensionBrivewayCount = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.nudWidthDimensionG = new System.Windows.Forms.NumericUpDown();
            this.nudWidthDimensionC2 = new System.Windows.Forms.NumericUpDown();
            this.label57 = new System.Windows.Forms.Label();
            this.nudWidthDimensionC1 = new System.Windows.Forms.NumericUpDown();
            this.label58 = new System.Windows.Forms.Label();
            this.nudWidthDimensionT2 = new System.Windows.Forms.NumericUpDown();
            this.label59 = new System.Windows.Forms.Label();
            this.nudWidthDimensionT1 = new System.Windows.Forms.NumericUpDown();
            this.label60 = new System.Windows.Forms.Label();
            this.nudWidthDimensionC = new System.Windows.Forms.NumericUpDown();
            this.label61 = new System.Windows.Forms.Label();
            this.nudWidthDimensionB = new System.Windows.Forms.NumericUpDown();
            this.label62 = new System.Windows.Forms.Label();
            this.nudHeightDimension = new System.Windows.Forms.NumericUpDown();
            this.label65 = new System.Windows.Forms.Label();
            this.gbLocationInPlan = new System.Windows.Forms.GroupBox();
            this.flpLocationInPlan = new System.Windows.Forms.FlowLayoutPanel();
            this.nudObliqueAngle = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.cbDrainageType = new System.Windows.Forms.ComboBox();
            this.label53 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSlopeLateralProfile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nudSlopeLateralProfile = new System.Windows.Forms.NumericUpDown();
            this.label56 = new System.Windows.Forms.Label();
            this.tbDesignBurden = new System.Windows.Forms.TextBox();
            this.tpService = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.nudLongitudeSchemeLm = new System.Windows.Forms.NumericUpDown();
            this.atvSpanStructures = new ITS.MapObjects.BridgesMapObject.Controls.AddableTreeView();
            this.atvSupports = new ITS.MapObjects.BridgesMapObject.Controls.AddableTreeView();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.tbNotes = new System.Windows.Forms.TextBox();
            this.tpMainInfo = new System.Windows.Forms.TabPage();
            this.cbTerritory = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbCharactObstacleAddInfo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbCharactObstacleDirectionOfFlow = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.nudCharactObstacleV = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.nudCharactObstacleH = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.nudCharactObstacleB = new System.Windows.Forms.NumericUpDown();
            this.gbRoadCategory = new System.Windows.Forms.GroupBox();
            this.cbMarkup = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rb_Category_IV = new System.Windows.Forms.RadioButton();
            this.rb_Category_V = new System.Windows.Forms.RadioButton();
            this.rb_Category_III = new System.Windows.Forms.RadioButton();
            this.rb_Category_IBr = new System.Windows.Forms.RadioButton();
            this.rb_Category_IB = new System.Windows.Forms.RadioButton();
            this.rb_Category_II = new System.Windows.Forms.RadioButton();
            this.rb_Category_IA = new System.Windows.Forms.RadioButton();
            this.nudQuantityLineApproach = new System.Windows.Forms.NumericUpDown();
            this.lb_NumLineRoad = new System.Windows.Forms.Label();
            this.nudQuantityLineBridge = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.nudKilometrМ = new System.Windows.Forms.NumericUpDown();
            this.nudKilometrКМ = new System.Windows.Forms.NumericUpDown();
            this.gbNearestVillage = new System.Windows.Forms.GroupBox();
            this.tbNearestVillage = new System.Windows.Forms.TextBox();
            this.nudDistanceToVillageKM = new System.Windows.Forms.NumericUpDown();
            this.lb_NearestVillage = new System.Windows.Forms.Label();
            this.lb_DistanceToVillage = new System.Windows.Forms.Label();
            this.lb_Kilometr = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.nudRoadCode = new System.Windows.Forms.NumericUpDown();
            this.nudRoadControlCode = new System.Windows.Forms.NumericUpDown();
            this.nudSubjectCode = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_RoadCode = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.pbBridgeType = new System.Windows.Forms.PictureBox();
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.rb_RepairStatus = new System.Windows.Forms.RadioButton();
            this.rb_TemporaryStatus = new System.Windows.Forms.RadioButton();
            this.rb_DeconstructStatus = new System.Windows.Forms.RadioButton();
            this.rb_RequiredStatus = new System.Windows.Forms.RadioButton();
            this.rb_InstalledStatus = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbOne = new System.Windows.Forms.RadioButton();
            this.rbLeft = new System.Windows.Forms.RadioButton();
            this.rbRight = new System.Windows.Forms.RadioButton();
            this.atvDocumentations = new ITS.MapObjects.BridgesMapObject.Controls.AddableTreeView();
            this.albDefects = new ITS.MapObjects.BridgesMapObject.Controls.AddableListBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.clbMoveType = new System.Windows.Forms.CheckedListBox();
            this.nudHeightLevelNumber = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cbQualityBridge = new System.Windows.Forms.ComboBox();
            this.lb_QualityBridge = new System.Windows.Forms.Label();
            this.chbIsOverTheRoad = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbConstructionName = new System.Windows.Forms.TextBox();
            this.tbBridgeFullName = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingType)).BeginInit();
            this.gbRoadName.SuspendLayout();
            this.tpAddInfo3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox23.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdapterPlatesLength)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.tpAddInfo2.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmbankmentHeightAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmbankmentHeightBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlopeLongitudinalAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlopeLongitudinalBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCarriagewayWidthAfter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCarriagewayWidthBefore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRailingsHeight)).BeginInit();
            this.groupBox20.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProtectionHeightOnApproach)).BeginInit();
            this.groupBox17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProtectionHeightOnBridge)).BeginInit();
            this.tpAddInfo1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).BeginInit();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionBrivewayCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionC2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionC1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionT2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionT1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightDimension)).BeginInit();
            this.gbLocationInPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudObliqueAngle)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlopeLateralProfile)).BeginInit();
            this.tpService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitudeSchemeLm)).BeginInit();
            this.groupBox24.SuspendLayout();
            this.tpMainInfo.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharactObstacleV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharactObstacleH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharactObstacleB)).BeginInit();
            this.gbRoadCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityLineApproach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityLineBridge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKilometrМ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKilometrКМ)).BeginInit();
            this.gbNearestVillage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistanceToVillageKM)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoadCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoadControlCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubjectCode)).BeginInit();
            this.groupBox15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBridgeType)).BeginInit();
            this.gbStatus.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightLevelNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(578, 488);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 22);
            this.btnOK.TabIndex = 44;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(656, 488);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lb_ConstructionType
            // 
            this.lb_ConstructionType.AutoSize = true;
            this.lb_ConstructionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_ConstructionType.Location = new System.Drawing.Point(24, 200);
            this.lb_ConstructionType.Name = "lb_ConstructionType";
            this.lb_ConstructionType.Size = new System.Drawing.Size(178, 13);
            this.lb_ConstructionType.TabIndex = 69;
            this.lb_ConstructionType.Text = "Название мостового сооружения";
            this.toolTip1.SetToolTip(this.lb_ConstructionType, resources.GetString("lb_ConstructionType.ToolTip"));
            // 
            // tvConstructionType
            // 
            this.tvConstructionType.Location = new System.Drawing.Point(1, 0);
            this.tvConstructionType.Name = "tvConstructionType";
            treeNode13.Name = "type_1";
            treeNode13.Text = "МОСТ";
            treeNode14.Name = "type_1_1";
            treeNode14.Text = "РАЗВОДНОЙ МОСТ";
            treeNode15.Name = "type_2";
            treeNode15.Text = "ПУТЕПРОВОД";
            treeNode16.Name = "type_3";
            treeNode16.Text = "ЭСТАКАДА";
            treeNode17.Name = "type_4";
            treeNode17.Text = "СКОТОПРОГОН";
            treeNode18.Name = "type_5";
            treeNode18.Text = "ПОНТОН";
            treeNode19.Name = "type_6";
            treeNode19.Text = "ЗАСЫПНОГО ТИПА";
            treeNode20.Name = "type_7";
            treeNode20.Text = "ВИАДУК";
            treeNode21.Name = "type_8";
            treeNode21.Text = "АКВЕДУК";
            treeNode22.Name = "type_9";
            treeNode22.Text = "ЛЕТАЮЩИЙ ПАРОМ";
            treeNode23.Name = "Узел0";
            treeNode23.Text = "ТОННЕЛЬ";
            treeNode24.Name = "Узел0";
            treeNode24.Text = "МОСТОВЫЕ СООРУЖЕНИЯ";
            this.tvConstructionType.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode24});
            this.tvConstructionType.Size = new System.Drawing.Size(215, 200);
            this.tvConstructionType.TabIndex = 0;
            this.tvConstructionType.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvConstructionType_AfterSelect);
            // 
            // albBridgeObstacles
            // 
            this.albBridgeObstacles.Location = new System.Drawing.Point(1, 329);
            this.albBridgeObstacles.Name = "albBridgeObstacles";
            this.albBridgeObstacles.Size = new System.Drawing.Size(212, 128);
            this.albBridgeObstacles.TabIndex = 99;
            this.albBridgeObstacles.ElementAdding += new ITS.MapObjects.BridgesMapObject.Controls.AddableListBox.GetObject(this.albBridgeObstacles_ElementAdding);
            // 
            // tbRoadName
            // 
            this.tbRoadName.Location = new System.Drawing.Point(6, 21);
            this.tbRoadName.MaxLength = 255;
            this.tbRoadName.Multiline = true;
            this.tbRoadName.Name = "tbRoadName";
            this.tbRoadName.Size = new System.Drawing.Size(200, 23);
            this.tbRoadName.TabIndex = 5;
            // 
            // gbRoadName
            // 
            this.gbRoadName.Controls.Add(this.tbRoadName);
            this.gbRoadName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbRoadName.Location = new System.Drawing.Point(1, 457);
            this.gbRoadName.Name = "gbRoadName";
            this.gbRoadName.Size = new System.Drawing.Size(212, 51);
            this.gbRoadName.TabIndex = 86;
            this.gbRoadName.TabStop = false;
            this.gbRoadName.Text = " Название дороги ";
            // 
            // tpPhotos
            // 
            this.tpPhotos.Location = new System.Drawing.Point(4, 22);
            this.tpPhotos.Name = "tpPhotos";
            this.tpPhotos.Size = new System.Drawing.Size(507, 456);
            this.tpPhotos.TabIndex = 7;
            this.tpPhotos.Text = "Фото";
            this.tpPhotos.UseVisualStyleBackColor = true;
            // 
            // tpAddInfo3
            // 
            this.tpAddInfo3.Controls.Add(this.label36);
            this.tpAddInfo3.Controls.Add(this.tbRoadSignsAfter);
            this.tpAddInfo3.Controls.Add(this.label35);
            this.tpAddInfo3.Controls.Add(this.tbRoadSignsBefore);
            this.tpAddInfo3.Controls.Add(this.dtpDateView);
            this.tpAddInfo3.Controls.Add(this.label1);
            this.tpAddInfo3.Controls.Add(this.groupBox6);
            this.tpAddInfo3.Controls.Add(this.groupBox2);
            this.tpAddInfo3.Controls.Add(this.albInfoOfRepairs);
            this.tpAddInfo3.Controls.Add(this.groupBox5);
            this.tpAddInfo3.Controls.Add(this.groupBox4);
            this.tpAddInfo3.Controls.Add(this.groupBox3);
            this.tpAddInfo3.Controls.Add(this.groupBox23);
            this.tpAddInfo3.Controls.Add(this.groupBox10);
            this.tpAddInfo3.Location = new System.Drawing.Point(4, 22);
            this.tpAddInfo3.Name = "tpAddInfo3";
            this.tpAddInfo3.Size = new System.Drawing.Size(507, 456);
            this.tpAddInfo3.TabIndex = 8;
            this.tpAddInfo3.Text = "Доп. инфо 3";
            this.tpAddInfo3.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label36.Location = new System.Drawing.Point(275, 4);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(182, 13);
            this.label36.TabIndex = 116;
            this.label36.Text = "Дорожные знаки за сооружением";
            this.toolTip1.SetToolTip(this.label36, resources.GetString("label36.ToolTip"));
            // 
            // tbRoadSignsAfter
            // 
            this.tbRoadSignsAfter.Location = new System.Drawing.Point(248, 20);
            this.tbRoadSignsAfter.MaxLength = 255;
            this.tbRoadSignsAfter.Name = "tbRoadSignsAfter";
            this.tbRoadSignsAfter.Size = new System.Drawing.Size(254, 20);
            this.tbRoadSignsAfter.TabIndex = 117;
            this.toolTip1.SetToolTip(this.tbRoadSignsAfter, resources.GetString("tbRoadSignsAfter.ToolTip"));
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label35.Location = new System.Drawing.Point(19, 414);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(200, 13);
            this.label35.TabIndex = 101;
            this.label35.Text = "Дорожные знаки перед сооружением";
            this.toolTip1.SetToolTip(this.label35, resources.GetString("label35.ToolTip"));
            // 
            // tbRoadSignsBefore
            // 
            this.tbRoadSignsBefore.Location = new System.Drawing.Point(3, 430);
            this.tbRoadSignsBefore.MaxLength = 255;
            this.tbRoadSignsBefore.Name = "tbRoadSignsBefore";
            this.tbRoadSignsBefore.Size = new System.Drawing.Size(223, 20);
            this.tbRoadSignsBefore.TabIndex = 115;
            this.toolTip1.SetToolTip(this.tbRoadSignsBefore, resources.GetString("tbRoadSignsBefore.ToolTip"));
            // 
            // dtpDateView
            // 
            this.dtpDateView.Location = new System.Drawing.Point(354, 435);
            this.dtpDateView.Name = "dtpDateView";
            this.dtpDateView.ShowCheckBox = true;
            this.dtpDateView.Size = new System.Drawing.Size(146, 20);
            this.dtpDateView.TabIndex = 114;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(245, 438);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 113;
            this.label1.Text = "Дата обследования";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.clbArrangements);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox6.Location = new System.Drawing.Point(229, 145);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(273, 143);
            this.groupBox6.TabIndex = 110;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = " Обустройства ";
            // 
            // clbArrangements
            // 
            this.clbArrangements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbArrangements.CheckOnClick = true;
            this.clbArrangements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbArrangements.FormattingEnabled = true;
            this.clbArrangements.HorizontalScrollbar = true;
            this.clbArrangements.Location = new System.Drawing.Point(3, 16);
            this.clbArrangements.Name = "clbArrangements";
            this.clbArrangements.Size = new System.Drawing.Size(267, 124);
            this.clbArrangements.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clbCommunications);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(229, 287);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(273, 149);
            this.groupBox2.TabIndex = 111;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " Коммуникации ";
            // 
            // clbCommunications
            // 
            this.clbCommunications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbCommunications.CheckOnClick = true;
            this.clbCommunications.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbCommunications.FormattingEnabled = true;
            this.clbCommunications.HorizontalScrollbar = true;
            this.clbCommunications.Location = new System.Drawing.Point(3, 16);
            this.clbCommunications.Name = "clbCommunications";
            this.clbCommunications.Size = new System.Drawing.Size(267, 130);
            this.clbCommunications.TabIndex = 1;
            // 
            // albInfoOfRepairs
            // 
            this.albInfoOfRepairs.Location = new System.Drawing.Point(248, 46);
            this.albInfoOfRepairs.Name = "albInfoOfRepairs";
            this.albInfoOfRepairs.Size = new System.Drawing.Size(254, 98);
            this.albInfoOfRepairs.TabIndex = 109;
            this.albInfoOfRepairs.ElementAdding += new ITS.MapObjects.BridgesMapObject.Controls.AddableListBox.GetObject(this.albInfoOfRepairs_ElementAdding);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.llEditBuildingCompany);
            this.groupBox5.Controls.Add(this.tbBuildingOrganization);
            this.groupBox5.Controls.Add(this.llClearBuildingCompany);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(3, 303);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(219, 51);
            this.groupBox5.TabIndex = 104;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Строительная организация ";
            // 
            // llEditBuildingCompany
            // 
            this.llEditBuildingCompany.AutoSize = true;
            this.llEditBuildingCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llEditBuildingCompany.Location = new System.Drawing.Point(132, 35);
            this.llEditBuildingCompany.Name = "llEditBuildingCompany";
            this.llEditBuildingCompany.Size = new System.Drawing.Size(84, 13);
            this.llEditBuildingCompany.TabIndex = 100;
            this.llEditBuildingCompany.TabStop = true;
            this.llEditBuildingCompany.Text = "Редактировать";
            this.llEditBuildingCompany.Click += new System.EventHandler(this.llEditBuildingCompany_Click);
            // 
            // tbBuildingOrganization
            // 
            this.tbBuildingOrganization.Enabled = false;
            this.tbBuildingOrganization.Location = new System.Drawing.Point(6, 15);
            this.tbBuildingOrganization.Name = "tbBuildingOrganization";
            this.tbBuildingOrganization.Size = new System.Drawing.Size(210, 20);
            this.tbBuildingOrganization.TabIndex = 84;
            this.tbBuildingOrganization.Text = "<Нет данных>";
            // 
            // llClearBuildingCompany
            // 
            this.llClearBuildingCompany.AutoSize = true;
            this.llClearBuildingCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llClearBuildingCompany.Location = new System.Drawing.Point(3, 35);
            this.llClearBuildingCompany.Name = "llClearBuildingCompany";
            this.llClearBuildingCompany.Size = new System.Drawing.Size(54, 13);
            this.llClearBuildingCompany.TabIndex = 99;
            this.llClearBuildingCompany.TabStop = true;
            this.llClearBuildingCompany.Text = "Очистить";
            this.llClearBuildingCompany.Click += new System.EventHandler(this.llClearBuildingCompany_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.llEditExploitOrganization);
            this.groupBox4.Controls.Add(this.tbExploitOrganization);
            this.groupBox4.Controls.Add(this.llClearExploitOrganization);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(3, 357);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(219, 51);
            this.groupBox4.TabIndex = 103;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " Эксплуатирующая организация ";
            // 
            // llEditExploitOrganization
            // 
            this.llEditExploitOrganization.AutoSize = true;
            this.llEditExploitOrganization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llEditExploitOrganization.Location = new System.Drawing.Point(132, 35);
            this.llEditExploitOrganization.Name = "llEditExploitOrganization";
            this.llEditExploitOrganization.Size = new System.Drawing.Size(84, 13);
            this.llEditExploitOrganization.TabIndex = 100;
            this.llEditExploitOrganization.TabStop = true;
            this.llEditExploitOrganization.Text = "Редактировать";
            this.llEditExploitOrganization.Click += new System.EventHandler(this.llEditExploitOrganization_Click);
            // 
            // tbExploitOrganization
            // 
            this.tbExploitOrganization.Enabled = false;
            this.tbExploitOrganization.Location = new System.Drawing.Point(6, 15);
            this.tbExploitOrganization.Name = "tbExploitOrganization";
            this.tbExploitOrganization.Size = new System.Drawing.Size(210, 20);
            this.tbExploitOrganization.TabIndex = 84;
            this.tbExploitOrganization.Text = "<Нет данных>";
            // 
            // llClearExploitOrganization
            // 
            this.llClearExploitOrganization.AutoSize = true;
            this.llClearExploitOrganization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llClearExploitOrganization.Location = new System.Drawing.Point(3, 35);
            this.llClearExploitOrganization.Name = "llClearExploitOrganization";
            this.llClearExploitOrganization.Size = new System.Drawing.Size(54, 13);
            this.llClearExploitOrganization.TabIndex = 99;
            this.llClearExploitOrganization.TabStop = true;
            this.llClearExploitOrganization.Text = "Очистить";
            this.llClearExploitOrganization.Click += new System.EventHandler(this.llClearExploitOrganization_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.llEditProjectOrganization);
            this.groupBox3.Controls.Add(this.tbProjectOrganization);
            this.groupBox3.Controls.Add(this.llClearProjectOrganization);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(3, 246);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(219, 51);
            this.groupBox3.TabIndex = 102;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " Проектная организация ";
            // 
            // llEditProjectOrganization
            // 
            this.llEditProjectOrganization.AutoSize = true;
            this.llEditProjectOrganization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llEditProjectOrganization.Location = new System.Drawing.Point(132, 35);
            this.llEditProjectOrganization.Name = "llEditProjectOrganization";
            this.llEditProjectOrganization.Size = new System.Drawing.Size(84, 13);
            this.llEditProjectOrganization.TabIndex = 100;
            this.llEditProjectOrganization.TabStop = true;
            this.llEditProjectOrganization.Text = "Редактировать";
            this.llEditProjectOrganization.Click += new System.EventHandler(this.llEditProjectOrganization_Click);
            // 
            // tbProjectOrganization
            // 
            this.tbProjectOrganization.Enabled = false;
            this.tbProjectOrganization.Location = new System.Drawing.Point(6, 15);
            this.tbProjectOrganization.Name = "tbProjectOrganization";
            this.tbProjectOrganization.Size = new System.Drawing.Size(210, 20);
            this.tbProjectOrganization.TabIndex = 84;
            this.tbProjectOrganization.Text = "<Нет данных>";
            // 
            // llClearProjectOrganization
            // 
            this.llClearProjectOrganization.AutoSize = true;
            this.llClearProjectOrganization.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llClearProjectOrganization.Location = new System.Drawing.Point(3, 35);
            this.llClearProjectOrganization.Name = "llClearProjectOrganization";
            this.llClearProjectOrganization.Size = new System.Drawing.Size(54, 13);
            this.llClearProjectOrganization.TabIndex = 99;
            this.llClearProjectOrganization.TabStop = true;
            this.llClearProjectOrganization.Text = "Очистить";
            this.llClearProjectOrganization.Click += new System.EventHandler(this.llClearProjectOrganization_Click);
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.chbAdapterPlatesLength);
            this.groupBox23.Controls.Add(this.nudAdapterPlatesLength);
            this.groupBox23.Controls.Add(this.label32);
            this.groupBox23.Controls.Add(this.flpAdapterPlatesAvailability);
            this.groupBox23.Location = new System.Drawing.Point(3, 147);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(133, 98);
            this.groupBox23.TabIndex = 100;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = " Переходные плиты ";
            // 
            // chbAdapterPlatesLength
            // 
            this.chbAdapterPlatesLength.AutoSize = true;
            this.chbAdapterPlatesLength.Location = new System.Drawing.Point(58, 78);
            this.chbAdapterPlatesLength.Name = "chbAdapterPlatesLength";
            this.chbAdapterPlatesLength.Size = new System.Drawing.Size(15, 14);
            this.chbAdapterPlatesLength.TabIndex = 92;
            this.chbAdapterPlatesLength.UseVisualStyleBackColor = true;
            this.chbAdapterPlatesLength.CheckedChanged += new System.EventHandler(this.chbAdapterPlatesLength_CheckedChanged);
            // 
            // nudAdapterPlatesLength
            // 
            this.nudAdapterPlatesLength.DecimalPlaces = 2;
            this.nudAdapterPlatesLength.Enabled = false;
            this.nudAdapterPlatesLength.Location = new System.Drawing.Point(73, 75);
            this.nudAdapterPlatesLength.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudAdapterPlatesLength.Name = "nudAdapterPlatesLength";
            this.nudAdapterPlatesLength.Size = new System.Drawing.Size(57, 20);
            this.nudAdapterPlatesLength.TabIndex = 91;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label32.Location = new System.Drawing.Point(1, 78);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(57, 13);
            this.label32.TabIndex = 90;
            this.label32.Text = "Длина, м ";
            // 
            // flpAdapterPlatesAvailability
            // 
            this.flpAdapterPlatesAvailability.AutoScroll = true;
            this.flpAdapterPlatesAvailability.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpAdapterPlatesAvailability.Location = new System.Drawing.Point(3, 13);
            this.flpAdapterPlatesAvailability.Margin = new System.Windows.Forms.Padding(0);
            this.flpAdapterPlatesAvailability.Name = "flpAdapterPlatesAvailability";
            this.flpAdapterPlatesAvailability.Size = new System.Drawing.Size(127, 60);
            this.flpAdapterPlatesAvailability.TabIndex = 89;
            this.flpAdapterPlatesAvailability.WrapContents = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.flpConesStrengthening);
            this.groupBox10.Location = new System.Drawing.Point(3, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(239, 144);
            this.groupBox10.TabIndex = 93;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = " Укрепление конусов ";
            // 
            // flpConesStrengthening
            // 
            this.flpConesStrengthening.AutoScroll = true;
            this.flpConesStrengthening.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpConesStrengthening.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpConesStrengthening.Location = new System.Drawing.Point(3, 16);
            this.flpConesStrengthening.Margin = new System.Windows.Forms.Padding(0);
            this.flpConesStrengthening.Name = "flpConesStrengthening";
            this.flpConesStrengthening.Size = new System.Drawing.Size(233, 125);
            this.flpConesStrengthening.TabIndex = 88;
            this.flpConesStrengthening.WrapContents = false;
            // 
            // tpAddInfo2
            // 
            this.tpAddInfo2.Controls.Add(this.groupBox22);
            this.tpAddInfo2.Controls.Add(this.groupBox21);
            this.tpAddInfo2.Controls.Add(this.label24);
            this.tpAddInfo2.Controls.Add(this.nudRailingsHeight);
            this.tpAddInfo2.Controls.Add(this.groupBox20);
            this.tpAddInfo2.Controls.Add(this.groupBox19);
            this.tpAddInfo2.Controls.Add(this.groupBox18);
            this.tpAddInfo2.Controls.Add(this.groupBox17);
            this.tpAddInfo2.Location = new System.Drawing.Point(4, 22);
            this.tpAddInfo2.Name = "tpAddInfo2";
            this.tpAddInfo2.Size = new System.Drawing.Size(507, 456);
            this.tpAddInfo2.TabIndex = 6;
            this.tpAddInfo2.Text = "Доп. инфо 2";
            this.tpAddInfo2.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Controls.Add(this.clbRegulatoryStructures);
            this.groupBox22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox22.Location = new System.Drawing.Point(252, 332);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(252, 121);
            this.groupBox22.TabIndex = 102;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "Регуляционные сооружения ";
            // 
            // clbRegulatoryStructures
            // 
            this.clbRegulatoryStructures.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbRegulatoryStructures.CheckOnClick = true;
            this.clbRegulatoryStructures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbRegulatoryStructures.FormattingEnabled = true;
            this.clbRegulatoryStructures.Location = new System.Drawing.Point(3, 16);
            this.clbRegulatoryStructures.Name = "clbRegulatoryStructures";
            this.clbRegulatoryStructures.Size = new System.Drawing.Size(246, 102);
            this.clbRegulatoryStructures.TabIndex = 0;
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.label31);
            this.groupBox21.Controls.Add(this.cbSlopeLongitudinalProfileAfter);
            this.groupBox21.Controls.Add(this.cbSlopeLongitudinalProfileBefore);
            this.groupBox21.Controls.Add(this.label30);
            this.groupBox21.Controls.Add(this.nudEmbankmentHeightAfter);
            this.groupBox21.Controls.Add(this.nudEmbankmentHeightBefore);
            this.groupBox21.Controls.Add(this.label29);
            this.groupBox21.Controls.Add(this.label28);
            this.groupBox21.Controls.Add(this.nudSlopeLongitudinalAfter);
            this.groupBox21.Controls.Add(this.nudSlopeLongitudinalBefore);
            this.groupBox21.Controls.Add(this.nudCarriagewayWidthAfter);
            this.groupBox21.Controls.Add(this.nudCarriagewayWidthBefore);
            this.groupBox21.Controls.Add(this.label27);
            this.groupBox21.Controls.Add(this.label26);
            this.groupBox21.Location = new System.Drawing.Point(190, 187);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(314, 146);
            this.groupBox21.TabIndex = 101;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = " Подходы ";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label31.Location = new System.Drawing.Point(95, 75);
            this.label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(113, 13);
            this.label31.TabIndex = 108;
            this.label31.Text = "Направление уклона";
            // 
            // cbSlopeLongitudinalProfileAfter
            // 
            this.cbSlopeLongitudinalProfileAfter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSlopeLongitudinalProfileAfter.FormattingEnabled = true;
            this.cbSlopeLongitudinalProfileAfter.Location = new System.Drawing.Point(160, 94);
            this.cbSlopeLongitudinalProfileAfter.Name = "cbSlopeLongitudinalProfileAfter";
            this.cbSlopeLongitudinalProfileAfter.Size = new System.Drawing.Size(154, 21);
            this.cbSlopeLongitudinalProfileAfter.TabIndex = 107;
            // 
            // cbSlopeLongitudinalProfileBefore
            // 
            this.cbSlopeLongitudinalProfileBefore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSlopeLongitudinalProfileBefore.FormattingEnabled = true;
            this.cbSlopeLongitudinalProfileBefore.Location = new System.Drawing.Point(4, 94);
            this.cbSlopeLongitudinalProfileBefore.Name = "cbSlopeLongitudinalProfileBefore";
            this.cbSlopeLongitudinalProfileBefore.Size = new System.Drawing.Size(154, 21);
            this.cbSlopeLongitudinalProfileBefore.TabIndex = 106;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label30.Location = new System.Drawing.Point(3, 123);
            this.label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(100, 13);
            this.label30.TabIndex = 105;
            this.label30.Text = "Высота насыпи, м";
            this.toolTip1.SetToolTip(this.label30, "Принимают в начале и конце мостового сооружения от\r\nуровня бровки насыпи до уровн" +
        "я естественного грунта");
            // 
            // nudEmbankmentHeightAfter
            // 
            this.nudEmbankmentHeightAfter.DecimalPlaces = 2;
            this.nudEmbankmentHeightAfter.Location = new System.Drawing.Point(231, 121);
            this.nudEmbankmentHeightAfter.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudEmbankmentHeightAfter.Name = "nudEmbankmentHeightAfter";
            this.nudEmbankmentHeightAfter.Size = new System.Drawing.Size(67, 20);
            this.nudEmbankmentHeightAfter.TabIndex = 104;
            this.toolTip1.SetToolTip(this.nudEmbankmentHeightAfter, "Принимают в конце мостового сооружения от\r\nуровня бровки насыпи до уровня естеств" +
        "енного грунта");
            // 
            // nudEmbankmentHeightBefore
            // 
            this.nudEmbankmentHeightBefore.DecimalPlaces = 2;
            this.nudEmbankmentHeightBefore.Location = new System.Drawing.Point(125, 122);
            this.nudEmbankmentHeightBefore.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudEmbankmentHeightBefore.Name = "nudEmbankmentHeightBefore";
            this.nudEmbankmentHeightBefore.Size = new System.Drawing.Size(67, 20);
            this.nudEmbankmentHeightBefore.TabIndex = 103;
            this.toolTip1.SetToolTip(this.nudEmbankmentHeightBefore, "Принимают в начале мостового сооружения от\r\nуровня бровки насыпи до уровня естест" +
        "венного грунта");
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label29.Location = new System.Drawing.Point(2, 55);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(120, 13);
            this.label29.TabIndex = 102;
            this.label29.Text = "Продольный уклон, ‰";
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label28.Location = new System.Drawing.Point(2, 26);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(113, 29);
            this.label28.TabIndex = 101;
            this.label28.Text = "Ширина проезжей части, м";
            this.toolTip1.SetToolTip(this.label28, "Замеряют на расстоянии\r\n25 м от начала и конца мостового сооружения");
            // 
            // nudSlopeLongitudinalAfter
            // 
            this.nudSlopeLongitudinalAfter.DecimalPlaces = 2;
            this.nudSlopeLongitudinalAfter.Location = new System.Drawing.Point(231, 52);
            this.nudSlopeLongitudinalAfter.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudSlopeLongitudinalAfter.Name = "nudSlopeLongitudinalAfter";
            this.nudSlopeLongitudinalAfter.Size = new System.Drawing.Size(67, 20);
            this.nudSlopeLongitudinalAfter.TabIndex = 100;
            // 
            // nudSlopeLongitudinalBefore
            // 
            this.nudSlopeLongitudinalBefore.DecimalPlaces = 2;
            this.nudSlopeLongitudinalBefore.Location = new System.Drawing.Point(125, 52);
            this.nudSlopeLongitudinalBefore.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudSlopeLongitudinalBefore.Name = "nudSlopeLongitudinalBefore";
            this.nudSlopeLongitudinalBefore.Size = new System.Drawing.Size(67, 20);
            this.nudSlopeLongitudinalBefore.TabIndex = 99;
            // 
            // nudCarriagewayWidthAfter
            // 
            this.nudCarriagewayWidthAfter.DecimalPlaces = 2;
            this.nudCarriagewayWidthAfter.Location = new System.Drawing.Point(231, 26);
            this.nudCarriagewayWidthAfter.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudCarriagewayWidthAfter.Name = "nudCarriagewayWidthAfter";
            this.nudCarriagewayWidthAfter.Size = new System.Drawing.Size(67, 20);
            this.nudCarriagewayWidthAfter.TabIndex = 98;
            this.toolTip1.SetToolTip(this.nudCarriagewayWidthAfter, "Замеряют на расстоянии\r\n25 м от конца мостового сооружения");
            // 
            // nudCarriagewayWidthBefore
            // 
            this.nudCarriagewayWidthBefore.DecimalPlaces = 2;
            this.nudCarriagewayWidthBefore.Location = new System.Drawing.Point(125, 26);
            this.nudCarriagewayWidthBefore.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudCarriagewayWidthBefore.Name = "nudCarriagewayWidthBefore";
            this.nudCarriagewayWidthBefore.Size = new System.Drawing.Size(67, 20);
            this.nudCarriagewayWidthBefore.TabIndex = 97;
            this.toolTip1.SetToolTip(this.nudCarriagewayWidthBefore, "Замеряют на расстоянии\r\n25 м от начала мостового сооружения");
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label27.Location = new System.Drawing.Point(219, 10);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(92, 13);
            this.label27.TabIndex = 97;
            this.label27.Text = "За сооружением";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label26.Location = new System.Drawing.Point(71, 10);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(111, 13);
            this.label26.TabIndex = 96;
            this.label26.Text = "Перед сооружением";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(200, 167);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(92, 13);
            this.label24.TabIndex = 100;
            this.label24.Text = "Высота перил, м";
            // 
            // nudRailingsHeight
            // 
            this.nudRailingsHeight.DecimalPlaces = 2;
            this.nudRailingsHeight.Location = new System.Drawing.Point(359, 166);
            this.nudRailingsHeight.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudRailingsHeight.Name = "nudRailingsHeight";
            this.nudRailingsHeight.Size = new System.Drawing.Size(72, 20);
            this.nudRailingsHeight.TabIndex = 99;
            // 
            // groupBox20
            // 
            this.groupBox20.Controls.Add(this.flpRailings);
            this.groupBox20.Location = new System.Drawing.Point(184, 1);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(320, 163);
            this.groupBox20.TabIndex = 98;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = " Тип перил ";
            // 
            // flpRailings
            // 
            this.flpRailings.AutoScroll = true;
            this.flpRailings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpRailings.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpRailings.Location = new System.Drawing.Point(3, 16);
            this.flpRailings.Margin = new System.Windows.Forms.Padding(0);
            this.flpRailings.Name = "flpRailings";
            this.flpRailings.Size = new System.Drawing.Size(314, 144);
            this.flpRailings.TabIndex = 88;
            this.flpRailings.WrapContents = false;
            // 
            // groupBox19
            // 
            this.groupBox19.Controls.Add(this.flpSidewalks);
            this.groupBox19.Location = new System.Drawing.Point(6, 332);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(243, 119);
            this.groupBox19.TabIndex = 97;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = " Тип тротуара ";
            // 
            // flpSidewalks
            // 
            this.flpSidewalks.AutoScroll = true;
            this.flpSidewalks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSidewalks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSidewalks.Location = new System.Drawing.Point(3, 16);
            this.flpSidewalks.Margin = new System.Windows.Forms.Padding(0);
            this.flpSidewalks.Name = "flpSidewalks";
            this.flpSidewalks.Size = new System.Drawing.Size(237, 100);
            this.flpSidewalks.TabIndex = 88;
            this.flpSidewalks.WrapContents = false;
            // 
            // groupBox18
            // 
            this.groupBox18.Controls.Add(this.label22);
            this.groupBox18.Controls.Add(this.nudProtectionHeightOnApproach);
            this.groupBox18.Controls.Add(this.label23);
            this.groupBox18.Controls.Add(this.flpProtectionTypeOnApproach);
            this.groupBox18.Controls.Add(this.cbProtectionOnApproach);
            this.groupBox18.Location = new System.Drawing.Point(3, 166);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(179, 163);
            this.groupBox18.TabIndex = 95;
            this.groupBox18.TabStop = false;
            this.groupBox18.Text = "     Ограждение на подходах ";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(17, 18);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(90, 13);
            this.label22.TabIndex = 94;
            this.label22.Text = "Тип ограждения";
            // 
            // nudProtectionHeightOnApproach
            // 
            this.nudProtectionHeightOnApproach.DecimalPlaces = 2;
            this.nudProtectionHeightOnApproach.Location = new System.Drawing.Point(94, 141);
            this.nudProtectionHeightOnApproach.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudProtectionHeightOnApproach.Name = "nudProtectionHeightOnApproach";
            this.nudProtectionHeightOnApproach.Size = new System.Drawing.Size(81, 20);
            this.nudProtectionHeightOnApproach.TabIndex = 93;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(7, 143);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(59, 13);
            this.label23.TabIndex = 90;
            this.label23.Text = "Высота, м";
            // 
            // flpProtectionTypeOnApproach
            // 
            this.flpProtectionTypeOnApproach.AutoScroll = true;
            this.flpProtectionTypeOnApproach.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpProtectionTypeOnApproach.Location = new System.Drawing.Point(3, 31);
            this.flpProtectionTypeOnApproach.Margin = new System.Windows.Forms.Padding(0);
            this.flpProtectionTypeOnApproach.Name = "flpProtectionTypeOnApproach";
            this.flpProtectionTypeOnApproach.Size = new System.Drawing.Size(176, 104);
            this.flpProtectionTypeOnApproach.TabIndex = 89;
            this.flpProtectionTypeOnApproach.WrapContents = false;
            // 
            // cbProtectionOnApproach
            // 
            this.cbProtectionOnApproach.AutoSize = true;
            this.cbProtectionOnApproach.Checked = true;
            this.cbProtectionOnApproach.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProtectionOnApproach.Location = new System.Drawing.Point(5, 2);
            this.cbProtectionOnApproach.Name = "cbProtectionOnApproach";
            this.cbProtectionOnApproach.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbProtectionOnApproach.Size = new System.Drawing.Size(15, 14);
            this.cbProtectionOnApproach.TabIndex = 88;
            this.cbProtectionOnApproach.UseVisualStyleBackColor = true;
            // 
            // groupBox17
            // 
            this.groupBox17.Controls.Add(this.label21);
            this.groupBox17.Controls.Add(this.nudProtectionHeightOnBridge);
            this.groupBox17.Controls.Add(this.label20);
            this.groupBox17.Controls.Add(this.flpProtectionTypeOnBridge);
            this.groupBox17.Controls.Add(this.cbProtectionOnBridge);
            this.groupBox17.Location = new System.Drawing.Point(3, 1);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(179, 163);
            this.groupBox17.TabIndex = 92;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "     Ограждение на сооружении ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(17, 18);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(90, 13);
            this.label21.TabIndex = 94;
            this.label21.Text = "Тип ограждения";
            // 
            // nudProtectionHeightOnBridge
            // 
            this.nudProtectionHeightOnBridge.DecimalPlaces = 2;
            this.nudProtectionHeightOnBridge.Location = new System.Drawing.Point(94, 139);
            this.nudProtectionHeightOnBridge.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudProtectionHeightOnBridge.Name = "nudProtectionHeightOnBridge";
            this.nudProtectionHeightOnBridge.Size = new System.Drawing.Size(81, 20);
            this.nudProtectionHeightOnBridge.TabIndex = 93;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(7, 142);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(59, 13);
            this.label20.TabIndex = 90;
            this.label20.Text = "Высота, м";
            // 
            // flpProtectionTypeOnBridge
            // 
            this.flpProtectionTypeOnBridge.AutoScroll = true;
            this.flpProtectionTypeOnBridge.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpProtectionTypeOnBridge.Location = new System.Drawing.Point(3, 31);
            this.flpProtectionTypeOnBridge.Margin = new System.Windows.Forms.Padding(0);
            this.flpProtectionTypeOnBridge.Name = "flpProtectionTypeOnBridge";
            this.flpProtectionTypeOnBridge.Size = new System.Drawing.Size(173, 104);
            this.flpProtectionTypeOnBridge.TabIndex = 89;
            this.flpProtectionTypeOnBridge.WrapContents = false;
            // 
            // cbProtectionOnBridge
            // 
            this.cbProtectionOnBridge.AutoSize = true;
            this.cbProtectionOnBridge.Checked = true;
            this.cbProtectionOnBridge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProtectionOnBridge.Location = new System.Drawing.Point(5, 2);
            this.cbProtectionOnBridge.Name = "cbProtectionOnBridge";
            this.cbProtectionOnBridge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbProtectionOnBridge.Size = new System.Drawing.Size(15, 14);
            this.cbProtectionOnBridge.TabIndex = 88;
            this.cbProtectionOnBridge.UseVisualStyleBackColor = true;
            // 
            // tpAddInfo1
            // 
            this.tpAddInfo1.Controls.Add(this.lbUnderbridgeClearance);
            this.tpAddInfo1.Controls.Add(this.lbHole);
            this.tpAddInfo1.Controls.Add(this.nudHole);
            this.tpAddInfo1.Controls.Add(this.nudLength);
            this.tpAddInfo1.Controls.Add(this.label63);
            this.tpAddInfo1.Controls.Add(this.label64);
            this.tpAddInfo1.Controls.Add(this.lbSlopeLongitudinalForReport);
            this.tpAddInfo1.Controls.Add(this.label8);
            this.tpAddInfo1.Controls.Add(this.label34);
            this.tpAddInfo1.Controls.Add(this.tbLongitudeScheme);
            this.tpAddInfo1.Controls.Add(this.label33);
            this.tpAddInfo1.Controls.Add(this.tbExpansionJointTypes);
            this.tpAddInfo1.Controls.Add(this.label3);
            this.tpAddInfo1.Controls.Add(this.chbInversedStartOfBridge);
            this.tpAddInfo1.Controls.Add(this.linkLabel1);
            this.tpAddInfo1.Controls.Add(this.cbDesignBurden);
            this.tpAddInfo1.Controls.Add(this.cbCoverType);
            this.tpAddInfo1.Controls.Add(this.lb_Cover);
            this.tpAddInfo1.Controls.Add(this.dtpConstructionDate);
            this.tpAddInfo1.Controls.Add(this.dtpRepairsDate);
            this.tpAddInfo1.Controls.Add(this.label50);
            this.tpAddInfo1.Controls.Add(this.label52);
            this.tpAddInfo1.Controls.Add(this.chbHeightDimension);
            this.tpAddInfo1.Controls.Add(this.groupBox14);
            this.tpAddInfo1.Controls.Add(this.nudHeightDimension);
            this.tpAddInfo1.Controls.Add(this.label65);
            this.tpAddInfo1.Controls.Add(this.gbLocationInPlan);
            this.tpAddInfo1.Controls.Add(this.nudObliqueAngle);
            this.tpAddInfo1.Controls.Add(this.label15);
            this.tpAddInfo1.Controls.Add(this.cbDrainageType);
            this.tpAddInfo1.Controls.Add(this.label53);
            this.tpAddInfo1.Controls.Add(this.groupBox12);
            this.tpAddInfo1.Controls.Add(this.label56);
            this.tpAddInfo1.Controls.Add(this.tbDesignBurden);
            this.tpAddInfo1.Location = new System.Drawing.Point(4, 22);
            this.tpAddInfo1.Name = "tpAddInfo1";
            this.tpAddInfo1.Size = new System.Drawing.Size(507, 456);
            this.tpAddInfo1.TabIndex = 5;
            this.tpAddInfo1.Text = "Доп. инфо 1";
            this.tpAddInfo1.UseVisualStyleBackColor = true;
            // 
            // lbUnderbridgeClearance
            // 
            this.lbUnderbridgeClearance.BackColor = System.Drawing.SystemColors.Control;
            this.lbUnderbridgeClearance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbUnderbridgeClearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbUnderbridgeClearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbUnderbridgeClearance.Location = new System.Drawing.Point(148, 5);
            this.lbUnderbridgeClearance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUnderbridgeClearance.Name = "lbUnderbridgeClearance";
            this.lbUnderbridgeClearance.Size = new System.Drawing.Size(178, 23);
            this.lbUnderbridgeClearance.TabIndex = 131;
            this.toolTip1.SetToolTip(this.lbUnderbridgeClearance, "Указываются для каждого пролётного строения отдельно на вкладке \"Доп. Инфо 4\"");
            // 
            // lbHole
            // 
            this.lbHole.AutoSize = true;
            this.lbHole.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbHole.Location = new System.Drawing.Point(7, 57);
            this.lbHole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHole.Name = "lbHole";
            this.lbHole.Size = new System.Drawing.Size(78, 13);
            this.lbHole.TabIndex = 130;
            this.lbHole.Text = "Отверстие, м ";
            this.toolTip1.SetToolTip(this.lbHole, resources.GetString("lbHole.ToolTip"));
            // 
            // nudHole
            // 
            this.nudHole.DecimalPlaces = 2;
            this.nudHole.Location = new System.Drawing.Point(148, 56);
            this.nudHole.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudHole.Name = "nudHole";
            this.nudHole.Size = new System.Drawing.Size(99, 20);
            this.nudHole.TabIndex = 129;
            this.toolTip1.SetToolTip(this.nudHole, resources.GetString("nudHole.ToolTip"));
            // 
            // nudLength
            // 
            this.nudLength.DecimalPlaces = 2;
            this.nudLength.Location = new System.Drawing.Point(148, 31);
            this.nudLength.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLength.Name = "nudLength";
            this.nudLength.Size = new System.Drawing.Size(99, 20);
            this.nudLength.TabIndex = 128;
            this.toolTip1.SetToolTip(this.nudLength, "Расстояние между началом и концом сооружения измеренное по его оси");
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label63.Location = new System.Drawing.Point(7, 32);
            this.label63.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(57, 13);
            this.label63.TabIndex = 127;
            this.label63.Text = "Длина, м ";
            this.toolTip1.SetToolTip(this.label63, "Расстояние между началом и концом сооружения измеренное по его оси");
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label64.Location = new System.Drawing.Point(7, 9);
            this.label64.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(133, 13);
            this.label64.TabIndex = 126;
            this.label64.Text = "Подмостовой габарит, м";
            this.toolTip1.SetToolTip(this.label64, "Указываются для каждого пролётного строения отдельно на вкладке \"Доп. Инфо 4\"");
            // 
            // lbSlopeLongitudinalForReport
            // 
            this.lbSlopeLongitudinalForReport.BackColor = System.Drawing.SystemColors.Control;
            this.lbSlopeLongitudinalForReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbSlopeLongitudinalForReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbSlopeLongitudinalForReport.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbSlopeLongitudinalForReport.Location = new System.Drawing.Point(290, 159);
            this.lbSlopeLongitudinalForReport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSlopeLongitudinalForReport.Name = "lbSlopeLongitudinalForReport";
            this.lbSlopeLongitudinalForReport.Size = new System.Drawing.Size(214, 23);
            this.lbSlopeLongitudinalForReport.TabIndex = 125;
            this.toolTip1.SetToolTip(this.lbSlopeLongitudinalForReport, "Указываются для каждого пролётного строения отдельно на вкладке \"Доп. Инфо 4\"");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(343, 146);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 124;
            this.label8.Text = "Продольный уклон";
            this.toolTip1.SetToolTip(this.label8, "Указываются для каждого пролётного строения отдельно на вкладке \"Доп. Инфо 4\"");
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label34.Location = new System.Drawing.Point(46, 293);
            this.label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(103, 13);
            this.label34.TabIndex = 123;
            this.label34.Text = "Продольная схема";
            this.toolTip1.SetToolTip(this.label34, "Указывается для каждого пролётного строения отдельно на вкладке \"Доп. Инфо 4\"");
            // 
            // tbLongitudeScheme
            // 
            this.tbLongitudeScheme.Enabled = false;
            this.tbLongitudeScheme.Location = new System.Drawing.Point(7, 309);
            this.tbLongitudeScheme.Multiline = true;
            this.tbLongitudeScheme.Name = "tbLongitudeScheme";
            this.tbLongitudeScheme.ReadOnly = true;
            this.tbLongitudeScheme.Size = new System.Drawing.Size(194, 32);
            this.tbLongitudeScheme.TabIndex = 122;
            this.toolTip1.SetToolTip(this.tbLongitudeScheme, "Указывается для каждого пролётного строения отдельно на вкладке \"Доп. Инфо 4\"");
            // 
            // label33
            // 
            this.label33.Location = new System.Drawing.Point(287, 341);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(166, 16);
            this.label33.TabIndex = 121;
            this.label33.Text = "Типы деформационных швов";
            this.toolTip1.SetToolTip(this.label33, "Указываются для каждого пролётного строения отдельно на вкладке \"Доп. Инфо 4\"");
            // 
            // tbExpansionJointTypes
            // 
            this.tbExpansionJointTypes.Enabled = false;
            this.tbExpansionJointTypes.Location = new System.Drawing.Point(229, 360);
            this.tbExpansionJointTypes.Multiline = true;
            this.tbExpansionJointTypes.Name = "tbExpansionJointTypes";
            this.tbExpansionJointTypes.ReadOnly = true;
            this.tbExpansionJointTypes.Size = new System.Drawing.Size(275, 93);
            this.tbExpansionJointTypes.TabIndex = 120;
            this.toolTip1.SetToolTip(this.tbExpansionJointTypes, "Указываются для каждого пролётного строения отдельно на вкладке \"Доп. Инфо 4\"");
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 435);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 119;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // chbInversedStartOfBridge
            // 
            this.chbInversedStartOfBridge.AutoSize = true;
            this.chbInversedStartOfBridge.Location = new System.Drawing.Point(53, 435);
            this.chbInversedStartOfBridge.Name = "chbInversedStartOfBridge";
            this.chbInversedStartOfBridge.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbInversedStartOfBridge.Size = new System.Drawing.Size(143, 17);
            this.chbInversedStartOfBridge.TabIndex = 101;
            this.chbInversedStartOfBridge.Text = "Инвертировано начало";
            this.chbInversedStartOfBridge.UseVisualStyleBackColor = true;
            this.chbInversedStartOfBridge.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(5, 411);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(54, 13);
            this.linkLabel1.TabIndex = 118;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Очистить";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // cbDesignBurden
            // 
            this.cbDesignBurden.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDesignBurden.DropDownWidth = 190;
            this.cbDesignBurden.FormattingEnabled = true;
            this.cbDesignBurden.Location = new System.Drawing.Point(6, 360);
            this.cbDesignBurden.Name = "cbDesignBurden";
            this.cbDesignBurden.Size = new System.Drawing.Size(220, 21);
            this.cbDesignBurden.TabIndex = 117;
            this.cbDesignBurden.SelectedIndexChanged += new System.EventHandler(this.cbDesignBurden_SelectedIndexChanged);
            // 
            // cbCoverType
            // 
            this.cbCoverType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCoverType.DropDownWidth = 190;
            this.cbCoverType.FormattingEnabled = true;
            this.cbCoverType.Location = new System.Drawing.Point(229, 285);
            this.cbCoverType.Name = "cbCoverType";
            this.cbCoverType.Size = new System.Drawing.Size(273, 21);
            this.cbCoverType.TabIndex = 115;
            this.cbCoverType.SelectedIndexChanged += new System.EventHandler(this.cbCoverType_SelectedIndexChanged);
            // 
            // lb_Cover
            // 
            this.lb_Cover.AutoSize = true;
            this.lb_Cover.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Cover.Location = new System.Drawing.Point(292, 269);
            this.lb_Cover.Name = "lb_Cover";
            this.lb_Cover.Size = new System.Drawing.Size(142, 13);
            this.lb_Cover.TabIndex = 114;
            this.lb_Cover.Text = "Покрытие проезжей части";
            // 
            // dtpConstructionDate
            // 
            this.dtpConstructionDate.Checked = false;
            this.dtpConstructionDate.Location = new System.Drawing.Point(7, 232);
            this.dtpConstructionDate.Name = "dtpConstructionDate";
            this.dtpConstructionDate.ShowCheckBox = true;
            this.dtpConstructionDate.Size = new System.Drawing.Size(194, 20);
            this.dtpConstructionDate.TabIndex = 110;
            // 
            // dtpRepairsDate
            // 
            this.dtpRepairsDate.Checked = false;
            this.dtpRepairsDate.Location = new System.Drawing.Point(7, 271);
            this.dtpRepairsDate.Name = "dtpRepairsDate";
            this.dtpRepairsDate.ShowCheckBox = true;
            this.dtpRepairsDate.Size = new System.Drawing.Size(194, 20);
            this.dtpRepairsDate.TabIndex = 109;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label50.Location = new System.Drawing.Point(75, 255);
            this.label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(79, 13);
            this.label50.TabIndex = 108;
            this.label50.Text = "Дата ремонта";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label52.Location = new System.Drawing.Point(70, 212);
            this.label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(89, 13);
            this.label52.TabIndex = 107;
            this.label52.Text = "Дата постройки";
            // 
            // chbHeightDimension
            // 
            this.chbHeightDimension.AutoSize = true;
            this.chbHeightDimension.Location = new System.Drawing.Point(133, 84);
            this.chbHeightDimension.Name = "chbHeightDimension";
            this.chbHeightDimension.Size = new System.Drawing.Size(15, 14);
            this.chbHeightDimension.TabIndex = 59;
            this.toolTip1.SetToolTip(this.chbHeightDimension, resources.GetString("chbHeightDimension.ToolTip"));
            this.chbHeightDimension.UseVisualStyleBackColor = true;
            this.chbHeightDimension.CheckedChanged += new System.EventHandler(this.cbHeightDimension_CheckedChanged);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.nudWidthDimensionBrivewayCount);
            this.groupBox14.Controls.Add(this.label14);
            this.groupBox14.Controls.Add(this.label13);
            this.groupBox14.Controls.Add(this.nudWidthDimensionG);
            this.groupBox14.Controls.Add(this.nudWidthDimensionC2);
            this.groupBox14.Controls.Add(this.label57);
            this.groupBox14.Controls.Add(this.nudWidthDimensionC1);
            this.groupBox14.Controls.Add(this.label58);
            this.groupBox14.Controls.Add(this.nudWidthDimensionT2);
            this.groupBox14.Controls.Add(this.label59);
            this.groupBox14.Controls.Add(this.nudWidthDimensionT1);
            this.groupBox14.Controls.Add(this.label60);
            this.groupBox14.Controls.Add(this.nudWidthDimensionC);
            this.groupBox14.Controls.Add(this.label61);
            this.groupBox14.Controls.Add(this.nudWidthDimensionB);
            this.groupBox14.Controls.Add(this.label62);
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox14.Location = new System.Drawing.Point(2, 102);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(284, 107);
            this.groupBox14.TabIndex = 58;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = " Габарит по ширине, м ";
            // 
            // nudWidthDimensionBrivewayCount
            // 
            this.nudWidthDimensionBrivewayCount.Location = new System.Drawing.Point(222, 75);
            this.nudWidthDimensionBrivewayCount.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidthDimensionBrivewayCount.Name = "nudWidthDimensionBrivewayCount";
            this.nudWidthDimensionBrivewayCount.Size = new System.Drawing.Size(59, 20);
            this.nudWidthDimensionBrivewayCount.TabIndex = 74;
            this.nudWidthDimensionBrivewayCount.ValueChanged += new System.EventHandler(this.nudWidthDimensionBrivewayCount_ValueChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(92, 73);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 34);
            this.label14.TabIndex = 73;
            this.label14.Text = "Количество проездов c ограждениями";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(7, 78);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 72;
            this.label13.Text = "Г";
            this.toolTip1.SetToolTip(this.label13, "Ширина мостового полотна между ограждениями проезда, включая разделительную полос" +
        "у, \r\nне имеющую ограждений и полосы безопасности");
            // 
            // nudWidthDimensionG
            // 
            this.nudWidthDimensionG.DecimalPlaces = 2;
            this.nudWidthDimensionG.Location = new System.Drawing.Point(26, 75);
            this.nudWidthDimensionG.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidthDimensionG.Name = "nudWidthDimensionG";
            this.nudWidthDimensionG.Size = new System.Drawing.Size(59, 20);
            this.nudWidthDimensionG.TabIndex = 71;
            this.toolTip1.SetToolTip(this.nudWidthDimensionG, "Ширина мостового полотна между ограждениями проезда, включая разделительную полос" +
        "у, \r\nне имеющую ограждений и полосы безопасности");
            this.nudWidthDimensionG.ValueChanged += new System.EventHandler(this.nudWidthDimensionG_ValueChanged);
            // 
            // nudWidthDimensionC2
            // 
            this.nudWidthDimensionC2.DecimalPlaces = 2;
            this.nudWidthDimensionC2.Location = new System.Drawing.Point(222, 48);
            this.nudWidthDimensionC2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidthDimensionC2.Name = "nudWidthDimensionC2";
            this.nudWidthDimensionC2.Size = new System.Drawing.Size(59, 20);
            this.nudWidthDimensionC2.TabIndex = 70;
            this.toolTip1.SetToolTip(this.nudWidthDimensionC2, "Ширина правого ограждения безопасности");
            this.nudWidthDimensionC2.ValueChanged += new System.EventHandler(this.nudWidthDimensionC2_ValueChanged);
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label57.Location = new System.Drawing.Point(194, 52);
            this.label57.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(20, 13);
            this.label57.TabIndex = 69;
            this.label57.Text = "С2";
            this.toolTip1.SetToolTip(this.label57, "Ширина правого ограждения безопасности");
            // 
            // nudWidthDimensionC1
            // 
            this.nudWidthDimensionC1.DecimalPlaces = 2;
            this.nudWidthDimensionC1.Location = new System.Drawing.Point(222, 20);
            this.nudWidthDimensionC1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidthDimensionC1.Name = "nudWidthDimensionC1";
            this.nudWidthDimensionC1.Size = new System.Drawing.Size(59, 20);
            this.nudWidthDimensionC1.TabIndex = 68;
            this.toolTip1.SetToolTip(this.nudWidthDimensionC1, "Ширина левого ограждения безопасности");
            this.nudWidthDimensionC1.ValueChanged += new System.EventHandler(this.nudWidthDimensionC1_ValueChanged);
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label58.Location = new System.Drawing.Point(194, 24);
            this.label58.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(20, 13);
            this.label58.TabIndex = 67;
            this.label58.Text = "С1";
            this.toolTip1.SetToolTip(this.label58, "Ширина левого ограждения безопасности");
            // 
            // nudWidthDimensionT2
            // 
            this.nudWidthDimensionT2.DecimalPlaces = 2;
            this.nudWidthDimensionT2.Location = new System.Drawing.Point(124, 48);
            this.nudWidthDimensionT2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidthDimensionT2.Name = "nudWidthDimensionT2";
            this.nudWidthDimensionT2.Size = new System.Drawing.Size(59, 20);
            this.nudWidthDimensionT2.TabIndex = 66;
            this.toolTip1.SetToolTip(this.nudWidthDimensionT2, "Ширина правого тротуара");
            this.nudWidthDimensionT2.ValueChanged += new System.EventHandler(this.nudWidthDimensionT2_ValueChanged);
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label59.Location = new System.Drawing.Point(98, 52);
            this.label59.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(20, 13);
            this.label59.TabIndex = 65;
            this.label59.Text = "Т2";
            this.toolTip1.SetToolTip(this.label59, "Ширина правого тротуара");
            // 
            // nudWidthDimensionT1
            // 
            this.nudWidthDimensionT1.DecimalPlaces = 2;
            this.nudWidthDimensionT1.Location = new System.Drawing.Point(124, 21);
            this.nudWidthDimensionT1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidthDimensionT1.Name = "nudWidthDimensionT1";
            this.nudWidthDimensionT1.Size = new System.Drawing.Size(59, 20);
            this.nudWidthDimensionT1.TabIndex = 64;
            this.toolTip1.SetToolTip(this.nudWidthDimensionT1, "Ширина левого тротуара");
            this.nudWidthDimensionT1.ValueChanged += new System.EventHandler(this.nudWidthDimensionT1_ValueChanged);
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label60.Location = new System.Drawing.Point(98, 24);
            this.label60.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(20, 13);
            this.label60.TabIndex = 63;
            this.label60.Text = "Т1";
            this.toolTip1.SetToolTip(this.label60, "Ширина левого тротуара");
            // 
            // nudWidthDimensionC
            // 
            this.nudWidthDimensionC.DecimalPlaces = 2;
            this.nudWidthDimensionC.Location = new System.Drawing.Point(26, 48);
            this.nudWidthDimensionC.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidthDimensionC.Name = "nudWidthDimensionC";
            this.nudWidthDimensionC.Size = new System.Drawing.Size(59, 20);
            this.nudWidthDimensionC.TabIndex = 62;
            this.toolTip1.SetToolTip(this.nudWidthDimensionC, "Ширина разделительной полосы");
            this.nudWidthDimensionC.ValueChanged += new System.EventHandler(this.nudWidthDimensionC_ValueChanged);
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label61.Location = new System.Drawing.Point(7, 52);
            this.label61.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(14, 13);
            this.label61.TabIndex = 61;
            this.label61.Text = "C";
            this.toolTip1.SetToolTip(this.label61, "Ширина разделительной полосы");
            // 
            // nudWidthDimensionB
            // 
            this.nudWidthDimensionB.DecimalPlaces = 2;
            this.nudWidthDimensionB.Location = new System.Drawing.Point(26, 21);
            this.nudWidthDimensionB.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudWidthDimensionB.Name = "nudWidthDimensionB";
            this.nudWidthDimensionB.Size = new System.Drawing.Size(59, 20);
            this.nudWidthDimensionB.TabIndex = 60;
            this.toolTip1.SetToolTip(this.nudWidthDimensionB, "Полная ширина мостового сооружения - расстояние между перилами");
            this.nudWidthDimensionB.ValueChanged += new System.EventHandler(this.nudWidthDimensionB_ValueChanged);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label62.Location = new System.Drawing.Point(7, 24);
            this.label62.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(14, 13);
            this.label62.TabIndex = 59;
            this.label62.Text = "В";
            this.toolTip1.SetToolTip(this.label62, "Полная ширина мостового сооружения - расстояние между перилами");
            // 
            // nudHeightDimension
            // 
            this.nudHeightDimension.DecimalPlaces = 2;
            this.nudHeightDimension.Enabled = false;
            this.nudHeightDimension.Location = new System.Drawing.Point(148, 81);
            this.nudHeightDimension.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudHeightDimension.Name = "nudHeightDimension";
            this.nudHeightDimension.Size = new System.Drawing.Size(99, 20);
            this.nudHeightDimension.TabIndex = 55;
            this.toolTip1.SetToolTip(this.nudHeightDimension, resources.GetString("nudHeightDimension.ToolTip"));
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label65.Location = new System.Drawing.Point(7, 84);
            this.label65.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(120, 13);
            this.label65.TabIndex = 50;
            this.label65.Text = "Габарит по высоте, м ";
            this.toolTip1.SetToolTip(this.label65, resources.GetString("label65.ToolTip"));
            // 
            // gbLocationInPlan
            // 
            this.gbLocationInPlan.Controls.Add(this.flpLocationInPlan);
            this.gbLocationInPlan.Location = new System.Drawing.Point(330, 25);
            this.gbLocationInPlan.Name = "gbLocationInPlan";
            this.gbLocationInPlan.Size = new System.Drawing.Size(174, 117);
            this.gbLocationInPlan.TabIndex = 85;
            this.gbLocationInPlan.TabStop = false;
            this.gbLocationInPlan.Text = " Расположение в плане ";
            // 
            // flpLocationInPlan
            // 
            this.flpLocationInPlan.AutoScroll = true;
            this.flpLocationInPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLocationInPlan.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpLocationInPlan.Location = new System.Drawing.Point(3, 16);
            this.flpLocationInPlan.Margin = new System.Windows.Forms.Padding(0);
            this.flpLocationInPlan.Name = "flpLocationInPlan";
            this.flpLocationInPlan.Size = new System.Drawing.Size(168, 98);
            this.flpLocationInPlan.TabIndex = 90;
            this.flpLocationInPlan.WrapContents = false;
            // 
            // nudObliqueAngle
            // 
            this.nudObliqueAngle.DecimalPlaces = 2;
            this.nudObliqueAngle.Location = new System.Drawing.Point(413, 5);
            this.nudObliqueAngle.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudObliqueAngle.Name = "nudObliqueAngle";
            this.nudObliqueAngle.Size = new System.Drawing.Size(85, 20);
            this.nudObliqueAngle.TabIndex = 80;
            this.toolTip1.SetToolTip(this.nudObliqueAngle, "Косина “a” равна 90° минус угол пересечения -\r\nугол между осью пролетного строени" +
        "я и осью опоры. Если угол пересечения\r\nравен 90°, то пересечение прямое, косина " +
        "равна 0.");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(327, 5);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 13);
            this.label15.TabIndex = 80;
            this.label15.Text = "Угол косины, °";
            this.toolTip1.SetToolTip(this.label15, "Косина “a” равна 90° минус угол пересечения -\r\nугол между осью пролетного строени" +
        "я и осью опоры. Если угол пересечения\r\nравен 90°, то пересечение прямое, косина " +
        "равна 0.");
            // 
            // cbDrainageType
            // 
            this.cbDrainageType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDrainageType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDrainageType.FormattingEnabled = true;
            this.cbDrainageType.Location = new System.Drawing.Point(229, 319);
            this.cbDrainageType.Name = "cbDrainageType";
            this.cbDrainageType.Size = new System.Drawing.Size(273, 21);
            this.cbDrainageType.TabIndex = 79;
            this.cbDrainageType.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbDrainageType_DrawItem);
            this.cbDrainageType.DropDownClosed += new System.EventHandler(this.cbDrainageType_DropDownClosed);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label53.Location = new System.Drawing.Point(284, 306);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(88, 13);
            this.label53.TabIndex = 81;
            this.label53.Text = "Тип водоотвода";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label6);
            this.groupBox12.Controls.Add(this.cbSlopeLateralProfile);
            this.groupBox12.Controls.Add(this.label2);
            this.groupBox12.Controls.Add(this.nudSlopeLateralProfile);
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox12.Location = new System.Drawing.Point(290, 186);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(214, 82);
            this.groupBox12.TabIndex = 77;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = " Поперечный уклон ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 20);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 112;
            this.label6.Text = "Угол, %";
            // 
            // cbSlopeLateralProfile
            // 
            this.cbSlopeLateralProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSlopeLateralProfile.FormattingEnabled = true;
            this.cbSlopeLateralProfile.Location = new System.Drawing.Point(12, 57);
            this.cbSlopeLateralProfile.Name = "cbSlopeLateralProfile";
            this.cbSlopeLateralProfile.Size = new System.Drawing.Size(196, 21);
            this.cbSlopeLateralProfile.TabIndex = 111;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(69, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 110;
            this.label2.Text = "Направление";
            // 
            // nudSlopeLateralProfile
            // 
            this.nudSlopeLateralProfile.DecimalPlaces = 2;
            this.nudSlopeLateralProfile.Location = new System.Drawing.Point(123, 18);
            this.nudSlopeLateralProfile.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudSlopeLateralProfile.Name = "nudSlopeLateralProfile";
            this.nudSlopeLateralProfile.Size = new System.Drawing.Size(85, 20);
            this.nudSlopeLateralProfile.TabIndex = 72;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label56.Location = new System.Drawing.Point(62, 344);
            this.label56.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(113, 13);
            this.label56.TabIndex = 84;
            this.label56.Text = "Проектные нагрузки";
            this.toolTip1.SetToolTip(this.label56, "Указывают по документации на период проведения диагностики с учетом \r\nрезультатов" +
        " усиления или реконструкции.");
            // 
            // tbDesignBurden
            // 
            this.tbDesignBurden.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbDesignBurden.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbDesignBurden.Location = new System.Drawing.Point(6, 387);
            this.tbDesignBurden.MaxLength = 255;
            this.tbDesignBurden.Name = "tbDesignBurden";
            this.tbDesignBurden.Size = new System.Drawing.Size(220, 20);
            this.tbDesignBurden.TabIndex = 83;
            this.toolTip1.SetToolTip(this.tbDesignBurden, "Указывают по документации на период проведения диагностики с учетом \r\nрезультатов" +
        " усиления или реконструкции.");
            // 
            // tpService
            // 
            this.tpService.Controls.Add(this.label12);
            this.tpService.Controls.Add(this.nudLongitudeSchemeLm);
            this.tpService.Controls.Add(this.atvSpanStructures);
            this.tpService.Controls.Add(this.atvSupports);
            this.tpService.Controls.Add(this.groupBox24);
            this.tpService.Location = new System.Drawing.Point(4, 22);
            this.tpService.Name = "tpService";
            this.tpService.Size = new System.Drawing.Size(507, 456);
            this.tpService.TabIndex = 4;
            this.tpService.Text = "Доп. инфо 4";
            this.tpService.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(411, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 53);
            this.label12.TabIndex = 120;
            this.label12.Text = "Максимальный расчётный пролёт (Lm), м";
            this.toolTip1.SetToolTip(this.label12, "Замеряют на расстоянии\r\n25 м от начала мостового сооружения.\r\nЕсли нет данных про" +
        " максимальный расчётный пролёт, оставлять ноль");
            // 
            // nudLongitudeSchemeLm
            // 
            this.nudLongitudeSchemeLm.DecimalPlaces = 2;
            this.nudLongitudeSchemeLm.Location = new System.Drawing.Point(424, 56);
            this.nudLongitudeSchemeLm.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudLongitudeSchemeLm.Name = "nudLongitudeSchemeLm";
            this.nudLongitudeSchemeLm.Size = new System.Drawing.Size(67, 20);
            this.nudLongitudeSchemeLm.TabIndex = 119;
            this.toolTip1.SetToolTip(this.nudLongitudeSchemeLm, "Замеряют на расстоянии\r\n25 м от начала мостового сооружения.\r\nЕсли нет данных про" +
        " максимальный расчётный пролёт, оставлять ноль");
            this.nudLongitudeSchemeLm.ValueChanged += new System.EventHandler(this.nudLongitudeSchemeLm_ValueChanged);
            // 
            // atvSpanStructures
            // 
            this.atvSpanStructures.Location = new System.Drawing.Point(3, 85);
            this.atvSpanStructures.Name = "atvSpanStructures";
            this.atvSpanStructures.Size = new System.Drawing.Size(250, 368);
            this.atvSpanStructures.TabIndex = 118;
            this.atvSpanStructures.ElementAdding += new ITS.MapObjects.BridgesMapObject.Controls.AddableTreeView.GetObject(this.atvSpanStructures_ElementAdding);
            // 
            // atvSupports
            // 
            this.atvSupports.Location = new System.Drawing.Point(259, 85);
            this.atvSupports.Name = "atvSupports";
            this.atvSupports.Size = new System.Drawing.Size(245, 368);
            this.atvSupports.TabIndex = 117;
            this.atvSupports.ElementAdding += new ITS.MapObjects.BridgesMapObject.Controls.AddableTreeView.GetObject(this.atvSupports_ElementAdding);
            // 
            // groupBox24
            // 
            this.groupBox24.Controls.Add(this.tbNotes);
            this.groupBox24.Location = new System.Drawing.Point(3, 3);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(402, 76);
            this.groupBox24.TabIndex = 116;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = " Примечания ";
            this.toolTip1.SetToolTip(this.groupBox24, "Отмечают особенности конструкции, не охваченные\r\nпунктами прочими пунктами: клима" +
        "тическую зону, наличие антисейсмических устройств и\r\nт. п.");
            // 
            // tbNotes
            // 
            this.tbNotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNotes.Location = new System.Drawing.Point(3, 16);
            this.tbNotes.MaxLength = 255;
            this.tbNotes.Multiline = true;
            this.tbNotes.Name = "tbNotes";
            this.tbNotes.Size = new System.Drawing.Size(396, 57);
            this.tbNotes.TabIndex = 86;
            this.toolTip1.SetToolTip(this.tbNotes, "Отмечают особенности конструкции, не охваченные\r\nпунктами прочими пунктами: клима" +
        "тическую зону, наличие антисейсмических устройств и\r\nт. п.");
            // 
            // tpMainInfo
            // 
            this.tpMainInfo.Controls.Add(this.cbTerritory);
            this.tpMainInfo.Controls.Add(this.label9);
            this.tpMainInfo.Controls.Add(this.groupBox7);
            this.tpMainInfo.Controls.Add(this.gbRoadCategory);
            this.tpMainInfo.Controls.Add(this.label25);
            this.tpMainInfo.Controls.Add(this.nudKilometrМ);
            this.tpMainInfo.Controls.Add(this.nudKilometrКМ);
            this.tpMainInfo.Controls.Add(this.gbNearestVillage);
            this.tpMainInfo.Controls.Add(this.lb_Kilometr);
            this.tpMainInfo.Controls.Add(this.groupBox9);
            this.tpMainInfo.Controls.Add(this.groupBox15);
            this.tpMainInfo.Controls.Add(this.gbStatus);
            this.tpMainInfo.Location = new System.Drawing.Point(4, 22);
            this.tpMainInfo.Name = "tpMainInfo";
            this.tpMainInfo.Size = new System.Drawing.Size(507, 456);
            this.tpMainInfo.TabIndex = 3;
            this.tpMainInfo.Text = "Осн. инфо";
            this.tpMainInfo.UseVisualStyleBackColor = true;
            // 
            // cbTerritory
            // 
            this.cbTerritory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTerritory.DropDownWidth = 190;
            this.cbTerritory.FormattingEnabled = true;
            this.cbTerritory.Location = new System.Drawing.Point(5, 309);
            this.cbTerritory.Name = "cbTerritory";
            this.cbTerritory.Size = new System.Drawing.Size(243, 21);
            this.cbTerritory.TabIndex = 117;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(88, 290);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 13);
            this.label9.TabIndex = 116;
            this.label9.Text = "Код территории";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.tbCharactObstacleAddInfo);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.chbCharactObstacleDirectionOfFlow);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.nudCharactObstacleV);
            this.groupBox7.Controls.Add(this.label17);
            this.groupBox7.Controls.Add(this.nudCharactObstacleH);
            this.groupBox7.Controls.Add(this.label16);
            this.groupBox7.Controls.Add(this.nudCharactObstacleB);
            this.groupBox7.Location = new System.Drawing.Point(255, 254);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(247, 197);
            this.groupBox7.TabIndex = 105;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = " Характеристики пересекаемого препятствия ";
            // 
            // tbCharactObstacleAddInfo
            // 
            this.tbCharactObstacleAddInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbCharactObstacleAddInfo.Location = new System.Drawing.Point(3, 131);
            this.tbCharactObstacleAddInfo.MaxLength = 255;
            this.tbCharactObstacleAddInfo.Multiline = true;
            this.tbCharactObstacleAddInfo.Name = "tbCharactObstacleAddInfo";
            this.tbCharactObstacleAddInfo.Size = new System.Drawing.Size(241, 63);
            this.tbCharactObstacleAddInfo.TabIndex = 87;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(85, 118);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 96;
            this.label5.Text = "Доп. инфо";
            this.toolTip1.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // chbCharactObstacleDirectionOfFlow
            // 
            this.chbCharactObstacleDirectionOfFlow.AutoSize = true;
            this.chbCharactObstacleDirectionOfFlow.Location = new System.Drawing.Point(158, 100);
            this.chbCharactObstacleDirectionOfFlow.Name = "chbCharactObstacleDirectionOfFlow";
            this.chbCharactObstacleDirectionOfFlow.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbCharactObstacleDirectionOfFlow.Size = new System.Drawing.Size(15, 14);
            this.chbCharactObstacleDirectionOfFlow.TabIndex = 95;
            this.toolTip1.SetToolTip(this.chbCharactObstacleDirectionOfFlow, "1 - слева направо (галочка есть), -1 - справа налево (галочки нет)");
            this.chbCharactObstacleDirectionOfFlow.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(7, 93);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 28);
            this.label19.TabIndex = 94;
            this.label19.Text = "Направление течения, слева направо";
            this.toolTip1.SetToolTip(this.label19, "1 - слева направо (галочка есть), -1 - справа налево (галочки нет)");
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(7, 77);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(123, 13);
            this.label18.TabIndex = 93;
            this.label18.Text = "Скорость течения, м/с";
            this.toolTip1.SetToolTip(this.label18, "V");
            // 
            // nudCharactObstacleV
            // 
            this.nudCharactObstacleV.DecimalPlaces = 2;
            this.nudCharactObstacleV.Location = new System.Drawing.Point(142, 74);
            this.nudCharactObstacleV.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudCharactObstacleV.Name = "nudCharactObstacleV";
            this.nudCharactObstacleV.Size = new System.Drawing.Size(99, 20);
            this.nudCharactObstacleV.TabIndex = 92;
            this.toolTip1.SetToolTip(this.nudCharactObstacleV, "V");
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(7, 55);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(89, 13);
            this.label17.TabIndex = 91;
            this.label17.Text = "Глубина реки, м";
            this.toolTip1.SetToolTip(this.label17, "H");
            // 
            // nudCharactObstacleH
            // 
            this.nudCharactObstacleH.DecimalPlaces = 2;
            this.nudCharactObstacleH.Location = new System.Drawing.Point(142, 51);
            this.nudCharactObstacleH.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudCharactObstacleH.Name = "nudCharactObstacleH";
            this.nudCharactObstacleH.Size = new System.Drawing.Size(99, 20);
            this.nudCharactObstacleH.TabIndex = 90;
            this.toolTip1.SetToolTip(this.nudCharactObstacleH, "H");
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(7, 31);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(134, 13);
            this.label16.TabIndex = 89;
            this.label16.Text = "Ширина зеркала воды, м";
            this.toolTip1.SetToolTip(this.label16, "B");
            // 
            // nudCharactObstacleB
            // 
            this.nudCharactObstacleB.DecimalPlaces = 2;
            this.nudCharactObstacleB.Location = new System.Drawing.Point(142, 29);
            this.nudCharactObstacleB.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudCharactObstacleB.Name = "nudCharactObstacleB";
            this.nudCharactObstacleB.Size = new System.Drawing.Size(99, 20);
            this.nudCharactObstacleB.TabIndex = 89;
            this.toolTip1.SetToolTip(this.nudCharactObstacleB, "B");
            // 
            // gbRoadCategory
            // 
            this.gbRoadCategory.Controls.Add(this.cbMarkup);
            this.gbRoadCategory.Controls.Add(this.label11);
            this.gbRoadCategory.Controls.Add(this.rb_Category_IV);
            this.gbRoadCategory.Controls.Add(this.rb_Category_V);
            this.gbRoadCategory.Controls.Add(this.rb_Category_III);
            this.gbRoadCategory.Controls.Add(this.rb_Category_IBr);
            this.gbRoadCategory.Controls.Add(this.rb_Category_IB);
            this.gbRoadCategory.Controls.Add(this.rb_Category_II);
            this.gbRoadCategory.Controls.Add(this.rb_Category_IA);
            this.gbRoadCategory.Controls.Add(this.nudQuantityLineApproach);
            this.gbRoadCategory.Controls.Add(this.lb_NumLineRoad);
            this.gbRoadCategory.Controls.Add(this.nudQuantityLineBridge);
            this.gbRoadCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbRoadCategory.Location = new System.Drawing.Point(5, 341);
            this.gbRoadCategory.Name = "gbRoadCategory";
            this.gbRoadCategory.Size = new System.Drawing.Size(244, 110);
            this.gbRoadCategory.TabIndex = 104;
            this.gbRoadCategory.TabStop = false;
            this.gbRoadCategory.Text = " Категория дороги ";
            // 
            // cbMarkup
            // 
            this.cbMarkup.AutoSize = true;
            this.cbMarkup.Location = new System.Drawing.Point(98, 89);
            this.cbMarkup.Name = "cbMarkup";
            this.cbMarkup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbMarkup.Size = new System.Drawing.Size(121, 17);
            this.cbMarkup.TabIndex = 87;
            this.cbMarkup.Text = "Наличие разметки";
            this.toolTip1.SetToolTip(this.cbMarkup, "В паспорте отмечается как 1 - если разметка есть (галочка есть), 0 - если нет (не" +
        "т галочки)");
            this.cbMarkup.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(83, 47);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(163, 13);
            this.label11.TabIndex = 86;
            this.label11.Text = "Количество полос на подходах";
            // 
            // rb_Category_IV
            // 
            this.rb_Category_IV.AutoSize = true;
            this.rb_Category_IV.Location = new System.Drawing.Point(48, 43);
            this.rb_Category_IV.Name = "rb_Category_IV";
            this.rb_Category_IV.Size = new System.Drawing.Size(35, 17);
            this.rb_Category_IV.TabIndex = 11;
            this.rb_Category_IV.Text = "IV";
            this.rb_Category_IV.UseVisualStyleBackColor = true;
            // 
            // rb_Category_V
            // 
            this.rb_Category_V.AutoSize = true;
            this.rb_Category_V.Location = new System.Drawing.Point(49, 66);
            this.rb_Category_V.Name = "rb_Category_V";
            this.rb_Category_V.Size = new System.Drawing.Size(32, 17);
            this.rb_Category_V.TabIndex = 10;
            this.rb_Category_V.Text = "V";
            this.rb_Category_V.UseVisualStyleBackColor = true;
            // 
            // rb_Category_III
            // 
            this.rb_Category_III.AutoSize = true;
            this.rb_Category_III.Location = new System.Drawing.Point(49, 20);
            this.rb_Category_III.Name = "rb_Category_III";
            this.rb_Category_III.Size = new System.Drawing.Size(34, 17);
            this.rb_Category_III.TabIndex = 9;
            this.rb_Category_III.Text = "III";
            this.rb_Category_III.UseVisualStyleBackColor = true;
            // 
            // rb_Category_IBr
            // 
            this.rb_Category_IBr.AutoSize = true;
            this.rb_Category_IBr.Location = new System.Drawing.Point(8, 64);
            this.rb_Category_IBr.Name = "rb_Category_IBr";
            this.rb_Category_IBr.Size = new System.Drawing.Size(35, 17);
            this.rb_Category_IBr.TabIndex = 8;
            this.rb_Category_IBr.Text = "IВ";
            this.rb_Category_IBr.UseVisualStyleBackColor = true;
            // 
            // rb_Category_IB
            // 
            this.rb_Category_IB.AutoSize = true;
            this.rb_Category_IB.Location = new System.Drawing.Point(8, 42);
            this.rb_Category_IB.Name = "rb_Category_IB";
            this.rb_Category_IB.Size = new System.Drawing.Size(35, 17);
            this.rb_Category_IB.TabIndex = 7;
            this.rb_Category_IB.Text = "IБ";
            this.rb_Category_IB.UseVisualStyleBackColor = true;
            // 
            // rb_Category_II
            // 
            this.rb_Category_II.AutoSize = true;
            this.rb_Category_II.Checked = true;
            this.rb_Category_II.Location = new System.Drawing.Point(8, 87);
            this.rb_Category_II.Name = "rb_Category_II";
            this.rb_Category_II.Size = new System.Drawing.Size(31, 17);
            this.rb_Category_II.TabIndex = 6;
            this.rb_Category_II.TabStop = true;
            this.rb_Category_II.Text = "II";
            this.rb_Category_II.UseVisualStyleBackColor = true;
            // 
            // rb_Category_IA
            // 
            this.rb_Category_IA.AutoSize = true;
            this.rb_Category_IA.Location = new System.Drawing.Point(8, 20);
            this.rb_Category_IA.Name = "rb_Category_IA";
            this.rb_Category_IA.Size = new System.Drawing.Size(35, 17);
            this.rb_Category_IA.TabIndex = 5;
            this.rb_Category_IA.Text = "IА";
            this.rb_Category_IA.UseVisualStyleBackColor = true;
            // 
            // nudQuantityLineApproach
            // 
            this.nudQuantityLineApproach.Location = new System.Drawing.Point(144, 63);
            this.nudQuantityLineApproach.Name = "nudQuantityLineApproach";
            this.nudQuantityLineApproach.Size = new System.Drawing.Size(39, 20);
            this.nudQuantityLineApproach.TabIndex = 74;
            this.nudQuantityLineApproach.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // lb_NumLineRoad
            // 
            this.lb_NumLineRoad.AutoSize = true;
            this.lb_NumLineRoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_NumLineRoad.Location = new System.Drawing.Point(86, 13);
            this.lb_NumLineRoad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_NumLineRoad.Name = "lb_NumLineRoad";
            this.lb_NumLineRoad.Size = new System.Drawing.Size(147, 13);
            this.lb_NumLineRoad.TabIndex = 46;
            this.lb_NumLineRoad.Text = "Количество полос на мосту";
            // 
            // nudQuantityLineBridge
            // 
            this.nudQuantityLineBridge.Location = new System.Drawing.Point(145, 26);
            this.nudQuantityLineBridge.Name = "nudQuantityLineBridge";
            this.nudQuantityLineBridge.Size = new System.Drawing.Size(39, 20);
            this.nudQuantityLineBridge.TabIndex = 71;
            this.nudQuantityLineBridge.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.label25.Location = new System.Drawing.Point(161, 263);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(18, 16);
            this.label25.TabIndex = 103;
            this.label25.Text = "+ ";
            // 
            // nudKilometrМ
            // 
            this.nudKilometrМ.Location = new System.Drawing.Point(180, 261);
            this.nudKilometrМ.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nudKilometrМ.Name = "nudKilometrМ";
            this.nudKilometrМ.Size = new System.Drawing.Size(50, 20);
            this.nudKilometrМ.TabIndex = 102;
            this.nudKilometrМ.ValueChanged += new System.EventHandler(this.BridgeCodeChanged);
            // 
            // nudKilometrКМ
            // 
            this.nudKilometrКМ.Location = new System.Drawing.Point(110, 261);
            this.nudKilometrКМ.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudKilometrКМ.Name = "nudKilometrКМ";
            this.nudKilometrКМ.Size = new System.Drawing.Size(50, 20);
            this.nudKilometrКМ.TabIndex = 101;
            this.nudKilometrКМ.ValueChanged += new System.EventHandler(this.BridgeCodeChanged);
            // 
            // gbNearestVillage
            // 
            this.gbNearestVillage.Controls.Add(this.tbNearestVillage);
            this.gbNearestVillage.Controls.Add(this.nudDistanceToVillageKM);
            this.gbNearestVillage.Controls.Add(this.lb_NearestVillage);
            this.gbNearestVillage.Controls.Add(this.lb_DistanceToVillage);
            this.gbNearestVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbNearestVillage.Location = new System.Drawing.Point(256, 160);
            this.gbNearestVillage.Name = "gbNearestVillage";
            this.gbNearestVillage.Size = new System.Drawing.Size(246, 88);
            this.gbNearestVillage.TabIndex = 65;
            this.gbNearestVillage.TabStop = false;
            this.gbNearestVillage.Text = " Ближайший населённый пункт ";
            // 
            // tbNearestVillage
            // 
            this.tbNearestVillage.Location = new System.Drawing.Point(6, 30);
            this.tbNearestVillage.MaxLength = 255;
            this.tbNearestVillage.Name = "tbNearestVillage";
            this.tbNearestVillage.Size = new System.Drawing.Size(234, 20);
            this.tbNearestVillage.TabIndex = 86;
            // 
            // nudDistanceToVillageKM
            // 
            this.nudDistanceToVillageKM.DecimalPlaces = 2;
            this.nudDistanceToVillageKM.Location = new System.Drawing.Point(82, 66);
            this.nudDistanceToVillageKM.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudDistanceToVillageKM.Name = "nudDistanceToVillageKM";
            this.nudDistanceToVillageKM.Size = new System.Drawing.Size(77, 20);
            this.nudDistanceToVillageKM.TabIndex = 79;
            // 
            // lb_NearestVillage
            // 
            this.lb_NearestVillage.AutoSize = true;
            this.lb_NearestVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_NearestVillage.Location = new System.Drawing.Point(79, 14);
            this.lb_NearestVillage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_NearestVillage.Name = "lb_NearestVillage";
            this.lb_NearestVillage.Size = new System.Drawing.Size(57, 13);
            this.lb_NearestVillage.TabIndex = 52;
            this.lb_NearestVillage.Text = "Название";
            // 
            // lb_DistanceToVillage
            // 
            this.lb_DistanceToVillage.AutoSize = true;
            this.lb_DistanceToVillage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_DistanceToVillage.Location = new System.Drawing.Point(0, 51);
            this.lb_DistanceToVillage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_DistanceToVillage.Name = "lb_DistanceToVillage";
            this.lb_DistanceToVillage.Size = new System.Drawing.Size(207, 13);
            this.lb_DistanceToVillage.TabIndex = 50;
            this.lb_DistanceToVillage.Text = "Расстояние до населённого пункта, км";
            // 
            // lb_Kilometr
            // 
            this.lb_Kilometr.AutoSize = true;
            this.lb_Kilometr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Kilometr.Location = new System.Drawing.Point(14, 264);
            this.lb_Kilometr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_Kilometr.Name = "lb_Kilometr";
            this.lb_Kilometr.Size = new System.Drawing.Size(91, 13);
            this.lb_Kilometr.TabIndex = 100;
            this.lb_Kilometr.Text = "Километр, км+м";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.nudRoadCode);
            this.groupBox9.Controls.Add(this.nudRoadControlCode);
            this.groupBox9.Controls.Add(this.nudSubjectCode);
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.label4);
            this.groupBox9.Controls.Add(this.lb_RoadCode);
            this.groupBox9.Location = new System.Drawing.Point(5, 160);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(243, 95);
            this.groupBox9.TabIndex = 87;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = " Расширенный код дороги ";
            // 
            // nudRoadCode
            // 
            this.nudRoadCode.Location = new System.Drawing.Point(161, 65);
            this.nudRoadCode.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoadCode.Name = "nudRoadCode";
            this.nudRoadCode.Size = new System.Drawing.Size(76, 20);
            this.nudRoadCode.TabIndex = 89;
            this.toolTip1.SetToolTip(this.nudRoadCode, "Если код дороги отсутствует, могут быть указаны\r\nпроизвольные символы, условно пр" +
        "инятые для данной дороги.");
            this.nudRoadCode.ValueChanged += new System.EventHandler(this.BridgeCodeChanged);
            // 
            // nudRoadControlCode
            // 
            this.nudRoadControlCode.Location = new System.Drawing.Point(161, 39);
            this.nudRoadControlCode.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudRoadControlCode.Name = "nudRoadControlCode";
            this.nudRoadControlCode.Size = new System.Drawing.Size(76, 20);
            this.nudRoadControlCode.TabIndex = 88;
            // 
            // nudSubjectCode
            // 
            this.nudSubjectCode.Location = new System.Drawing.Point(161, 14);
            this.nudSubjectCode.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSubjectCode.Name = "nudSubjectCode";
            this.nudSubjectCode.Size = new System.Drawing.Size(76, 20);
            this.nudSubjectCode.TabIndex = 87;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(7, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 13);
            this.label10.TabIndex = 86;
            this.label10.Text = "Код дорожного управления";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(7, 19);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 85;
            this.label4.Text = "Код субъекта РФ";
            // 
            // lb_RoadCode
            // 
            this.lb_RoadCode.AutoSize = true;
            this.lb_RoadCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_RoadCode.Location = new System.Drawing.Point(7, 67);
            this.lb_RoadCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_RoadCode.Name = "lb_RoadCode";
            this.lb_RoadCode.Size = new System.Drawing.Size(64, 13);
            this.lb_RoadCode.TabIndex = 50;
            this.lb_RoadCode.Text = "Код дороги";
            this.toolTip1.SetToolTip(this.lb_RoadCode, "Если код дороги отсутствует, могут быть указаны\r\nпроизвольные символы, условно пр" +
        "инятые для данной дороги.");
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.pbBridgeType);
            this.groupBox15.Location = new System.Drawing.Point(2, 2);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(349, 155);
            this.groupBox15.TabIndex = 78;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = " Тип мостового сооружения ";
            // 
            // pbBridgeType
            // 
            this.pbBridgeType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBridgeType.Location = new System.Drawing.Point(3, 16);
            this.pbBridgeType.Name = "pbBridgeType";
            this.pbBridgeType.Size = new System.Drawing.Size(343, 136);
            this.pbBridgeType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBridgeType.TabIndex = 0;
            this.pbBridgeType.TabStop = false;
            // 
            // gbStatus
            // 
            this.gbStatus.Controls.Add(this.rb_RepairStatus);
            this.gbStatus.Controls.Add(this.rb_TemporaryStatus);
            this.gbStatus.Controls.Add(this.rb_DeconstructStatus);
            this.gbStatus.Controls.Add(this.rb_RequiredStatus);
            this.gbStatus.Controls.Add(this.rb_InstalledStatus);
            this.gbStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbStatus.Location = new System.Drawing.Point(355, 3);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(147, 155);
            this.gbStatus.TabIndex = 73;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = " Статус ";
            // 
            // rb_RepairStatus
            // 
            this.rb_RepairStatus.AutoSize = true;
            this.rb_RepairStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_RepairStatus.Location = new System.Drawing.Point(6, 65);
            this.rb_RepairStatus.Name = "rb_RepairStatus";
            this.rb_RepairStatus.Size = new System.Drawing.Size(78, 17);
            this.rb_RepairStatus.TabIndex = 4;
            this.rb_RepairStatus.Text = "[ Р ] емонт";
            this.rb_RepairStatus.UseVisualStyleBackColor = true;
            // 
            // rb_TemporaryStatus
            // 
            this.rb_TemporaryStatus.AutoSize = true;
            this.rb_TemporaryStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_TemporaryStatus.Location = new System.Drawing.Point(6, 88);
            this.rb_TemporaryStatus.Name = "rb_TemporaryStatus";
            this.rb_TemporaryStatus.Size = new System.Drawing.Size(99, 17);
            this.rb_TemporaryStatus.TabIndex = 3;
            this.rb_TemporaryStatus.Text = "[ В ] ременный";
            this.rb_TemporaryStatus.UseVisualStyleBackColor = true;
            // 
            // rb_DeconstructStatus
            // 
            this.rb_DeconstructStatus.AutoSize = true;
            this.rb_DeconstructStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_DeconstructStatus.Location = new System.Drawing.Point(6, 111);
            this.rb_DeconstructStatus.Name = "rb_DeconstructStatus";
            this.rb_DeconstructStatus.Size = new System.Drawing.Size(121, 17);
            this.rb_DeconstructStatus.TabIndex = 2;
            this.rb_DeconstructStatus.Text = "[ Д ] емонтировать";
            this.rb_DeconstructStatus.UseVisualStyleBackColor = true;
            // 
            // rb_RequiredStatus
            // 
            this.rb_RequiredStatus.AutoSize = true;
            this.rb_RequiredStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_RequiredStatus.Location = new System.Drawing.Point(6, 42);
            this.rb_RequiredStatus.Name = "rb_RequiredStatus";
            this.rb_RequiredStatus.Size = new System.Drawing.Size(93, 17);
            this.rb_RequiredStatus.TabIndex = 1;
            this.rb_RequiredStatus.Text = "[ Т ] ребуется";
            this.rb_RequiredStatus.UseVisualStyleBackColor = true;
            // 
            // rb_InstalledStatus
            // 
            this.rb_InstalledStatus.AutoSize = true;
            this.rb_InstalledStatus.Checked = true;
            this.rb_InstalledStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rb_InstalledStatus.Location = new System.Drawing.Point(6, 19);
            this.rb_InstalledStatus.Name = "rb_InstalledStatus";
            this.rb_InstalledStatus.Size = new System.Drawing.Size(101, 17);
            this.rb_InstalledStatus.TabIndex = 0;
            this.rb_InstalledStatus.TabStop = true;
            this.rb_InstalledStatus.Text = "[ У ] становлен";
            this.rb_InstalledStatus.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMainInfo);
            this.tabControl1.Controls.Add(this.tpAddInfo1);
            this.tabControl1.Controls.Add(this.tpAddInfo2);
            this.tabControl1.Controls.Add(this.tpAddInfo3);
            this.tabControl1.Controls.Add(this.tpService);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tpPhotos);
            this.tabControl1.Location = new System.Drawing.Point(216, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(515, 482);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.atvDocumentations);
            this.tabPage1.Controls.Add(this.albDefects);
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.nudHeightLevelNumber);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cbQualityBridge);
            this.tabPage1.Controls.Add(this.lb_QualityBridge);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(507, 456);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Text = "Прочее";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 148);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(246, 93);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " Положение мостового сооружения ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.rbOne);
            this.flowLayoutPanel1.Controls.Add(this.rbLeft);
            this.flowLayoutPanel1.Controls.Add(this.rbRight);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(240, 74);
            this.flowLayoutPanel1.TabIndex = 90;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // rbOne
            // 
            this.rbOne.AutoSize = true;
            this.rbOne.Location = new System.Drawing.Point(3, 3);
            this.rbOne.Name = "rbOne";
            this.rbOne.Size = new System.Drawing.Size(166, 17);
            this.rbOne.TabIndex = 0;
            this.rbOne.TabStop = true;
            this.rbOne.Text = "Мостовое сооружение одно";
            this.rbOne.UseVisualStyleBackColor = true;
            this.rbOne.CheckedChanged += new System.EventHandler(this.rbIsLeftButtons_CheckedChanged);
            // 
            // rbLeft
            // 
            this.rbLeft.AutoSize = true;
            this.rbLeft.Location = new System.Drawing.Point(3, 26);
            this.rbLeft.Name = "rbLeft";
            this.rbLeft.Size = new System.Drawing.Size(228, 17);
            this.rbLeft.TabIndex = 1;
            this.rbLeft.TabStop = true;
            this.rbLeft.Text = "Мостовое сооружение слева от другого";
            this.rbLeft.UseVisualStyleBackColor = true;
            this.rbLeft.CheckedChanged += new System.EventHandler(this.rbIsLeftButtons_CheckedChanged);
            // 
            // rbRight
            // 
            this.rbRight.AutoSize = true;
            this.rbRight.Location = new System.Drawing.Point(3, 49);
            this.rbRight.Name = "rbRight";
            this.rbRight.Size = new System.Drawing.Size(234, 17);
            this.rbRight.TabIndex = 2;
            this.rbRight.TabStop = true;
            this.rbRight.Text = "Мостовое сооружение справа от другого";
            this.rbRight.UseVisualStyleBackColor = true;
            this.rbRight.CheckedChanged += new System.EventHandler(this.rbIsLeftButtons_CheckedChanged);
            // 
            // atvDocumentations
            // 
            this.atvDocumentations.Location = new System.Drawing.Point(252, 1);
            this.atvDocumentations.Name = "atvDocumentations";
            this.atvDocumentations.Size = new System.Drawing.Size(250, 194);
            this.atvDocumentations.TabIndex = 122;
            this.atvDocumentations.ElementAdding += new ITS.MapObjects.BridgesMapObject.Controls.AddableTreeView.GetObject(this.atvDocumentations_ElementAdding);
            // 
            // albDefects
            // 
            this.albDefects.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.albDefects.Location = new System.Drawing.Point(0, 242);
            this.albDefects.Name = "albDefects";
            this.albDefects.Size = new System.Drawing.Size(507, 214);
            this.albDefects.TabIndex = 121;
            this.albDefects.ElementAdding += new ITS.MapObjects.BridgesMapObject.Controls.AddableListBox.GetObject(this.albDefects_ElementAdding);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.clbMoveType);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox8.Location = new System.Drawing.Point(3, 1);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(246, 145);
            this.groupBox8.TabIndex = 120;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = " Тип движения ";
            // 
            // clbMoveType
            // 
            this.clbMoveType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbMoveType.CheckOnClick = true;
            this.clbMoveType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clbMoveType.FormattingEnabled = true;
            this.clbMoveType.Location = new System.Drawing.Point(3, 16);
            this.clbMoveType.Name = "clbMoveType";
            this.clbMoveType.Size = new System.Drawing.Size(240, 126);
            this.clbMoveType.TabIndex = 0;
            // 
            // nudHeightLevelNumber
            // 
            this.nudHeightLevelNumber.Location = new System.Drawing.Point(377, 197);
            this.nudHeightLevelNumber.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudHeightLevelNumber.Name = "nudHeightLevelNumber";
            this.nudHeightLevelNumber.Size = new System.Drawing.Size(59, 20);
            this.nudHeightLevelNumber.TabIndex = 119;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(249, 199);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 13);
            this.label7.TabIndex = 118;
            this.label7.Text = "Номер уровня высоты";
            // 
            // cbQualityBridge
            // 
            this.cbQualityBridge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQualityBridge.DropDownWidth = 190;
            this.cbQualityBridge.FormattingEnabled = true;
            this.cbQualityBridge.Location = new System.Drawing.Point(377, 221);
            this.cbQualityBridge.Name = "cbQualityBridge";
            this.cbQualityBridge.Size = new System.Drawing.Size(116, 21);
            this.cbQualityBridge.TabIndex = 117;
            // 
            // lb_QualityBridge
            // 
            this.lb_QualityBridge.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_QualityBridge.Location = new System.Drawing.Point(249, 216);
            this.lb_QualityBridge.Name = "lb_QualityBridge";
            this.lb_QualityBridge.Size = new System.Drawing.Size(139, 26);
            this.lb_QualityBridge.TabIndex = 116;
            this.lb_QualityBridge.Text = "Качество мостового            сооружения";
            // 
            // chbIsOverTheRoad
            // 
            this.chbIsOverTheRoad.AutoSize = true;
            this.chbIsOverTheRoad.Location = new System.Drawing.Point(36, 307);
            this.chbIsOverTheRoad.Name = "chbIsOverTheRoad";
            this.chbIsOverTheRoad.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbIsOverTheRoad.Size = new System.Drawing.Size(145, 17);
            this.chbIsOverTheRoad.TabIndex = 100;
            this.chbIsOverTheRoad.Text = "Находится над дорогой";
            this.chbIsOverTheRoad.UseVisualStyleBackColor = true;
            this.chbIsOverTheRoad.Visible = false;
            this.chbIsOverTheRoad.CheckedChanged += new System.EventHandler(this.BridgeCodeChanged);
            // 
            // tbConstructionName
            // 
            this.tbConstructionName.Location = new System.Drawing.Point(2, 216);
            this.tbConstructionName.MaxLength = 255;
            this.tbConstructionName.Name = "tbConstructionName";
            this.tbConstructionName.Size = new System.Drawing.Size(212, 20);
            this.tbConstructionName.TabIndex = 87;
            this.toolTip1.SetToolTip(this.tbConstructionName, resources.GetString("tbConstructionName.ToolTip"));
            this.tbConstructionName.Leave += new System.EventHandler(this.tbConstructionName_Leave);
            // 
            // tbBridgeFullName
            // 
            this.tbBridgeFullName.Enabled = false;
            this.tbBridgeFullName.Location = new System.Drawing.Point(2, 257);
            this.tbBridgeFullName.Multiline = true;
            this.tbBridgeFullName.Name = "tbBridgeFullName";
            this.tbBridgeFullName.ReadOnly = true;
            this.tbBridgeFullName.Size = new System.Drawing.Size(211, 32);
            this.tbBridgeFullName.TabIndex = 124;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label37.Location = new System.Drawing.Point(24, 241);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(177, 13);
            this.label37.TabIndex = 125;
            this.label37.Text = "Предпросмотр полного названия";
            // 
            // BridgeEditView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.tbBridgeFullName);
            this.Controls.Add(this.chbIsOverTheRoad);
            this.Controls.Add(this.tvConstructionType);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lb_ConstructionType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.albBridgeObstacles);
            this.Controls.Add(this.tbConstructionName);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gbRoadName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BridgeEditView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мостовое сооружение";
            this.Load += new System.EventHandler(this.BridgeEditView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingType)).EndInit();
            this.gbRoadName.ResumeLayout(false);
            this.gbRoadName.PerformLayout();
            this.tpAddInfo3.ResumeLayout(false);
            this.tpAddInfo3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAdapterPlatesLength)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.tpAddInfo2.ResumeLayout(false);
            this.tpAddInfo2.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmbankmentHeightAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEmbankmentHeightBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlopeLongitudinalAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlopeLongitudinalBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCarriagewayWidthAfter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCarriagewayWidthBefore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRailingsHeight)).EndInit();
            this.groupBox20.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox18.ResumeLayout(false);
            this.groupBox18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProtectionHeightOnApproach)).EndInit();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudProtectionHeightOnBridge)).EndInit();
            this.tpAddInfo1.ResumeLayout(false);
            this.tpAddInfo1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLength)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionBrivewayCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionC2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionC1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionT2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionT1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidthDimensionB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightDimension)).EndInit();
            this.gbLocationInPlan.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudObliqueAngle)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSlopeLateralProfile)).EndInit();
            this.tpService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudLongitudeSchemeLm)).EndInit();
            this.groupBox24.ResumeLayout(false);
            this.groupBox24.PerformLayout();
            this.tpMainInfo.ResumeLayout(false);
            this.tpMainInfo.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharactObstacleV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharactObstacleH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCharactObstacleB)).EndInit();
            this.gbRoadCategory.ResumeLayout(false);
            this.gbRoadCategory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityLineApproach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantityLineBridge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKilometrМ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudKilometrКМ)).EndInit();
            this.gbNearestVillage.ResumeLayout(false);
            this.gbNearestVillage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistanceToVillageKM)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoadCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRoadControlCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSubjectCode)).EndInit();
            this.groupBox15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBridgeType)).EndInit();
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudHeightLevelNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lb_ConstructionType;
        private System.Windows.Forms.TreeView tvConstructionType;
        private Controls.AddableListBox albBridgeObstacles;
        private System.Windows.Forms.GroupBox gbRoadName;
        private System.Windows.Forms.TextBox tbRoadName;
        private System.Windows.Forms.TabPage tpPhotos;
        private System.Windows.Forms.TabPage tpAddInfo3;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.FlowLayoutPanel flpConesStrengthening;
        private System.Windows.Forms.TabPage tpAddInfo2;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.FlowLayoutPanel flpRailings;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.FlowLayoutPanel flpSidewalks;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown nudProtectionHeightOnApproach;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.FlowLayoutPanel flpProtectionTypeOnApproach;
        private System.Windows.Forms.CheckBox cbProtectionOnApproach;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown nudProtectionHeightOnBridge;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.FlowLayoutPanel flpProtectionTypeOnBridge;
        private System.Windows.Forms.CheckBox cbProtectionOnBridge;
        private System.Windows.Forms.TabPage tpAddInfo1;
        private System.Windows.Forms.DateTimePicker dtpConstructionDate;
        private System.Windows.Forms.DateTimePicker dtpRepairsDate;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.CheckBox chbHeightDimension;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.NumericUpDown nudWidthDimensionBrivewayCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nudWidthDimensionG;
        private System.Windows.Forms.NumericUpDown nudWidthDimensionC2;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.NumericUpDown nudWidthDimensionC1;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.NumericUpDown nudWidthDimensionT2;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.NumericUpDown nudWidthDimensionT1;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.NumericUpDown nudWidthDimensionC;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.NumericUpDown nudWidthDimensionB;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.NumericUpDown nudHeightDimension;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.GroupBox gbLocationInPlan;
        private System.Windows.Forms.NumericUpDown nudObliqueAngle;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbDrainageType;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSlopeLateralProfile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudSlopeLateralProfile;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.TextBox tbDesignBurden;
        private System.Windows.Forms.TabPage tpService;
        private System.Windows.Forms.TabPage tpMainInfo;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox chbCharactObstacleDirectionOfFlow;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown nudCharactObstacleV;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown nudCharactObstacleH;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.NumericUpDown nudCharactObstacleB;
        private System.Windows.Forms.GroupBox gbRoadCategory;
        private System.Windows.Forms.CheckBox cbMarkup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton rb_Category_IV;
        private System.Windows.Forms.RadioButton rb_Category_V;
        private System.Windows.Forms.RadioButton rb_Category_III;
        private System.Windows.Forms.RadioButton rb_Category_IBr;
        private System.Windows.Forms.RadioButton rb_Category_IB;
        private System.Windows.Forms.RadioButton rb_Category_II;
        private System.Windows.Forms.RadioButton rb_Category_IA;
        private System.Windows.Forms.NumericUpDown nudQuantityLineApproach;
        private System.Windows.Forms.Label lb_NumLineRoad;
        private System.Windows.Forms.NumericUpDown nudQuantityLineBridge;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.NumericUpDown nudKilometrМ;
        private System.Windows.Forms.NumericUpDown nudKilometrКМ;
        private System.Windows.Forms.GroupBox gbNearestVillage;
        private System.Windows.Forms.TextBox tbNearestVillage;
        private System.Windows.Forms.NumericUpDown nudDistanceToVillageKM;
        private System.Windows.Forms.Label lb_NearestVillage;
        private System.Windows.Forms.Label lb_DistanceToVillage;
        private System.Windows.Forms.Label lb_Kilometr;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.NumericUpDown nudRoadControlCode;
        private System.Windows.Forms.NumericUpDown nudSubjectCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_RoadCode;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.PictureBox pbBridgeType;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.RadioButton rb_RepairStatus;
        private System.Windows.Forms.RadioButton rb_TemporaryStatus;
        private System.Windows.Forms.RadioButton rb_DeconstructStatus;
        private System.Windows.Forms.RadioButton rb_RequiredStatus;
        private System.Windows.Forms.RadioButton rb_InstalledStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ComboBox cbCoverType;
        private System.Windows.Forms.Label lb_Cover;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.ComboBox cbSlopeLongitudinalProfileAfter;
        private System.Windows.Forms.ComboBox cbSlopeLongitudinalProfileBefore;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown nudEmbankmentHeightAfter;
        private System.Windows.Forms.NumericUpDown nudEmbankmentHeightBefore;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.NumericUpDown nudSlopeLongitudinalAfter;
        private System.Windows.Forms.NumericUpDown nudSlopeLongitudinalBefore;
        private System.Windows.Forms.NumericUpDown nudCarriagewayWidthAfter;
        private System.Windows.Forms.NumericUpDown nudCarriagewayWidthBefore;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown nudRailingsHeight;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.CheckedListBox clbRegulatoryStructures;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.TextBox tbNotes;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.CheckBox chbAdapterPlatesLength;
        private System.Windows.Forms.NumericUpDown nudAdapterPlatesLength;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.FlowLayoutPanel flpAdapterPlatesAvailability;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.LinkLabel llEditBuildingCompany;
        private System.Windows.Forms.TextBox tbBuildingOrganization;
        private System.Windows.Forms.LinkLabel llClearBuildingCompany;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel llEditExploitOrganization;
        private System.Windows.Forms.TextBox tbExploitOrganization;
        private System.Windows.Forms.LinkLabel llClearExploitOrganization;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.LinkLabel llEditProjectOrganization;
        private System.Windows.Forms.TextBox tbProjectOrganization;
        private System.Windows.Forms.LinkLabel llClearProjectOrganization;
        private Controls.AddableListBox albInfoOfRepairs;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox clbArrangements;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox clbCommunications;
        private Controls.AddableTreeView atvSpanStructures;
        private Controls.AddableTreeView atvSupports;
        private System.Windows.Forms.DateTimePicker dtpDateView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckedListBox clbMoveType;
        private System.Windows.Forms.NumericUpDown nudHeightLevelNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbQualityBridge;
        private System.Windows.Forms.Label lb_QualityBridge;
        private Controls.AddableListBox albDefects;
        private System.Windows.Forms.ComboBox cbTerritory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chbIsOverTheRoad;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown nudRoadCode;
        private System.Windows.Forms.ComboBox cbDesignBurden;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Controls.AddableTreeView atvDocumentations;
        private System.Windows.Forms.CheckBox chbInversedStartOfBridge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudLongitudeSchemeLm;
        private System.Windows.Forms.TextBox tbConstructionName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rbOne;
        private System.Windows.Forms.RadioButton rbLeft;
        private System.Windows.Forms.RadioButton rbRight;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbExpansionJointTypes;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox tbLongitudeScheme;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox tbRoadSignsBefore;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox tbRoadSignsAfter;
        private System.Windows.Forms.TextBox tbBridgeFullName;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label lbSlopeLongitudinalForReport;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbUnderbridgeClearance;
        private System.Windows.Forms.Label lbHole;
        private System.Windows.Forms.NumericUpDown nudHole;
        private System.Windows.Forms.NumericUpDown nudLength;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbCharactObstacleAddInfo;
        private System.Windows.Forms.FlowLayoutPanel flpLocationInPlan;
    }
}