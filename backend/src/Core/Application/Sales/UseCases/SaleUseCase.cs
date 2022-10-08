using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Sales.DTOs;
using Application.Sales.Ports;
using Application.Sales.Requests;
using Application.Sales.Responses;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using Domain.Ports;

namespace Application.Sales.UseCases;

public class SaleUseCase : ISaleUseCase
{
    private readonly ISaleRepository _saleRepository;

    public SaleUseCase(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }
    public async Task<CreateSalesWithFileResponse> CreateSalesWithFile(CreateSalesWithFileRequest request)
    {
        try
        {
            if (request.Buffer is null)
            {
                throw new InvalidFileException("File buffer is null");
            }
            var streamReader = new StreamReader(new MemoryStream(request.Buffer));
            var saleList = new List<Sale>();
            while (!streamReader.EndOfStream)
            {
                var saleString = await streamReader.ReadLineAsync();
                if (saleString is null)
                {
                    throw new InvalidFileException("File with invalid text");
                }
                var type = Convert.ToInt32(saleString.Substring(0, 1));
                var date = DateTime.Parse(saleString.Substring(1, 25));
                var description = saleString.Substring(26, 30);
                var value = Convert.ToDouble(saleString.Substring(56, 10))/100.0;
                var salesmanName = saleString.Substring(66);

                saleList.Add(new Sale
                {
                    Id = 0,
                    Date = date,
                    SaleType = (SaleType)type,
                    Description = description,
                    Value = value,
                    SalesmanName = salesmanName
                });
            }
            var createdSales = await _saleRepository.CreateSalesWithFile(saleList);
            var salesDtoList = new List<SaleDTO>(); 
            foreach(var sale in createdSales)
            {
                salesDtoList.Add(SaleDTO.MapToDTO(sale));
            }
            return new CreateSalesWithFileResponse
            {
                Data = salesDtoList,
                Success = true
            };
        }
        catch (InvalidFileException error)
        {
            return new CreateSalesWithFileResponse
            {
                Success = false,
                ErrorCode = ErrorCodes.INVALID_SALE_FILE,
                Message = error.Message
            };
        }
        catch (System.Exception error)
        {
            return new CreateSalesWithFileResponse
            {
                Success = false,
                Message = error.Message,
                ErrorCode = ErrorCodes.INTERNAL_SERVER_ERROR
            };
        }        
    }

    public async Task<GetSalesListResponse> GetSalesListResponse()
    {
        var salesList = await _saleRepository.GetSalesList();

        var salesDtoList = salesList.Select(x => SaleDTO.MapToDTO(x)).ToList();

        return new GetSalesListResponse
        {
            Success = true,
            Data = salesDtoList
        };
    }
}
