using System;

namespace CleanArchitecture.CodeGenerator.Helpers
{
	internal interface ILogger
	{
		void Initialize(IServiceProvider provider, string name);
		void Log(object message);
	}
}
