using iugu.net.Entity;
using Ploeh.AutoFixture;

namespace iugu.net.IntegratedTests.DataBuilders
{
    public static class PayerModelDataBuilder
    {
        private static readonly Fixture _dataBuilder = new Fixture();

        public static PayerModel CreateValid()
        {
            var addressModel = _dataBuilder.Build<AddressModel>()
                                           .With(am => am.ZipCode, "01304-001")
                                           .With(am => am.District, "Consolação")
                                           .With(am => am.State, "São Paulo")
                                           .With(am => am.Street, "R. Augusta")
                                           .With(am => am.Number, "1598")
                                           .With(am => am.City, "São Paulo")
                                           .With(am => am.Country, "Brasil")
                                           .Create();


            var payer = _dataBuilder.Build<PayerModel>()
                                    .With(pm => pm.CpfOrCnpj, "23687237818")
                                    .With(m => m.Address, addressModel)
                                    .Create();


            return payer;
        }
    }
}
