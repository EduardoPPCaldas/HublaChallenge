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
            
            if(response.Success) return await Task.FromResult(Created("", response));

            switch (response.ErrorCode)
            {
                default:
                    return BadRequest(response);
            }
        }
    }

    [HttpGet]
    public async Task<ActionResult<GetSalesListResponse>> GetSalesList()
    {
        var response = await _saleUseCase.GetSalesListResponse();

        if (response.Success) return Ok(response);

        switch (response.ErrorCode)
        {
            default:
                return BadRequest(response);
        }
    }
}
