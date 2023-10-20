namespace UsersAPI.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public long Phone { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string Status { get; set; }
    }
}
