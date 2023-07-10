using System;
using System.Runtime.Serialization;

namespace Reports.Exceptions
{
	public class InformationNotFoundException : Exception
	{
		public InformationNotFoundException()
		{
		}

		public InformationNotFoundException(string message) : base(message)
		{

		}

		public InformationNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected InformationNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
