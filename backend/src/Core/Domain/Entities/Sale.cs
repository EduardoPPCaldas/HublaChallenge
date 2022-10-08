using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Entities;

public class Sale
{
    public int Id { get; set; }
    public SaleType SaleType { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public double Value { get; set; }
    public string? SalesmanName { get; set; }
}
