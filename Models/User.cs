namespace Utilities
{
    public class User
    {
        public string Username { get; set; }
        private int Id { get; set; }
        public string HashedPassword { get; set; }
        public byte[] Salt { get; set; }
    }
}
