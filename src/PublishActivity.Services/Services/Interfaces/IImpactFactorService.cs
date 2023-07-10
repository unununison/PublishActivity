using PublishActivity.Data.Models;

namespace PublishActivity.Services.Services.Interfaces
{
	/// <summary>
	/// Интерфейс для работы с импакт-факторами
	/// </summary>
	public interface IImpactFactorService
	{
		/// <summary>
		/// Поиск импакт-фактора журнала
		/// </summary>
		/// <param name="issn">Issn журнала</param>
		/// <returns>Данные об импакт-факторе</returns>
		Task<Dictionary<int, decimal>?> FindAsync(string issn);

		/// <summary>
		/// Обновление импакт-фактора всех журналов
		/// </summary>
		/// <returns>Список журналов с не обновлённым импакт-фактором</returns>
		Task<IEnumerable<Edition>> UpdateAllImpactFactorsAsync();

		/// <summary>
		/// Обновить 
		/// </summary>
		/// <param name="editionId">Журнал</param>
		/// <param name="impactFactors">Импакт-факторы журналов</param>
		/// <returns>Токен выполнения задачи</returns>
		Task UpdateImpactFactorAsync(int editionId, Dictionary<int, decimal> impactFactors);
	}
}
