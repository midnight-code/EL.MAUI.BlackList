using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Models
{
    public class UserBaseTokenModel
    {
        public string UserID { get; set; }
        public string Token { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateEnd { get; set; }

    }
}
