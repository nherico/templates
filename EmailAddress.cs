using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class EmailAddress
    {
        public int? EmailAddressID { get; set; }
        public int? CustomerID { get; set; }
        public string Email { get; set; }
    }
}
