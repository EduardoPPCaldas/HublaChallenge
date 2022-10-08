using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Sales.Requests;
using Application.Sales.Responses;

namespace Application.Sales.Ports;

public interface ISaleUseCase
{
    Task<CreateSalesWithFileResponse> CreateSalesWithFile(CreateSalesWithFileRequest request);
}
