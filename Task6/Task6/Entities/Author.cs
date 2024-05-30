using System.ComponentModel.DataAnnotations;

namespace Task6.Entities
{
    public class Author
    {
        [StringLength(200, ErrorMessage = "First name can't be more than 200 characters")]
        public string FirstName { get; set; }

        [StringLength(200, ErrorMessage = "Last name can't be more than 200 characters")]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Author(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
    }
}
