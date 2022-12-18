using System;
using System.Collections.Generic;
using System.Text.Json.Nodes;

namespace ResoApp;

public partial class TbInvoice
{
    public int Id { get; set; }
    public int Invoicetotal { get; set; }
    public DateTime InvoiceDate { get; set; }
    public string InvoiceItems { get; set; } = "";
  
}
