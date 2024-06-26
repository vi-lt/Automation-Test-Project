using Microsoft.Playwright;
using NUnit.Allure.Attributes;
using PlaywrightTests.Setup;

namespace PlaywrightTests;
[AllureSuite("Test Suite")]
[AllureFeature("Feature")]
public partial class TestCaseHomePage : BaseTest
{
    [Test]
    [AllureName("Verify User can add to Cart Successfully In Detail")]
    [AllureTag("UI")]
    public async Task VerifyAddToCartSuccessfullyInDetail()
    {
        await Common.VerifyUrl(BaseUrl);
        await Common.WaitToLoadTimeOut(2000);
        await LoginPageObjectModel.inputUserName(Constant.userName);
        await Common.WaitToLoadTimeOut(2000);
        await LoginPageObjectModel.inputPassword(Constant.password);
        await Common.WaitToLoadTimeOut(2000);
        await LoginPageObjectModel.clickLoginButton();
        await Common.WaitToLoadTimeOut(2000);
        await Common.VerifyUrl(BaseUrl + "inventory.html");
        await HomePageObjectModel.clickOnNameCart(Constant.cardList[0]);
        await Common.WaitToLoadTimeOut(2000);
        await HomePageObjectModel.clickButtonAddToCart();
        await HomePageObjectModel.VerifyNumberAfterClickAddToCart("1");
        await Common.WaitToLoadTimeOut(2000);
    }

    [Test]
    [AllureName("Verify User can add to Cart Successfully")]
    [AllureTag("UI")]
    public async Task VerifyAddToCartSuccessfully()
    {
        await Common.VerifyUrl(BaseUrl);
        await Common.WaitToLoadTimeOut(2000);
        await LoginPageObjectModel.inputUserName(Constant.userName);
        await Common.WaitToLoadTimeOut(2000);
        await LoginPageObjectModel.inputPassword(Constant.password);
        await Common.WaitToLoadTimeOut(2000);
        await LoginPageObjectModel.clickLoginButton();
        await Common.WaitToLoadTimeOut(2000);
        await Common.VerifyUrl(BaseUrl + "inventory.html");
        await HomePageObjectModel.clickButtonAddToCartBaseOnName(Constant.cardList[0]);
        await Common.WaitToLoadTimeOut(2000);
        await HomePageObjectModel.VerifyNumberAfterClickAddToCart("1");
        await HomePageObjectModel.clickButtonAddToCartBaseOnName(Constant.cardList[1]);
        await Common.WaitToLoadTimeOut(2000);
        await HomePageObjectModel.VerifyNumberAfterClickAddToCart("2");
        await HomePageObjectModel.clickButtonAddToCartBaseOnName(Constant.cardList[2]);
        await Common.WaitToLoadTimeOut(2000);
        await HomePageObjectModel.VerifyNumberAfterClickAddToCart("3");
        await HomePageObjectModel.clickButtonAddToCartBaseOnName(Constant.cardList[3]);
        await Common.WaitToLoadTimeOut(2000);
        await HomePageObjectModel.VerifyNumberAfterClickAddToCart("4");
        await HomePageObjectModel.clickButtonAddToCartBaseOnName(Constant.cardList[4]);
        await Common.WaitToLoadTimeOut(2000);
        await HomePageObjectModel.VerifyNumberAfterClickAddToCart("5");
        await HomePageObjectModel.clickButtonAddToCartBaseOnName(Constant.cardList[5]);
        await Common.WaitToLoadTimeOut(2000);
        await HomePageObjectModel.VerifyNumberAfterClickAddToCart("6");
    }
}