#region Licence
//  ALMListManagerTool
//  Copyright © Hewlett-Packard Company 2012

//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.

//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.

//  You should have received a copy of the GNU General Public License along
//  with this program; if not, write to the Free Software Foundation, Inc.,
//  51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
#endregion

namespace hp.go2alm.ALMListManagerTool
{
    partial class ALMListManagerFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ALMListManagerFrm));
            this.TabControl = new System.Windows.Forms.TabControl();
            this.ALMLoginTab = new System.Windows.Forms.TabPage();
            this.ALMLabel = new System.Windows.Forms.Label();
            this.ALMLoginGroup = new System.Windows.Forms.GroupBox();
            this.cmbALMServer = new System.Windows.Forms.ComboBox();
            this.lblALMServer = new System.Windows.Forms.Label();
            this.ALMLogOffButton = new System.Windows.Forms.Button();
            this.ALMUserLabel = new System.Windows.Forms.Label();
            this.ALMUser = new System.Windows.Forms.TextBox();
            this.ALMPasswordLabel = new System.Windows.Forms.Label();
            this.ALMPassword = new System.Windows.Forms.MaskedTextBox();
            this.ALMLoginButton = new System.Windows.Forms.Button();
            this.ALMLoginLabel = new System.Windows.Forms.Label();
            this.ALMListManagerTab = new System.Windows.Forms.TabPage();
            this.gbLists = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnSaveTo = new System.Windows.Forms.Button();
            this.ALMListsTree = new System.Windows.Forms.TreeView();
            this.gbEditMode = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstVwEditMode = new System.Windows.Forms.ListView();
            this.btnRenameItem = new System.Windows.Forms.Button();
            this.btnDeleteItem = new System.Windows.Forms.Button();
            this.btnNewItem = new System.Windows.Forms.Button();
            this.ALMDomainLabel = new System.Windows.Forms.Label();
            this.ALMDomainList = new System.Windows.Forms.ComboBox();
            this.ALMProjectLabel = new System.Windows.Forms.Label();
            this.ALMProjectList = new System.Windows.Forms.ComboBox();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.StatusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CopyTextButton = new System.Windows.Forms.Button();
            this.OpenLogFileButton = new System.Windows.Forms.Button();
            this.HelpLinkButton = new System.Windows.Forms.Button();
            this.OpenLogFolderButton = new System.Windows.Forms.Button();
            this.importFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TabControl.SuspendLayout();
            this.ALMLoginTab.SuspendLayout();
            this.ALMLoginGroup.SuspendLayout();
            this.ALMListManagerTab.SuspendLayout();
            this.gbLists.SuspendLayout();
            this.gbEditMode.SuspendLayout();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.ALMLoginTab);
            this.TabControl.Controls.Add(this.ALMListManagerTab);
            this.TabControl.ItemSize = new System.Drawing.Size(73, 18);
            this.TabControl.Location = new System.Drawing.Point(-1, -1);
            this.TabControl.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(784, 433);
            this.TabControl.TabIndex = 0;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // ALMLoginTab
            // 
            this.ALMLoginTab.Controls.Add(this.ALMLabel);
            this.ALMLoginTab.Controls.Add(this.ALMLoginGroup);
            this.ALMLoginTab.Location = new System.Drawing.Point(4, 22);
            this.ALMLoginTab.Name = "ALMLoginTab";
            this.ALMLoginTab.Padding = new System.Windows.Forms.Padding(3);
            this.ALMLoginTab.Size = new System.Drawing.Size(776, 407);
            this.ALMLoginTab.TabIndex = 0;
            this.ALMLoginTab.Text = "ALM Login";
            this.ALMLoginTab.UseVisualStyleBackColor = true;
            // 
            // ALMLabel
            // 
            this.ALMLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ALMLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMLabel.Image = ((System.Drawing.Image)(resources.GetObject("ALMLabel.Image")));
            this.ALMLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ALMLabel.Location = new System.Drawing.Point(101, 37);
            this.ALMLabel.Name = "ALMLabel";
            this.ALMLabel.Size = new System.Drawing.Size(568, 87);
            this.ALMLabel.TabIndex = 45;
            this.ALMLabel.Text = "       Application Lifecycle Management";
            this.ALMLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ALMLoginGroup
            // 
            this.ALMLoginGroup.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ALMLoginGroup.Controls.Add(this.cmbALMServer);
            this.ALMLoginGroup.Controls.Add(this.lblALMServer);
            this.ALMLoginGroup.Controls.Add(this.ALMLogOffButton);
            this.ALMLoginGroup.Controls.Add(this.ALMUserLabel);
            this.ALMLoginGroup.Controls.Add(this.ALMUser);
            this.ALMLoginGroup.Controls.Add(this.ALMPasswordLabel);
            this.ALMLoginGroup.Controls.Add(this.ALMPassword);
            this.ALMLoginGroup.Controls.Add(this.ALMLoginButton);
            this.ALMLoginGroup.Controls.Add(this.ALMLoginLabel);
            this.ALMLoginGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMLoginGroup.Location = new System.Drawing.Point(60, 142);
            this.ALMLoginGroup.Name = "ALMLoginGroup";
            this.ALMLoginGroup.Size = new System.Drawing.Size(657, 210);
            this.ALMLoginGroup.TabIndex = 44;
            this.ALMLoginGroup.TabStop = false;
            this.ALMLoginGroup.Text = "Log in to ALM";
            // 
            // cmbALMServer
            // 
            this.cmbALMServer.DropDownWidth = 200;
            this.cmbALMServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbALMServer.FormattingEnabled = true;
            this.cmbALMServer.Location = new System.Drawing.Point(228, 63);
            this.cmbALMServer.Name = "cmbALMServer";
            this.cmbALMServer.Size = new System.Drawing.Size(200, 21);
            this.cmbALMServer.TabIndex = 1;
            this.cmbALMServer.SelectedIndexChanged += new System.EventHandler(this.cmbALMServer_SelectedIndexChanged);
            this.cmbALMServer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbALMServer_KeyUp);
            // 
            // lblALMServer
            // 
            this.lblALMServer.AutoSize = true;
            this.lblALMServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblALMServer.Location = new System.Drawing.Point(155, 65);
            this.lblALMServer.Name = "lblALMServer";
            this.lblALMServer.Size = new System.Drawing.Size(63, 13);
            this.lblALMServer.TabIndex = 40;
            this.lblALMServer.Text = "ALM Server";
            // 
            // ALMLogOffButton
            // 
            this.ALMLogOffButton.Enabled = false;
            this.ALMLogOffButton.Location = new System.Drawing.Point(338, 165);
            this.ALMLogOffButton.Name = "ALMLogOffButton";
            this.ALMLogOffButton.Size = new System.Drawing.Size(90, 23);
            this.ALMLogOffButton.TabIndex = 39;
            this.ALMLogOffButton.Text = "Log off";
            this.ALMLogOffButton.UseVisualStyleBackColor = true;
            this.ALMLogOffButton.Click += new System.EventHandler(this.ALMLogOffButton_Click);
            // 
            // ALMUserLabel
            // 
            this.ALMUserLabel.AutoSize = true;
            this.ALMUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMUserLabel.Location = new System.Drawing.Point(155, 100);
            this.ALMUserLabel.Name = "ALMUserLabel";
            this.ALMUserLabel.Size = new System.Drawing.Size(29, 13);
            this.ALMUserLabel.TabIndex = 35;
            this.ALMUserLabel.Text = "User";
            // 
            // ALMUser
            // 
            this.ALMUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMUser.Location = new System.Drawing.Point(228, 97);
            this.ALMUser.Name = "ALMUser";
            this.ALMUser.Size = new System.Drawing.Size(200, 20);
            this.ALMUser.TabIndex = 2;
            this.ALMUser.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ALMUser_KeyDown);
            // 
            // ALMPasswordLabel
            // 
            this.ALMPasswordLabel.AutoSize = true;
            this.ALMPasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMPasswordLabel.Location = new System.Drawing.Point(155, 135);
            this.ALMPasswordLabel.Name = "ALMPasswordLabel";
            this.ALMPasswordLabel.Size = new System.Drawing.Size(53, 13);
            this.ALMPasswordLabel.TabIndex = 36;
            this.ALMPasswordLabel.Text = "Password";
            // 
            // ALMPassword
            // 
            this.ALMPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMPassword.Location = new System.Drawing.Point(228, 132);
            this.ALMPassword.Name = "ALMPassword";
            this.ALMPassword.Size = new System.Drawing.Size(200, 20);
            this.ALMPassword.TabIndex = 3;
            this.ALMPassword.UseSystemPasswordChar = true;
            this.ALMPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ALMPassword_KeyDown);
            // 
            // ALMLoginButton
            // 
            this.ALMLoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.ALMLoginButton.Location = new System.Drawing.Point(228, 165);
            this.ALMLoginButton.Name = "ALMLoginButton";
            this.ALMLoginButton.Size = new System.Drawing.Size(90, 23);
            this.ALMLoginButton.TabIndex = 5;
            this.ALMLoginButton.Text = "Log in";
            this.ALMLoginButton.UseVisualStyleBackColor = true;
            this.ALMLoginButton.Click += new System.EventHandler(this.ALMLoginButton_Click);
            // 
            // ALMLoginLabel
            // 
            this.ALMLoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMLoginLabel.Location = new System.Drawing.Point(6, 25);
            this.ALMLoginLabel.Name = "ALMLoginLabel";
            this.ALMLoginLabel.Size = new System.Drawing.Size(645, 35);
            this.ALMLoginLabel.TabIndex = 37;
            this.ALMLoginLabel.Text = "Please Log in to ALM...";
            this.ALMLoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ALMListManagerTab
            // 
            this.ALMListManagerTab.Controls.Add(this.gbLists);
            this.ALMListManagerTab.Controls.Add(this.gbEditMode);
            this.ALMListManagerTab.Controls.Add(this.ALMDomainLabel);
            this.ALMListManagerTab.Controls.Add(this.ALMDomainList);
            this.ALMListManagerTab.Controls.Add(this.ALMProjectLabel);
            this.ALMListManagerTab.Controls.Add(this.ALMProjectList);
            this.ALMListManagerTab.Location = new System.Drawing.Point(4, 22);
            this.ALMListManagerTab.Margin = new System.Windows.Forms.Padding(0);
            this.ALMListManagerTab.Name = "ALMListManagerTab";
            this.ALMListManagerTab.Size = new System.Drawing.Size(776, 407);
            this.ALMListManagerTab.TabIndex = 1;
            this.ALMListManagerTab.Text = "List Manager";
            this.ALMListManagerTab.UseVisualStyleBackColor = true;
            // 
            // gbLists
            // 
            this.gbLists.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gbLists.Controls.Add(this.btnSearch);
            this.gbLists.Controls.Add(this.txtSearch);
            this.gbLists.Controls.Add(this.lblSearch);
            this.gbLists.Controls.Add(this.btnImportExcel);
            this.gbLists.Controls.Add(this.btnExportToExcel);
            this.gbLists.Controls.Add(this.btnSaveTo);
            this.gbLists.Controls.Add(this.ALMListsTree);
            this.gbLists.Location = new System.Drawing.Point(5, 52);
            this.gbLists.Name = "gbLists";
            this.gbLists.Size = new System.Drawing.Size(348, 351);
            this.gbLists.TabIndex = 49;
            this.gbLists.TabStop = false;
            this.gbLists.Text = "Lists";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(267, 11);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 54;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(68, 13);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(187, 20);
            this.txtSearch.TabIndex = 53;
            // 
            // lblSearch
            // 
            this.lblSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.Location = new System.Drawing.Point(3, 16);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(59, 13);
            this.lblSearch.TabIndex = 50;
            this.lblSearch.Text = "Search list:";
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImportExcel.Image = global::ALMListManagerTool.Properties.Resources.Excel_16x32;
            this.btnImportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImportExcel.Location = new System.Drawing.Point(84, 321);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(84, 24);
            this.btnImportExcel.TabIndex = 52;
            this.btnImportExcel.Text = "   Import";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportToExcel.Image = global::ALMListManagerTool.Properties.Resources.Excel_16x32;
            this.btnExportToExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportToExcel.Location = new System.Drawing.Point(171, 321);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(84, 24);
            this.btnExportToExcel.TabIndex = 51;
            this.btnExportToExcel.Text = "    Export";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnSaveTo
            // 
            this.btnSaveTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveTo.Location = new System.Drawing.Point(258, 321);
            this.btnSaveTo.Name = "btnSaveTo";
            this.btnSaveTo.Size = new System.Drawing.Size(84, 24);
            this.btnSaveTo.TabIndex = 50;
            this.btnSaveTo.Text = "Save To...";
            this.btnSaveTo.UseVisualStyleBackColor = true;
            this.btnSaveTo.Click += new System.EventHandler(this.btnSaveTo_Click);
            // 
            // ALMListsTree
            // 
            this.ALMListsTree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.ALMListsTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMListsTree.HideSelection = false;
            this.ALMListsTree.Location = new System.Drawing.Point(6, 38);
            this.ALMListsTree.Name = "ALMListsTree";
            this.ALMListsTree.Size = new System.Drawing.Size(336, 276);
            this.ALMListsTree.TabIndex = 0;
            this.ALMListsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ALMListsTree_AfterSelect);
            // 
            // gbEditMode
            // 
            this.gbEditMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gbEditMode.Controls.Add(this.btnSave);
            this.gbEditMode.Controls.Add(this.lstVwEditMode);
            this.gbEditMode.Controls.Add(this.btnRenameItem);
            this.gbEditMode.Controls.Add(this.btnDeleteItem);
            this.gbEditMode.Controls.Add(this.btnNewItem);
            this.gbEditMode.Location = new System.Drawing.Point(359, 3);
            this.gbEditMode.Name = "gbEditMode";
            this.gbEditMode.Size = new System.Drawing.Size(412, 400);
            this.gbEditMode.TabIndex = 48;
            this.gbEditMode.TabStop = false;
            this.gbEditMode.Text = "Edit List";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(322, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 24);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstVwEditMode
            // 
            this.lstVwEditMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lstVwEditMode.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstVwEditMode.HideSelection = false;
            this.lstVwEditMode.Location = new System.Drawing.Point(6, 53);
            this.lstVwEditMode.Name = "lstVwEditMode";
            this.lstVwEditMode.Size = new System.Drawing.Size(400, 310);
            this.lstVwEditMode.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstVwEditMode.TabIndex = 48;
            this.lstVwEditMode.UseCompatibleStateImageBehavior = false;
            this.lstVwEditMode.View = System.Windows.Forms.View.Details;
            this.lstVwEditMode.SelectedIndexChanged += new System.EventHandler(this.lstVwEditMode_SelectedIndexChanged);
            // 
            // btnRenameItem
            // 
            this.btnRenameItem.Location = new System.Drawing.Point(186, 19);
            this.btnRenameItem.Name = "btnRenameItem";
            this.btnRenameItem.Size = new System.Drawing.Size(84, 24);
            this.btnRenameItem.TabIndex = 46;
            this.btnRenameItem.Text = "Rename Item";
            this.btnRenameItem.UseVisualStyleBackColor = true;
            this.btnRenameItem.Click += new System.EventHandler(this.btnRenameItem_Click);
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Location = new System.Drawing.Point(96, 19);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(84, 24);
            this.btnDeleteItem.TabIndex = 47;
            this.btnDeleteItem.Text = "Delete Item";
            this.btnDeleteItem.UseVisualStyleBackColor = true;
            this.btnDeleteItem.Click += new System.EventHandler(this.btnDeleteItem_Click);
            // 
            // btnNewItem
            // 
            this.btnNewItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewItem.Location = new System.Drawing.Point(6, 19);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(84, 24);
            this.btnNewItem.TabIndex = 44;
            this.btnNewItem.Text = "New Item";
            this.btnNewItem.UseVisualStyleBackColor = true;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // ALMDomainLabel
            // 
            this.ALMDomainLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ALMDomainLabel.AutoSize = true;
            this.ALMDomainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMDomainLabel.Location = new System.Drawing.Point(8, 9);
            this.ALMDomainLabel.Name = "ALMDomainLabel";
            this.ALMDomainLabel.Size = new System.Drawing.Size(46, 13);
            this.ALMDomainLabel.TabIndex = 42;
            this.ALMDomainLabel.Text = "Domain:";
            // 
            // ALMDomainList
            // 
            this.ALMDomainList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ALMDomainList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ALMDomainList.Enabled = false;
            this.ALMDomainList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMDomainList.FormattingEnabled = true;
            this.ALMDomainList.Location = new System.Drawing.Point(73, 6);
            this.ALMDomainList.Name = "ALMDomainList";
            this.ALMDomainList.Size = new System.Drawing.Size(274, 21);
            this.ALMDomainList.TabIndex = 40;
            this.ALMDomainList.SelectedIndexChanged += new System.EventHandler(this.ALMDomainList_SelectedIndexChanged);
            // 
            // ALMProjectLabel
            // 
            this.ALMProjectLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ALMProjectLabel.AutoSize = true;
            this.ALMProjectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMProjectLabel.Location = new System.Drawing.Point(8, 33);
            this.ALMProjectLabel.Name = "ALMProjectLabel";
            this.ALMProjectLabel.Size = new System.Drawing.Size(43, 13);
            this.ALMProjectLabel.TabIndex = 43;
            this.ALMProjectLabel.Text = "Project:";
            // 
            // ALMProjectList
            // 
            this.ALMProjectList.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ALMProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ALMProjectList.Enabled = false;
            this.ALMProjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMProjectList.FormattingEnabled = true;
            this.ALMProjectList.Location = new System.Drawing.Point(73, 30);
            this.ALMProjectList.Name = "ALMProjectList";
            this.ALMProjectList.Size = new System.Drawing.Size(274, 21);
            this.ALMProjectList.TabIndex = 41;
            this.ALMProjectList.SelectedIndexChanged += new System.EventHandler(this.ALMProjectList_SelectedIndexChanged);
            // 
            // LogTextBox
            // 
            this.LogTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogTextBox.Location = new System.Drawing.Point(0, 0);
            this.LogTextBox.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(782, 227);
            this.LogTextBox.TabIndex = 11;
            this.LogTextBox.WordWrap = false;
            this.LogTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LogTextBox_KeyDown);
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StatusProgressBar.MarqueeAnimationSpeed = 0;
            this.StatusProgressBar.Name = "StatusProgressBar";
            this.StatusProgressBar.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.StatusProgressBar.Size = new System.Drawing.Size(200, 16);
            this.StatusProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.StatusProgressBar.Visible = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = false;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Always;
            this.StatusLabel.Size = new System.Drawing.Size(769, 17);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "Importing requirement ASDFG12345...";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StatusBar
            // 
            this.StatusBar.AutoSize = false;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel,
            this.StatusProgressBar});
            this.StatusBar.Location = new System.Drawing.Point(0, 705);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(784, 22);
            this.StatusBar.TabIndex = 50;
            this.StatusBar.Text = "StatusBar";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TabControl);
            this.splitContainer1.Panel1MinSize = 433;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LogTextBox);
            this.splitContainer1.Panel2MinSize = 60;
            this.splitContainer1.Size = new System.Drawing.Size(783, 666);
            this.splitContainer1.SplitterDistance = 433;
            this.splitContainer1.TabIndex = 54;
            // 
            // CopyTextButton
            // 
            this.CopyTextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CopyTextButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CopyTextButton.BackgroundImage")));
            this.CopyTextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CopyTextButton.Location = new System.Drawing.Point(475, 672);
            this.CopyTextButton.Name = "CopyTextButton";
            this.CopyTextButton.Size = new System.Drawing.Size(115, 33);
            this.CopyTextButton.TabIndex = 52;
            this.CopyTextButton.Text = "Select/copy all";
            this.CopyTextButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CopyTextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CopyTextButton.UseVisualStyleBackColor = true;
            this.CopyTextButton.Click += new System.EventHandler(this.CopyTextButton_Click);
            // 
            // OpenLogFileButton
            // 
            this.OpenLogFileButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OpenLogFileButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenLogFileButton.BackgroundImage")));
            this.OpenLogFileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OpenLogFileButton.Location = new System.Drawing.Point(340, 672);
            this.OpenLogFileButton.Name = "OpenLogFileButton";
            this.OpenLogFileButton.Size = new System.Drawing.Size(105, 33);
            this.OpenLogFileButton.TabIndex = 51;
            this.OpenLogFileButton.Text = "Open Log file";
            this.OpenLogFileButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OpenLogFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OpenLogFileButton.UseVisualStyleBackColor = true;
            this.OpenLogFileButton.Click += new System.EventHandler(this.OpenLogFileButton_Click);
            // 
            // HelpLinkButton
            // 
            this.HelpLinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpLinkButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("HelpLinkButton.BackgroundImage")));
            this.HelpLinkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.HelpLinkButton.Location = new System.Drawing.Point(748, 672);
            this.HelpLinkButton.Name = "HelpLinkButton";
            this.HelpLinkButton.Size = new System.Drawing.Size(35, 33);
            this.HelpLinkButton.TabIndex = 53;
            this.HelpLinkButton.UseVisualStyleBackColor = true;
            this.HelpLinkButton.Click += new System.EventHandler(this.HelpLinkButton_Click);
            // 
            // OpenLogFolderButton
            // 
            this.OpenLogFolderButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OpenLogFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("OpenLogFolderButton.BackgroundImage")));
            this.OpenLogFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OpenLogFolderButton.Location = new System.Drawing.Point(195, 672);
            this.OpenLogFolderButton.Name = "OpenLogFolderButton";
            this.OpenLogFolderButton.Size = new System.Drawing.Size(115, 33);
            this.OpenLogFolderButton.TabIndex = 49;
            this.OpenLogFolderButton.Text = "Open Log folder";
            this.OpenLogFolderButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OpenLogFolderButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OpenLogFolderButton.UseVisualStyleBackColor = true;
            this.OpenLogFolderButton.Click += new System.EventHandler(this.OpenLogFolderButton_Click);
            // 
            // importFileDialog
            // 
            this.importFileDialog.FileName = "openFileDialog1";
            this.importFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            // 
            // ALMListManagerFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 727);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.CopyTextButton);
            this.Controls.Add(this.OpenLogFileButton);
            this.Controls.Add(this.HelpLinkButton);
            this.Controls.Add(this.OpenLogFolderButton);
            this.Controls.Add(this.StatusBar);
            this.Name = "ALMListManagerFrm";
            this.Text = "ALM List Manager Tool";
            this.TabControl.ResumeLayout(false);
            this.ALMLoginTab.ResumeLayout(false);
            this.ALMLoginGroup.ResumeLayout(false);
            this.ALMLoginGroup.PerformLayout();
            this.ALMListManagerTab.ResumeLayout(false);
            this.ALMListManagerTab.PerformLayout();
            this.gbLists.ResumeLayout(false);
            this.gbLists.PerformLayout();
            this.gbEditMode.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage ALMLoginTab;
        private System.Windows.Forms.TabPage ALMListManagerTab;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Button CopyTextButton;
        private System.Windows.Forms.Button OpenLogFileButton;
        private System.Windows.Forms.Button HelpLinkButton;
        private System.Windows.Forms.ToolStripProgressBar StatusProgressBar;
        private System.Windows.Forms.Button OpenLogFolderButton;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Label ALMLabel;
        private System.Windows.Forms.GroupBox ALMLoginGroup;
        private System.Windows.Forms.Button ALMLogOffButton;
        private System.Windows.Forms.Label ALMUserLabel;
        private System.Windows.Forms.TextBox ALMUser;
        private System.Windows.Forms.Label ALMPasswordLabel;
        private System.Windows.Forms.MaskedTextBox ALMPassword;
        private System.Windows.Forms.Button ALMLoginButton;
        private System.Windows.Forms.Label ALMLoginLabel;
        private System.Windows.Forms.TreeView ALMListsTree;
        private System.Windows.Forms.Label ALMDomainLabel;
        private System.Windows.Forms.ComboBox ALMDomainList;
        private System.Windows.Forms.Label ALMProjectLabel;
        private System.Windows.Forms.ComboBox ALMProjectList;
        private System.Windows.Forms.Button btnDeleteItem;
        private System.Windows.Forms.Button btnRenameItem;
        private System.Windows.Forms.Button btnNewItem;
        private System.Windows.Forms.GroupBox gbEditMode;
        private System.Windows.Forms.ListView lstVwEditMode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox gbLists;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSaveTo;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.OpenFileDialog importFileDialog;
        private System.Windows.Forms.ComboBox cmbALMServer;
        private System.Windows.Forms.Label lblALMServer;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
    }
}

