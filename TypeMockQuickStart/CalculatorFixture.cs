using System;
using NUnit.Framework;

namespace TypeMockQuickStart
{
	[TestFixture]
	public class CalculatorFixture
	{
		[Test]
		public void AddTwoPositiveNumbers()
		{
			// Setup
			Calculator calc = new Calculator();

			// Execute
			double result = calc.Add(3, 7);

			// Assert
			Assert.AreEqual(10, result);
		}

		[Test]
		public void DivideTwoPositiveNumbers()
		{
			Calculator calc = new Calculator();
			double result = calc.Divide(10, 5);
			Assert.AreEqual(2, result);
		}

		[Test]
		[ExpectedException(typeof(DivideByZeroException))]
		public void DivideByZero()
		{
			Calculator calc = new Calculator();
			double result = calc.Divide(5, 0);
		}
	}
}
