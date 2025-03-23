namespace HotelsApi.Dtos
{
    public class CreateCity
    {
        public int? CityCode { get; set; }

        public string CityName { get; set; } = null!;

        public int? StateId { get; set; }
    }
    public class UpdateCity : CreateCity
    {
        public int CityId { get; set; }
    }
    public class GetCityName
    {
        public int CityId { get; set; }

        public int? CityCode { get; set; }

        public string CityName { get; set; } = null!;

        public int? StateId { get; set; }
    }
}
