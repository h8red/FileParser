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

            // list of all our users we read in from the different files
            List<User> userList = new List<User>();

            // read in the pipe
            MyParser pPipe = new MyParser(new PipeParser(), args[0]);
            userList.AddRange(pPipe.myUsers);

            // read in the CSV
            MyParser pCSV = new MyParser(new CSVParser(), args[1]);
            userList.AddRange(pCSV.myUsers);

            // read in the spaced        
            MyParser pSpace = new MyParser(new SpaceParser(), args[2]);
            userList.AddRange(pSpace.myUsers);


            Console.WriteLine("\r\nOutput 1. Gender (female -> male), LastName ascending\r\n");
            // write the output for Gender (female->male), last asc
            Util.OutputUsers((from rows in userList
                             orderby rows.Gender ascending, rows.LastName ascending
                             select rows).ToList());

            Console.WriteLine("\r\nOutput 2. DOB ascending\r\n");
            // write the output for birthdate, asc
            Util.OutputUsers((from rows in userList
                              orderby rows.DOB ascending
                              select rows).ToList());

            Console.WriteLine("\r\nOutput 3. LastName descending\r\n");
            // write the output for last name, desc
            Util.OutputUsers((from rows in userList
                              orderby rows.LastName descending
                              select rows).ToList());
            

            Console.WriteLine("\r\nPress enter to exit...");
            Console.ReadLine();
        }

        

    }
}
