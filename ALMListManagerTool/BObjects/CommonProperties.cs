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
    public static class CommonProperties
    {
        private static TDConnection _ALMConnecion;
        private static List _UserGroupList;
        private static CustomizationLists _customLists;
        private static Customization _customization;

        public static TDConnection ALMConnection
        {
            get 
            {
                return _ALMConnecion;
            }
            set
            {
                _ALMConnecion = value;
            }
        }

        public static List UserGroupsList
        {
            get
            {
                return ALMConnection.UserGroupsList;
            }
            set
            {
                _UserGroupList = value;
            }
        }

        /// <summary>
        /// Property CustomLists
        /// </summary>
        public static CustomizationLists CustomLists
        {
            get
            {
                return _customLists;
            }
            set
            {
                _customLists = value;
            }
        }

        public static Customization Customization
        {
            get
            {
                return _customization;
            }
            set
            {
                _customization = value;
            }
        }
    }
}
