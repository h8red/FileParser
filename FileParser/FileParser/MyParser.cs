using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser
{
    public class MyParser
    {
        public List<User> myUsers { get; set; }

        public MyParser(IParser parser, string fileName)
        {
            myUsers = new List<User>();
            myUsers.AddRange(parser.ParseFile(fileName));
        }        
    }

    public interface IParser
    {
        List<User> ParseFile(string fileName);
    }

    // Pipe interface
    public class PipeParser : IParser
    {
        public List<User> ParseFile(string fileName)
        {
            // parse the pipe delineated file
            List<User> userList = new List<User>();
            using (System.IO.StreamReader file = new System.IO.StreamReader(fileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] userTokens = line.Split('|');

                    // add it to the local List
                    userList.Add(new User()
                    {
                        LastName = Convert.ToString(userTokens[0]),
                        FirstName = Convert.ToString(userTokens[1]),
                        Gender = Convert.ToString(userTokens[2]),
                        FavoriteColor = Convert.ToString(userTokens[3]),
                        DOB = Convert.ToDateTime(userTokens[4])
                    });
                }
            }

            Console.WriteLine(string.Format("PIPE ParseFile called on file {0}", fileName));

            return userList;
        }
    }

    // CSV Interface
    public class CSVParser : IParser
    {
        public List<User> ParseFile(string fileName)
        {
            // parse the csv
            List<User> userList = new List<User>();
            using (System.IO.StreamReader file = new System.IO.StreamReader(fileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] userTokens = line.Split(',');

                    // add it to the local List
                    userList.Add(new User()
                    {
                        LastName = Convert.ToString(userTokens[0]),
                        FirstName = Convert.ToString(userTokens[1]),
                        Gender = Convert.ToString(userTokens[2]),
                        FavoriteColor = Convert.ToString(userTokens[3]),
                        DOB = Convert.ToDateTime(userTokens[4])
                    });
                }
            }

            Console.WriteLine(string.Format("CSV ParseFile called on file {0}", fileName));

            return userList;
        }
    }
    // Space Interface
    public class SpaceParser : IParser
    {
        public List<User> ParseFile(string fileName)
        {
            // parse the space delineated file
            List<User> userList = new List<User>();
            using (System.IO.StreamReader file = new System.IO.StreamReader(fileName))
            {
                string line;

                while ((line = file.ReadLine()) != null)
                {
                    string[] userTokens = line.Split(' ');

                    // add it to the local List
                    userList.Add(new User()
                    {
                        LastName = Convert.ToString(userTokens[0]),
                        FirstName = Convert.ToString(userTokens[1]),
                        Gender = Convert.ToString(userTokens[2]),
                        FavoriteColor = Convert.ToString(userTokens[3]),
                        DOB = Convert.ToDateTime(userTokens[4])
                    });
                }
            }

            Console.WriteLine(string.Format("SPACE ParseFile called on file {0}", fileName));
            return userList;
        }
    }    
}
