using System.Text.RegularExpressions;

namespace NameSorter
{
    public class Name
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public bool ValidateLastNameExist(string fullName)
        {
            var nameParts = fullName.Trim().Split(' ');
            // var lastName = nameParts.LastOrDefault();

            if (nameParts.Length >= 2)
                return true;
            else
                return false;
        }

        public bool ValidString(string fullName)
        {
            var nameParts = fullName.Trim().Split(' ');
            
            if (Regex.IsMatch(fullName, @"^[a-zA-Z ]+$"))
                return true;

            else
                return false;
        }

    }
}
