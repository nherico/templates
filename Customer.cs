using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Customer
    {
        public int? CustomerID { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }
        public DateTime? DateCreated { get; set; }
        public List<EmailAddress> EmailAdress { get; set; }

        public Customer()
        {
            EmailAdress = new List<EmailAddress>();
        }
    }
}
