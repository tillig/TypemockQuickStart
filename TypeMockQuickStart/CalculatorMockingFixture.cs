using System;
using NUnit.Framework;
using TypeMock;

namespace TypeMockQuickStart
{
	[TestFixture]
	[VerifyMocks]
	public class CalculatorMockingFixture
	{
		[Test]
		public void MultiplyPositiveAddResult()
		{
			Calculator calc = new Calculator();
			using (RecordExpectations recorder = RecorderManager.StartRecording())
			{
				double dummy = calc.Add(0, 0);
				recorder.Return(15D);
			}
			double result = calc.AddThenMultiply(5, 10, 20);
			Assert.AreEqual(300, result);
		}

		[Test]
		[ExpectedException(typeof(InvalidOperationException))]
		public void SkipConstructor()
		{
			Calculator calc;
			using (RecordExpectations recorder = RecorderManager.StartRecording())
			{
				calc = new Calculator();
			}
			calc = new Calculator();
			double result = calc.Add(2, 2);
			Assert.AreEqual(4, result);
		}

		[Test]
		public void SkipConstructorAddThenMultiply()
		{
			Calculator calc;
			using (RecordExpectations recorder = RecorderManager.StartRecording())
			{
				calc = new Calculator();
				double dummy = calc.Add(0, 0);
				recorder.Return(15D);
			}
			calc = new Calculator();
			double result = calc.AddThenMultiply(5, 10, 20);
			Assert.AreEqual(300, result);
		}
	}
}
