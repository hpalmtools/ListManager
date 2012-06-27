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
using System.Linq;
using System.Text;
using System.Configuration;
using TDAPIOLELib;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;


namespace hp.go2alm.ALMListManagerTool
{
    public class ALMListManagerBL
    {
        ALMListManagerDAO ALMListMgrDAO = new ALMListManagerDAO();

        /// <summary>
        /// Creates the connection to ALM
        /// </summary>
        /// /// <param name="serverName">ALM server name</param>
        /// <param name="ALMUser">ALM User</param>
        /// <param name="ALMPassword">ALM Password</param>
        public void PerformALMLogin(string serverName, string ALMUser, string ALMPassword)
        {
            ALMListMgrDAO.PerformALMLogin(serverName, ALMUser, ALMPassword);
        }

        /// <summary>
        /// Gets the list of domains where the user has access
        /// </summary>
        /// <returns>Returns a list of strings with the names of the domains</returns>
        public List<string> LoadALMDomains()
        {
            return ALMListMgrDAO.GetALMDomainList();
        }

        /// <summary>
        /// Gets the list of projects according to a particular domain
        /// </summary>
        /// <param name="ALMDomainName">Domain Name</param>
        /// <returns>Returns a list of strings with the names of the projects</returns>
        public List<string> LoadALMProjects(string ALMDomainName)
        {
            return ALMListMgrDAO.GetALMProjectList(ALMDomainName);
        }

        /// <summary>
        /// Log off the user and release the ALM connection
        /// </summary>
        public void ALMLogOff()
        {
            ALMListMgrDAO.ALMLogOff();
        }

        /// <summary>
        /// Creates connection to the Domain/Project. Open customization. Gets the lists of the particular domain/project
        /// </summary>
        /// <param name="ALMDomainName">Domain Name</param>
        /// <param name="ALMProjectName">Project Name</param>
        public void LoadALMLists(string ALMDomainName, string ALMProjectName)
        {
            ALMListMgrDAO.PerformALMProjectConnection(ALMDomainName, ALMProjectName);
            LoadCustomization();
            CommonProperties.CustomLists = ALMListMgrDAO.GetALMLists();
        }

        /// <summary>
        /// Fills the TreeView object with al the lists
        /// </summary>
        /// <returns>Returns a TreeNode with all the collection of lists</returns>
        public TreeNode FillTreeView()
        {
            TreeNode treeNode = new TreeNode();
            TreeNode node = new TreeNode();
            CustomizationList customList;
            CustomizationListNode customListNode;

            ConfigSection section = (ConfigSection)ConfigurationManager.GetSection("listConfiguration");

            for (int i = 0; i < CommonProperties.CustomLists.Count; i++)
            {
                customList = (CustomizationList)CommonProperties.CustomLists.get_ListByCount(i + 1);
                customListNode = (CustomizationListNode)customList.RootNode;

                //Fills the root node
                treeNode.Nodes.Add(customListNode.ID.ToString(), customListNode.Name);
                
                //If is a locked list will change the color of the node
                if (section != null)
                {
                    if (section.ExistListName(customListNode.Name))
                    {
                        treeNode.Nodes[i].ForeColor = Color.Gray;
                    }
                }

                //Current Node
                node = treeNode.Nodes[i];
                FillTreeViewChildren(ref node, customListNode);
                treeNode.Nodes[i] = node;

            }

            return treeNode;
        }

        /// <summary>
        /// Fills all the children of a particular list
        /// </summary>
        /// <param name="parentNode">Root list</param>
        /// <param name="parentCListNode">Custom list node</param>
        private void FillTreeViewChildren(ref TreeNode parentNode, CustomizationListNode parentCListNode)
        {
            if (parentCListNode.ChildrenCount > 0)
            {
                List childList = new List();
                childList = parentCListNode.Children;

                for (int i = 0; i < childList.Count; i++)
                {
                    CustomizationListNode childListNode = (CustomizationListNode)childList[i + 1];

                    parentNode.Nodes.Add(childListNode.ID.ToString(), childListNode.Name);

                    if (parentNode.ForeColor == Color.Gray)
                    {
                        parentNode.Nodes[i].ForeColor = Color.Gray;
                    }

                    if (childListNode.Children.Count > 0)
                    {
                        TreeNode currentNode = parentNode.Nodes[childListNode.ID.ToString()];
                        FillTreeViewChildren(ref currentNode,childListNode);
                    }
                }
            }
        }

