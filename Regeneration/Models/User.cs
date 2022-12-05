namespace Regeneration
{
    public class User
    {
        public int Id { get; set; }
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = ""; 
        public string email { get; set; } = "";
        public int password { get; set; }
        

        public User( string firstName, string lastName, string email, int password)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
        }
    }

    
}


