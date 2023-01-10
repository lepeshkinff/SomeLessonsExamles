namespace CbIntegrator.Bussynes.Options
{
	/// <summary>
	/// Настройки подключения к бд
	/// </summary>
	public record DbOptions
	{
		/// <summary>
		/// Строка подключения
		/// </summary>
		public string ConnectionString { get; init; }
	}
}
