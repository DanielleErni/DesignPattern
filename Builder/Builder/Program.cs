using System;

namespace BuilderPatternRealLifeExample
{
    // Product class
    public class UserProfile
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Preferences { get; set; }

        public override string ToString()
        {
            return $"UserProfile: Username={Username}, Email={Email}, Age={Age}, Address={Address}, Preferences={Preferences}";
        }
    }

    // Builder class
    public class UserProfileBuilder
    {
        private UserProfile _userProfile = new();

        public UserProfileBuilder SetUsername(string username)
        {
            _userProfile.Username = username;
            return this;
        }

        public UserProfileBuilder SetEmail(string email)
        {
            _userProfile.Email = email;
            return this;
        }

        public UserProfileBuilder SetAge(int age)
        {
            _userProfile.Age = age;
            return this;
        }

        public UserProfileBuilder SetAddress(string address)
        {
            _userProfile.Address = address;
            return this;
        }

        public UserProfileBuilder SetPreferences(string preferences)
        {
            _userProfile.Preferences = preferences;
            return this;
        }

        public UserProfile Build()
        {
            return _userProfile;
        }
    }

    // Client code
    class Program
    {
        static void Main(string[] args)
        {
            UserProfileBuilder builder = new UserProfileBuilder();
            UserProfile userProfile = builder.SetUsername("john_doe")
                                             .SetEmail("john.doe@example.com")
                                             .SetAge(30)
                                             .SetAddress("123 Main St, Anytown, USA")
                                             .SetPreferences("DarkMode, EmailNotifications")
                                             .Build();

            Console.WriteLine(userProfile);
        }
    }
}