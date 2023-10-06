namespace Application.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public User(int id) {
            Id = id;
            Name = "Name of the user";
            Email = "admin@domain.com";
            Active = true;
        }
    }
}
