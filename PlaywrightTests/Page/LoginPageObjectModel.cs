using Microsoft.Playwright;
using NUnit.Allure.Attributes;

namespace BigEcommerceApp.Tests.Models;

public class LoginPageObjectModel(IPage Page)
{
    private readonly IPage _page = Page;
    private ILocator txt_UserName => _page.Locator("//input[@id='user-name']");
    private ILocator txt_Password => _page.Locator("//input[@id='password']");
    private ILocator btn_Login => _page.Locator("//input[@id='login-button']");
    private ILocator msg_ErrorLock => _page.Locator("//h3[@data-test='error']");

    //private ILocator menu_left(string nameMenu) => _page.Locator("//ul[@class='menu__list']//a[text()='"+ nameMenu + "']");

    # region Action
    [AllureStep]
    public async Task inputUserName(string username)
    {
        await txt_UserName.FillAsync(username);
    }

    [AllureStep]
    public async Task inputPassword(string password)
    {
        await txt_Password.FillAsync(password);
    }

    [AllureStep]
    public async Task clickLoginButton()
    {
        await btn_Login.ClickAsync();
    }
    #endregion

    #region Verify
    [AllureStep]
    public async Task VerifyInputUserNameIsEnable()
    {
        await txt_UserName.IsEnabledAsync();
    }

    [AllureStep]
    public async Task VerifyInputPasswordIsEnable()
    {
        await txt_Password.IsEnabledAsync();
    }

    [AllureStep]
    public async Task VerifyLoginButtonIsEnable()
    {
        await btn_Login.IsEnabledAsync();
    }

    [AllureStep]
    public async Task VerifyMessageLockIsVisible()
    {
        await msg_ErrorLock.IsVisibleAsync();
    }
    #endregion
}