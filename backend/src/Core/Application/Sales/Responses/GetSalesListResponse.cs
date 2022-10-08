using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Sales.DTOs;

namespace Application.Sales.Responses;

public class GetSalesListResponse : Response
{
    public List<SaleDTO>? Data { get; set; }
}
