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
    partial class ExportToExcel
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
            this.gbLists = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.lstVwALMList = new System.Windows.Forms.ListView();
            this.lblDomainProject = new System.Windows.Forms.Label();
            this.gbDomainProject = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbLists.SuspendLayout();
            this.gbDomainProject.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLists
            // 
            this.gbLists.Controls.Add(this.btnCancel);
            this.gbLists.Controls.Add(this.btnExportExcel);
            this.gbLists.Controls.Add(this.lstVwALMList);
            this.gbLists.Location = new System.Drawing.Point(4, 53);
            this.gbLists.Name = "gbLists";
            this.gbLists.Size = new System.Drawing.Size(375, 411);
            this.gbLists.TabIndex = 51;
            this.gbLists.TabStop = false;
            this.gbLists.Text = "Select the lists you want to export";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(286, 382);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 23);
            this.btnCancel.TabIndex = 53;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.Image = global::ALMListManagerTool.Properties.Resources.Excel_16x32;
            this.btnExportExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportExcel.Location = new System.Drawing.Point(197, 382);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(83, 23);
            this.btnExportExcel.TabIndex = 52;
            this.btnExportExcel.Text = "   Export";
            this.btnExportExcel.UseVisualStyleBackColor = true;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // lstVwALMList
            // 
            this.lstVwALMList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstVwALMList.Location = new System.Drawing.Point(6, 19);
            this.lstVwALMList.Name = "lstVwALMList";
            this.lstVwALMList.Size = new System.Drawing.Size(363, 355);
            this.lstVwALMList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lstVwALMList.TabIndex = 48;
            this.lstVwALMList.UseCompatibleStateImageBehavior = false;
            this.lstVwALMList.View = System.Windows.Forms.View.Details;
            // 
            // lblDomainProject
            // 
            this.lblDomainProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDomainProject.Location = new System.Drawing.Point(6, 15);
            this.lblDomainProject.Name = "lblDomainProject";
            this.lblDomainProject.Size = new System.Drawing.Size(363, 23);
            this.lblDomainProject.TabIndex = 52;
            this.lblDomainProject.Text = "...";
            this.lblDomainProject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbDomainProject
            // 
            this.gbDomainProject.Controls.Add(this.lblDomainProject);
            this.gbDomainProject.Location = new System.Drawing.Point(4, 1);
            this.gbDomainProject.Name = "gbDomainProject";
            this.gbDomainProject.Size = new System.Drawing.Size(375, 46);
            this.gbDomainProject.TabIndex = 54;
            this.gbDomainProject.TabStop = false;
            this.gbDomainProject.Text = "Domain/Project";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(383, 22);
            this.statusStrip1.TabIndex = 55;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // ExportToExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 489);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gbDomainProject);
            this.Controls.Add(this.gbLists);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExportToExcel";
            this.Text = "Export To Excel";
            this.gbLists.ResumeLayout(false);
            this.gbDomainProject.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLists;
        private System.Windows.Forms.ListView lstVwALMList;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label lblDomainProject;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbDomainProject;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}