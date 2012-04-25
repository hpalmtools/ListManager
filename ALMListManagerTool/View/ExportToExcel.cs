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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using System.Collections;

namespace hp.go2alm.ALMListManagerTool
{
    public partial class ExportToExcel : Form
    {
        #region Variablles
        ALMListManagerBL ALMListMgrBL = new ALMListManagerBL();
        ExportToExcelBL exportExcelBL = new ExportToExcelBL();
        #endregion

        #region Constructors
        public ExportToExcel()
        {
            InitializeComponent();
        }

        public ExportToExcel(string ALMDomainName, string ALMProjectName)
        {
            InitializeComponent();

            ColumnHeader h = new ColumnHeader();
            h.Width = lstVwALMList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            lstVwALMList.Columns.Add(h);

            lblDomainProject.Text = ALMDomainName + "/" + ALMProjectName;

            ALMListMgrBL.FillList(ref lstVwALMList, -1, false);
            toolStripStatusLabel1.Text = "...";
        }
        #endregion

        #region Events
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportListToExcel();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
            this.Close();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Methods to perfom the export lists to excel
        /// </summary>
        private void ExportListToExcel()
        {
            Hashtable ht = new Hashtable();

            try
            {
                if (lstVwALMList.SelectedItems.Count > 0)
                {
                    toolStripStatusLabel1.Text = "Please wait...";
                    statusStrip1.Refresh();

                    foreach (ListViewItem item in lstVwALMList.SelectedItems)
                    {
                        ht.Add(item.Name, item.Text);
                    }

                    exportExcelBL.FillExcelSheet(ht);
                    //exportExcelBL.FillExcelBySheets(ht);

                    toolStripStatusLabel1.Text = "Export finished";

                    this.DialogResult = DialogResult.OK;
                    this.Dispose();
                    this.Close();
                }
                else
                {
                    toolStripStatusLabel1.Text = "Select one or more items to export";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = "ERROR: " + ex.Message;
                this.DialogResult = DialogResult.Cancel;
            }
        }
        #endregion
    }
}
