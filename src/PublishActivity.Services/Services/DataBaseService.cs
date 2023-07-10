using PublishActivity.Data.Models;
using PublishActivity.Services.Services.Interfaces;

namespace PublishActivity.Services.Services
{
	public class DataBaseService : IDataBaseService
	{
		public BasePpsContext BasePpsContext { get; set; }

		public DataBaseService(BasePpsContext context)
		{
			BasePpsContext = context;
		}


	}
}
