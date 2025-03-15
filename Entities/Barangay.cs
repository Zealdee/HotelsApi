using System;
using System.Collections.Generic;

namespace HotelsApi.Entities;

public partial class Barangay
{
    public int BarangayId { get; set; }

    public string BarangayName { get; set; } = null!;

    public int PostalCode { get; set; }
}
