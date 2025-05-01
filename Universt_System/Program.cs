using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Universt_System.Teachers;
using Universt_System.departments;
using Universt_System.categories;
using Universt_System.majors;
using University_System.courses;
using University_System;

namespace Universt_System
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmAddUpdateCourseSection(2));
        }
    }
}
