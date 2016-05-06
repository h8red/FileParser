using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace FileParser
{
    public static class Util
    {
        public static void OutputUsers(List<User> usrList)
        {
            foreach (User u in usrList)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", u.FirstName, u.LastName, u.Gender, u.FavoriteColor, u.getFormattedDob());
            }
        }        

        public static string ReadStringFromFile(string fileName)
        {
            if(!File.Exists(fileName))
            {
                // no file found, throw exception
                throw new FileNotFoundException("The file {0} was not found", fileName);
            }

            return File.ReadAllText(fileName);            
        }

        public static List<User> OutputByGender(List<User> userList)
        {
            return (from rows in userList
                              orderby rows.Gender ascending, rows.LastName ascending
                              select rows).ToList();
        }
        
        public static List<User> OutputByDob(List<User> userList)
        {
            return (from rows in userList
                              orderby rows.DOB ascending
                              select rows).ToList();
        }
            
        public static List<User> OutputByLastName(List<User> userList)
        {
            return (from rows in userList
                              orderby rows.LastName descending
                              select rows).ToList();
        }                                
            
    }    
}
