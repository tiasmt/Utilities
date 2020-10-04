using CsvHelper.Configuration.Attributes;

namespace Utilities
{
    public class User
    {
        [Name("Id")]
        public int Id { get; set; }
        [Name("Username")]
        public string Username { get; set; }
        [Name("HashedPassword")]
        public string HashedPassword { get; set; }
        [Name("Salt")]
        public byte[] Salt { get; set; }

    }
}
