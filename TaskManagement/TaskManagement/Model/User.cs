namespace TaskManagement.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Login? Login { get; set; }

    }
}
