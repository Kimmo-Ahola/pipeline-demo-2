using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
}
