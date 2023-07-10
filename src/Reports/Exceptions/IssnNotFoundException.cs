using System;

namespace Reports.Exceptions
{
	public class IssnNotFoundException : Exception
	{
		public IssnNotFoundException(string message) : base(message)
		{

		}
	}
}
