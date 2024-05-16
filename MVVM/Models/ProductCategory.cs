﻿using System.ComponentModel.DataAnnotations;

namespace Cashbox.MVVM.Models;

public partial class ProductCategory
{
    [Key]
    public int Id { get; set; }

    public string Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = [];
}
