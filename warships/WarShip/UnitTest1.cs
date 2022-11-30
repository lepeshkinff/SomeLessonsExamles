using FluentAssertions;
using morskoyboy;
using Xunit;

using Ship = morskoyboy.WarShip;

namespace WarShip.Test
{
	public class CellShould
	{
		[Theory(DisplayName = "Проверяем установку корабля")]
		[InlineData(CellValue.Ship)]
		[InlineData(CellValue.Hit)]
		[InlineData(CellValue.Crash)]
		[InlineData(CellValue.Empty)]
		public Cell SetShipSuccess(CellValue cellValue)
		{
			var cell = new Cell();

			cell.SetShip(new Ship(WarshipType.Single), cellValue);

			cell.CellValue.Should().Be(cellValue);

			return cell;
		}

		[Theory(DisplayName = "Проверяем выстрел по ячейке")]
		[InlineData(CellValue.Ship, CellValue.Crash)]
		[InlineData(CellValue.Hit, CellValue.Hit)]
		[InlineData(CellValue.Crash, CellValue.Crash)]
		[InlineData(CellValue.Empty, CellValue.Hit)]
		public void CellCrash(CellValue cellValue, CellValue expected)
		{
			var cell = SetShipSuccess(cellValue);

			cell.Crash();
						
			cell.CellValue.Should().Be(expected);
		}

		[Theory(DisplayName = "Проверяем что после выстрела вызвано событие")]
		[InlineData(CellValue.Ship, CellValue.Crash)]
		[InlineData(CellValue.Hit, CellValue.Hit)]
		[InlineData(CellValue.Crash, CellValue.Crash)]
		[InlineData(CellValue.Empty, CellValue.Hit)]
		public void CellCrashEvent(CellValue cellValue, CellValue expected)
		{
			var cell = SetShipSuccess(cellValue);

			cell.Crash();

			cell.CellValue.Should().Be(expected);
		}
	}
}