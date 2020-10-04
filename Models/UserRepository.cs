using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

using CsvHelper;

namespace Utilities
{
    internal class UserRepository : IUserRepository
    {
        private readonly string Path = "Data\\Users.csv";
        private int NextId = 0;
        public UserRepository()
        {
        }

        public User Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            User user = null;
            var csvFileLenth = new System.IO.FileInfo(Path).Length;
            if (csvFileLenth != 0)
            {
                using (var reader = new StreamReader(Path))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<User>();
                    NextId = records.Count();
                    user = records.FirstOrDefault(user => user.Username == username);
                }
            }
            return user;
        }

        public void Save(User entity)
        {
            entity.Id = NextId;
            using (var writer = new StreamWriter(Path, append: true))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.NextRecord();
                csv.WriteRecord(entity);
            }
            System.Console.WriteLine($"User {entity.Username} saved!");
        }
    }
}