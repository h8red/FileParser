using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
