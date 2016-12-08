using iugu.net.Entity;
using iugu.net.Lib;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using iugu.net.Request;

namespace iugu.UnitTest
{
    [TestFixture]
    public class CustomerIntegratedTests
    {
        [Test]
        public async Task Create_a_customer_with_success()
        {
            // Arrange
            var custom = new List<CustomVariables>();
            custom.Add(new CustomVariables { name = "Tipo", value = "Desmanche" });
            custom.Add(new CustomVariables { name = "Representante", value = "Fabio Munhoz (RJ)" });

            CustomerModel myClient;

            // Act
            using (var apiClient = new Customer())
            {
                myClient = await apiClient.CreateAsync("malka2@gmail.com", "Daniel Teste 2 C#", "teste da api em C#", custom).ConfigureAwait(false);
            };

            // Assert
            Assert.That(myClient.email, Is.EqualTo("malka2@gmail.com"));
            Assert.That(myClient.id, Is.Not.Empty);
        }

        [Test]
        public async Task Create_a_customer_with_customer_request_with_success()
        {
            // Arrange
            var custom = new List<CustomVariables>();
            custom.Add(new CustomVariables { name = "Tipo", value = "Desmanche" });
            custom.Add(new CustomVariables { name = "Representante", value = "Fabio Munhoz (RJ)" });

            CustomerModel myClient;
            var customer = new CustomerRequestMessage
            {
                Email = "malka2@gmail.com",
                Name = "Daniel Teste 2 C#"
            };
            // Act
            using (var apiClient = new Customer())
            {
                myClient = await apiClient.CreateAsync(customer, null).ConfigureAwait(false);
            };

            // Assert
            Assert.That(myClient.email, Is.EqualTo("malka2@gmail.com"));
            Assert.That(myClient.id, Is.Not.Empty);
        }

        [Test]
        public void Search_a_not_found_customer()
        {
            // Arrange

            // Act
            using (var apiClient = new Customer())
            {
                var ex = Assert.Throws<AggregateException>(() => apiClient.Get(Guid.NewGuid().ToString()));
                Assert.That(ex.InnerExceptions.First().Message, Does.Contain("404").And.Contain("Not Found"));
            };

        }

        [Test]
        public async Task List_customers_with_success()
        {
            // Arrange
            CustomersModel myClients;

            // Act
            using (var apiClient = new Customer())
            {
                myClients = await apiClient.GetAsync().ConfigureAwait(false);
            };

            // Assert
            Assert.That(myClients, Is.Not.Null);
            Assert.That(myClients.items, Is.Not.Empty);
        }
    }
}
