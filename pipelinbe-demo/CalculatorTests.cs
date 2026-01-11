using calc;

namespace pipelinbe_demo;

public class CalculatorTests
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

	[Test]
	public void Subtraction()
	{
		// Arrange
		int first = 1;
		int second = 2;
		// Act

		var result = calculator.Subtraction(first, second);
		// Assert

		Assert.That(result, Is.EqualTo(first - second));
	}

	[Test]
	public void Multiplication()
	{
		// Arrange
		int first = 1;
		int second = 2;
		// Act

		var result = calculator.Multiplication(first, second);
		// Assert

		Assert.That(result, Is.EqualTo(first * second));
	}

	[Test]
	public void Division()
	{
		// Arrange
		int first = 1;
		int second = 2;
		// Act

		var result = calculator.Divide(first, second);
		// Assert

		Assert.That(result, Is.EqualTo(first / second));
	}

}
