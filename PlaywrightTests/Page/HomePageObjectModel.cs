using AspectInjector.Broker;
using Microsoft.Playwright;
using NUnit.Allure.Attributes;
using System.Reflection.Metadata.Ecma335;

namespace BigEcommerceApp.Tests.Models;

public class HomePageObjectModel(IPage Page)
{
    private readonly IPage _page = Page;
    private string btn_BurgerXPath = "//div[@class='bm-burger-button']";
    private string menu_LeftXPath(string nameMenu) => "//a[contains(text(),'" + nameMenu + "')]";
    private string lbl_NameCartXPath(string nameCart) => "//div[contains(text(),'" + nameCart + "')]";
    private string btn_AddToCartXPath = "//button[contains(@id,'add')]";
    private string numb_CartXpath = "//span[@class='shopping_cart_badge']";

    private ILocator btn_Burger => _page.Locator(btn_BurgerXPath);
    private ILocator menu_Left(string nameMenu) => _page.Locator(menu_LeftXPath(nameMenu));
    private ILocator lbl_NameCart(string nameCart) => _page.Locator(lbl_NameCartXPath(nameCart));
    private ILocator btn_AddToCart => _page.Locator(btn_AddToCartXPath);
    private ILocator numb_Cart => _page.Locator(numb_CartXpath);


    # region Action
    [AllureStep]
    public async Task clickButtonBurger()
    {
        await btn_Burger.ClickAsync();
    }

    public async Task clickOnMenuLeft(string menuName)
    {
        await menu_Left(menuName).ClickAsync();
    }

    [AllureStep]
    public async Task clickOnNameCart(string nameCart)
    {
        await lbl_NameCart(nameCart).ClickAsync();
    }

    [AllureStep]
    public async Task clickButtonAddToCart()
    {
        await btn_AddToCart.ClickAsync();
    }

    [AllureStep]
    public async Task clickButtonAddToCartBaseOnName(string nameCart)
    {
        var xpath = lbl_NameCartXPath(nameCart) + "/ancestor::div[@class='inventory_item_description']" + btn_AddToCartXPath;
        await _page.Locator(xpath).ClickAsync();
    }
    #endregion

    #region Verify
    [AllureStep]
    public async Task VerifyNumberAfterClickAddToCart(string expect)
    {
        string actual = await numb_Cart.TextContentAsync();
        Assert.AreEqual(actual, expect);
    }
    #endregion
}