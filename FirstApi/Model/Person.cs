using System.ComponentModel.DataAnnotations;

namespace FirstApi.Model
{
    public class Person
    {
        [Required]
        public string Aadhar { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Range(18, 110)]
        public int Age { get; set; }
    }
    public class PersonOperation
    {
        static List<Person> _people = new List<Person>();
        public static List<Person> GetPeople()
        {
            if (_people.Count == 0)
            {
                _people.Add(new Person() { Aadhar = "7586948759374", Age = 25, Email = "meena@gmail.com", Name = "meena" });
                _people.Add(new Person() { Aadhar = "7584653867252", Age = 24, Email = "eena@gmail.com", Name = "eena" });
                _people.Add(new Person() { Aadhar = "7586383929374", Age = 27, Email = "reena@gmail.com", Name = "reena" });
            }
            return _people;
        }

        public static Person Search(string pAadhar)
        {
            return GetPeople().Where(p => p.Aadhar == pAadhar).FirstOrDefault();
        }
        public static List<Person> PeopleofAge(int pstartAge, int pendAge)
        {
            return GetPeople().Where(p => p.Age >= pstartAge && p.Age <= pendAge).ToList();
        }

        public static void CreateNew(Person p)
        {
            GetPeople();
            _people.Add(p);
        }
        public static bool Update(string pAadhar, Person UpdatedPerson)
        {
            var found = GetPeople().Where(p => p.Aadhar == pAadhar).FirstOrDefault();
            if (found != null)
            {
                found.Email = UpdatedPerson.Email;
                found.Name = UpdatedPerson.Name;
                found.Age = UpdatedPerson.Age;
                return true;
            }
            else
                throw new Exception("No such record");
            
        }

        public static bool Delete(string pAadhar)
        {
            var found = GetPeople().Where(p => p.Aadhar == pAadhar).FirstOrDefault();
            if (found != null)
            {
                GetPeople().Remove(found);
                return true;
            }
            else
                throw new Exception("no such record");
        }
    }

    public class PersonOperationV2
    {

    }
}
