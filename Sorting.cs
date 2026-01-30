using Labb_3_DanielNilsson.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_DanielNilsson
{
    internal class Sorting
    {

        public static void OrderByFirstName()
        {
            using (var context = new HighSchoolLabb2Context())
            {
                var namelist = context.Studenters.OrderBy(s => s.Förnamn).ToList();
                foreach (Studenter s in namelist)
                {
                    Console.WriteLine($"{s.Förnamn} {s.Efternamn}");
                }
            }

        }

        public static void OrderByLastName()
        {
            using (var context = new HighSchoolLabb2Context())
            {
                var namelist = context.Studenters.OrderBy(s => s.Efternamn).ToList();
                foreach (Studenter s in namelist)
                {
                    Console.WriteLine($"{s.Efternamn} {s.Förnamn}");
                }
            }
        }

        public static void OrderByLastNameDesc()
        {
            using (var context = new HighSchoolLabb2Context())
            {
                var namelist = context.Studenters.OrderByDescending(s => s.Efternamn).ToList();
                foreach (Studenter s in namelist)
                {
                    Console.WriteLine($"{s.Efternamn} {s.Förnamn}");
                }
            }

        }

        public static void OrderByFirstNameDesc()
        {
            using (var context = new HighSchoolLabb2Context())
            {
                var namelist = context.Studenters.OrderByDescending(s => s.Förnamn).ToList();
                foreach (Studenter s in namelist)
                {
                    Console.WriteLine($"{s.Förnamn} {s.Efternamn}");
                }
            }

        }

        public static void SortByClass()
        {
            using (var context = new HighSchoolLabb2Context())//Using rensar minnet efteråt
            {
                Console.Clear();

                var klasslista = context.Klassers.OrderBy(k => k.Namn).ToList();

                int counter = 1;
                foreach (Klasser k in klasslista)
                {
                    Console.WriteLine($"{counter}.{k.Namn}");
                    counter++;
                }
                Console.WriteLine("Välj klass för att se dess elever:\n");
                int choice = Utilities.UserInputNumberMinMax(1, klasslista.Count());

                var studentlista = context.Studenters.Where(s => s.KlassId==choice).ToList();
                foreach(Studenter s in studentlista)
                {
                    Console.WriteLine($"{s.Förnamn} {s.Efternamn}");
                }
                Utilities.ExitMenu();
            }





        }


    }
}
