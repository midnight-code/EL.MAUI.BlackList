using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Models
{
    public class Documents
    {
        public int ID { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public int DriverID { get; set; }
        public string ImgType { get; set; } = string.Empty;
    }
}
