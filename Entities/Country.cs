using System;
using System.Collections.Generic;

namespace HotelsApi.Entities;

public partial class Country
{
    public int CountryId { get; set; }

    public int CountryCode { get; set; }

    public string CountryName { get; set; } = null!;
}
