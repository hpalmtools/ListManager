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

namespace hp.go2alm.ALMListManagerTool
{
    public class ConfigSection : ConfigurationSection
    {
        /// <summary>

        /// The value of the property here "Folders" needs to match that of the config file section

        /// </summary>

        [ConfigurationProperty("blockedLists")]
        public ConfigCollection BlockedLists
        {

            get { return ((ConfigCollection)(base["blockedLists"])); }

        }

        [ConfigurationProperty("serverNames")]
        public ConfigCollection ServerNames
        {

            get { return ((ConfigCollection)(base["serverNames"])); }

        }

        public bool ExistListName(string listName)
        {
            ConfigCollection col = (ConfigCollection)(base["blockedLists"]);

            foreach (ConfigElement element in col)
            {
                if (element.Name.Equals(listName))
                {
                    return true;
                }
            }

            return false;
        }
    }

    /// <summary>
    /// The collection class that will store the list of each element/item that
    /// is returned back from the configuration manager.
    /// </summary>
    [ConfigurationCollection(typeof(ConfigElement))]
    public class ConfigCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigElement)(element)).Name;
        }



        public ConfigElement this[int idx]
        {
            get
            {
                return (ConfigElement)BaseGet(idx);
            }
        }
    }

    /// <summary>
    /// The class that holds onto each element returned by the configuration manager.
    /// </summary>
    public class ConfigElement : ConfigurationElement
    {
        [ConfigurationProperty("name", DefaultValue = "", IsKey = true, IsRequired = true)]
        public string Name
        {
            get
            {
                return ((string)(base["name"]));
            }
            set
            {
                base["name"] = value;
            }
        }
    }
}
