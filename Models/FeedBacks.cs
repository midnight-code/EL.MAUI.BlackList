using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Models
{
    public class FeedBacks
    {
        public int FeedBackId { get; set; }
        public int DriversId { get; set; }
        public int TaxiPoolsId { get; set; }
        public string Subjest { get; set; } = string.Empty;
        public DateTime AddDate { get; set; }
        public int CityId { get; set; }
        public string UserGuid { get; set; }

        public TaxiPools TaxiPools { get; set; }
        public City City { get; set; }
    }
}
