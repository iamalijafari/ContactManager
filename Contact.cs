/*
 * This is Contact class that has a cunstractor and some property to save contacts as object.
 */
namespace Contact_List
{
    public class Contact
    {
        public Contact(string firstName, string middleName, string lastName, string phoneNumber, string email)
        {
            FirstName = firstName;
            MiddleName = middleName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
