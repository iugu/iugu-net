using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iugu.Entity
{
    public class CustomVariables
    {
        public string name { get; set; }
        public string value { get; set; }

    }



    public class Logs
    {
        /// <summary>
        /// Descrição da Entrada de Log
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// Anotações da Entrada de Log
        /// </summary>
        public string notes { get; set; }

    }

    public class Feature
    {
        /// <summary>
        /// Nome da Funcionalidade
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Identificador único da funcionalidade
        /// </summary>
        public string identifier { get; set; }

        /// <summary>
        /// Valor da Funcionalidade (número maior que 0)
        /// </summary>
        public int value { get; set; }
    }

    public class Prices
    {
        /// <summary>
        /// Moeda do Preço (Somente "BRL" por enquanto)
        /// </summary>
        public string currency { get; set; }

        /// <summary>
        /// Preço do Plano em Centavos
        /// </summary>
        public int value_cents { get; set; }
    }

    public class CreditCard
    {
        /// <summary>
        /// Número do Cartão de Crédito
        /// </summary>
        public int number { get; set; }

        /// <summary>
        /// CVV do Cartão de Crédito
        /// </summary>
        public int verification_value { get; set; }

        /// <summary>
        /// Nome do Cliente como está no Cartão
        /// </summary>
        public string first_name { get; set; }

        /// <summary>
        /// Sobrenome do Cliente como está no Cartão
        /// </summary>
        public string last_name { get; set; }

        /// <summary>
        /// Mês de Vencimento no Formato MM (Ex: 01, 02, 12)
        /// </summary>
        public int month { get; set; }

        /// <summary>
        /// Ano de Vencimento no Formato YYYY (2014, 2015, 2016)
        /// </summary>
        public int year { get; set; }
    }

}
