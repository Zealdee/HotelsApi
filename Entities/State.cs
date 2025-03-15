using System;
using System.Collections.Generic;

namespace HotelsApi.Entities;

public partial class State
{
    public int StateId { get; set; }

    public int? StateCode { get; set; }

    public string StateName { get; set; } = null!;
}
