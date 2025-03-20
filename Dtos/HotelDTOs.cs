using Microsoft.Identity.Client;

namespace HotelsApi.Dtos
{
    public class CreateHotel
    {
        public int hotelCode { get; set; }

        public string HotelName { get; set; } = null!;

        public string HotelDescription { get; set; } = null!;

        public int? BarangayId { get; set; }
    }
    public class UpdateHotel: CreateHotel
    {
        public int Id { get; set; }
    }
    public class GetHotel
    {
        public int HotelId { get; set; }

        public int HotelCode { get; set; }

        public string HotelName { get; set; } = null!;

        public string HotelDescription { get; set; } = null!;

        public int? BarangayId { get; set; }
    }
}
