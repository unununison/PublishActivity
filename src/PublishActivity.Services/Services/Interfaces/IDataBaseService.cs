using PublishActivity.Data.Models;

namespace PublishActivity.Services.Services.Interfaces
{
	public interface IDataBaseService
	{
		public BasePpsContext BasePpsContext { get; set; }
	}
}