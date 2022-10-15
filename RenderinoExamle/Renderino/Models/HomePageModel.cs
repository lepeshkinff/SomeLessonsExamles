namespace Renderino.Models
{
	/// <summary>
	/// Модель для главной страницы
	/// </summary>
	public record HomePageModel
	{
		public IEnumerable<string> Names { get; init; }
	}
}
