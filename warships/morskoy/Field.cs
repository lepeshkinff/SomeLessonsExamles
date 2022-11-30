using System.Collections.Generic;
using System.Text;

namespace morskoyboy
{
    public class Field
    {
        private Cell[,] cells;
        public CellValue GetCellsValue(byte x, byte y)
        {
            return cells[x, y].CellValue;
        }
        
        public Field(int sizex, int sizey)
        {
            cells = new Cell[sizex, sizey];

            for(var i = 0; i < sizex; i++)
            {
                for(var j = 0; j < sizey; j++)
                {
                    cells[i, j] = new Cell();
                }
            }
        }
        public Field(int sizex) : this(sizex, sizex)
        {

        }
        public Field() : this(10)
        {

        }

        public IEnumerable<(int x, int y, Cell value)> GetCellsValues()
        {
            for (var j = 0; j < cells.GetLength(1); j++)
            {
                for (var i = 0; i < cells.GetLength(0); i++)

                {
                    yield return (i, j, cells[i, j]);
                }
            };
        }

        internal bool SetCellShip(int x, int y, WarShip value, CellValue cellValue)
        {
            if (!Validate(x, y))
            {
                throw new GameException("Недопустимое значение");
            }
            var cell = cells[x, y];
            if (cell.CellValue != CellValue.Empty)
            {
                return false;
            }
            cell.SetShip(value, cellValue);

            return true;
        }

        internal CellValue CrashValue(byte x, byte y)
        {
            if (!Validate(x, y))
            {
                throw new GameException("Недопустимое значение");
            }
            var cell = cells[x, y];
            return cell.Crash();
        }
        
        public bool Validate(int x, int y)
        {
            return x >= 0 && x < cells.GetLength(0)
                && y >= 0 && y < cells.GetLength(1);
        }
        
    }

}
