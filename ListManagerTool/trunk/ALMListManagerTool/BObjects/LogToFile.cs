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
using System.IO;
using System.Configuration;

namespace hp.go2alm.ALMListManagerTool
{
    public static class LogToFile
    {
        public static void LogInfoMessage(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            DateTime dt = DateTime.UtcNow;

            // Create a writer and open the file
            StreamWriter log;

            //Validate if directory doesn't exist, create it
            if (!Directory.Exists(logPath.Substring(0,logPath.LastIndexOf('/')+1)))
            {
                Directory.CreateDirectory(logPath.Substring(0, logPath.LastIndexOf('/')));
            }

            if (!File.Exists(logPath))
            {
                log = new StreamWriter(logPath);
            }
            else
            {
                //Validate last date, if it's different, will rename last log file and creates a new one of current day
                DateTime last = System.IO.File.GetLastWriteTimeUtc(logPath);
                string fullPath = System.IO.Path.GetFullPath(logPath);
                string fileName = System.IO.Path.GetFileName(logPath);
                fullPath = fullPath.Substring(0,fullPath.LastIndexOf("\\")+1);

                if (last.Day < dt.Day)
                {
                    if (!File.Exists(fullPath + fileName + "." + string.Format("{0:yyyy-MM-dd}", last)))
                    {
                        File.Copy(fullPath + fileName, fullPath + fileName + "." + string.Format("{0:yyyy-MM-dd}", last));
                        File.Delete(logPath);

                        log = new StreamWriter(logPath);
                    }
                    else
                    {
                        log = File.AppendText(fullPath + fileName + "." + string.Format("{0:yyyy-MM-dd}", last));
                    }
                }
                else
                {
                    log = File.AppendText(logPath);
                }
            }

            // Write to the file
            log.WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now.ToUniversalTime()) 
                + "\t" 
                + "INFO"
                + "\t" 
                + message);

            // Close the stream
            log.Close();
        }

        public static void LogWarnMessage(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            // Create a writer and open the file
            StreamWriter log;

            if (!File.Exists(logPath))
            {
                log = new StreamWriter(logPath);
            }
            else
            {
                log = File.AppendText(logPath);
            }

            // Write to the file
            log.WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now.ToUniversalTime())
                + "\t"
                + "WARN"
                + "\t"
                + message);

            // Close the stream
            log.Close();
        }

        public static void LogErrorMessage(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            // Create a writer and open the file
            StreamWriter log;

            if (!File.Exists(logPath))
            {
                log = new StreamWriter(logPath);
            }
            else
            {
                log = File.AppendText(logPath);
            }

            // Write to the file
            log.WriteLine(string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now.ToUniversalTime())
                + "\t"
                + "ERROR"
                + "\t"
                + message);

            // Close the stream
            log.Close();
        }
    }
}
