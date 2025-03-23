namespace HotelsApi.Dtos
{
    public class CreateBarangay
    {
        public string BarangayName { get; set; } = null!;

        public int PostalCode { get; set; }

        public int CountryId { get; set; }
    }
    public class UpdateBarangay : CreateBarangay
    {
        public int BarangayId { get; set; }
    }
    public class GetBarangayName
    {
            public int BarangayId { get; set; }

            public string BarangayName { get; set; } = null!;

            public int PostalCode { get; set; }

            public int CountryId { get; set; }
        }
}
