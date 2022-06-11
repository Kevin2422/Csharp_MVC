namespace firstmvc.Models
{
      public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User(string name, string ln)
        {
          FirstName = name;
          LastName = ln;
        }
}
}