using System;
using System.Collections.Generic;

namespace ResoApp;

public partial class TbCategory
{
    public int Id { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual ICollection<TbItem> TbItems { get; } = new List<TbItem>();
}
