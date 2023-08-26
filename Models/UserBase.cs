using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Models
{
    public partial class UserBase
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberPublic { get; set; }
        public string NameCompPublic { get; set; }
       
        public int PinCode { get; set; }
        public DateTime DateStart { get; set; }
        

        public int CityID { get; set; }
        public string CityName { get; set; }
        public int TaxiPoolID { get; set; }
        public string UserName { get; set; }

    }
}
