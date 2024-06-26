using Microsoft.Playwright;
using NUnit.Allure.Attributes;
using PlaywrightTests.Setup;

namespace PlaywrightTests;
[AllureSuite("Test Suite")]
[AllureFeature("Feature")]
public partial class TestCaseLogin : BaseTest
{
    [Test]
    [AllureName("Verify Default UI")]
    [AllureTag("UI")]
    public async Task VerifyDefaultUI()
    {
        await Common.VerifyUrl(BaseUrl);
        await LoginPageObjectModel.VerifyInputUserNameIsEnable();
        await LoginPageObjectModel.VerifyInputPasswordIsEnable();
        await LoginPageObjectModel.VerifyLoginButtonIsEnable();
        await Common.WaitToLoadTimeOut(3000); //Just add in the end to look at the result fail or pass
    }

    [Test]
    [AllureName("Verify Lock User Login Failed")]
    [AllureTag("UI")]
    public async Task VerifyLoginFailed()
    {
        await Common.VerifyUrl(BaseUrl);
        await LoginPageObjectModel.inputUserName(Constant.userNameLock);
        await LoginPageObjectModel.inputPassword(Constant.password);
        await LoginPageObjectModel.clickLoginButton();
        await LoginPageObjectModel.VerifyMessageLockIsVisible();
        await Common.WaitToLoadTimeOut(3000); //Just add in the end to look at the result fail or pass
    }

    [Test]
    [AllureName("Verify User Login Successfully")]
    [AllureTag("UI")]
    public async Task VerifyLoginSuccessfully()
    {
        await Common.VerifyUrl(BaseUrl);
        await LoginPageObjectModel.inputUserName(Constant.userName);
        await LoginPageObjectModel.inputPassword(Constant.password);
        await LoginPageObjectModel.clickLoginButton();
        await Common.VerifyUrl(BaseUrl + "inventory.html");
        await Common.WaitToLoadTimeOut(3000); //Just add in the end to look at the result fail or pass
    }

    [Test]
    [AllureName("This is test case failed")]
    [AllureTag("UI")]
    public async Task VerifyLogin()
    {
        await Common.VerifyUrl(BaseUrl);
        await LoginPageObjectModel.inputUserName(Constant.userName);
        await LoginPageObjectModel.inputPassword(Constant.password);
        await LoginPageObjectModel.clickLoginButton();
        await Common.WaitToLoadTimeOut(3000);
        await Common.VerifyUrl(BaseUrl);
        await Common.WaitToLoadTimeOut(3000); //Just add in the end to look at the result fail or pass
    }

    [Test]
    [AllureName("Verify User can log out")]
    [AllureTag("UI")]
    public async Task VerifyLogOutSuccessfully()
    {
        await Common.VerifyUrl(BaseUrl);
        await LoginPageObjectModel.inputUserName(Constant.userName);
        await LoginPageObjectModel.inputPassword(Constant.password);
        await LoginPageObjectModel.clickLoginButton();
        await Common.VerifyUrl(BaseUrl + "inventory.html");
        await HomePageObjectModel.clickButtonBurger();
        await HomePageObjectModel.clickOnMenuLeft("Logout");
        await Common.VerifyUrl(BaseUrl);
        await Common.WaitToLoadTimeOut(3000); //Just add in the end to look at the result fail or pass
    }
}