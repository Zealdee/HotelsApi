using System;
using System.Collections.Generic;

namespace HotelsApi.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int HotelId { get; set; }

    public string HotelName { get; set; } = null!;

    public string HotelCode { get; set; } = null!;

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public string FullNamer { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public string? EmailAddress { get; set; }

    public virtual Hotel Hotel { get; set; } = null!;
}
