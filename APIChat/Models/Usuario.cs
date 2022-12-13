using System;
using System.Collections.Generic;

namespace APIChat.Models;

public partial class Usuario
{
    public int Id { get; }

    public string Name { get; set; } = null!;

    public string User { get; set; } = null!;

    public string Password { get; set; } = null!;
}
