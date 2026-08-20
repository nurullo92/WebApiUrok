using System.Net.Mail;

namespace AuthentificationPrograms.Models
{
    public class UserViewModel
    {

        public string FullName { get; set; }
        public bool FromRussia { get; set; }



        public UserViewModel(User user)
        { 
            FullName = GetFullName(user.FirstName, user.LastName);
            FromRussia = GetFromRussiaValue(user.Email);
        }




        public string GetFullName(string firstName,string lastName)
        {
            return String.Concat(firstName, "", lastName);
        }



        public bool GetFromRussiaValue(string email)
        {
            MailAddress mailaddress = new MailAddress(email);

            if (mailaddress.Host.EndsWith(".ru"))
                return false;
            return true;
            
        
        }

    }
}
