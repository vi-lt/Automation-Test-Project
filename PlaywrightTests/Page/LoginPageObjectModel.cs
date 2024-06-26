using Microsoft.Playwright;
using NUnit.Allure.Attributes;

namespace BigEcommerceApp.Tests.Models;

public class LoginPageObjectModel(IPage Page)
{
    private readonly IPage _page = Page;
    private string txt_UserNameXPath = "//input[@id='user-name']";
    private string txt_PasswordXPath = "//input[@id='password']";
    private string btn_LoginXPath = "//input[@id='login-button']";
    private string msg_ErrorLockXPath = "//h3[@data-test='error']";

    private ILocator txt_UserName => _page.Locator(txt_UserNameXPath);
    private ILocator txt_Password => _page.Locator(txt_PasswordXPath);
    private ILocator btn_Login => _page.Locator(btn_LoginXPath);
    private ILocator msg_ErrorLock => _page.Locator(msg_ErrorLockXPath);

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