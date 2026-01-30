using Labb_3_DanielNilsson.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Labb_3_DanielNilsson
{
    internal class menu
    {

        public static void Mainmenu()
        {
            bool terminateProgram = false;
            do
            {
                Console.WriteLine("Vad vill du göra?\n\n1.Se alla elever\n2.Se elever i en klass\n3.Registrera ny personal\n\n4.Avsluta");
                int choice = Utilities.UserInputNumberMinMax(1, 4);
                switch (choice)
                {
                    case 1:
                        SortingMenu();
                        break;

                    case 2:
                        Sorting.SortByClass();
                        break;

                    case 3:
                        AddEmployeeMenu();
                        break;
                    case 4:
                        Console.WriteLine("\n\nProgrammet avslutas");
                        terminateProgram = true;
                        break;
                }
            } while (terminateProgram == false);
        }

        public static void SortingMenu()
        {
            Console.Clear();
            Console.WriteLine("Hur vill du sortera?\n1.Förnamn (stigande)\n2.Förnamn (fallande)\n\n3.Efternamn (stigande)\n4.Efternamn(fallande)");
            var sortchoice = Utilities.UserInputNumberMinMax(1, 4);
            switch (sortchoice)
            {
                case 1:
                    Sorting.OrderByFirstName();
                    Utilities.ExitMenu();
                    break;

                case 2:
                    Sorting.OrderByFirstNameDesc();
                    Utilities.ExitMenu();
                    break;

                case 3:
                    Sorting.OrderByLastName();
                    Utilities.ExitMenu();
                    break;

                case 4:
                    Sorting.OrderByLastNameDesc();
                    Utilities.ExitMenu();
                    break;
            }

        }

        public static void AddEmployeeMenu()
        {
            Console.Clear();
            int jobId;
            string firstname = Utilities.UserInputString("förnamn");
            string lastname = Utilities.UserInputString("efternamn");
            Console.WriteLine("Ange yrkesId enligt tabell:\n");
            using (var context = new HighSchoolLabb2Context())
            {
                var yrkeslista = context.Yrkestitels.ToList();
                foreach (var job in yrkeslista)
                {
                    Console.WriteLine(job.Id +"."+ job.Titel);
                }
                jobId= Utilities.UserInputNumberMinMax(1, yrkeslista.Count());
            }
            Employees.AddEmployee(firstname, lastname, jobId);

        }
    }
}
