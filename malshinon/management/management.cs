using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Cursor;

namespace malshinon
{
    internal class management
    {
        private managementDAL ManagementDAL;
        private reporter Reporter;


        public management()
        {
            this.ManagementDAL = new managementDAL();
            this.Reporter = new reporter();
        }

        public void menu()
        {
            PrintManager.MenuForManagement();
            int choice = int.Parse(Console.ReadLine());
        }
    }

}
