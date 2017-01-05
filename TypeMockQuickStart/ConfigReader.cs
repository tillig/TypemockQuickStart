using System;
using System.Configuration;

namespace TypeMockQuickStart
{
	public class ConfigReader
	{
		public string AppendValueToSetting(string valueToAppend)
		{
			string setting = ConfigurationManager.AppSettings["configReader"];
			string result = setting + valueToAppend;
			return result;
		}
	}
}
