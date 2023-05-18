using Microsoft.AspNetCore.Mvc;
using Model.Registrations;
using Persistence.Interfaces;
using Moq;
using NuGet.ContentModel;
using Service.Registrations;
using Service.Tables;
using WebApplication2.controllers;
using Persistence.DAL.Registrations;
using AutoFixture;
using Model.Errors;

namespace Test.Controllers
{
    public class ProductControllerGetByIdTests
    {
        [Fact]
        public void ValidProductId_GetByIdIsCalled_ReturnValidDetailsView()
        {   

            //arrange
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var product = fixture.Create<Product>();
            var productRepository = new Mock<IProductDAL>();
            var productService = new ProductService(productRepository.Object);
            productRepository.Setup(pr => pr.InsertProduct(product)).Returns(product);
           
            //act
            var result = productService.InsertProduct(product);
            //assert
            Assert.NotNull(result);
            Assert.IsType<Product>(result);
            Assert.Equal(product.Name, result.Name);
            Assert.Equal(product.CategoryId, result.CategoryId);
            Assert.Equal(product.ManufacturerId, result.ManufacturerId);
            Assert.Equal(product.CreatedAt, result.CreatedAt);
            
            productRepository.Verify(pr => pr.InsertProduct(It.IsAny<Product>()), Times.Once);
        }

        [Fact]
        public void InvalidProduct_InsertProductCalled_ReturnInvalidProduct()
        {
            //arrange
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var product = fixture.Create<Product>();
            var productRepository = new Mock<IProductDAL>();
            var productService = new ProductService(productRepository.Object);
            productRepository.Setup(pr => pr.InsertProduct(product)).Returns(product);
            product = new Product { CategoryId = null, ManufacturerId = null, ProductId = 0 };

            //act + Assert
            var exception = Assert.Throws<BadRequestException>(() => productService.InsertProduct(product));
            Assert.Equal(exception.Message, $"object {product.Name} was not inserted into database");
        }

    }
}