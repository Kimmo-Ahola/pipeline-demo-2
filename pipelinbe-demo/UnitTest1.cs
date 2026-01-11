using calc;

namespace pipelinbe_demo;

public class Tests
{
	private Calculator calculator;
	[SetUp]
	public void Setup()
	{
		calculator = new Calculator();
	}

	[Test]
	public void Addition()
	{
		// Arrange
		int first = 1;
		int second = 2;
		// Act

		var result = calculator.Addition(first, second);
		// Assert

		Assert.That(result, Is.EqualTo(first + second));
	}
}
