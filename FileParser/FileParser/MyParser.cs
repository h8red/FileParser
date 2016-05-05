using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    public class MyParser
    {
        public MyParser(IParser parser, string fileName)
        {
            parser.ParseFile(fileName);
        }

        public bool SaveInfoToDb()
        {
            Console.WriteLine("****SaveInfoToDb called****\r\n");
            return true;
        }
    }

    public interface IParser
    {
        void ParseFile(string fileName);
    }

    public class PipeParser : IParser
    {
        public void ParseFile(string fileName)
        {
            // parse the pipe delineated file

            Console.WriteLine(string.Format("PIPE ParseFile called on file {0}", fileName));
        }
    }

    public class CSVParser : IParser
    {
        public void ParseFile(string fileName)
        {
            // parse the csv

            Console.WriteLine(string.Format("CSV ParseFile called on file {0}", fileName));
        }
    }

    public class SpaceParser : IParser
    {
        public void ParseFile(string fileName)
        {
            // parse the space delineated file

            Console.WriteLine(string.Format("SPACE ParseFile called on file {0}", fileName));
        }
    }
}
