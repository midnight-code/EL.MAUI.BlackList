using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Models
{
    public class Drivers
    {

        [Column("id")] public int Id { get; set; }
        [Column("firstName")] public string FirstName { get; set; } = string.Empty;
        [Column("lastName")] public string LastName { get; set; } = string.Empty;
        [Column("secondName")] public string SecondName { get; set; } = string.Empty;
        [Column("inn")] public string Inn { get; set; } = string.Empty;
        [Column("pasportId")] public int PasportId { get; set; }
        [Column("addList")] public bool AddList { get; set; }
        [Column("avatarId")] public int AvatarId { get; set; }
        [Column("dateRogden")] public DateTime DateRogden { get; set; }
        [Column("taxiPoolsId")] public int TaxiPoolsId { get; set; }

        public ICollection<FeedBacks> FeedBacks { get; set; } = new HashSet<FeedBacks>();
        public TaxiPools TaxiPools { get; set; }
    }
}
