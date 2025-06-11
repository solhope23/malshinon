using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinon
{
    internal static class PrintManager
    {
        public static void MenuForManagement()
        {
            Console.WriteLine("Hi \n" +
                              "to submit a report enter 1 \n" +
                              "to request information enter 2 \n" +
                              "to exit enter 9 \n");
        }

        public static void MenuForReporter()
        {
            Console.WriteLine("Hi \n" +
                              "To enter your full name enter 1 \n" +
                              "To enter your secret code if you have one enter 2 \n");
        }


        public static void MenuForReporterFirstName()
        {
            Console.WriteLine("Enter your first name");
        }

        public static void MenuForReporterLastName()
        {
            Console.WriteLine("Enter your last name");
        }

        public static void MenuForReporterSecretCode()
        {
            Console.WriteLine("Enter your secret code");
        }

        public static void MenuForReporterIntel()
        {
            Console.WriteLine("Enter your intelreport");
        }




    }
}
