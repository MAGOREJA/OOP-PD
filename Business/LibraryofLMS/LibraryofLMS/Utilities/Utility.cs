using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofLMS.Utilities
{
    class Utility
    {
        private static string ConnectionString = "Data Source=DESKTOP-UL67J8E\\\\SQLEXPRESS;Initial Catalog=Lab;Integrated Security=True";

        public static string GetConnectionString()
        {
            return ConnectionString;
        }

    }
}
