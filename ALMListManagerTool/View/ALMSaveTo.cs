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

namespace hp.go2alm.ALMListManagerTool
{
    public partial class ALMSaveTo : Form
    {
        #region Variables
        ALMListManagerBL ALMListMgrBL = new ALMListManagerBL();
        private string ALMDomainName;
        private string ALMProjectName;
        private string _returnMessage;
        #endregion

        #region Properties
        public string ReturnMessage
        {
            get 
            {
                return _returnMessage;
            }
            set 
            {
                _returnMessage = value;
            }
        }
        #endregion

        #region Constructors
        public ALMSaveTo()
        {
            InitializeComponent();
        }

        public ALMSaveTo(string selectedDomain, string selectedProject)
        {
            InitializeComponent();
            LoadALMDomains();
            ALMDomainList.SelectedItem = selectedDomain;
            ALMProjectList.SelectedItem = selectedProject;

            gbCurrentList.Text = ALMDomainList.SelectedItem.ToString() 
                + "/" + ALMProjectList.SelectedItem.ToString()
                + " Lists";

            ColumnHeader h = new ColumnHeader();
            h.Width = lstVwALMList.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            lstVwALMList.Columns.Add(h);

            FillList(selectedDomain, selectedProject);

            ALMDomainName = selectedDomain;
            ALMProjectName = selectedProject;
        }
        #endregion

        #region Events
        private void ALMDomainList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ALMDomainList.SelectedIndex >= 0)
            {
                LoadALMProjects(ALMDomainList.SelectedItem.ToString());
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }

        private void rbRename_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRename.Checked)
            {
                txtNewListName.Enabled = true;
                txtNewListName.Focus();
            }
            else
            {
                txtNewListName.Enabled = false;
                txtNewListName.Text = string.Empty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstVwALMList.SelectedItems.Count > 0)
            {
                try
                {
                    if (!ALMProjectList.SelectedItem.ToString().Equals(ALMProjectName))
                    {
                        statusLabel.Text = "Saving changes. This may take a few minutes, please be patient...";
                        statusBar.Refresh();

                        // 1 - Replace, 2 - Rename, 3 - Add
                        int selectedOption = 0;
                        if (rbReplace.Checked)
                        {
                            selectedOption = 1;
                        }
                        else if (rbRename.Checked)
                        {
                            if (string.IsNullOrEmpty(txtNewListName.Text))
                            {
                                //MessageBox.Show("Please add a new list name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                statusLabel.Text = "Please add a new list name";
                                txtNewListName.Focus();
                                return;
                            }
                            selectedOption = 2;
                        }
                        else if (rbAddNewData.Checked)
                        {
                            selectedOption = 3;
                        }

                        ReturnMessage = ALMListMgrBL.SaveTo(selectedOption, ALMDomainList.SelectedItem.ToString(),
                            ALMProjectList.SelectedItem.ToString(), lstVwALMList.SelectedItems[0].Text,
                            txtNewListName.Text.Trim());

                        //MessageBox.Show("The list was updated correctly", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("Please select a project different to " + ALMProjectName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        statusLabel.Text = "Please select a project different to " + ALMProjectName;
                        return;
                    }

                    //statusLabel.Text = "Saving changes. This may take a few minutes, please be patient...";
                    //statusBar.Refresh();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    this.Dispose();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("ERROR: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    statusLabel.Text = "ERROR: " + ex.Message;
                    return;
                }
            }
            else
            {
                //MessageBox.Show("Please select an item from the list", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                statusLabel.Text = "Please select an item from the list";
                lstVwALMList.Focus();
                return;
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Loads list of ALM domains
        /// </summary>
        private void LoadALMDomains()
        {
            try
            {
                List<string> almDomainNameList = ALMListMgrBL.LoadALMDomains();
                ALMDomainList.Items.Clear();
                ALMDomainList.Items.AddRange(almDomainNameList.ToArray());
            }
            catch (Exception ex)
            {
                statusLabel.Text = "ERROR: " + ex.Message;
            }
        }

        /// <summary>
        /// Loads list of ALM projects
        /// </summary>
        /// <param name="ALMDomainName">Domain name</param>
        public void LoadALMProjects(string ALMDomainName)
        {
            try
            {
                List<string> almProjectNameList = ALMListMgrBL.LoadALMProjects(ALMDomainName);

                ALMProjectList.Items.Clear();
                ALMProjectList.Items.AddRange(almProjectNameList.ToArray());
            }
            catch (Exception ex)
            {
                statusLabel.Text = "ERROR: " + ex.Message;
            } 
        }

        /// <summary>
        /// Fills listview object
        /// </summary>
        /// <param name="selectedDomain">Domain name</param>
        /// <param name="selectedProject">Project name</param>
        private void FillList(string selectedDomain, string selectedProject)
        {
            try
            {
                ALMListMgrBL.FillList(ref lstVwALMList, -1, false);
            }
            catch (Exception ex)
            {
                statusLabel.Text = "ERROR: " + ex.Message;
            }
        }
        #endregion
    }
}
