namespace AccountsAPI
{
    public class AccountObj
    {
        public int Id { get; set;}
        public string? Username { get; set; }
    }

    public class CreationAccountObj
    {
        public string? Username { get; set; }
    }
}