namespace HumanResourceApp.Models
{
    public class Person
    {
        public int BusinessEntityID { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        public Guid rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime Birthdate { get; set; }
        public int Age { get; set; }
        public int FYear { get; set; }
        public ICollection<PersonPhone> PersonPhones { get; set; }
    }

    public class PersonPhone
    {
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
