using System.Reflection;
using Application.Sales.Requests;
using Application.Sales.UseCases;
using Domain.Entities;
using Domain.Ports;
using Moq;

namespace UnitTests.Core.Application;

public class SaleUseCaseTests
{
    [Fact]
    public async Task SaleUseCase_ShouldReturnSuccessTrue_WhenReceivingACorrectFile()
    {
        var saleRepositoryMock = new Mock<ISaleRepository>();
        var saleList = new List<Sale>();
        saleRepositoryMock.Setup(x => x.CreateSalesWithFile(It.IsAny<List<Sale>>())).Returns(Task.FromResult(saleList));
        var saleUseCase = new SaleUseCase(saleRepositoryMock.Object);

        var buffer = await File.ReadAllBytesAsync(Directory.GetCurrentDirectory() + "/Resources/sales.txt");

        var createSalesWithFileRequest = new CreateSalesWithFileRequest();
        createSalesWithFileRequest.Buffer = buffer;

        var response = await saleUseCase.CreateSalesWithFile(createSalesWithFileRequest);
        Assert.True(response.Success);
    }

    [Fact]
    public async Task SaleUseCase_ShouldReturnSuccesFalse_WhenReceivingANullBuffer()
    {
        var saleRepositoryMock = new Mock<ISaleRepository>();
        var saleList = new List<Sale>();
        saleRepositoryMock.Setup(x => x.CreateSalesWithFile(It.IsAny<List<Sale>>())).Returns(Task.FromResult(saleList));
        var saleUseCase = new SaleUseCase(saleRepositoryMock.Object);

        var createSalesWithFileRequest = new CreateSalesWithFileRequest();

        var response = await saleUseCase.CreateSalesWithFile(createSalesWithFileRequest);
        Assert.False(response.Success);
        Assert.Equal("File buffer is null", response.Message);
    }

    [Fact]
    public async Task SaleUseCase_ShouldReturnSuccesFalse_WhenReceivingAWrongFile()
    {
        var saleRepositoryMock = new Mock<ISaleRepository>();
        var saleList = new List<Sale>();
        saleRepositoryMock.Setup(x => x.CreateSalesWithFile(It.IsAny<List<Sale>>())).Returns(Task.FromResult(saleList));
        var saleUseCase = new SaleUseCase(saleRepositoryMock.Object);

        var buffer = await File.ReadAllBytesAsync(Directory.GetCurrentDirectory() + "/Resources/badSales.txt");

        var createSalesWithFileRequest = new CreateSalesWithFileRequest();
        createSalesWithFileRequest.Buffer = buffer;

        var response = await saleUseCase.CreateSalesWithFile(createSalesWithFileRequest);
        Assert.True(response.Success);
    }
}