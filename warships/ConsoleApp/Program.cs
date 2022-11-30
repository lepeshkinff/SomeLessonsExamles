
using morskoyboy;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static FieldUI ui = new FieldUI();
        static void Main(string[] args)
        {
            var gamove = new Game();
            gamove.Start();
            gamove.OnPlayerRetry += Gamove_OnPlayerRetry;
            gamove.OnPlayerMove += Gamove_OnPlayerMove;
            gamove.OnErrorMove += Gamove_OnErrorMove;

            gamove.SetWarship(PlayerValue.First, WarshipType.Single, true, 0, 0);
            gamove.SetWarship(PlayerValue.First, WarshipType.Single, true, 2, 0);
            gamove.SetWarship(PlayerValue.First, WarshipType.Single, true, 4, 0);
            gamove.SetWarship(PlayerValue.First, WarshipType.Single, true, 6, 0);
            gamove.SetWarship(PlayerValue.First, WarshipType.Lincor, true, 2, 2);
            gamove.SetWarship(PlayerValue.First, WarshipType.Double, false, 8, 2);

            gamove.SetWarship(PlayerValue.Second, WarshipType.Single, true, 0, 0);
            gamove.SetWarship(PlayerValue.Second, WarshipType.Single, true, 2, 0);
            gamove.SetWarship(PlayerValue.Second, WarshipType.Single, true, 4, 0);
            gamove.SetWarship(PlayerValue.Second, WarshipType.Single, true, 6, 0);
            gamove.SetWarship(PlayerValue.Second, WarshipType.Lincor, true, 2, 2);
            gamove.SetWarship(PlayerValue.Second, WarshipType.Double, false, 8, 2);

            
            while(true)
            {
                var field = gamove.GetPlayerField(gamove.Current);                
                var opponent = gamove.GetOpponentField(gamove.Current);
                ui.PrintField(field, opponent);

                var row = ui.UserInput($"Стреляй! {gamove.Current}");
                var coors = row.Split(" ")
                    .Select(int.Parse)
                    .ToList();

                gamove.PlayerMove((byte)coors[0], (byte)coors[1], gamove.Current);

            }
        }

        private static void Gamove_OnErrorMove(byte x, byte y, PlayerValue playerValue)
        {
            ui.PrintMessage($"{playerValue}, так ходить низя {x} {y}");
        }

        private static void Gamove_OnPlayerMove(CellValue cell, PlayerValue playerValue)
        {
            ui.PrintMessage($"Результат выстрела {playerValue}: {cell}");
        }

        private static void Gamove_OnPlayerRetry(CellValue cell, PlayerValue playerValue)
        {
            ui.PrintMessage($"Попробуй ещё раз {playerValue} (результат предыдущий {cell})");
        }


    }
}
