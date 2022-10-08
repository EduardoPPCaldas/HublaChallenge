using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Enums;

namespace Application.Sales.DTOs;

public class SaleDTO
{
    public SaleType SaleType { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public double Value { get; set; }
    public string? SalesmanName { get; set; }

    public static SaleDTO MapToDTO(Sale sale)
    {
        return new SaleDTO
        {
            Date = sale.Date,
            Description = sale.Description,
            SalesmanName = sale.SalesmanName,
            SaleType = sale.SaleType,
            Value = sale.Value
        };
    }

    public static Sale MapToEntity(SaleDTO saleDTO)
    {
        return new Sale
        {
            Date = saleDTO.Date,
            SalesmanName = saleDTO.SalesmanName,
            SaleType = saleDTO.SaleType,
            Value = saleDTO.Value
        };
    }
}
