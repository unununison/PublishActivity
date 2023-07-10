using System;

namespace Reports.Exceptions
{
	public class JournalNotFoundException : Exception
	{
		public JournalNotFoundException(string message) : base(message)
		{

		}
	}
}
