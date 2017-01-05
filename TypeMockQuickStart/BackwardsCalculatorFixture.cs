using System;
using NUnit.Framework;
using TypeMock;

namespace TypeMockQuickStart
{
	[TestFixture]
	[VerifyMocks]
	public class BackwardsCalculatorFixture
	{
		[Test]
		public void ReverseAddPositive()
		{
			using (RecordExpectations recorder = RecorderManager.StartRecording())
			{
				Calculator dummyCalc = new Calculator();
				dummyCalc.Add(10, 20);
				recorder.CheckArguments();
				recorder.Return(30D);
			}
			BackwardsCalculator bCalc = new BackwardsCalculator();
			string result = bCalc.ReverseAdd(10, 20);
			Assert.AreEqual("03", result);
		}
	}
}
