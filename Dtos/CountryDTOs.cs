namespace HotelsApi.Dtos
{
    public class CreateCountry
    {
        public int CountryCode { get; set; }

        public string CountryName { get; set; } = null!;
    }
    public class UpdateCountry : CreateCountry
    {
        public int CountryId { get; set; }
    }
    public class GetCountryName
    {
        public int CountryId { get; set; }

        public int CountryCode { get; set; }

        public string CountryName { get; set; } = null!;
    }
}
