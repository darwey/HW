namespace MediCon.Report.Prescription
{
    partial class rxList
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(rxList));
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter5 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter6 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter7 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter8 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            this.textBox39 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.rxListDataSrc = new Telerik.Reporting.SqlDataSource();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.pictureBox2 = new Telerik.Reporting.PictureBox();
            this.PhysicianName = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.pageHeaderSection1 = new Telerik.Reporting.PageHeaderSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.Date = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox39
            // 
            this.textBox39.KeepTogether = false;
            this.textBox39.Multiline = false;
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.0833333432674408D), Telerik.Reporting.Drawing.Unit.Inch(0.48749998211860657D));
            this.textBox39.Style.Font.Bold = false;
            this.textBox39.Style.Font.Name = "Arial Narrow";
            this.textBox39.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox39.StyleName = "";
            this.textBox39.Value = "";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.50000005960464478D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            this.detail.PageBreak = Telerik.Reporting.PageBreak.None;
            this.detail.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.detail.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.5795242786407471D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(4.5304694175720215D)));
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Cm(1.2700002193450928D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.24305544793605804D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.25277784466743469D)));
            this.table1.Body.SetCellContent(1, 0, this.textBox19);
            this.table1.Body.SetCellContent(0, 0, this.textBox16, 1, 2);
            this.table1.Body.SetCellContent(0, 2, this.textBox8);
            this.table1.Body.SetCellContent(1, 1, this.textBox13, 1, 2);
            tableGroup1.Name = "tableGroup1";
            tableGroup2.Name = "tableGroup2";
            tableGroup3.Name = "group";
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.ColumnGroups.Add(tableGroup2);
            this.table1.ColumnGroups.Add(tableGroup3);
            this.table1.DataSource = this.rxListDataSrc;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox19,
            this.textBox16,
            this.textBox8,
            this.textBox13,
            this.textBox39});
            this.table1.KeepTogether = false;
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.49583333730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.0055555556900799274D));
            this.table1.Name = "table1";
            tableGroup6.Name = "group2";
            tableGroup7.Name = "group6";
            tableGroup5.ChildGroups.Add(tableGroup6);
            tableGroup5.ChildGroups.Add(tableGroup7);
            tableGroup5.Groupings.Add(new Telerik.Reporting.Grouping(null));
            tableGroup5.Name = "detailTableGroup";
            tableGroup4.ChildGroups.Add(tableGroup5);
            tableGroup4.Groupings.Add(new Telerik.Reporting.Grouping("=Fields.rxID"));
            tableGroup4.Name = "rxID";
            tableGroup4.ReportItem = this.textBox39;
            tableGroup4.Sortings.Add(new Telerik.Reporting.Sorting("=Fields.rxID", Telerik.Reporting.SortDirection.Asc));
            this.table1.RowGroups.Add(tableGroup4);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Cm(7.5916609764099121D), Telerik.Reporting.Drawing.Unit.Inch(0.49583327770233154D));
            // 
            // textBox19
            // 
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.62186002731323242D), Telerik.Reporting.Drawing.Unit.Inch(0.25277778506278992D));
            this.textBox19.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox19.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.20000000298023224D);
            this.textBox19.Style.Font.Name = "Arial Narrow";
            this.textBox19.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox19.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox19.StyleName = "";
            this.textBox19.Value = "Sig.     ";
            // 
            // textBox16
            // 
            this.textBox16.KeepTogether = false;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4055094718933105D), Telerik.Reporting.Drawing.Unit.Inch(0.23472218215465546D));
            this.textBox16.Style.Font.Bold = true;
            this.textBox16.Style.Font.Name = "Arial Narrow";
            this.textBox16.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Value = "= Fields.productDesc + \" \" + Fields.measurementDesc  + \" \" + Fields.unitDesc";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.50000005960464478D), Telerik.Reporting.Drawing.Unit.Inch(0.23472218215465546D));
            this.textBox8.Style.Font.Bold = true;
            this.textBox8.Style.Font.Name = "Arial Narrow";
            this.textBox8.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox8.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.StyleName = "";
            this.textBox8.Value = "=\"# \" + Fields.qtyRx";
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.2836496829986572D), Telerik.Reporting.Drawing.Unit.Inch(0.25277778506278992D));
            this.textBox13.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.20000000298023224D);
            this.textBox13.Style.Font.Name = "Arial Narrow";
            this.textBox13.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox13.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBox13.StyleName = "";
            this.textBox13.Value = resources.GetString("textBox13.Value");
            // 
            // rxListDataSrc
            // 
            this.rxListDataSrc.ConnectionString = "Medicon";
            this.rxListDataSrc.Name = "rxListDataSrc";
            this.rxListDataSrc.Parameters.AddRange(new Telerik.Reporting.SqlDataSourceParameter[] {
            new Telerik.Reporting.SqlDataSourceParameter("@rxID", System.Data.DbType.String, "=Parameters.rxID.Value")});
            this.rxListDataSrc.SelectCommand = resources.GetString("rxListDataSrc.SelectCommand");
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.0999997854232788D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox2,
            this.PhysicianName,
            this.textBox15,
            this.textBox14});
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.pageFooterSection1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.pageFooterSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchoring = Telerik.Reporting.AnchoringStyles.Bottom;
            this.pictureBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.69999974966049194D));
            this.pictureBox2.MimeType = "image/png";
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.04992151260376D), Telerik.Reporting.Drawing.Unit.Inch(0.39996066689491272D));
            this.pictureBox2.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            this.pictureBox2.Value = ((object)(resources.GetObject("pictureBox2.Value")));
            // 
            // PhysicianName
            // 
            this.PhysicianName.Anchoring = Telerik.Reporting.AnchoringStyles.Bottom;
            this.PhysicianName.CanShrink = false;
            this.PhysicianName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9333768654614687E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.24999974668025971D));
            this.PhysicianName.Name = "PhysicianName";
            this.PhysicianName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0498819351196289D), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448D));
            this.PhysicianName.Style.Font.Bold = true;
            this.PhysicianName.Style.Font.Name = "Arial Narrow";
            this.PhysicianName.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.PhysicianName.Style.Font.Underline = true;
            this.PhysicianName.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.PhysicianName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.PhysicianName.Value = "= ToUpper(Parameters.personnelFullName.Value)\r\n";
            // 
            // textBox15
            // 
            this.textBox15.Anchoring = Telerik.Reporting.AnchoringStyles.Bottom;
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9333768654614687E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.54999971389770508D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.049842357635498D), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448D));
            this.textBox15.Style.Font.Name = "Arial Narrow";
            this.textBox15.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox15.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.Value = "PTR # __________";
            // 
            // textBox14
            // 
            this.textBox14.Anchoring = Telerik.Reporting.AnchoringStyles.Bottom;
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9333768654614687E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.39999976754188538D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0498809814453125D), Telerik.Reporting.Drawing.Unit.Inch(0.15000000596046448D));
            this.textBox14.Style.Font.Name = "Arial Narrow";
            this.textBox14.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox14.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "License No. _______________";
            // 
            // pageHeaderSection1
            // 
            this.pageHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(1.7000000476837158D);
            this.pageHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1,
            this.textBox7,
            this.textBox5,
            this.textBox11,
            this.Date,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox6});
            this.pageHeaderSection1.Name = "pageHeaderSection1";
            this.pageHeaderSection1.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.pageHeaderSection1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9354959881165996E-05D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.0499606132507324D), Telerik.Reporting.Drawing.Unit.Inch(0.59996062517166138D));
            this.pictureBox1.Sizing = Telerik.Reporting.Drawing.ImageSizeMode.Stretch;
            this.pictureBox1.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.pictureBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.pictureBox1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // textBox7
            // 
            this.textBox7.Format = "{0:D}";
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.0583333969116211D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.94992130994796753D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox7.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Font.Name = "Arial Narrow";
            this.textBox7.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "=Format(\'{0:MMM dd, yyyy}\', Parameters.mp_dateTimeRx.Value)";
            // 
            // textBox5
            // 
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5999999046325684D), Telerik.Reporting.Drawing.Unit.Inch(0.94166666269302368D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox5.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Font.Name = "Arial Narrow";
            this.textBox5.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "= Parameters.PatientAge.Value";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D), Telerik.Reporting.Drawing.Unit.Inch(1.394444465637207D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D), Telerik.Reporting.Drawing.Unit.Inch(0.26107186079025269D));
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.textBox11.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "Rx";
            // 
            // Date
            // 
            this.Date.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7583334445953369D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.Date.Name = "Date";
            this.Date.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D), Telerik.Reporting.Drawing.Unit.Inch(0.19992116093635559D));
            this.Date.Style.Font.Name = "Arial Narrow";
            this.Date.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.Date.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.Date.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.Date.Value = "Date:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.94166666269302368D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.49999997019767761D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox1.Style.Font.Name = "Arial Narrow";
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Name:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.1417454481124878D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343D));
            this.textBox2.Style.Font.Name = "Arial Narrow";
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "Address:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2999999523162842D), Telerik.Reporting.Drawing.Unit.Inch(0.94166666269302368D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox3.Style.Font.Name = "Arial Narrow";
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox3.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Age:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(0.94166666269302368D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Name = "Arial Narrow";
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "= ToUpper(Parameters.fullName.Value)";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.5D), Telerik.Reporting.Drawing.Unit.Inch(1.1417454481124878D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.3999998569488525D), Telerik.Reporting.Drawing.Unit.Inch(0.20000001788139343D));
            this.textBox6.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(0.5D);
            this.textBox6.Style.Font.Name = "Arial Narrow";
            this.textBox6.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(7D);
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "= ToUpper(Parameters.PatientAddress.Value)";
            // 
            // rxList
            // 
            this.DocumentName = "= ToUpper(Parameters.fullName.Value)";
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageHeaderSection1,
            this.detail,
            this.pageFooterSection1});
            this.Name = "rxList";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins = new Telerik.Reporting.Drawing.MarginsU(Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D));
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.PageSettings.PaperSize = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.25D), Telerik.Reporting.Drawing.Unit.Inch(5.5D));
            reportParameter1.Name = "rxID";
            reportParameter1.Text = "rxID";
            reportParameter2.Name = "fullName";
            reportParameter3.Name = "PatientAddress";
            reportParameter4.Name = "PatientAge";
            reportParameter5.Name = "personnelFullName";
            reportParameter6.Name = "personnel_licenseNo";
            reportParameter7.Name = "personnel_title";
            reportParameter8.Name = "mp_dateTimeRx";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.ReportParameters.Add(reportParameter5);
            this.ReportParameters.Add(reportParameter6);
            this.ReportParameters.Add(reportParameter7);
            this.ReportParameters.Add(reportParameter8);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.TextItemBase)),
            new Telerik.Reporting.Drawing.TypeSelector(typeof(Telerik.Reporting.HtmlTextBox))});
            styleRule1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Point(2D);
            styleRule1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Point(2D);
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(4.0499606132507324D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.PageHeaderSection pageHeaderSection1;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.PictureBox pictureBox2;
        private Telerik.Reporting.TextBox PhysicianName;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox39;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox Date;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.SqlDataSource rxListDataSrc;
    }
}