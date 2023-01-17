using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CbIntegrator.Bussynes.Services
{
	public class CurrncyService
	{
		private readonly string urlCurrencyDaily;

		public CurrncyService(string urlCurrencyDaily)
		{
			this.urlCurrencyDaily = urlCurrencyDaily;
		}
		/// <summary>
		/// Получение курcа валют с сайте ЦБ РФ:
		/// </summary>
		/// <returns>Key - идентификатор валюты</returns>
		public IDictionary<string, ValCursValute?> GetCurrency()
		{
			using var client = new WebClient();
			var xml = client.DownloadString(urlCurrencyDaily);
			var serial = new XmlSerializer(typeof(ValCurs));
			using var reader = XmlReader.Create(xml);
			var courses = serial.Deserialize(reader) as ValCurs;

			if(courses is null)
			{
				return new Dictionary<string, ValCursValute?>();
			}

			var result = courses!.Valute
				.GroupBy(x => x.ID)
				.ToDictionary(x => x.Key, v => v.FirstOrDefault());

			return result;
		}

		public ValCursValute? GetCurrencyById(Currency currencyId)
		{
			string? id = currencyId switch
			{
				Currency.Dollar => CurrencyIds.DOLLAR_ID,
				Currency.Euro => CurrencyIds.EURO_ID,
				Currency.Cyn => CurrencyIds.CNY_ID,
				_ => null
			};

			if(id == null)
			{
				return null;
			}

			var result = GetCurrency();
			return result.TryGetValue(id, out var cv) ? cv : null;
		}
	}

}
