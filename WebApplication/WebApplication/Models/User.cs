namespace Application.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public User() {
            Name = "Name of the user";
            Email = "admin@domain.com";
            Active = true;
        }
    }
}
