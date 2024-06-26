using Microsoft.Playwright;
using NUnit.Allure.Attributes;

namespace BigEcommerceApp.Tests.Models;

public class HomePageObjectModel(IPage Page)
{
    private readonly IPage _page = Page;
    private ILocator btn_Burger => _page.Locator("//div[@class='bm-burger-button']");
    private ILocator msg_ErrorLock => _page.Locator("//h3[@data-test='error']");
    private ILocator menu_left(string nameMenu) => _page.Locator("//a[contains(text(),'" + nameMenu + "')]");

    # region Action
    [AllureStep]
    public async Task clickButtonBurger()
    {
        await btn_Burger.ClickAsync();
    }

    public async Task clickOnMenuLeft(string menuName)
    {
        await menu_left(menuName).ClickAsync();
    }
    #endregion

    #region Verify
    [AllureStep]
    public async Task VerifyMessageLockIsVisible()
    {
        await msg_ErrorLock.IsVisibleAsync();
    }
    #endregion
}