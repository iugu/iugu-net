using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace iugu.UnitTest
{
    [TestFixture]
    public class Customer
    {
        [Test]
        public void Create_a_customer_with_success()
        {
            var custom = new List<CustomVariables>();
            custom.Add(new CustomVariables { name = "Tipo", value = "Desmanche" });
            custom.Add(new CustomVariables { name = "Representante", value = "Fabio Munhoz (RJ)" });

            var usuario = new Lib.Customer().Create("malka2@gmail.com", "Daniel Teste 2 C#", "teste da api em C#", custom);
            var criado = usuario.id;
        }
    }
}
