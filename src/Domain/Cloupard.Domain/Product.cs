using System;
using System.Collections.Generic;

namespace Cloupard.Api;

public partial class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
