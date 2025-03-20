namespace HotelsApi.Dtos
{
    public class CreateState
    {
        public int? StateCode { get; set; }

        public string StateName { get; set; } = null!;

        public int? CountryId { get; set; }
    }
    public class UpdateState : CreateState
    {
        public int StateId { get; set; }
    }
    public class GetState
    {
        public int StateId { get; set; }

        public int? StateCode { get; set; }

        public string StateName { get; set; } = null!;

        public int? CountryId { get; set; }
    }
}
