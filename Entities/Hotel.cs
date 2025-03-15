using System;
using System.Collections.Generic;

namespace HotelsApi.Entities;

public partial class Hotel
{
    public int HotelId { get; set; }

    public int HotelCode { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelDescription { get; set; } = null!;
}