        /// <summary>
        /// Fills the ListView object (Let the blocked list to display)
        /// </summary>
        /// <param name="lstVw">Object ListView</param>
        /// <param name="id">Id of the parent list</param>
        public void FillList(ref ListView lstVw, int id, bool showBlockedLists=true)
        {
            CustomizationList customList;
            CustomizationListNode customListNode;
            if (id != -1)
            {
                customList = (CustomizationList)CommonProperties.CustomLists.get_List(id);
                customListNode = (CustomizationListNode)customList.Find(id);

                if (customListNode.ChildrenCount > 0)
                {
                    List childList = new List();
                    childList = customListNode.Children;

                    for (int i = 0; i < childList.Count; i++)
                    {
                        CustomizationListNode childListNode = (CustomizationListNode)childList[i + 1];

                        lstVw.Items.Add(childListNode.ID.ToString(), childListNode.Name, null);
                    }
                }
            }
            else
            {
                ConfigSection section = (ConfigSection)ConfigurationManager.GetSection("listConfiguration");

                for (int i = 0; i < CommonProperties.CustomLists.Count; i++)
                {
                    customList = (CustomizationList)CommonProperties.CustomLists.get_ListByCount(i + 1);
                    customListNode = (CustomizationListNode)customList.RootNode;

                    

                    //If is a locked list will change the color of the node
                    if (section != null)
                    {
                        if (section.ExistListName(customListNode.Name)) //Change color if it's a blocked list
                        {
                            if (showBlockedLists)
                            {
                                lstVw.Items.Add(customListNode.ID.ToString(), customListNode.Name, null);
                                lstVw.Items[customListNode.ID.ToString()].ForeColor = Color.Gray;
                            }
                        }
                        else
                        {
                            lstVw.Items.Add(customListNode.ID.ToString(), customListNode.Name, null);
                        }
                    }
                    else
                    {
                        throw new Exception("Please validate configuration of blocked lists");
                    }
                }
            }
        }

