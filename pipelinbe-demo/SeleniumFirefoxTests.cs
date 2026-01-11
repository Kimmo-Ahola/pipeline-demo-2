using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace pipelinbe_demo;

[Category("UI")]
public class SeleniumFirefoxTests
{
	private FirefoxDriver _firefoxDriver;
	private const string BaseURL = "https://www.kimmoahola.net/selenium.html";

	[SetUp]
	public void Setup()
	{
		new DriverManager().SetUpDriver(new FirefoxConfig());

		var options = new FirefoxOptions();
		options.AddArgument("--headless");

		_firefoxDriver = new FirefoxDriver(options);
		_firefoxDriver.Navigate().GoToUrl(BaseURL);
	}

	[TearDown]
	public void Teardown()
	{
		_firefoxDriver.Dispose();
		_firefoxDriver.Quit();
	}

	[Test]
	public void GetMainTitleText()
	{
		var title = _firefoxDriver.FindElement(By.Id("main-title")).Text;
		Assert.That(title, Is.EqualTo("Selenium Test Page"));
	}

	[Test]
	public void EnterUsername()
	{
		var usernameInput = _firefoxDriver.FindElement(By.Name("username"));
		usernameInput.Clear();
		usernameInput.SendKeys("testuser");
		Assert.That(usernameInput.GetAttribute("value"), Is.EqualTo("testuser"));
	}

	[Test]
	public void CheckCheckbox2()
	{
		var checkbox = _firefoxDriver.FindElement(By.Name("check2"));
		if (!checkbox.Selected)
		{
			checkbox.Click();
		}
		Assert.That(checkbox.Selected);
	}

	[Test]
	public void SelectBlueRadio()
	{
		var radio = _firefoxDriver.FindElement(By.CssSelector("input[type='radio'][value='blue']"));
		radio.Click();
		Assert.That(radio.Selected);
	}

	[Test]
	public void SelectDropdownOption3()
	{
		var dropdown = _firefoxDriver.FindElement(By.Id("dropdown"));
		var dropdownElement = new SelectElement(dropdown);
		dropdownElement.SelectByText("Option 3");
		Assert.That(dropdownElement.SelectedOption.GetAttribute("value"), Is.EqualTo("option3"));
	}

	[Test]
	public void ClickButtonByClass()
	{
		var button = _firefoxDriver.FindElement(By.ClassName("btn-class"));
		button.Click();
		Assert.Pass("Button clicked successfully");
	}

	[Test]
	public void GetLinkHrefWithoutNavigating()
	{
		var link = _firefoxDriver.FindElement(By.Id("link-id"));
		var href = link.GetAttribute("href");
		ClassicAssert.IsNotNull(href);
	}

	[Test]
	public void GetNestedSpanText()
	{
		var span = _firefoxDriver.FindElement(By.CssSelector(".outer .inner #nested-span"));
		var text = span.Text;
		Assert.That(text, Is.EqualTo("Nested Span"));
	}

	[Test]
	public void GetImageAltText()
	{
		var image = _firefoxDriver.FindElement(By.Id("image-id"));
		var alt = image.GetAttribute("alt");
		Assert.That(alt, Is.EqualTo("Did you find the alt text?"));
	}
}