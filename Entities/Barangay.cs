using System;
using System.Collections.Generic;

namespace HotelsApi.Entities;

public partial class Barangay
{
    public int BarangayId { get; set; }

    public string BarangayName { get; set; } = null!;

    public int PostalCode { get; set; }

    public int? CountryId { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Hotel> Hotels { get; set; } = new List<Hotel>();
}
