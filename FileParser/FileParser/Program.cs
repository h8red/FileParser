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
            List<User> userList = new List<User>();

            MyParser pPipe = new MyParser(new PipeParser(), "fileNamePipe");
            pPipe.SaveInfoToDb();

            MyParser pCSV = new MyParser(new CSVParser(), "fileNameCSV");
            pCSV.SaveInfoToDb();

            MyParser pSpace = new MyParser(new SpaceParser(), "fileNameSPACE");
            pSpace.SaveInfoToDb();

            Console.ReadLine();
        }
    }
}
