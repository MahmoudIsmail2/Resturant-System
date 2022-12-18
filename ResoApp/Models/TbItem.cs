using System;
using System.Collections.Generic;

namespace ResoApp;

public partial class TbItem
{
    public int Id { get; set; }

    public string Itemname { get; set; } = null!;

    public decimal Itemprice { get; set; }

    public int Categoryid { get; set; }

    public int Qty { get; set; }

    public virtual TbCategory Category { get; set; } = null!;

   // public virtual ICollection<TbInvoice> TbInvoices { get; } = new List<TbInvoice>();
}
