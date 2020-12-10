using NUnit.Framework;

namespace iugu.net.IntegratedTests
{
    [SetUpFixture]
    public class GlobalSetup
    {
        [OneTimeSetUp]
        public void IuguClientConfig()
        {
            IuguClient.Init(new IuguClientProperties()
            {
                ApiKey = "74c265aedbfaea379bc0148fae9b5526"
            });
        }
    }
}
