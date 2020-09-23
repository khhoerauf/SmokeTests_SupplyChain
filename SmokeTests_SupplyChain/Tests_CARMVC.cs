using NUnit.Framework;
using SmokeTests_SupplyChain.CARMVC;

namespace SmokeTests_SupplyChain
{
    class Tests_CARMVC
    {
        private CapExProjectPage page { get; set; }

        [SetUp]
        public void Setup()
        {
            page = new CapExProjectPage();
        }

        [Test]
        public void Overviewpage()
        {

        }
    }
}
