﻿namespace WikiApp
{
    partial class frm1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm1));
            this.txtInput = new System.Windows.Forms.TextBox();
            this.cmbBox = new System.Windows.Forms.ComboBox();
            this.rdoButtonL = new System.Windows.Forms.RadioButton();
            this.rdoButtonN = new System.Windows.Forms.RadioButton();
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.txtBoxDefinition = new System.Windows.Forms.TextBox();
            this.lstView = new System.Windows.Forms.ListView();
            this.clmName = new System.Windows.Forms.ColumnHeader();
            this.clmCategory = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.bntSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.stsStrip = new System.Windows.Forms.StatusStrip();
            this.drpBoxButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.errorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpBox.SuspendLayout();
            this.stsStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(31, 23);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(200, 23);
            this.txtInput.TabIndex = 0;
            this.txtInput.DoubleClick += new System.EventHandler(this.txtInput_DoubleClick);
            this.txtInput.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtInput_MouseMove);
            // 
            // cmbBox
            // 
            this.cmbBox.FormattingEnabled = true;
            this.cmbBox.Location = new System.Drawing.Point(31, 60);
            this.cmbBox.Name = "cmbBox";
            this.cmbBox.Size = new System.Drawing.Size(200, 23);
            this.cmbBox.TabIndex = 1;
            // 
            // rdoButtonL
            // 
            this.rdoButtonL.AutoSize = true;
            this.rdoButtonL.Location = new System.Drawing.Point(6, 22);
            this.rdoButtonL.Name = "rdoButtonL";
            this.rdoButtonL.Size = new System.Drawing.Size(57, 19);
            this.rdoButtonL.TabIndex = 2;
            this.rdoButtonL.TabStop = true;
            this.rdoButtonL.Text = "Linear";
            this.rdoButtonL.UseVisualStyleBackColor = true;
            this.rdoButtonL.CheckedChanged += new System.EventHandler(this.rdoButtonL_CheckedChanged);
            // 
            // rdoButtonN
            // 
            this.rdoButtonN.AutoSize = true;
            this.rdoButtonN.Location = new System.Drawing.Point(6, 47);
            this.rdoButtonN.Name = "rdoButtonN";
            this.rdoButtonN.Size = new System.Drawing.Size(85, 19);
            this.rdoButtonN.TabIndex = 3;
            this.rdoButtonN.TabStop = true;
            this.rdoButtonN.Text = "Non-Linear";
            this.rdoButtonN.UseVisualStyleBackColor = true;
            this.rdoButtonN.CheckedChanged += new System.EventHandler(this.rdoButtonN_CheckedChanged);
            // 
            // grpBox
            // 
            this.grpBox.Controls.Add(this.rdoButtonL);
            this.grpBox.Controls.Add(this.rdoButtonN);
            this.grpBox.Location = new System.Drawing.Point(31, 97);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(200, 100);
            this.grpBox.TabIndex = 4;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Structure";
            // 
            // txtBoxDefinition
            // 
            this.txtBoxDefinition.Location = new System.Drawing.Point(31, 211);
            this.txtBoxDefinition.Multiline = true;
            this.txtBoxDefinition.Name = "txtBoxDefinition";
            this.txtBoxDefinition.Size = new System.Drawing.Size(200, 217);
            this.txtBoxDefinition.TabIndex = 5;
            // 
            // lstView
            // 
            this.lstView.AllowColumnReorder = true;
            this.lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmName,
            this.clmCategory});
            this.lstView.FullRowSelect = true;
            this.lstView.Location = new System.Drawing.Point(378, 23);
            this.lstView.Name = "lstView";
            this.lstView.Size = new System.Drawing.Size(296, 473);
            this.lstView.TabIndex = 6;
            this.lstView.UseCompatibleStateImageBehavior = false;
            this.lstView.View = System.Windows.Forms.View.Details;
            this.lstView.SelectedIndexChanged += new System.EventHandler(this.lstView_SelectedIndexChanged);
            // 
            // clmName
            // 
            this.clmName.Text = "Name";
            this.clmName.Width = 200;
            // 
            // clmCategory
            // 
            this.clmCategory.Text = "Category";
            this.clmCategory.Width = 100;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(273, 60);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(273, 91);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(273, 122);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(273, 215);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // bntSave
            // 
            this.bntSave.Location = new System.Drawing.Point(273, 184);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(75, 23);
            this.bntSave.TabIndex = 11;
            this.bntSave.Text = "Save";
            this.bntSave.UseVisualStyleBackColor = true;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(273, 153);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // stsStrip
            // 
            this.stsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drpBoxButton,
            this.toolStripStatusLabel1});
            this.stsStrip.Location = new System.Drawing.Point(0, 521);
            this.stsStrip.Name = "stsStrip";
            this.stsStrip.Size = new System.Drawing.Size(696, 22);
            this.stsStrip.TabIndex = 13;
            this.stsStrip.Text = "statusStrip1";
            // 
            // drpBoxButton
            // 
            this.drpBoxButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.drpBoxButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drpBoxButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorToolStripMenuItem});
            this.drpBoxButton.Enabled = false;
            this.drpBoxButton.Image = ((System.Drawing.Image)(resources.GetObject("drpBoxButton.Image")));
            this.drpBoxButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drpBoxButton.Name = "drpBoxButton";
            this.drpBoxButton.Size = new System.Drawing.Size(29, 20);
            this.drpBoxButton.Text = "Errors";
            // 
            // errorToolStripMenuItem
            // 
            this.errorToolStripMenuItem.Name = "errorToolStripMenuItem";
            this.errorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.errorToolStripMenuItem.Text = "Error";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Search Text Field";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(260, 269);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 23);
            this.txtSearch.TabIndex = 16;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "Error";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // frm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 543);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stsStrip);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.bntSave);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstView);
            this.Controls.Add(this.txtBoxDefinition);
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.cmbBox);
            this.Controls.Add(this.txtInput);
            this.Name = "frm1";
            this.Text = "Wiki Applicatcion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm1_FormClosed);
            this.Load += new System.EventHandler(this.frm1_Load);
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.stsStrip.ResumeLayout(false);
            this.stsStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtInput;
        private ComboBox cmbBox;
        private RadioButton rdoButtonL;
        private RadioButton rdoButtonN;
        private GroupBox grpBox;
        private TextBox txtBoxDefinition;
        private ListView lstView;
        private ColumnHeader clmName;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnSearch;
        private Button bntSave;
        private Button btnLoad;
        private StatusStrip stsStrip;
        private ToolStripDropDownButton drpBoxButton;
        private ColumnHeader clmCategory;
        private Label label1;
        private TextBox txtSearch;
        private ToolStripMenuItem errorToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
    }
}