
namespace EL.MAUI.BlackList.Models
{
    public class TaxiPools
    {
        public int TaxiPoolsId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int CityId { get; set; }

        public City City { get; set; }
    }
}
