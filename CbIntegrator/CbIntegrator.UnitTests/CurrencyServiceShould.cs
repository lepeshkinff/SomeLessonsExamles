using CbIntegrator.Bussynes.Services;

namespace CbIntegrator.UnitTests
{
	public class CurrencyServiceShould
	{
		private CurrncyService service;
		public CurrencyServiceShould()
		{
			service = new CurrncyService("file:///E:/VS/SomeLessonsExamles/CbIntegrator/CbIntegrator.UnitTests/Resources/daily.xml");
		}

		[Fact]
		public void ReturnCurrency_Dollar()
		{
			var result = service.GetCurrency();

			Assert.True(result.TryGetValue(CurrencyIds.DOLLAR_ID, out var currency));
			Assert.NotNull(result);
		}

		[Fact]
		public void NotReturnCurrency_Unknown()
		{
			var result = service.GetCurrency();

			Assert.False(result.TryGetValue("--", out var currency));
			Assert.Null(currency);
		}

		[Theory]
		[InlineData(Currency.Cyn, true)]
		[InlineData(Currency.Dollar, true)]
		[InlineData(Currency.Euro, true)]
		[InlineData((Currency)7, false)]
		public void ReturnCurrencyById(Currency id, bool resultExpected) 
		{
			var result = service.GetCurrencyById(id);

			Assert.Equal(result is not null, resultExpected);
		}
	}


}