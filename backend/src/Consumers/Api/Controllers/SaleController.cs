using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Sales.Ports;
using Application.Sales.Requests;
using Application.Sales.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SaleController : ControllerBase
{
    private readonly ISaleUseCase _saleUseCase;

    public SaleController(ISaleUseCase saleUseCase)
    {
        _saleUseCase = saleUseCase;
    }

    [HttpPost]
    public async Task<ActionResult<CreateSalesWithFileResponse>> CreateSaleWithFile(IFormFile file)
    {
        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            var buffer = memoryStream.ToArray();
            var request = new CreateSalesWithFileRequest
            {
                Buffer = buffer
            };

            var response = await _saleUseCase.CreateSalesWithFile(request);
            
            return await Task.FromResult(Created("", response));
        }
    }
}