        /// <summary>
        /// Saves all the actions that the user can perform.
        /// </summary>
        /// <param name="id">Id of the parent list</param>
        /// <param name="lstView">ListView object</param>
        public string Save(int id, ListView lstView)
        {
            CustomizationList customList;
            CustomizationListNode parentListNode;
            DateTime dt = DateTime.Now.ToUniversalTime();
            string message = "Changes applied to the list: " + Environment.NewLine;
            string errorMessage = "\t \t \t \t Errors found: " + Environment.NewLine;

            try
            {
                if (id != -1) //When it's an item and not a project list
                {
                    parentListNode = ALMListMgrDAO.GetALMListNode(id);
                    //customList = (CustomizationList)CustomLists.get_List(id);
                    //parentListNode = (CustomizationListNode)customList.Find(id);

                    if (parentListNode.ChildrenCount > 0)
                    {
                        List childList = new List();
                        childList = parentListNode.Children; //Get the children of the parent list

                        for (int i = 0; i < childList.Count; i++)
                        {

                            //Cast the object to a CustomizationListNode
                            CustomizationListNode childListNode = (CustomizationListNode)childList[i + 1];

                            //RENAME
                            //If the childID exists in the list
                            if (lstView.Items.ContainsKey(childListNode.ID.ToString()))
                            {
                                string value = lstView.Items[childListNode.ID.ToString()].Text;

                                //And it's different
                                if (!value.Equals(childListNode.Name.ToString()))
                                {
                                    if (!ExistsCustomListNode(value, parentListNode))
                                    {
                                        message += "\t \t \t \t \t Item '" + childListNode.Name + "' renamed to '" + value + "'" + Environment.NewLine;
                                        childListNode.Name = value; //Rename the item
                                    }
                                    else
                                    {
                                        errorMessage += "\t \t \t \t \t Item '" + childListNode.Name + "' could not be renamed. The item already exists" + Environment.NewLine;
                                    }

                                }
                            }
                            //DELETE
                            else //If the childID doesn't exist in the list, will delete it
                            {
                                parentListNode.RemoveChild(childListNode);
                                message += "\t \t \t \t \t Item '" + childListNode.Name.ToString() + "' deleted " + Environment.NewLine;
                            }
                        }
                    }

                    //ADD
                    //Scroll the list and look for the items with ID= -1 (New ones)
                    for (int j = 0; j < lstView.Items.Count; j++)
                    {
                        if (lstView.Items[j].Name.Equals("-1"))
                        {
                            //Validates that the name doesn't exist in any of the items in the list
                            if (!ExistsCustomListNode(lstView.Items[j].Text, parentListNode))
                            {
                                parentListNode.AddChild(lstView.Items[j].Text);
                                message += "\t \t \t \t \t Item '" + lstView.Items[j].Text + "' added" + Environment.NewLine;
                            }
                            else
                            {
                                errorMessage += "\t \t \t \t \t Item '" + lstView.Items[j].Text + "' could not be added. The item already exists" + Environment.NewLine;
                            }
                        }
                    }
                }
                else //When is the root List
                {
                    for (int i = 0; i < CommonProperties.CustomLists.Count; i++)
                    {
                        customList = (CustomizationList)CommonProperties.CustomLists.get_ListByCount(i + 1);
                        parentListNode = (CustomizationListNode)customList.RootNode;

                        //RENAME LIST
                        //If the list exists in the object ListView
                        if (lstView.Items.ContainsKey(parentListNode.ID.ToString()))
                        {
                            string value = lstView.Items[parentListNode.ID.ToString()].Text;

                            // And the name is different
                            if (!value.Equals(parentListNode.Name))
                            {
                                if (!CommonProperties.CustomLists.get_IsListExist(value))
                                {
                                    message += "\t \t \t \t \t List '" + parentListNode.Name + "' renamed to '" + value + "'" + Environment.NewLine;
                                    parentListNode.Name = value;
                                }
                                else
                                {
                                    errorMessage += "\t \t \t \t \t List '" + parentListNode.Name + "' could not be renamed. The list already exists" + Environment.NewLine;
                                }
                            }
                        }
                        //DELETE LIST
                        else
                        {
                            //Only specific role can delete lists
                            if (IsUserInGroupList(ConfigurationManager.AppSettings["groupToDeleteLists"]))
                            {
                                //If the list doesn't come from the template
                                if (!parentListNode.IsTemplate)
                                {
                                    CommonProperties.CustomLists.RemoveList(parentListNode.Name);
                                    message += "\t \t \t \t \t List '" + parentListNode.Name + "' deleted " + Environment.NewLine;
                                }
                                else
                                {
                                    errorMessage += "\t \t \t \t \t List '" + parentListNode.Name + "' couldn't be removed. Is flagged as a template list." + Environment.NewLine;
                                }
                            }
                            else
                            {
                                errorMessage += "\t \t \t \t \t List '" + parentListNode.Name + "' couldn't be removed. Insufficient permissions." + Environment.NewLine;
                            }
                        }
                    }

                    //ADD LIST
                    for (int j = 0; j < lstView.Items.Count; j++)
                    {
                        //If the item ID = -1 (New ones)
                        if (lstView.Items[j].Name.Equals("-1"))
                        {
                            //Validates that the list doesn't exist
                            if (!CommonProperties.CustomLists.get_IsListExist(lstView.Items[j].Text))
                            {
                                CommonProperties.CustomLists.AddList(lstView.Items[j].Text);
                                message += "\t \t \t \t \t List '" + lstView.Items[j].Text + "' added." + Environment.NewLine;
                            }
                            else
                            {
                                errorMessage += "\t \t \t \t \t List '" + lstView.Items[j].Text + "' couldn't be added. The list already exists." + Environment.NewLine;
                            }
                        }
                    }
                }

                ALMListMgrDAO.CommitCustomization();

                if (!message.Equals("Changes applied to the list: " + Environment.NewLine))
                {
                    if (!errorMessage.Equals("\t \t \t \t Errors found: " + Environment.NewLine))
                    {
                        return message + Environment.NewLine + errorMessage;
                    }
                    else
                    {
                        return message;
                    }
                }
                else
                {
                    if (errorMessage.Equals("\t \t \t \t Errors found: " + Environment.NewLine))
                    {
                        return "No changes were applied.";
                    }
                    else
                    {
                        return errorMessage.Substring(8);
                    }
                }
            }
            catch (Exception e)
            {
                errorMessage = "Failed to save List: " + e.Message;
                return errorMessage;
            }
        }

