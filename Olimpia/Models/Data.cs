﻿using System;
using System.Collections.Generic;

namespace Olimpia.Models;

public partial class Data
{
    public string Id { get; set; } = null!;

    public string? Country { get; set; }

    public string? County { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime UpdatedTime { get; set; }

    public string PlayerId { get; set; } = null!;

    public virtual Player Player { get; set; } = null!;
}
