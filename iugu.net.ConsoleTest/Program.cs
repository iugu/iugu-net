using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iugu;

namespace iugu.net.ConsoleTest
{
    class Program
    {
        //[OK] Autenticação
        //[OK] Tokens (falta testar)
        //[OK] Cobrança Direta (falta testar)
        //[OK] Clientes
        //[OK] Formas de Pagamento (Falta testar)
        //[OK] Faturas
        //[OK] Planos
        //Assinaturas
        //Transferências de Valores
        //Market Place




        static void Main(string[] args)
        {
            var iugu = new iugu();

            Console.WriteLine("Teste de Clientes em: " + iugu.BaseURI);
            var usuario = new Lib.Customer();
            //var userid = Console.ReadLine();
            //var customer = usuario.Delete(userid);
            //Console.WriteLine(customer.name);
            //var usuario = new Lib.Customer().Create(new Entity.CustomerModel
            //{
            //    email = "malka@gmail.com",
            //    name = "Daniel Teste C#",
            //    notes = "teste da api em C#",
            //});

            Console.WriteLine(usuario.Get().totalItems);

            Console.ReadLine();

        }
    }
}
