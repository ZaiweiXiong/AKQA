using TechTalk.SpecFlow;
using ConsoleApp3.Pages;

namespace ConsoleApp3.Steps
{
    [Binding]
    class WishList
    {

        private BunningsPage bunningsPage = new BunningsPage();

        [Given(@"Visit the bunnings website")]
        public void GivenVisitTheBunningsWebsite()
        {
            bunningsPage.bunnings();
        }

        [When(@"sercah term ""(.*)""")]
        public void WhenSercahTerm(string p0)
        {
            bunningsPage.bunnigsSerch();
        }

        [When(@"Randomly visit one prouect from Seearch result and click on add to wish list")]
        public void WhenRandomlyVisitOneProuectFromSeearchResultAndClickOnAddToWishList()
        {
            bunningsPage.selectOneProduct();
        }

        [Then(@"The prouect should be added successfully")]
        public void ThenTheProuectShouldBeAddedSuccessfully()
        {
            bunningsPage.addSelectedProduct().AssertProductList();
        }



    }
}
