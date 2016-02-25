namespace iugu.net.Entity
{
    // TODO: Precisa de refatoração, nomes fora do padrão .Net, sem documentação também
    public class TransferModel
    {
        public string id { get; set; }
        public string created_at { get; set; }
        public string amount_cents { get; set; }
        public string amount_localized { get; set; }
        public Receiver receiver { get; set; }
    }

    // TODO: Precisa de refatoração, nomes fora do padrão .Net, sem documentação também
    public class Receiver
    {
        public string id { get; set; }
        public string name { get; set; }
    }
}
