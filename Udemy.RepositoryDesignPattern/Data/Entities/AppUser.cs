namespace Udemy.RepositoryDesignPattern.Data.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Account>? Accounts { get; set; }
    }
}
