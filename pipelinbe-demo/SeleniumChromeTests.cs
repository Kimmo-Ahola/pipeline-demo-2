using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace pipelinbe_demo;

[Category("UI")]
public class SeleniumChromeTests
{
	private ChromeDriver _chromeDriver;
	private const string BaseURL = "https://www.kimmoahola.net/selenium.html";

	[SetUp]
	public void Setup()
	{
		new DriverManager().SetUpDriver(new ChromeConfig());

		var options = new ChromeOptions();
		options.AddArgument("--headless");
		_chromeDriver = new ChromeDriver(options);
		_chromeDriver.Navigate().GoToUrl(BaseURL);
	}

	[TearDown]
	public void Teardown()
	{
		_chromeDriver.Dispose();
	}

	[Test]
	public void GetMainTitleText()
	{
		var title = _chromeDriver.FindElement(By.Id("main-title")).Text;
		Assert.That(title, Is.EqualTo("Selenium Test Page"));
	}

	[Test]
	public void EnterUsername()
	{
		var usernameInput = _chromeDriver.FindElement(By.Name("username"));
		usernameInput.Clear();
		usernameInput.SendKeys("testuser");
		Assert.That(usernameInput.GetAttribute("value"), Is.EqualTo("testuser"));
	}

	[Test]
	public void CheckCheckbox2()
	{
		var checkbox = _chromeDriver.FindElement(By.Name("check2"));
		if (!checkbox.Selected)
		{
			checkbox.Click();
		}
		Assert.That(checkbox.Selected);
	}

	[Test]
	public void SelectBlueRadio()
	{
		var radio = _chromeDriver.FindElement(By.CssSelector("input[type='radio'][value='blue']"));
		radio.Click();
		Assert.That(radio.Selected);
	}

	[Test]
	public void SelectDropdownOption3()
	{
		var dropdown = _chromeDriver.FindElement(By.Id("dropdown"));
		var dropdownElement = new SelectElement(dropdown);
		dropdownElement.SelectByText("Option 3");
		Assert.That(dropdownElement.SelectedOption.GetAttribute("value"), Is.EqualTo("option3"));
	}

	[Test]
	public void ClickButtonByClass()
	{
		var button = _chromeDriver.FindElement(By.ClassName("btn-class"));
		button.Click();
		Assert.Pass("Button clicked successfully");
	}

	[Test]
	public void GetLinkHrefWithoutNavigating()
	{
		var link = _chromeDriver.FindElement(By.Id("link-id"));
		var href = link.GetAttribute("href");
		ClassicAssert.IsNotNull(href);
	}

	[Test]
	public void GetNestedSpanText()
	{
		var span = _chromeDriver.FindElement(By.CssSelector(".outer .inner #nested-span"));
		var text = span.Text;
		Assert.That(text, Is.EqualTo("Nested Span"));
	}

	[Test]
	public void GetImageAltText()
	{
		var image = _chromeDriver.FindElement(By.Id("image-id"));
		var alt = image.GetAttribute("alt");
		Assert.That(alt, Is.EqualTo("Did you find the alt text?"));
	}
}
