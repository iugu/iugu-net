using iugu.net.Entity;
using iugu.net.Lib;
using iugu.net.Request;
using iugu.net.Response;
using NUnit.Framework;
using Ploeh.AutoFixture;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace iugu.net.IntegratedTests
{
    [TestFixture]
    public class ErrorResponseIntegratedTests
    {
        [Test]
        public async Task Create_customer_with_error_return_exception_with_error_response()
        {
            // Arrange
            var myClient = new CustomerModel();
            var request = new Fixture().Build<CustomerRequestMessage>()
                                       .With(a => a.Email, "invalid email")
                                       .With(a => a.CpfOrCnpj, "1111111111")
                                       .Create();

            // Act
            var ex = new Exception();

            using (var apiClient = new Customer())
            {
                ex = Assert.ThrowsAsync<Exception>(async () => await apiClient.CreateAsync(request, null).ConfigureAwait(false));
            };

            // Assert
            Assert.That(ex.Message, Does.Contain("422")
                                        .And
                                        .Contain("email")
                                        .And
                                        .Contains("não é válido")
                                        .Or
                                        .Contains("is invalid"));
        }

        [Test]
        public async Task Get_complex_formatted_error_message()
        {
            // Arrange
            var myClient = new CustomerModel();
            var request = new Fixture().Build<CustomerRequestMessage>()
                                       .With(a => a.Email, "invalid email")
                                       .With(a => a.CpfOrCnpj, "1111111111")
                                       .Create();

            var ex = new Exception();

            using (var apiClient = new Customer())
            {
                ex = Assert.ThrowsAsync<Exception>(async () => await apiClient.CreateAsync(request, null).ConfigureAwait(false));
            };

            // Act
            var errors = await ErrorResponseMessage.BuildAsync(ex.Message).ConfigureAwait(false);

            // Assert   
            Assert.That(errors.Errors, Is.Not.Empty);
            Assert.That(errors.StatusCode, Is.EqualTo(422));
            Assert.That(errors.ReasonPhase, Is.EqualTo("Unprocessable Entity"));
        }

        [Test]
        public async Task Get_simple_formatted_error_message()
        {
            // Arrange
            var ex = new Exception();
            
            // Act
            using (var apiClient = new Customer())
            {
                ex = Assert.ThrowsAsync<Exception>(async () => await apiClient.GetAsync(Guid.NewGuid().ToString()).ConfigureAwait(false));
            };
            
            // Act
            var errors = await ErrorResponseMessage.BuildAsync(ex.Message).ConfigureAwait(false);

            // Assert   
            Assert.That(errors.Errors, Is.Not.Empty);
            Assert.That(errors.Errors.First().Errors.First(), Is.EqualTo("Customer Not Found"));
            Assert.That(errors.StatusCode, Is.EqualTo(404));
            Assert.That(errors.ReasonPhase, Is.EqualTo("Not Found"));
        }

    }

}
