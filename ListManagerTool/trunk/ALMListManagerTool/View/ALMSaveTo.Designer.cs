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
    partial class ALMSaveTo
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
            this.gbSaveTo = new System.Windows.Forms.GroupBox();
            this.gbCurrentList = new System.Windows.Forms.GroupBox();
            this.lstVwALMList = new System.Windows.Forms.ListView();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.txtNewListName = new System.Windows.Forms.TextBox();
            this.lblNewListName = new System.Windows.Forms.Label();
            this.rbAddNewData = new System.Windows.Forms.RadioButton();
            this.rbRename = new System.Windows.Forms.RadioButton();
            this.rbReplace = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ALMDomainLabel = new System.Windows.Forms.Label();
            this.ALMDomainList = new System.Windows.Forms.ComboBox();
            this.ALMProjectLabel = new System.Windows.Forms.Label();
            this.ALMProjectList = new System.Windows.Forms.ComboBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbSaveTo.SuspendLayout();
            this.gbCurrentList.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSaveTo
            // 
            this.gbSaveTo.Controls.Add(this.gbCurrentList);
            this.gbSaveTo.Controls.Add(this.gbOptions);
            this.gbSaveTo.Controls.Add(this.btnCancel);
            this.gbSaveTo.Controls.Add(this.btnSave);
            this.gbSaveTo.Controls.Add(this.ALMDomainLabel);
            this.gbSaveTo.Controls.Add(this.ALMDomainList);
            this.gbSaveTo.Controls.Add(this.ALMProjectLabel);
            this.gbSaveTo.Controls.Add(this.ALMProjectList);
            this.gbSaveTo.Location = new System.Drawing.Point(4, 2);
            this.gbSaveTo.Name = "gbSaveTo";
            this.gbSaveTo.Size = new System.Drawing.Size(375, 507);
            this.gbSaveTo.TabIndex = 0;
            this.gbSaveTo.TabStop = false;
            this.gbSaveTo.Text = "Save List To Domain/Project";
            // 
            // gbCurrentList
            // 
            this.gbCurrentList.Controls.Add(this.lstVwALMList);
            this.gbCurrentList.Location = new System.Drawing.Point(8, 73);
            this.gbCurrentList.Name = "gbCurrentList";
            this.gbCurrentList.Size = new System.Drawing.Size(359, 250);
            this.gbCurrentList.TabIndex = 50;
            this.gbCurrentList.TabStop = false;
            this.gbCurrentList.Text = "Project Lists";
            // 
            // lstVwALMList
            // 
            this.lstVwALMList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstVwALMList.Location = new System.Drawing.Point(8, 17);
            this.lstVwALMList.MultiSelect = false;
            this.lstVwALMList.Name = "lstVwALMList";
            this.lstVwALMList.Size = new System.Drawing.Size(344, 225);
            this.lstVwALMList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstVwALMList.TabIndex = 48;
            this.lstVwALMList.UseCompatibleStateImageBehavior = false;
            this.lstVwALMList.View = System.Windows.Forms.View.Details;
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.txtNewListName);
            this.gbOptions.Controls.Add(this.lblNewListName);
            this.gbOptions.Controls.Add(this.rbAddNewData);
            this.gbOptions.Controls.Add(this.rbRename);
            this.gbOptions.Controls.Add(this.rbReplace);
            this.gbOptions.Location = new System.Drawing.Point(8, 329);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(361, 145);
            this.gbOptions.TabIndex = 49;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Select an option:";
            // 
            // txtNewListName
            // 
            this.txtNewListName.Enabled = false;
            this.txtNewListName.Location = new System.Drawing.Point(16, 116);
            this.txtNewListName.Name = "txtNewListName";
            this.txtNewListName.Size = new System.Drawing.Size(339, 20);
            this.txtNewListName.TabIndex = 4;
            // 
            // lblNewListName
            // 
            this.lblNewListName.AutoSize = true;
            this.lblNewListName.Location = new System.Drawing.Point(13, 97);
            this.lblNewListName.Name = "lblNewListName";
            this.lblNewListName.Size = new System.Drawing.Size(79, 13);
            this.lblNewListName.TabIndex = 3;
            this.lblNewListName.Text = "New List Name";
            // 
            // rbAddNewData
            // 
            this.rbAddNewData.AutoSize = true;
            this.rbAddNewData.Location = new System.Drawing.Point(16, 65);
            this.rbAddNewData.Name = "rbAddNewData";
            this.rbAddNewData.Size = new System.Drawing.Size(136, 17);
            this.rbAddNewData.TabIndex = 2;
            this.rbAddNewData.Text = "Add new data to the list";
            this.rbAddNewData.UseVisualStyleBackColor = true;
            // 
            // rbRename
            // 
            this.rbRename.AutoSize = true;
            this.rbRename.Location = new System.Drawing.Point(16, 42);
            this.rbRename.Name = "rbRename";
            this.rbRename.Size = new System.Drawing.Size(98, 17);
            this.rbRename.TabIndex = 1;
            this.rbRename.Text = "Rename the list";
            this.rbRename.UseVisualStyleBackColor = true;
            this.rbRename.CheckedChanged += new System.EventHandler(this.rbRename_CheckedChanged);
            // 
            // rbReplace
            // 
            this.rbReplace.AutoSize = true;
            this.rbReplace.Checked = true;
            this.rbReplace.Location = new System.Drawing.Point(16, 19);
            this.rbReplace.Name = "rbReplace";
            this.rbReplace.Size = new System.Drawing.Size(136, 17);
            this.rbReplace.TabIndex = 0;
            this.rbReplace.TabStop = true;
            this.rbReplace.Text = "Replace the existing list";
            this.rbReplace.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 478);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(101, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ALMDomainLabel
            // 
            this.ALMDomainLabel.AutoSize = true;
            this.ALMDomainLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMDomainLabel.Location = new System.Drawing.Point(14, 22);
            this.ALMDomainLabel.Name = "ALMDomainLabel";
            this.ALMDomainLabel.Size = new System.Drawing.Size(46, 13);
            this.ALMDomainLabel.TabIndex = 46;
            this.ALMDomainLabel.Text = "Domain:";
            // 
            // ALMDomainList
            // 
            this.ALMDomainList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ALMDomainList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMDomainList.FormattingEnabled = true;
            this.ALMDomainList.Location = new System.Drawing.Point(79, 19);
            this.ALMDomainList.Name = "ALMDomainList";
            this.ALMDomainList.Size = new System.Drawing.Size(270, 21);
            this.ALMDomainList.TabIndex = 44;
            this.ALMDomainList.SelectedIndexChanged += new System.EventHandler(this.ALMDomainList_SelectedIndexChanged);
            // 
            // ALMProjectLabel
            // 
            this.ALMProjectLabel.AutoSize = true;
            this.ALMProjectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMProjectLabel.Location = new System.Drawing.Point(14, 50);
            this.ALMProjectLabel.Name = "ALMProjectLabel";
            this.ALMProjectLabel.Size = new System.Drawing.Size(43, 13);
            this.ALMProjectLabel.TabIndex = 47;
            this.ALMProjectLabel.Text = "Project:";
            // 
            // ALMProjectList
            // 
            this.ALMProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ALMProjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ALMProjectList.FormattingEnabled = true;
            this.ALMProjectList.Location = new System.Drawing.Point(79, 46);
            this.ALMProjectList.Name = "ALMProjectList";
            this.ALMProjectList.Size = new System.Drawing.Size(270, 21);
            this.ALMProjectList.TabIndex = 45;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusBar.Location = new System.Drawing.Point(0, 513);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(383, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(16, 17);
            this.statusLabel.Text = "...";
            // 
            // ALMSaveTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 535);
            this.ControlBox = false;
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.gbSaveTo);
            this.MaximizeBox = false;
            this.Name = "ALMSaveTo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ALM Save List To...";
            this.gbSaveTo.ResumeLayout(false);
            this.gbSaveTo.PerformLayout();
            this.gbCurrentList.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSaveTo;
        private System.Windows.Forms.Label ALMDomainLabel;
        private System.Windows.Forms.ComboBox ALMDomainList;
        private System.Windows.Forms.Label ALMProjectLabel;
        private System.Windows.Forms.ComboBox ALMProjectList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListView lstVwALMList;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.TextBox txtNewListName;
        private System.Windows.Forms.Label lblNewListName;
        private System.Windows.Forms.RadioButton rbAddNewData;
        private System.Windows.Forms.RadioButton rbRename;
        private System.Windows.Forms.RadioButton rbReplace;
        private System.Windows.Forms.GroupBox gbCurrentList;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
    }
}