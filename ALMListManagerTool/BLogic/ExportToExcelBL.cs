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
using System.Collections;
using TDAPIOLELib;
using Microsoft.Office.Interop.Excel;
using System.Xml;
using System.Drawing;

namespace hp.go2alm.ALMListManagerTool
{
    public class ExportToExcelBL
    {
        #region Variables
        Microsoft.Office.Interop.Excel.Application xla = new Microsoft.Office.Interop.Excel.Application();
        Workbook wb;
        Worksheet ws;
        Hashtable positionHash = new Hashtable();
        #endregion

        #region Methods
        /// <summary>
        /// Method that creates an Excel workbook with all the lists that the user selected
        /// </summary>
        /// <param name="ht">Hashtable with the list names and ids</param>
        public void FillExcelSheet(Hashtable ht)
        {
            int idxRow = 2;
            int idxCol = 1;
            CustomizationList customList;
            CustomizationListNode customListNode;
            positionHash = new Hashtable();

            wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);
            ws = (Worksheet)xla.ActiveSheet;
            ws.Cells.NumberFormat = "@";
            ws.Name = "Lists";

            ws.Cells[1, 1] = "LIST NAME";
            ((Range)ws.Cells[1, 1]).Font.Bold = true;
            ((Range)ws.Cells[1, 1]).BorderAround();

            foreach (DictionaryEntry item in ht) //Foreach of items that are selected
            {
                customList = (CustomizationList)CommonProperties.CustomLists.get_List(item.Value);
                customListNode = (CustomizationListNode)customList.RootNode;

                if (positionHash.Count == 0)
                {
                    idxCol = 1;
                }
                else
                {
                    if (positionHash.ContainsKey(customListNode.ID))
                    {
                        //get column position + 1
                        idxCol = int.Parse(positionHash[customListNode.ID].ToString()) + 1;
                    }
                }

                //Insert the parent list name
                ws.Cells[idxRow, idxCol] = customListNode.Name.ToString();
                ((Range)ws.Cells[idxRow, idxCol]).BorderAround();

                //Set the back color for parent list
                Range rg = (Range)ws.Cells[idxRow, idxCol];
                rg.Interior.Color = Color.LightGoldenrodYellow;

                //Saves the position of item
                positionHash.Add(customListNode.ID, idxCol.ToString());

                idxRow = FillCells((idxRow + 1),customListNode);

                idxRow += 1;
            }

            //Autofits all used columns
            ws.UsedRange.EntireColumn.AutoFit();

            xla.Visible = true;
        }

        /// <summary>
        /// Recursive method that fills the cells with the children list
        /// </summary>
        /// <param name="idxRow">Row position</param>
        /// <param name="customListNode">CustomlistNode object</param>
        /// <returns>Return current row position + 1</returns>
        private int FillCells(int idxRow, CustomizationListNode customListNode)
        {
            int idxCol = 0;

            if (customListNode.ChildrenCount > 0)
            {
                List childList = new List();
                childList = customListNode.Children;

                for (int i = 0; i < childList.Count; i++)
                {
                    CustomizationListNode childListNode = (CustomizationListNode)childList[i + 1];

                    //get column father position + 1
                    idxCol = int.Parse(positionHash[customListNode.ID].ToString()) + 1;

                    if (((Range)ws.Cells[1, idxCol]).Value2 == null)
                    {
                        ws.Cells[1, idxCol] = "LIST ITEM";
                        ((Range)ws.Cells[1, idxCol]).Font.Bold = true;
                        ((Range)ws.Cells[1, idxCol]).BorderAround();
                    }

                    ws.Cells[idxRow, idxCol] = childListNode.Name.ToString();
                    ((Range)ws.Cells[idxRow, idxCol]).BorderAround();
                    ((Range)ws.Cells[idxRow, idxCol]).Interior.Color = Color.LightGoldenrodYellow;

                    //Saves the position of item
                    positionHash.Add(childListNode.ID, idxCol.ToString());

                    idxRow += 1;

                    if (childListNode.Children.Count > 0)
                    {
                        idxRow = FillCells(idxRow, childListNode);
                    }
                }
            }

            return idxRow;
        }

        /// <summary>
        /// Method that creates an Excel workbook with all the lists that the user selected
        /// </summary>
        /// <param name="ht">Hashtable with the list names and ids</param>
        public void FillExcelBySheets(Hashtable ht)
        {
            int idxRow = 1;
            int idxCol = 1;
            CustomizationList customList;
            CustomizationListNode customListNode;
            positionHash = new Hashtable();

            wb = xla.Workbooks.Add(XlSheetType.xlWorksheet);

            foreach (DictionaryEntry item in ht) //Foreach of items that are selected
            {
                customList = (CustomizationList)CommonProperties.CustomLists.get_List(item.Value);
                customListNode = (CustomizationListNode)customList.RootNode;
                
                positionHash = new Hashtable();

                wb.Worksheets.Add(Type.Missing,wb.Worksheets[wb.Worksheets.Count]);

                ws = (Worksheet)xla.ActiveSheet;
                ws.Cells.NumberFormat = "@";
                ws.Name = customListNode.Name;

                if (positionHash.Count == 0)
                {
                    idxCol = 1;
                    idxRow = 1;
                }
                else
                {
                    if (positionHash.ContainsKey(customListNode.ID))
                    {
                        //get column position + 1
                        idxCol = int.Parse(positionHash[customListNode.ID].ToString()) + 1;
                    }
                }

                //Insert the parent list name
                ws.Cells[idxRow, idxCol] = customListNode.Name.ToString();

                //Set the back color for parent list
                Range rg = (Range)ws.Cells[idxRow, idxCol];
                rg.Interior.Color = Color.LightGoldenrodYellow;
                rg.BorderAround();

                //Saves the position of item
                positionHash.Add(customListNode.ID, idxCol.ToString());

                idxRow = FillCells((idxRow + 1), customListNode);

                idxRow += 1;
            }

            //Autofits all used columns

            ws.UsedRange.EntireColumn.AutoFit();
            Worksheet worksheet = (Worksheet)wb.Worksheets[1];
            worksheet.Delete();

            xla.Visible = true;
        }
        #endregion
    }
}
