using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 3)
            {
                Console.WriteLine("3 files (Piped, CSV, Space) need to be passed in to be parsed");
                
                //Console.ReadKey();
                // TESTING
                Console.WriteLine("********************\r\nUsing DEFAULT test files\r\n");
                args = new string[3];
                args[0] = "pipe.txt";
                args[1] = "csv.txt";
                args[2] = "space.txt";
                //TESTING

                //return;
            }

            List<User> userList = new List<User>();

            MyParser pPipe = new MyParser(new PipeParser(), args[0]);
            userList.AddRange(pPipe.myUsers);

            MyParser pCSV = new MyParser(new CSVParser(), args[1]);
            userList.AddRange(pCSV.myUsers);

            MyParser pSpace = new MyParser(new SpaceParser(), args[2]);
            userList.AddRange(pSpace.myUsers);

            Console.WriteLine("Number of users found: {0}", userList.Count);
            foreach(User u in userList)
            {
                Console.WriteLine("{0} {1} {2} {3} {4}", u.LastName, u.FirstName, u.Gender, u.FavoriteColor, u.getFormattedDob());
            }


            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }
    }
}
