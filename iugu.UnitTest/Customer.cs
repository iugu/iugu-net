using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace iugu.UnitTest
{
    [TestClass]
    public class Customer
    {
        [TestMethod]
        public void Create()
        {
            var iugu = new iugu();
            var custom = new System.Collections.Generic.List<CustomVariables>();
            custom.Add(new CustomVariables{ name = "Tipo", value = "Desmanche"});
            custom.Add(new CustomVariables{ name = "Representante", value = "Fabio Munhoz (RJ)"});

            var usuario = new Lib.Customer().Create("malka2@gmail.com","Daniel Teste 2 C#","teste da api em C#",custom);
            var criado = usuario.id;
        }


    }
}
