using iugu.net.Entity;
using iugu.net.Lib;
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using iugu.net.Request;
using iugu.net.Entity.Lists;

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
            custom.Add(new CustomVariables { Name = "Tipo", Value = "Desmanche" });
            custom.Add(new CustomVariables { Name = "Representante", Value = "Fabio Munhoz (RJ)" });

            CustomerModel myClient;

            var crm = new CustomerRequestMessage
            {
                Email = "malka2@gmail.com",
                Name = "Daniel Teste 2 C#",
                Notes = "teste da api em C#",
                CustomVariables = custom
            };

            // Act
            using (var apiClient = new Customer())
            {
                myClient = await apiClient.CreateAsync(crm).ConfigureAwait(false);
            };

            // Assert
            Assert.That(myClient.Email, Is.EqualTo("malka2@gmail.com"));
            Assert.That(myClient.ID, Is.Not.Empty);
        }

        [Test]
        public async Task Create_a_customer_with_customer_request_with_success()
        {
            // Arrange
            var custom = new List<CustomVariables>();
            custom.Add(new CustomVariables { Name = "Tipo", Value = "Desmanche" });
            custom.Add(new CustomVariables { Name = "Representante", Value = "Fabio Munhoz (RJ)" });

            CustomerModel myClient;
            var customer = new CustomerRequestMessage
            {
                Email = "malka2@gmail.com",
                Name = "Daniel Teste 2 C#",
                CpfOrCnpj = "20250884000140", //from http://www.geradorcnpj.com/
                CustomVariables = custom,
                zip_code = "01310940",
                number = 900,
                complement = "1º Subsolo"
            };
            // Act
            using (var apiClient = new Customer())
            {
                myClient = await apiClient.CreateAsync(customer, null).ConfigureAwait(false);
            };

            // Assert
            Assert.That(myClient.Email, Is.EqualTo("malka2@gmail.com"));
            Assert.That(myClient.ID, Is.Not.Empty);
        }

        [Test]
        public void Search_a_not_found_customer()
        {
            // Arrange

            // Act
            //TODO: re-create this test
            //using (var apiClient = new Customer())
            //{
            //    var ex = Assert.Throws<AggregateException>(() => apiClient.GetAsync("ddd").Result);
            //    Assert.That(ex.InnerExceptions.First().Message, Does.Contain("404").And.Contain("Not Found"));
            //};

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
