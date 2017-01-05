using System;

namespace TypeMockQuickStart
{
	public class Calculator
	{
		private bool _allowAdd;

		public Calculator() : this(true) { }

		public Calculator(bool allowAdd)
		{
			this._allowAdd = allowAdd;
		}

		public double Add(double a, double b)
		{
			if (!this._allowAdd)
			{
				throw new InvalidOperationException("Add operation is not allowed.");
			}
			return a + b;
		}

		public double Divide(double a, double b)
		{
			if (b == 0)
			{
				throw new DivideByZeroException();
			}
			return a / b;
		}

		public double AddThenMultiply(double a, double b, double c)
		{
			double addResult = this.Add(a, b);
			double multiplyResult = addResult * c;
			return multiplyResult;
		}
	}
}
