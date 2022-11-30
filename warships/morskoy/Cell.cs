using System;

namespace morskoyboy
{
    public class Cell
    {
        public delegate void CellEvent(Cell cell, bool changed);

        public event CellEvent OnCellChange;
        public WarShip Ship { get; private set; }
        public CellValue CellValue { get; private set; }
                
        internal void SetShip(WarShip warShip, CellValue cellValue)
        {
            Ship = warShip;
            CellValue = cellValue;
        }

        internal CellValue Crash()
        {
            var changed = false;
            switch(CellValue)
            {
                case CellValue.Ship:
                    CellValue = CellValue.Crash;
                    Ship?.Crash();
                    changed = true;
                    break;
                case CellValue.Empty:
                    CellValue = CellValue.Hit;
                    changed = true;
                    break;
            }

            OnCellChange?.Invoke(this, changed);

            return CellValue;
        }
	}

}
