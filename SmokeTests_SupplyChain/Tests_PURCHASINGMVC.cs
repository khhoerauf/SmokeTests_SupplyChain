using NUnit.Framework;
using SmokeTests_SupplyChain.PURCHASINGMVC;

namespace SmokeTests_SupplyChain
{
    class Tests_PURCHASINGMVC : TestBase
    {
        private PurchaseOrdersPage po;
        private VendorsPage vendor;
        private DashboardPage dashboard;

        [SetUp]
        public void Setup()
        {
            po = new PurchaseOrdersPage(Driver);
            vendor = new VendorsPage(Driver);
            dashboard = new DashboardPage(Driver);
        }

        [Test]
        public void TestIfServiceIsHealthy()
        {
            ServiceHealthyCheck("http://sxwebbeta1:8060/wcfhealth.aspx");
            ServiceHealthyCheck("http://wawebbeta1.qg.com:8060/wcfhealth.aspx");
        }

        [Test]
        public void TestOverviewSearch()
        {
            po.SearchForPoByEmploee("Kiley Stair");
        }

        [Test]
        public void TestLoadingPoDetailsView()
        {
            po.LookupPO(2984552);
        }

        [Test]
        public void TestLoadingVendorDetailsView()
        {

        }

        [Test]
        public void TestVendorSearchbox()
        {
            po.GoToVendorTab();

            vendor.SelectSearchFilterStartWith();
            vendor.SearchForVendor("6435");
            vendor.GetEmptySearchResultAndVerify();
            vendor.SearchForVendor(" ");
            vendor.CompareExpectedCountWithActualCountResults(1);
            vendor.GetEmptySearchResultAndVerify();
            vendor.SearchForVendor("V22743");
            vendor.GetFirstSearchResultAndVerify("V22743");
            vendor.SearchForVendor("V33");
            vendor.VerifyIfResultsAreGreaterThan(10);
        }

        [Test]
        public void TestLoadingPoDashboard()
        {
            po.GoToDashboardTab();
        }
    }
}
