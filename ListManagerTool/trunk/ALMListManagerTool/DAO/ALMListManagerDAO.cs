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
using TDAPIOLELib;

namespace hp.go2alm.ALMListManagerTool
{
    public class ALMListManagerDAO
    {
        /// <summary>
        /// Creates the connection to ALM
        /// </summary>
        /// <param name="ALMServerName">URL of the ALM instance</param>
        /// <param name="ALMUser"> ALM User</param>
        /// <param name="ALMPassword">ALM Password</param>
        public void PerformALMLogin(string ALMServerName, string ALMUser, string ALMPassword)
        {
            if (CommonProperties.ALMConnection == null)
            {
                CommonProperties.ALMConnection = new TDConnection();
                CommonProperties.ALMConnection.InitConnectionEx(ALMServerName);
                CommonProperties.ALMConnection.Login(ALMUser, ALMPassword);
            }
        }

        /// <summary>
        /// Gets all the Domain List that a user can access
        /// </summary>
        /// <returns>Returns a list of strings with the names of the domains</returns>
        public List<string> GetALMDomainList()
        {
            List<string> almDomainNameList = new List<string>();
            List almDomainList = CommonProperties.ALMConnection.VisibleDomains;
            foreach (string currentALMDomain in almDomainList)
            {
                almDomainNameList.Add(currentALMDomain);
            }
            almDomainNameList.Sort();
            return almDomainNameList;
        }

        /// <summary>
        /// Gets all the projects of a particular domain
        /// </summary>
        /// <param name="ALMDomainName">Name of the domain</param>
        /// <returns>Returns a list of strings with all the names of the projects</returns>
        public List<string> GetALMProjectList(string ALMDomainName)
        {
            List<string> almProjectNameList = new List<string>();
            List almProjectList = CommonProperties.ALMConnection.get_VisibleProjects(ALMDomainName);
            foreach (string currentALMProjectName in almProjectList)
            {
                almProjectNameList.Add(currentALMProjectName);
            }
            almProjectNameList.Sort();
            return almProjectNameList;
        }

        /// <summary>
        /// Creates the connection to a particular Domain/Project in ALM
        /// </summary>
        /// <param name="ALMDomainName">Name of the domain</param>
        /// <param name="ALMProjectName">Name of the project</param>
        public void PerformALMProjectConnection(string ALMDomainName, string ALMProjectName)
        {
            CommonProperties.ALMConnection.Connect(ALMDomainName, ALMProjectName);

        }

        /// <summary>
        /// Disconnect the user from the domain/project
        /// </summary>
        public void PerformALMProjectDisconnection()
        {
            CommonProperties.ALMConnection.Disconnect();

        }

        /// <summary>
        /// Loads the customization object for the connection
        /// </summary>
        public void LoadCustomization()
        {
            CommonProperties.Customization = (Customization)CommonProperties.ALMConnection.Customization;
            CommonProperties.Customization.Load();
            
        }

        /// <summary>
        /// Indicates if this user is a member of the specified group. 
        /// </summary>
        /// <param name="groupList">Name of the group</param>
        /// <returns>true if the user is member, false if not</returns>
        public bool IsUserInGroupList(string groupList)
        {
            CustomizationUsers customUsers = (CustomizationUsers)CommonProperties.Customization.Users;
            CustomizationUser customUser = (CustomizationUser)customUsers.User[CommonProperties.ALMConnection.UserName];
            
            if (customUser.get_InGroup(groupList))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Gets all the collection of lists in ALM
        /// </summary>
        /// <returns>All the lists of a Domain/Project</returns>
        public CustomizationLists GetALMLists()
        {
            return (CustomizationLists)CommonProperties.Customization.Lists;
        }

        /// <summary>
        /// Gets an specific list in ALM
        /// </summary>
        /// <param name="param">List ID or Name ID</param>
        /// <returns>The CustomizationList object of specific list</returns>
        public CustomizationList GetALMList(object param) 
        {
            CustomizationLists customLists = (CustomizationLists)CommonProperties.Customization.Lists;
            return (CustomizationList)customLists.get_List(param);
        }

        /// <summary>
        /// Gets an specific list node in ALM
        /// </summary>
        /// <param name="param">List ID or Name ID</param>
        /// <returns>The CustomizationListNode object of specific list</returns>
        public CustomizationListNode GetALMListNode(object param)
        {
            CustomizationLists customLists = (CustomizationLists)CommonProperties.Customization.Lists;
            CustomizationList lst = (CustomizationList)customLists.get_List(param);

            return (CustomizationListNode)lst.Find(param);
        }

        /// <summary>
        /// Disconnect the user from ALM and release the connection.
        /// </summary>
        public void ALMLogOff()
        {
            if (CommonProperties.ALMConnection != null)
            {
                if (CommonProperties.ALMConnection.Connected)
                {
                    CommonProperties.ALMConnection.Disconnect();
                }
                if (CommonProperties.ALMConnection.LoggedIn)
                {
                    CommonProperties.ALMConnection.Logout();
                }
                CommonProperties.ALMConnection.ReleaseConnection();
                CommonProperties.ALMConnection = null;
            }
        }

        public void CommitCustomization()
        {
            CommonProperties.Customization.Commit();
        }

        public void ReleaseConnObject()
        {
            try
            {
                CommonProperties.ALMConnection.ReleaseConnection();
                CommonProperties.ALMConnection = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
