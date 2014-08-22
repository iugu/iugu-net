using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iugu.Entity;

namespace iugu
{
    public class InvoiceModel
    {
        public string id { get; set; }
        public string due_date { get; set; }
        public string currency { get; set; }
        public object discount_cents { get; set; }
        public string email { get; set; }
        public int items_total_cents { get; set; }
        public object notification_url { get; set; }
        public object return_url { get; set; }
        public string status { get; set; }
        public object tax_cents { get; set; }
        public string updated_at { get; set; }
        public int total_cents { get; set; }
        public object paid_at { get; set; }
        public string secure_id { get; set; }
        public string secure_url { get; set; }
        public object customer_id { get; set; }
        public object user_id { get; set; }
        public string total { get; set; }
        public string taxes_paid { get; set; }
        public object interest { get; set; }
        public object discount { get; set; }
        public string created_at { get; set; }
        public object refundable { get; set; }
        public object installments { get; set; }
        public BankSlip bank_slip { get; set; }
        public List<Item> items { get; set; }
        public List<Variable> variables { get; set; }
        public List<CustomVariables> custom_variables { get; set; }
        public List<Logs> logs { get; set; }
    }

    public class BankSlip
    {
        public string digitable_line { get; set; }
        public string barcode_data { get; set; }
        public string barcode { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string description { get; set; }
        public int price_cents { get; set; }
        public int quantity { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string price { get; set; }
    }

    public class Variable
    {
        public string id { get; set; }
        public string variable { get; set; }
        public string value { get; set; }
    }

    public class InvoiceListModel
    {
        public Facets facets { get; set; }
        public int totalItems { get; set; }
        public List<InvoiceModel> items { get; set; }
    }

    public class Term
    {
        public string term { get; set; }
        public int count { get; set; }
    }

    public class Status
    {
        public string _type { get; set; }
        public int missing { get; set; }
        public int total { get; set; }
        public int other { get; set; }
        public List<Term> terms { get; set; }
    }

    public class Facets
    {
        public Status status { get; set; }
    }
}
