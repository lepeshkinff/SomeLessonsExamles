using System;
using System.Collections.Generic;
using System.Text;

namespace morskoyboy
{
    /// <summary>
    /// Описание и значение клеток
    /// </summary>
    public enum CellValue
    {
        /// <summary>
        /// пустая клетка
        /// </summary>
        Empty = 0,
        /// <summary>
        /// корабль
        /// </summary>
        Ship = 1,
        /// <summary>
        /// попадание в пустую клетку
        /// </summary>
        Hit = 2,
        /// <summary>
        /// попадание по кораблю
        /// </summary>
        Crash = 3,
    }
}
