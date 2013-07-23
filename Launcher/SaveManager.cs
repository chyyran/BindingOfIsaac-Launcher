// -----------------------------------------------------------------------
// <copyright file="SaveManager.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Launcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class SaveManager
    {
        public static string getSolPath()
        {
            string savePathContainer = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Macromedia", "Flash Player", "#SharedObjects");
            string savePath = Path.Combine(Directory.GetDirectories(savePathContainer).First(), "localhost");
            return savePath;

        }



    }

}
