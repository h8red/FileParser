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
            try
            {
                MyParser pPipe = new MyParser(new PipeParser(), Util.ReadStringFromFile(args[0]));
                userList.AddRange(pPipe.myUsers);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An exception was thrown trying to parse the PIPE file: {0}", ex.Message);
            }

            // read in the CSV
            try
            {
                MyParser pCSV = new MyParser(new CSVParser(), Util.ReadStringFromFile(args[1]));
                userList.AddRange(pCSV.myUsers);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An exception was thrown trying to parse the CSV file: {0}", ex.Message);
            }

            // read in the spaced        
            try
            {
                MyParser pSpace = new MyParser(new SpaceParser(), Util.ReadStringFromFile(args[2]));
                userList.AddRange(pSpace.myUsers);
            }
            catch(Exception ex)
            {
                Console.WriteLine("An exception was thrown trying to parse the SPACED file: {0}", ex.Message);
            }
            
            Console.WriteLine("\r\nOutput 1. Gender (female -> male), LastName ascending\r\n");
            // write the output for Gender (female->male), last asc
            Util.OutputUsers(Util.OutputByGender(userList));            
            
            Console.WriteLine("\r\nOutput 2. DOB ascending\r\n");
            Util.OutputUsers(Util.OutputByDob(userList));
            
            Console.WriteLine("\r\nOutput 3. LastName descending\r\n");
            Util.OutputUsers(Util.OutputByLastName(userList));
            
            Console.WriteLine("\r\nPress enter to exit...");
            Console.ReadLine();
        }

        

    }
}
