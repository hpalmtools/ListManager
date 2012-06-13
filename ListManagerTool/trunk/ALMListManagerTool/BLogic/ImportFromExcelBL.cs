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
using Microsoft.Office.Interop.Excel;
using TDAPIOLELib;
using System.Collections;
using System.Configuration;

namespace hp.go2alm.ALMListManagerTool
{
    public class ImportFromExcelBL
    {
        #region Variables
        ALMListManagerDAO ALMListMgrDAO = new ALMListManagerDAO();
        Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
        Workbook wb;
        Worksheet ws;
        #endregion

        #region Methods
        /// <summary>
        /// Method to import an excel file
        /// </summary>
        /// <param name="filename">Excel path and filename</param>
        /// <returns>Returns a message with all the actions performed</returns>
        public string ImportFromExcel(string filename)
        {
            try
            {
                bool blockedList = false;
                string message = string.Empty;
                ConfigSection section = (ConfigSection)ConfigurationManager.GetSection("listConfiguration");

                List<CollectionKeyValue> list = new List<CollectionKeyValue>();
                wb = xla.Workbooks.Open(filename);
                ws = (Worksheet)wb.Worksheets[1];

                CustomizationList customList;
                CustomizationListNode parentListNode = null;
                CustomizationListNode currentListNode = null;

                Range rg = ws.UsedRange;
                string itemName = string.Empty;

                int rowsCount = rg.Rows.Count;
                int colsCount = rg.Columns.Count;

                for (int i = 2; i <= rowsCount; i++)
                {
                    for (int j = 1; j <= colsCount; j++)
                    {
                        if (((Range)rg.Cells[i, j]).Value2 != null)
                        {
                            itemName = ((Range)rg.Cells[i, j]).Value2.ToString();

                            if (j == 1) //Get list name
                            {
                                if (!itemName.Trim().Equals(string.Empty))
                                {

                                    //If is a locked list won't be imported
                                    if (section != null)
                                    {
                                        if (section.ExistListName(itemName))
                                        {
                                            blockedList = true;
                                            if (message.Equals(string.Empty))
                                            {
                                                message += "The list '" + itemName + "' couldn't be imported. It's a blocked list." + Environment.NewLine;
                                            }
                                            else
                                            {
                                                message += "\t \t \tThe list '" + itemName + "' couldn't be imported. It's a blocked list." + Environment.NewLine;
                                            }
                                        }
                                        else
                                        {
                                            blockedList = false;
                                        }
                                    }
                                    else
                                    {
                                        return "Please validate the configuration of the blocked lists";
                                    }

                                    if (blockedList == false)
                                    {
                                        if (CommonProperties.CustomLists.get_IsListExist(itemName)) //If the item exists, remove it
                                        {
                                            //CommonProperties.CustomLists.RemoveList(itemName); //Remove the list with all its items.

                                            customList = (CustomizationList)CommonProperties.CustomLists.get_List(itemName);
                                            parentListNode = (CustomizationListNode)customList.RootNode;

                                            List lst = parentListNode.Children;
                                            foreach (CustomizationListNode CurrentNode in lst)
                                            {
                                                parentListNode.RemoveChild(CurrentNode.Name);
                                            }

                                            ALMListMgrDAO.CommitCustomization();
                                        }
                                        else
                                        {
                                            CommonProperties.CustomLists.AddList(itemName);
                                            ALMListMgrDAO.CommitCustomization();
                                        }

                                        customList = (CustomizationList)CommonProperties.CustomLists.get_List(itemName);
                                        parentListNode = (CustomizationListNode)customList.RootNode;

                                        list.Add(new CollectionKeyValue(int.Parse(parentListNode.ID.ToString()), j));

                                        if (message.Equals(string.Empty))
                                        {
                                            message += "List '" + itemName + "' imported." + Environment.NewLine;
                                        }
                                        else
                                        {
                                            message += "\t \t \tList '" + itemName + "' imported." + Environment.NewLine;
                                        }

                                        break;
                                    }
                                }
                                else
                                {
                                    return "Wrong format in the list, please validate";
                                }
                            }
                            else // Items of list
                            {
                                if (blockedList == false)
                                {

                                    if (!itemName.Trim().Equals(string.Empty))
                                    {
                                        //Needs to find the parent ID in the list according the position
                                        //Starting with the last item in the list
                                        for (int pos = list.Count - 1; pos >= 0; pos--)
                                        {
                                            //Get the first item with the column less than the current item
                                            if ((j - 1) == list[pos].Position)
                                            {
                                                CustomizationListNode newListNode;
                                                int customListId = list[pos].Id;

                                                //If the id is different from the parentList ID
                                                if (customListId != int.Parse(parentListNode.ID.ToString()))
                                                {
                                                    //Get the CustomListNode to add the child
                                                    currentListNode = SearchItemById(customListId, parentListNode);
                                                    currentListNode.AddChild(itemName);
                                                    newListNode = (CustomizationListNode)currentListNode.get_Child(itemName);

                                                    list.Add(new CollectionKeyValue(int.Parse(newListNode.ID.ToString()), j));
                                                }
                                                else //Is a child of the parent list
                                                {
                                                    parentListNode.AddChild(itemName);
                                                    newListNode = (CustomizationListNode)parentListNode.get_Child(itemName);
                                                    list.Add(new CollectionKeyValue(int.Parse(newListNode.ID.ToString()), j));
                                                }


                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }

                //Applies customization
                ALMListMgrDAO.CommitCustomization();

                if (message.Equals(string.Empty))
                {
                    message += "Import finished.";
                }
                else
                {
                    message += "\t \t \tImport finished.";
                }

                return message;
            }
            catch (Exception e)
            {
                return "ERROR: " + e.Message;
            }
        }

        /// <summary>
        /// Method to import an excel file by sheets
        /// </summary>
        /// <param name="filename">Excel path and filename</param>
        /// <returns>Returns a message with all the actions performed</returns>
        public string ImportFromExcelBySheets(string filename)
        {
            bool blockedList = false;
            string message = string.Empty;
            ConfigSection section = (ConfigSection)ConfigurationManager.GetSection("listConfiguration");

            List<CollectionKeyValue> list = new List<CollectionKeyValue>();
            wb = xla.Workbooks.Open(filename);
            //ws = (Worksheet)wb.Worksheets[1];

            CustomizationList customList;
            CustomizationListNode parentListNode = null;
            CustomizationListNode currentListNode = null;

            Range rg;// = ws.UsedRange;
            string itemName = string.Empty;

            int rowsCount = -1;// = rg.Rows.Count;
            int colsCount = -1;// = rg.Columns.Count;

            for (int a = 1; a <= wb.Worksheets.Count; a++)
            {
                ws = (Worksheet)wb.Worksheets[a];
                rg = ws.UsedRange;

                rowsCount = rg.Rows.Count;
                colsCount = rg.Columns.Count;

                for (int i = 1; i <= rowsCount; i++)
                {
                    for (int j = 1; j <= colsCount; j++)
                    {
                        if (((Range)rg.Cells[i, j]).Value2 != null)
                        {
                            itemName = ((Range)rg.Cells[i, j]).Value2.ToString();

                            if (j == 1) //Get list name
                            {
                                if (!itemName.Trim().Equals(string.Empty))
                                {
                                    //If is a locked list won't be imported
                                    if (section != null)
                                    {
                                        if (section.ExistListName(itemName))
                                        {
                                            blockedList = true;
                                            if (message.Equals(string.Empty))
                                            {
                                                message += "The list '" + itemName + "' couldn't be imported. It's a blocked list." + Environment.NewLine;
                                            }
                                            else
                                            {
                                                message += "\t \t \tThe list '" + itemName + "' couldn't be imported. It's a blocked list." + Environment.NewLine;
                                            }
                                        }
                                        else
                                        {
                                            blockedList = false;
                                        }
                                    }
                                    else
                                    {
                                        return "Please validate the configuration of the blocked lists";
                                    }

                                    if (blockedList == false)
                                    {
                                        if (CommonProperties.CustomLists.get_IsListExist(itemName)) //If the item exists, remove it
                                        {
                                            //CommonProperties.CustomLists.RemoveList(itemName); //Remove the list with all its items.

                                            customList = (CustomizationList)CommonProperties.CustomLists.get_List(itemName);
                                            parentListNode = (CustomizationListNode)customList.RootNode;

                                            List lst = parentListNode.Children;
                                            foreach (CustomizationListNode CurrentNode in lst)
                                            {
                                                parentListNode.RemoveChild(CurrentNode.Name);
                                            }

                                            ALMListMgrDAO.CommitCustomization();
                                        }
                                        else
                                        {
                                            CommonProperties.CustomLists.AddList(itemName);
                                            ALMListMgrDAO.CommitCustomization();
                                        }

                                        customList = (CustomizationList)CommonProperties.CustomLists.get_List(itemName);
                                        parentListNode = (CustomizationListNode)customList.RootNode;

                                        list.Add(new CollectionKeyValue(int.Parse(parentListNode.ID.ToString()), j));

                                        if (message.Equals(string.Empty))
                                        {
                                            message += "List '" + itemName + "' imported." + Environment.NewLine;
                                        }
                                        else
                                        {
                                            message += "\t \t \tList '" + itemName + "' imported." + Environment.NewLine;
                                        }

                                        break;
                                    }
                                }
                                else
                                {
                                    return "Wrong format in the list, please validate";
                                }
                            }
                            else // Items of list
                            {
                                if (blockedList == false)
                                {

                                    if (!itemName.Trim().Equals(string.Empty))
                                    {
                                        //Needs to find the parent ID in the list according the position
                                        //Starting with the last item in the list
                                        for (int pos = list.Count - 1; pos >= 0; pos--)
                                        {
                                            //Get the first item with the column less than the current item
                                            if ((j - 1) == list[pos].Position)
                                            {
                                                CustomizationListNode newListNode;
                                                int customListId = list[pos].Id;

                                                //If the id is different from the parentList ID
                                                if (customListId != int.Parse(parentListNode.ID.ToString()))
                                                {
                                                    //Get the CustomListNode to add the child
                                                    currentListNode = SearchItemById(customListId, parentListNode);
                                                    currentListNode.AddChild(itemName);
                                                    newListNode = (CustomizationListNode)currentListNode.get_Child(itemName);

                                                    list.Add(new CollectionKeyValue(int.Parse(newListNode.ID.ToString()), j));
                                                }
                                                else //Is a child of the parent list
                                                {
                                                    parentListNode.AddChild(itemName);
                                                    newListNode = (CustomizationListNode)parentListNode.get_Child(itemName);
                                                    list.Add(new CollectionKeyValue(int.Parse(newListNode.ID.ToString()), j));
                                                }


                                                break;
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
            }


            //Applies customization
            ALMListMgrDAO.CommitCustomization();

            if (message.Equals(string.Empty))
            {
                message += "Import finished.";
            }
            else
            {
                message += "\t \t \tImport finished.";
            }

            return message;
        }

        /// <summary>
        /// Method to search for parent item
        /// </summary>
        /// <param name="itemID">child item id</param>
        /// <param name="customListNode">CustomListNode of ProjectList</param>
        /// <returns>Returns CustomListNode of the father list</returns>
        private CustomizationListNode SearchItemById(int itemID, CustomizationListNode customListNode)
        {
            int customListNodeID;
            CustomizationListNode currentListNode;

            if (customListNode.ChildrenCount > 0)
            {
                List childList = new List();
                childList = customListNode.Children;

                for (int i = 0; i < childList.Count; i++)
                {
                    CustomizationListNode childListNode = (CustomizationListNode)childList[i + 1];
                    customListNodeID = int.Parse(childListNode.ID.ToString());

                    if (customListNodeID == itemID)
                    {
                        return childListNode;
                    }

                    if (childListNode.ChildrenCount > 0)
                    {
                        currentListNode =  SearchItemById(itemID, childListNode);
                        customListNodeID = int.Parse(currentListNode.ID.ToString());

                        if (customListNodeID == itemID)
                        {
                            return currentListNode;
                        }
                    }
                }
            }

            return customListNode;
        }
        #endregion
    }

    /// <summary>
    /// Class used to save a collection of Key-Value list
    /// </summary>
    public class CollectionKeyValue
    {
        private int _id;
        private int _position;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public CollectionKeyValue(int id, int position)
        {
            Id = id;
            Position = position;
        }
    }
}
