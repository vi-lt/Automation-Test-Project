using Microsoft.Playwright;
using NUnit.Allure.Attributes;
using PlaywrightTests.Setup;

namespace PlaywrightTests;
[AllureSuite("Test Suite")]
[AllureFeature("Feature")]
public partial class TestCaseHomePage : BaseTest
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

}