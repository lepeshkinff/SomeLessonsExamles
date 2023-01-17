using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CbIntegrator.Bussynes.Models;
using CbIntegrator.Bussynes.Options;

namespace CbIntegrator.Bussynes.Repositories
{
	public class CurenciesRepository : DbConnector
	{
		public CurenciesRepository(DbOptions configuration) : base(configuration)
		{
		}

		public virtual List<Currency> GetCurencies()
		{
			return GetList<Currency>(
				"select code, name, price from currencies",
				null,
				ReadCurrency);
		}

		private Currency ReadCurrency(IDataReader reader)
		{
			var currency = new Currency();
			currency.Price = reader.GetInt64(2);
			currency.Code = reader.GetString(0);
			currency.Name = reader.GetString(1);

			return currency;
		}
	}

	public class DummyCurenciesRepository : CurenciesRepository
	{
		public DummyCurenciesRepository(): base(new DbOptions())
		{

		}

		public override List<Currency> GetCurencies()
		{
			return new List<Currency>();
		}
	}
}