        /// <summary>
        /// Saves list to a diferent project
        /// </summary>
        /// <param name="option">Option selected. 1 - Replace list, 2 - Rename list, 3 - Add new items to list</param>
        /// <param name="ALMDomainName">Domain where the list will be saved</param>
        /// <param name="ALMProjectName">Project where the list will be saved</param>
        /// <param name="oriListName">Name of the original list</param>
        /// <param name="newListName">Name of the new list (If option 2 is selected)</param>
        public string SaveTo(int option, string ALMDomainName, string ALMProjectName, string oriListName, string newListName)
        {
            CustomizationList customListToModify;
            CustomizationListNode customListNode;
            CustomizationListNode oriCustomListNode;
            string message = "Changes applied to the list: " + Environment.NewLine;
            string errorMessage = "\t \t \t \t Errors found: " + Environment.NewLine;

            try
            {
                //Get CustomizationList which will work with
                CustomizationList oriCustomList = ALMListMgrDAO.GetALMList(oriListName);

                //Disconnect user from the original domain/project
                PerformALMProjectDisconnection();

                //Connect to the selected domain/project to save the list
                PerformALMProjectConnection(ALMDomainName, ALMProjectName);

                //Load customization object
                LoadCustomization();

                //Get all project lists of current domain/project
                CommonProperties.CustomLists = ALMListMgrDAO.GetALMLists();


                switch (option)
                {
                    case 1: //REPLACE LIST

                        //Deletes the list if exists
                        if (CommonProperties.CustomLists.get_IsListExist(oriListName))
                        {
                            CustomizationList customList = (CustomizationList)CommonProperties.CustomLists.get_List(oriCustomList.Name);
                            CustomizationListNode customListNode1 = (CustomizationListNode)customList.RootNode;
                            //CommonProperties.CustomLists.RemoveList(oriListName);

                            List lst = customListNode1.Children;
                            foreach (CustomizationListNode CurrentNode in lst)
                            {
                                customListNode1.RemoveChild(CurrentNode.Name);
                            }

                            //Applies customization
                            ALMListMgrDAO.CommitCustomization();
                        }
                        else
                        {
                            CommonProperties.CustomLists.AddList(oriCustomList.Name);
                            //Applies customization
                            ALMListMgrDAO.CommitCustomization();
                        }

                        customListToModify = (CustomizationList)CommonProperties.CustomLists.get_List(oriCustomList.Name);

                        customListNode = (CustomizationListNode)customListToModify.RootNode;
                        oriCustomListNode = (CustomizationListNode)oriCustomList.RootNode;

                        if (oriCustomListNode.ChildrenCount > 0)
                        {
                            AddItemsToList(oriCustomListNode, customListNode);
                        }

                        message += "\t \t \t \t \t The list '" + oriCustomList.Name + "' was replaced." + Environment.NewLine;

                        break;

                    case 2: //RENAME LIST
                        if (CommonProperties.CustomLists.get_IsListExist(oriListName))
                        {
                            customListToModify = (CustomizationList)CommonProperties.CustomLists.get_List(oriCustomList.Name);
                            customListNode = (CustomizationListNode)customListToModify.RootNode;
                            customListNode.Name = newListName;

                            message += "\t \t \t \t \t The list '" + oriListName + "' was renamed to '" + newListName + "'" + Environment.NewLine;
                        }
                        else //If the list doesn't exist
                        {
                            errorMessage += "\t \t \t \t \t Failed to rename list. The list '" + oriListName + "' doesn't exist in " + ALMDomainName + "/" + ALMProjectName + Environment.NewLine;
                        }
                        break;

                    case 3: //NEW ITEMS
                        if (CommonProperties.CustomLists.get_IsListExist(oriListName))
                        {
                            customListToModify = (CustomizationList)CommonProperties.CustomLists.get_List(oriCustomList.Name);

                            customListNode = (CustomizationListNode)customListToModify.RootNode;
                            oriCustomListNode = (CustomizationListNode)oriCustomList.RootNode;

                            message +=  AddItemsToList(oriCustomListNode, customListNode);
                        }
                        else
                        {
                            errorMessage += "\t \t \t \t \t Failed to add items to the list. The list '" + oriListName + "' doesn't exist in " + ALMDomainName + "/" + ALMProjectName + Environment.NewLine;
                        }
                        break;
                }

                //Apply all changes
                ALMListMgrDAO.CommitCustomization();

                if (!message.Equals("Changes applied to the list: " + Environment.NewLine))
                {
                    if (!errorMessage.Equals("\t \t \t \t Errors found: " + Environment.NewLine))
                    {
                        return message + Environment.NewLine + errorMessage;
                    }
                    else
                    {
                        return message;
                    }
                }
                else
                {
                    if (errorMessage.Equals("\t \t \t \t Errors found: " + Environment.NewLine))
                    {
                        return "No changes were applied.";
                    }
                    else
                    {
                        return errorMessage.Substring(8);
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage += "Failed updating list " + oriListName + ". " + ex.Message;
                return errorMessage;
            }
        }

        /// <summary>
        /// Method to add items to a ALM customList
        /// </summary>
        /// <param name="oriCustomListNode">Original CustomListNode where will be add new items</param>
        /// <param name="currentCustomListNode">CustomListNode where the items are taken to save them to the original customList</param>
        /// <returns>Returns the message of the performed operations</returns>
        private string AddItemsToList(CustomizationListNode oriCustomListNode, CustomizationListNode currentCustomListNode)
        {
            string message = "";
            for (int i = 0; i < oriCustomListNode.ChildrenCount; i++)
            {
                CustomizationListNode customGrandChild = null;
                List oriChildList = new List();
                List currentChildList = new List();
                oriChildList = oriCustomListNode.Children;
                currentChildList = currentCustomListNode.Children;


                //Get the original ChildListNode
                CustomizationListNode oriChildListNode = (CustomizationListNode)oriChildList[i + 1];

                if (oriChildListNode.ChildrenCount > 0) //If the child has grandchildren
                {
                    if (!ExistsCustomListNode(oriChildListNode.Name, currentCustomListNode)) //If the item doesn't exist
                    {
                        currentCustomListNode.AddChild(oriChildListNode.Name);
                        customGrandChild = (CustomizationListNode)currentCustomListNode.get_Child(oriChildListNode.Name);

                        AddItemsToList(oriChildListNode, customGrandChild);
                        message += "\t \t \t \t \t Item '" + oriChildListNode.Name + "' added to List '" + oriCustomListNode.Name + "'" + Environment.NewLine;
                    }
                }
                else // If child has no more children
                {
                    if (!ExistsCustomListNode(oriChildListNode.Name, currentCustomListNode)) //If the item doesn't exist
                    {
                        currentCustomListNode.AddChild(oriChildListNode.Name);
                        message += "\t \t \t \t \t Item '" + oriChildListNode.Name + "' added to List '" + oriCustomListNode.Name + "'" + Environment.NewLine;
                    }
                }
            }

            return message;
        }

        /// <summary>
        /// Validates that the item exists in the list
        /// </summary>
        /// <param name="listNodeName">Name of the list to validate</param>
        /// <param name="customListNode">CustomizationListNode to validate</param>
        /// <returns>True if exists, False if don't</returns>
        private bool ExistsCustomListNode(string listNodeName, CustomizationListNode customListNode)
        {
            CustomizationListNode childListNode;
            for (int i = 0; i < customListNode.ChildrenCount; i++)
            {
                List childList = new List();
                childList = customListNode.Children;

                childListNode = (CustomizationListNode)childList[i + 1];

                if (childListNode.Name.Equals(listNodeName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Validate if the logged user belongs to an specific groupList
        /// </summary>
        /// <param name="groupList">groupList name</param>
        /// <returns>True if the user belongs to the specific groupList. False if not</returns>
        public bool IsUserInGroupList(string groupList)
        {
            return ALMListMgrDAO.IsUserInGroupList(groupList);
        }

        /// <summary>
        /// Loads the customization object
        /// </summary>
        public void LoadCustomization()
        {
            ALMListMgrDAO.LoadCustomization();
        }

        /// <summary>
        /// Perform ALM project disconnection
        /// </summary>
        public void PerformALMProjectDisconnection()
        {
            ALMListMgrDAO.PerformALMProjectDisconnection();
        }

        /// <summary>
        /// Perform ALM project connection
        /// </summary>
        /// <param name="ALMDomainName">Domain name</param>
        /// <param name="ALMProjectName">Project name</param>
        public void PerformALMProjectConnection(string ALMDomainName, string ALMProjectName)
        {
            ALMListMgrDAO.PerformALMProjectConnection(ALMDomainName, ALMProjectName);
        }

        /// <summary>
        /// Release the connection object.
        /// </summary>
        public void ReleaseConnObject()
        {
            ALMListMgrDAO.ReleaseConnObject();
        }
    }
}
