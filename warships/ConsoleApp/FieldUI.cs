using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using morskoyboy;

namespace ConsoleApp
{
    class FieldUI
    {
        private readonly object _sync = new object();
        /// <summary>
        /// Сообщение пользователю
        /// </summary>
        /// <param name="message"></param>
        public void PrintMessage(string message)
        {
            Print(0, 0, message);
        }

        /// <summary>
        /// Чтение ввода
        /// </summary>
        public string UserInput(string message)
        {
            Print(10, 25, message);
            Console.SetCursorPosition(10, 26);
            var row = Console.ReadLine();           
            ClearLine(10, 26);
            return row;
        }

        private void Print(int x, int y, string message)
        {
            lock(_sync)
            {
                ClearLine(x, y);
                Console.SetCursorPosition(x, y);
                Console.Write(message);
            }
        }

        protected (string, ConsoleColor) GetCellUI(CellValue tomato)
        {
            switch (tomato)
            {
                case CellValue.Empty:
                    return ("X ", ConsoleColor.White);
                case CellValue.Hit:
                    return ("X ", ConsoleColor.Blue);
                case CellValue.Crash:
                    return ("W ", ConsoleColor.Red);
                case CellValue.Ship:
                    return ("W ", ConsoleColor.Green);
                default: throw new Exception();
            }
        }

        public void PrintField(Field fieldUser, Field opponent)
        {
            PrintFieldInternale(10, 5, fieldUser);
            PrintFieldInternale(22, 5, opponent);
        }
        private void PrintFieldInternale(int xFiledPosition, int yFiledPosotion, Field field)
        {
            var cells = field.GetCellsValues();
            foreach (var cell in cells)
            {
                Console.SetCursorPosition(xFiledPosition + cell.x, yFiledPosotion + cell.y);
                var displayChar = GetCellUI(cell.value.CellValue);
                var col = Console.ForegroundColor;
                Console.ForegroundColor = displayChar.Item2;
                Console.Write(displayChar.Item1);
                Console.ForegroundColor = col;
            }
        }

        public void ClearLine(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }
    }
}
