using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Ports;

namespace Data.Data.Sales;

public class SaleRepository : ISaleRepository
{
    private readonly DatabaseContext _databaseContext;

    public SaleRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<List<Sale>> CreateSalesWithFile(List<Sale> salesList)
    {
        foreach (var sale in salesList)
        {
            _databaseContext.Sales.Add(sale);
        }
        await _databaseContext.SaveChangesAsync();
        return salesList;
    }
}
