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
using System.Configuration;
using System.Collections;
using System.Threading;
using System.Xml;

namespace hp.go2alm.ALMListManagerTool
{
    public partial class ALMListManagerFrm : Form
    {
        #region Variables
        ALMListManagerBL ALMListMgrBL = new ALMListManagerBL();
        ImportFromExcelBL importExcelBL = new ImportFromExcelBL();
        private bool flag = false;
        private string currentSearchText;
        private List<TreeNode> foundNodes;
        private int selectedIndex = 0;
        XmlDocument xmlDoc = new XmlDocument();
        private int selectedCmbIndex = -1;

        #endregion

        #region Constructor

        public ALMListManagerFrm()
        {
            InitializeComponent();

            InitializeForm();
            
        }
        #endregion

        #region Events
        private void ALMLoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PerformLogin())
                {
                    LoadALMDomains();
                }
            }
            catch (Exception te)
            {
                LogErrorMessage("User logged off from ALM session. Login action aborted. " + te.Message);
            }
        }

        private void ALMUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ALMPassword.Focus();
                ALMPassword.SelectAll();
            }
        }

        private void ALMPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ALMLoginButton.Focus();
                ALMLoginButton.PerformClick();
            }
        }

        private void ALMLogOffButton_Click(object sender, EventArgs e)
        {
            
            PerformLogOff();
        }

        private void ALMDomainList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EnableAllButtons(false);
                lstVwEditMode.Items.Clear();
                ALMListsTree.Nodes.Clear();

                if (ALMDomainList.SelectedIndex >= 0)
                {
                    LoadALMProjects(ALMDomainList.SelectedItem.ToString());

                }
            }
            catch (Exception ex)
            {
                LogErrorMessage("ERROR: " + ex.Message);
            }
        }

        private void ALMProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] str = new string[2];

            try
            {
                if (ALMProjectList.SelectedIndex >= 0)
                {
                    EnableAllButtons(false);
                    lstVwEditMode.Items.Clear();
                    ALMListsTree.Nodes.Clear();

                    LoadALMLists(ALMDomainList.SelectedItem.ToString(), ALMProjectList.SelectedItem.ToString());
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage("ERROR: " + ex.Message);
            }
        }

        private void OpenLogFolderButton_Click(object sender, EventArgs e)
        {
            try
            {
                string logsPath = ConfigurationManager.AppSettings["logPath"];
                logsPath = logsPath.Substring(0,logsPath.LastIndexOf("/"));
                logsPath = System.IO.Path.GetFullPath(logsPath);
                System.Diagnostics.Process.Start(logsPath);
            }
            catch (Exception ex)
            {
                LogErrorMessage("Could not open the logs folder. " + ex.Message);
            }
        }

        private void OpenLogFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                string logFileName = ConfigurationManager.AppSettings["logPath"];
                System.Diagnostics.Process.Start("notepad.exe", logFileName);
            }
            catch (Exception ex)
            {
                LogErrorMessage("Could not open the Log file. " + ex.Message);
            }
        }

        private void CopyTextButton_Click(object sender, EventArgs e)
        {
            LogTextBox.SelectAll();
            LogTextBox.Copy();
        }

        private void LogTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && e.KeyValue == 'A')
            {
                LogTextBox.SelectAll();
            }
        }

        private void HelpLinkButton_Click(object sender, EventArgs e)
        {
            try
            {
                string userGuide = ConfigurationManager.AppSettings["userGuidePath"];
                System.Diagnostics.Process.Start(userGuide);
            }
            catch (Exception ex)
            {
                LogErrorMessage("Could not open the user guide. Please validate the configuration. " + ex.Message);
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab.Equals(ALMLoginTab))
            {
                ALMUser.Focus();
                ALMUser.SelectAll();
            }
            else if (TabControl.SelectedTab.Equals(ALMListManagerTab))
            {
                ALMDomainList.Focus();
            }
        }

        private void ALMListsTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (ALMListsTree.Nodes.Count > 0)
            {
                lstVwEditMode.Items.Clear();

                //The lists that are blocked, can't be modified
                if (ALMListsTree.SelectedNode.ForeColor == Color.Gray)
                {
                    EnableEditButtons(false);
                }
                else
                {
                    EnableEditButtons(true);
                }

                LoadChildrenList(int.Parse(e.Node.Name), ALMDomainList.SelectedItem.ToString(), ALMProjectList.SelectedItem.ToString());

                if (e.Node.Name.Equals("-1"))
                {
                    LogInfoMessage("Project Lists are available to perform changes");
                }
                else
                {
                    LogInfoMessage("List " + e.Node.Text + " is selected");
                }

                lstVwEditMode.LabelEdit = false;
            }
        }

        private void btnRenameItem_Click(object sender, EventArgs e)
        {
            if (ALMDomainList.Items.Count > 0 && ALMProjectList.Items.Count > 0 && ALMListsTree.Nodes.Count > 0
                && ALMListsTree.SelectedNode != null)
            {
                if (lstVwEditMode.SelectedItems.Count > 0)
                {
                    lstVwEditMode.LabelEdit = true;
                    lstVwEditMode.SelectedItems[0].BeginEdit();
                    lstVwEditMode.SelectedItems[0].Focused = true;
                    lstVwEditMode.SelectedItems[0].Selected = true;
                }
                else
                {
                    LogInfoMessage("Please select an item in the list");
                }
            }
            else
            {
                LogInfoMessage("Please select a list");
            }
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            if (ALMDomainList.Items.Count > 0 && ALMProjectList.Items.Count > 0 && ALMListsTree.Nodes.Count > 0
                && ALMListsTree.SelectedNode != null)
            {
                lstVwEditMode.SelectedItems.Clear();

                flag = true;
                lstVwEditMode.LabelEdit = true;
                lstVwEditMode.Items.Add("-1", "New Item", null);
                lstVwEditMode.Items[lstVwEditMode.Items.IndexOfKey("-1")].Focused = true;
                lstVwEditMode.Items[lstVwEditMode.Items.IndexOfKey("-1")].Selected = true;
                lstVwEditMode.Items[lstVwEditMode.Items.IndexOfKey("-1")].EnsureVisible();

                lstVwEditMode.Focus();
                lstVwEditMode.Select();
            }
            else
            {
                LogInfoMessage("Please select a list");
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (ALMDomainList.Items.Count > 0 && ALMProjectList.Items.Count > 0 && ALMListsTree.Nodes.Count > 0
                && ALMListsTree.SelectedNode != null)
            {
                if (lstVwEditMode.SelectedItems.Count > 0)
                {
                    lstVwEditMode.LabelEdit = false;
                    lstVwEditMode.Items.Remove(lstVwEditMode.SelectedItems[0]);
                }
                else
                {
                    LogInfoMessage("Please select an item in the list");
                }
            }
            else
            {
                LogInfoMessage("Please select a list");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            object[] parameters = new object[2];
            string[] param = new string[2];

            try
            {
                if (ALMListsTree.Nodes.Count > 0 && lstVwEditMode.Items.Count > 0)
                {
                    LogInfoMessage("Saving changes in List: " + ALMDomainList.SelectedItem.ToString() + "/" + ALMProjectList.SelectedItem.ToString());

                    LogInfoMessage("This may take a few minutes, please be patient.");

                    EnableAllButtons(false);

                    string str = ALMListMgrBL.Save(int.Parse(ALMListsTree.SelectedNode.Name), lstVwEditMode);

                    LogInfoMessage(str);

                    if (str.StartsWith("Changes applied to the list: " + Environment.NewLine))
                    {
                        lstVwEditMode.Items.Clear();
                        ALMListsTree.Nodes.Clear();
                        LoadALMLists(ALMDomainList.SelectedItem.ToString(), ALMProjectList.SelectedItem.ToString());
                    }
                    else
                    {
                        lstVwEditMode.Items.Clear();
                        LoadChildrenList(int.Parse(ALMListsTree.SelectedNode.Name), ALMDomainList.SelectedItem.ToString(), ALMProjectList.SelectedItem.ToString());
                    }

                    EnableAllButtons(true);
                }
                else
                {
                    LogInfoMessage("Please select a list");
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage("ERROR: " + ex.Message);
            }
        }

        private void btnSaveTo_Click(object sender, EventArgs e)
        {
            try
            {
                if (ALMListsTree.Nodes.Count > 0)
                {
                    ALMSaveTo frmALMSaveTo = new ALMSaveTo(ALMDomainList.SelectedItem.ToString(), ALMProjectList.SelectedItem.ToString());
                    frmALMSaveTo.ShowDialog();

                    LogInfoMessage(frmALMSaveTo.ReturnMessage);

                    if (frmALMSaveTo.DialogResult == DialogResult.OK)
                    {
                        //Disconnect user from the original domain/project
                        ALMListMgrBL.PerformALMProjectDisconnection();

                        ALMListMgrBL.LoadALMLists(ALMDomainList.SelectedItem.ToString(), ALMProjectList.SelectedItem.ToString());
                    }
                }
                else
                {
                    LogInfoMessage("Please select a project");
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage("ERROR: " + ex.Message);
            }
        }

        private void lstVwEditMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigSection section = (ConfigSection)ConfigurationManager.GetSection("listConfiguration");

            if (lstVwEditMode.Items.Count > 0)
            {
                //If is a locked list will change the color of the node
                if (section != null)
                {
                    if (lstVwEditMode.SelectedItems.Count > 0)
                    {
                        if (section.ExistListName(lstVwEditMode.SelectedItems[0].Text) ||
                            section.ExistListName(ALMListsTree.SelectedNode.Text))
                        {
                            EnableEditButtons(false);
                            lstVwEditMode.LabelEdit = false;
                            return;
                        }
                        else
                        {
                            EnableEditButtons(true);
                        }
                    }
                }

                if (flag)
                {
                    lstVwEditMode.LabelEdit = true;
                    flag = false;
                }
                else
                {
                    lstVwEditMode.LabelEdit = false;
                }
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (ALMListsTree.Nodes.Count > 0)
            {
                ExportToExcel frmExport = new ExportToExcel(ALMDomainList.SelectedItem.ToString(), ALMProjectList.SelectedItem.ToString());
                frmExport.ShowDialog();

                if (frmExport.DialogResult == DialogResult.OK)
                {
                    LogInfoMessage("Export finished");
                }
            }
            else
            {
                LogInfoMessage("Please select a project");
            }
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (ALMListsTree.Nodes.Count > 0)
                {
                    importFileDialog.FileName = string.Empty;

                    if (importFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (MessageBox.Show("This operation will delete all list items and import the items in a clean list. Would you like to continue?", "INFO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                        	Cursor.Current = Cursors.WaitCursor;

							LogInfoMessage("Please wait, this may take a few minutes");

                        	string message = importExcelBL.ImportFromExcel(importFileDialog.FileName);
                        	//string message = importExcelBL.ImportFromExcelBySheets(importFileDialog.FileName);

                        	LogInfoMessage(message);

							Cursor.Current = Cursors.Default;

                        	LoadALMLists(ALMDomainList.SelectedItem.ToString(), ALMProjectList.SelectedItem.ToString());
						}
                    }
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage("ERROR: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ALMListsTree.Nodes.Count > 0)
            {
                // When the search condition changes, call FindNodeText to research
                if (currentSearchText != txtSearch.Text.ToUpper())
                {
                    currentSearchText = txtSearch.Text.ToUpper();
                    foundNodes = new List<TreeNode>();
                    foundNodes = FindNodeByText(this.ALMListsTree.Nodes[0].Nodes, currentSearchText);
                    selectedIndex = 0;
                }
                if (selectedIndex < foundNodes.Count)
                {
                    // Select found nodes one by one
                    ALMListsTree.SelectedNode = foundNodes[selectedIndex++];
                    ALMListsTree.Focus();
                }
                else
                {
                    selectedIndex = 0;
                }
            }
        }

        private void cmbALMServer_KeyUp(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Delete && cmbALMServer.Text.Trim().Equals(string.Empty)) ||
                (e.KeyCode == Keys.Back && cmbALMServer.Text.Trim().Equals(string.Empty)))
            {
                DeleteServer(cmbALMServer.Items[selectedCmbIndex].ToString());

                FillALMServers();
            }

            if (e.KeyCode == Keys.Enter)
            {
                AddServer(cmbALMServer.Text);
                FillALMServers();
            }
        }

        private void cmbALMServer_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedCmbIndex = cmbALMServer.SelectedIndex;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Sets all the initial configurations to the form.
        /// </summary>
        private void InitializeForm()
        {
            StatusLabel.Text = string.Empty;

            ColumnHeader h = new ColumnHeader();
            h.Width = lstVwEditMode.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            lstVwEditMode.Columns.Add(h);

            EnableAllButtons(false);

            ALMLoginTab.Focus();
            cmbALMServer.Focus();
            cmbALMServer.Select();

            FillALMServers();

            if (cmbALMServer.Items.Count > 0)
            {
                cmbALMServer.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Fills the combobox with all servers that are in the app.config
        /// </summary>
        private void FillALMServers()
        {
            try
            {
                this.cmbALMServer.Items.Clear();
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                
                ConfigSection configSection = (ConfigSection)config.GetSection("serverConfiguration");

                if (configSection != null)
                {
                    if (configSection.ServerNames.Count > 0)
                    {
                        for (int i = 0; i < configSection.ServerNames.Count; i++)
                        {
                            this.cmbALMServer.Items.Add(configSection.ServerNames[i].Name);
                        }
                    }
                    else
                    {
                        LogErrorMessage("Please validate servers configuration");
                        ALMLoginButton.Enabled = false;
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                LogErrorMessage("ERROR: " + e.Message);
            }
        }

        /// <summary>
        /// Validate an add a new server if doesn't exists in the App.config
        /// </summary>
        /// <param name="serverName"></param>
        private void AddServer(string serverName)
        {
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");
            XmlNode serverNamesNode = xmlDoc.SelectSingleNode("configuration/serverConfiguration/serverNames");
            try
            {
                if (KeyExists(serverName))
                {
                    LogErrorMessage("Server <" + serverName + "> already exists in the configuration.");
                    return;
                }

                XmlNode newChild = serverNamesNode.FirstChild.Clone();
                newChild.Attributes["name"].Value = serverName;
                serverNamesNode.AppendChild(newChild);
                //We have to save the configuration in two places, 
                //because while we have a root App.config,
                //we also have an ApplicationName.exe.config.
                xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");
                xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                //xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
                ConfigurationManager.RefreshSection("serverConfiguration");
            }
            catch (Exception ex)
            {
                LogErrorMessage("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Determines if a server exists within the App.config
        /// </summary>
        /// <param name="serverName"></param>
        /// <returns></returns>
        public bool KeyExists(string serverName)
        {
            XmlNode serverNamesNode =
              xmlDoc.SelectSingleNode("configuration/serverConfiguration/serverNames");
            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in serverNamesNode)
            {
                if (childNode.Attributes["name"].Value == serverName)
                    return true;
            }
            return false;
        }

        public void DeleteServer(string serverName)
        {
            xmlDoc.Load(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");
            if (!KeyExists(serverName))
            {
                LogErrorMessage("Server <" + serverName + "> does not exist in the configuration. Update failed.");
            }

            XmlNode serverNamesNode = xmlDoc.SelectSingleNode("configuration/serverConfiguration/serverNames");

            // Attempt to locate the requested setting.
            foreach (XmlNode childNode in serverNamesNode)
            {
                if (childNode.Attributes["name"].Value == serverName)
                    serverNamesNode.RemoveChild(childNode);
            }

            xmlDoc.Save(AppDomain.CurrentDomain.BaseDirectory + "..\\..\\App.config");
            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        /// <summary>
        /// Login the user
        /// </summary>
        /// <returns>True if login successfull. False if there was a problem</returns>
        private bool PerformLogin() 
        {
            try
            {
                if (cmbALMServer.Items.Count > 0)
                {
                    ALMLoginLabel.ForeColor = Color.Black;
                    ALMLoginLabel.Text = "Logging in to ALM... ";
                    LogInfoMessage("Logging in to ALM... ");
                    ALMLoginButton.Enabled = false;

                    ALMListMgrBL.PerformALMLogin(cmbALMServer.Text, ALMUser.Text, ALMPassword.Text);

                    LogInfoMessage("Finished ALM login");
                    ALMUser.Enabled = false;
                    ALMPassword.Enabled = false;
                    ALMLoginLabel.ForeColor = Color.Blue;
                    ALMLoginLabel.Text = "Logged in as " + ALMUser.Text;
                    ALMLoginLabel.Enabled = true;
                    ALMLogOffButton.Enabled = true;
                    ALMDomainList.Enabled = true;
                    ALMProjectList.Enabled = true;
                    TabControl.SelectedTab = ALMListManagerTab;
                    ALMDomainList.Focus();

                    return true;
                }
                else
                {
                    LogErrorMessage("Please validate servers configuration");
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogErrorMessage("ALM login FAILED.");
                string errorMessage = "Error while login in.";
                if (ex.Message.Contains("Retrieving the COM class factory for component with CLSID"))
                {
                    errorMessage = "Please install ALM, it is a prerequisite for using this tool.";
                }
                else if (ex.Message.Contains("Unable to cast COM object of type"))
                {
                    errorMessage = "Please install ALM connectivity addin, it is a prerequisite for using this tool.";
                }
                LogErrorMessage(errorMessage + " For more info check the user guide. Error: " + ex.Message);
                ALMLoginLabel.ForeColor = Color.Red;
                ALMLoginLabel.Text = errorMessage;
                ALMPassword.Focus();
                ALMPassword.SelectAll();
                ALMLoginButton.Enabled = true;
                ALMDomainList.Enabled = false;
                ALMProjectList.Enabled = false;

                ALMListMgrBL.ALMLogOff();

                EnableAllButtons(false);

                return false;
            }
        }

        /// <summary>
        /// Fill the Domain combobox
        /// </summary>
        private void LoadALMDomains()
        {
            try
            {
                LogInfoMessage("Loading list of ALM domains... ");
                ALMDomainList.Items.Clear();
                ALMDomainList.Items.Add("Loading list of ALM domains.");
                ALMDomainList.Items.Add("This may take a few minutes please be patient... ");

                List<string> almDomainNameList = ALMListMgrBL.LoadALMDomains();

                ALMDomainList.Items.Clear();
                ALMDomainList.Items.AddRange(almDomainNameList.ToArray());

                LogInfoMessage("Finished loading ALM domains.");
            }
            catch (Exception ex)
            {
                LogErrorMessage("FAILED loading ALM domains.");
                LogErrorMessage(ex.Message);
                ALMUser.Enabled = true;
                ALMPassword.Enabled = true;
                ALMLoginButton.Enabled = true;
            }
        }

        /// <summary>
        /// Log the messages to a logfile and shows the error on screen.
        /// </summary>
        /// <param name="status">Message to log</param>
        private void LogInfoMessage(string status)
        {
            LogToFile.LogInfoMessage(status);
            LogTextBox.Text += string.Format("{0:yyyy-MM-dd  HH:mm:ss}", DateTime.Now.ToUniversalTime()) 
                + "\t"
                + "INFO"
                + "\t" 
                + status 
                + Environment.NewLine;
            LogTextBox.SelectionStart = LogTextBox.Text.Length;
            LogTextBox.ScrollToCaret();

            StatusLabel.Text = status;
            
            LogTextBox.Refresh();
            StatusBar.Refresh();
        }

        /// <summary>
        /// Log the warn messages to a logfile and shows the error on screen.
        /// </summary>
        /// <param name="status">Message to log</param>
        private void LogWarnMessage(string status)
        {
            LogToFile.LogInfoMessage(status);
            LogTextBox.Text += string.Format("{0:yyyy-MM-dd  HH:mm:ss}", DateTime.Now.ToUniversalTime()) 
                + "\t" 
                + "WARN"
                + "\t" 
                + status 
                + Environment.NewLine;
            LogTextBox.SelectionStart = LogTextBox.Text.Length;
            LogTextBox.ScrollToCaret();

            StatusLabel.Text = status;

            LogTextBox.Refresh();
            StatusBar.Refresh();
        }

        /// <summary>
        /// Log the error messages to a logfile and shows the error on screen.
        /// </summary>
        /// <param name="status">Message to log</param>
        private void LogErrorMessage(string status)
        {
            LogToFile.LogInfoMessage(status);
            LogTextBox.Text += string.Format("{0:yyyy-MM-dd  HH:mm:ss}", DateTime.Now.ToUniversalTime())
                + "\t"
                + "ERROR"
                + "\t"
                + status 
                + Environment.NewLine;
            LogTextBox.SelectionStart = LogTextBox.Text.Length;
            LogTextBox.ScrollToCaret();

            StatusLabel.Text = status;

            LogTextBox.Refresh();
            StatusBar.Refresh();
        }

        /// <summary>
        /// Perform ALM logoff
        /// </summary>
        public void PerformLogOff()
        {
            try
            {
                LogInfoMessage("User logged off from ALM session. Aborting sessions in the middle of a transaction may cause some exceptions, please ignore any exceptions in the following seconds.");
                ALMLoginLabel.ForeColor = Color.Black;
                ALMLoginLabel.Text = "Please log in to ALM...";
                ALMPassword.Text = "";
                ALMUser.Enabled = true;
                ALMPassword.Enabled = true;
                ALMLoginButton.Enabled = true;
                ALMLogOffButton.Enabled = false;

                ALMListMgrBL.ALMLogOff();

                ALMDomainList.Items.Clear();
                ALMProjectList.Items.Clear();
                ALMDomainList.Enabled = false;
                ALMProjectList.Enabled = false;
                ALMPassword.Focus();
                ALMPassword.SelectAll();

                EnableAllButtons(false);
                ALMListsTree.Nodes.Clear();
                lstVwEditMode.Items.Clear();
            }
            catch (Exception ex)
            {
                LogErrorMessage("ERROR: " + ex.Message);
            }
        }

        /// <summary>
        /// Fills the Projects combobox according a domain
        /// </summary>
        /// <param name="ALMDomainName">Domain name</param>
        public void LoadALMProjects(object ALMDomainName)
        {
            try
            {
                LogInfoMessage("Loading list of ALM projects in the selected domain (" + ALMDomainName + ")... ");
                ALMProjectList.Items.Clear();
                ALMProjectList.Items.Add("Loading list of ALM projects in the selected domain (" + ALMDomainName + ")... ");
                ALMProjectList.Items.Add("This may take a few minutes please be patient... ");
                ALMProjectList.Enabled = false;

                List<string> almProjectNameList = ALMListMgrBL.LoadALMProjects(ALMDomainName.ToString());

                ALMProjectList.Items.Clear();
                ALMProjectList.Items.AddRange(almProjectNameList.ToArray());
                LogInfoMessage("Finished loading ALM projects.");
                ALMProjectList.Enabled = true;
                ALMProjectList.Focus();
            }
            catch (Exception ex)
            {
                LogErrorMessage("User Logged off from ALM session. Load projects aborted. " + ex.Message);
            }
        }

        /// <summary>
        /// Fills the TreeView object with al ALM Project Lists
        /// </summary>
        /// <param name="ALMDomainName">Domain Name</param>
        /// <param name="ALMProjectName">Project Name</param>
        private void LoadALMLists(string ALMDomainName, string ALMProjectName)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ALMDomainList.Enabled = false;
                ALMProjectList.Enabled = false;

                LogInfoMessage("Loading ALM Lists in: " + ALMDomainList.SelectedItem.ToString() + "/"
                        + ALMProjectList.SelectedItem.ToString());
                LogInfoMessage("This may take a few minutes, please be patient...");

                ALMListsTree.BeginUpdate();
                ALMListsTree.Nodes.Clear();

                ALMListMgrBL.LoadALMLists(ALMDomainName, ALMProjectName);

                TreeNode node = ALMListMgrBL.FillTreeView();

                ALMListsTree.Nodes.Add(node);
                ALMListsTree.TopNode.Text = "Lists";
                ALMListsTree.TopNode.Name = "-1";
                ALMListsTree.TopNode.Expand();
                ALMListsTree.EndUpdate();
                ALMListsTree.Sort();

                LogInfoMessage("Finished loading ALM Lists");

                EnableAllButtons(true);
                ALMDomainList.Enabled = true;
                ALMProjectList.Enabled = true;

                Cursor.Current = Cursors.Default;
            }
            catch (Exception e)
            {
                LogErrorMessage("Failed loading ALM Lists");
                LogErrorMessage(e.Message);
            }
        }

        /// <summary>
        /// Fills the listview object with the items from the selected list
        /// </summary>
        /// <param name="id">ID of parent item</param>
        /// <param name="ALMDomainName">Domain Name</param>
        /// <param name="ALMProjectName">Project Name</param>
        private void LoadChildrenList(int id, string ALMDomainName, string ALMProjectName)
        {
            ALMListMgrBL.FillList(ref lstVwEditMode, id);
            
        }

        /// <summary>
        /// Enable-Disable all the controls in the main form
        /// </summary>
        /// <param name="status">True to enable, False to disable</param>
        private void EnableAllButtons(bool status)
        {
            this.btnNewItem.Enabled = status;
            this.btnRenameItem.Enabled = status;
            this.btnDeleteItem.Enabled = status;
            this.btnSave.Enabled = status;
            this.btnSaveTo.Enabled = status;
            this.btnExportToExcel.Enabled = status;
            this.btnImportExcel.Enabled = status;
            this.txtSearch.Enabled = status;
            this.btnSearch.Enabled = status;
        }

        /// <summary>
        /// Enable-Disable all buttons of edition mode
        /// </summary>
        /// <param name="status">True to enable, False to disable</param>
        private void EnableEditButtons(bool status)
        {
            this.btnNewItem.Enabled = status;
            this.btnRenameItem.Enabled = status;
            this.btnDeleteItem.Enabled = status;
            this.btnSave.Enabled = status;
        }

        /// <summary>
        /// Save the performed changes to ALM server
        /// </summary>
        /// <param name="id">List parent ID</param>
        /// <param name="vw">ListView object</param>
        private void Save(int id, ListView vw)
        {
            string str = ALMListMgrBL.Save(id, vw);

            LogInfoMessage(str);
        }

        /// <summary>
        /// Permits perform a search in the TreeView object
        /// </summary>
        /// <param name="treeNodeCol">Node collection</param>
        /// <param name="nodeText">Text to search</param>
        /// <returns>Returns a list of treenodes with the items that match what is searched</returns>
        private List<TreeNode> FindNodeByText(TreeNodeCollection treeNodeCol, string nodeText)
        {
            // Store the found node
            List<TreeNode> lstFoundNode = new List<TreeNode>();

            // Traversal stack
            Stack<TreeNode> nodeStack = new Stack<TreeNode>();

            for (int i = 0; i < treeNodeCol.Count; i++)
            {
                nodeStack.Push(treeNodeCol[i]);
            }

            //Reverse stack
            Stack<TreeNode> reverseStack = new Stack<TreeNode>(nodeStack);

            while (reverseStack.Count != 0)
            {
                TreeNode treeNode = reverseStack.Pop();

                if (treeNode.Text.ToUpper().Contains(nodeText.ToUpper()))
                {
                    lstFoundNode.Add(treeNode);
                }
            }

            return lstFoundNode;
        }

        #endregion

        private void ALMListManagerFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure we disconnect from ALM when closing
            PerformLogOff();
        }
    }
        
}
