using System;
using System.Linq;

namespace TypeMockQuickStart
{
	public class BackwardsCalculator
	{
		private Calculator _calculator;

		public BackwardsCalculator()
		{
			this._calculator = new Calculator();
		}

		public string ReverseAdd(double a, double b)
		{
			string forward = this._calculator.Add(a, b).ToString();
			string reversed = new string(forward.ToCharArray().Reverse().ToArray());
			return reversed;
		}
	}
}
