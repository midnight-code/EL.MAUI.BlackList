using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Models
{
    public class TokenModel
    {
        public int ID { get; set; }
        public string Token { get; set; } = string.Empty;
        public DateTime DateAdd { get; set; }
        public string Users { get; set; } = string.Empty;
    }
}
