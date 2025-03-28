﻿using System;
using System.Collections.Generic;

namespace HotelsApi.Entities;

public partial class City
{
    public int CityId { get; set; }

    public int? CityCode { get; set; }

    public string CityName { get; set; } = null!;

    public int? StateId { get; set; }

    public virtual State? State { get; set; }
}
