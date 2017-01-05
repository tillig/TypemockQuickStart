using System;
using NUnit.Framework;
using TypeMock;
using System.Configuration;

namespace TypeMockQuickStart
{
	[TestFixture]
	[VerifyMocks]
	public class ConfigReaderFixture
	{
		[Test]
		public void SettingFound()
		{
			ConfigReader reader = new ConfigReader();
			using (RecordExpectations recorder = RecorderManager.StartRecording())
			{
				string dummySetting = ConfigurationManager.AppSettings["configReader"];
				recorder.CheckArguments();
				recorder.Return("readFromAppSettings");
			}
			string result = reader.AppendValueToSetting("PassedInFromTest");
			Assert.AreEqual("readFromAppSettingsPassedInFromTest", result);
		}

		[Test]
		public void SettingNotFound()
		{
			ConfigReader reader = new ConfigReader();
			using (RecordExpectations recorder = RecorderManager.StartRecording())
			{
				string dummySetting = ConfigurationManager.AppSettings["configReader"];
				recorder.Return(null);
			}
			string result = reader.AppendValueToSetting("PassedInFromTest");
			Assert.AreEqual("PassedInFromTest", result);
		}

		[Test]
		public void SettingEmpty()
		{
			ConfigReader reader = new ConfigReader();
			using (RecordExpectations recorder = RecorderManager.StartRecording())
			{
				string dummySetting = ConfigurationManager.AppSettings["configReader"];
				recorder.Return("");
			}
			string result = reader.AppendValueToSetting("PassedInFromTest");
			Assert.AreEqual("PassedInFromTest", result);
		}
	}
}
