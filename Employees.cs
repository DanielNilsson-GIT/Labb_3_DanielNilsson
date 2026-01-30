using Labb_3_DanielNilsson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_DanielNilsson
{
    internal class Employees
    {
        //Lägga till ny personal
        //Användaren ska få möjlighet att mata in uppgifter om en ny anställd och den datan sparas då ner i databasen.

        public static void AddEmployee(string firstname,string secondname,int jobid)
        {
            using (var context = new HighSchoolLabb2Context())
            {
                var newEmployee = new Personal()
                {
                    Förnamn = firstname,
                    Efternamn = secondname,
                    YrkesId = jobid

                };
                context.Personals.Add(newEmployee);
                context.SaveChanges();
            }

        } 
    }
}
