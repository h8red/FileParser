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

        public MyParser(IParser parser, string data)
        {
            myUsers = new List<User>();            
            myUsers.AddRange(parser.ParseFile(data));
        }        
    }

    public interface IParser
    {
        List<User> ParseFile(string fileName);
    }

    // Pipe interface
    public class PipeParser : IParser
    {
        public List<User> ParseFile(string data)
        {
            // parse the pipe delineated file
            List<User> userList = new List<User>();

            // split on either \r\n or \n
            string[] lines = data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach(string line in lines)
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
            
            return userList;
        }
    }

    // CSV Interface
    public class CSVParser : IParser
    {
        public List<User> ParseFile(string data)
        {
            // parse the csv
            List<User> userList = new List<User>();

            // split on either \r\n or \n
            string[] lines = data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach (string line in lines)
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
            
            return userList;
        }
    }
    // Space Interface
    public class SpaceParser : IParser
    {
        public List<User> ParseFile(string data)
        {
            // parse the space delineated file
            List<User> userList = new List<User>();

            // split on either \r\n or \n
            string[] lines = data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            foreach (string line in lines)
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
            
            return userList;
        }
    }    
}
