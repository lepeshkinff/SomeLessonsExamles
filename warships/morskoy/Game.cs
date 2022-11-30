using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace morskoyboy
{
    public class Game
    {
        private Field firstmap = new Field();
        private Field secondmap = new Field();
        private IEnumerator<PlayerValue> _turns = GameTurns().GetEnumerator();

        public PlayerValue Current => _turns.Current;
        private Dictionary<PlayerValue, Dictionary<WarshipType, List<WarShip>>> _playersShips = new();

        public delegate void PlayerEvent(CellValue cell, PlayerValue playerValue);
        public delegate void PlayerErrorMove(byte x, byte y, PlayerValue playerValue);

        public event PlayerEvent OnPlayerMove;
        public event PlayerEvent OnPlayerRetry;
        public event PlayerErrorMove OnErrorMove;

        public Game()
        {
            OnPlayerMove += Game_OnPlayerMove;
        }

        private void Game_OnPlayerMove(CellValue cell, PlayerValue playerValue)
        {
            if (cell != CellValue.Crash)
            {
                _turns.MoveNext();
            }
        }

        public bool CanSetWarship(PlayerValue playerValue, WarshipType type, bool vertical, int xPosition, int yPosition)
        {
            if (!_playersShips.TryGetValue(playerValue, out var ships))
            {
                return false;
            }

            if (!ships.TryGetValue(type, out var items))
            {
                return false;
            }

            if (items.Count == 0)
            {
                return false;
            }

            var ship = items.First();
            var field = GetPlayerField(playerValue);
            var cells = field.GetCellsValues();

            if (vertical)
            {
                var closeLeft = xPosition - 1;
                var closeRight = xPosition + 1;
                var positions = Enumerable.Range(yPosition - 1, ship.Deck + 1).ToList();
                if (cells.Any(x => 
                    x.value.CellValue != CellValue.Empty 
                    && (x.x == xPosition || x.x == closeLeft || x.x == closeRight)
                    && positions.Contains(x.y)))
                {
                    return false;
                }

                positions = Enumerable.Range(yPosition, ship.Deck).ToList();
                var result = cells.Count(x =>
                    x.value.CellValue == CellValue.Empty
                    && x.x == xPosition
                    && positions.Contains(x.y));

                return result == ship.Deck;
            }
            else
            {
                var closeLeft = yPosition - 1;
                var closeRight = yPosition + 1;
                var positions = Enumerable.Range(xPosition - 1, ship.Deck + 1).ToList();
                if (cells.Any(x =>
                    x.value.CellValue != CellValue.Empty
                    && (x.y == yPosition || x.y == closeLeft || x.y == closeRight)
                    && positions.Contains(x.y)))
                {
                    return false;
                }

                positions = Enumerable.Range(xPosition, ship.Deck).ToList();
                var result = cells.Count(x =>
                    x.value.CellValue == CellValue.Empty
                    && x.y == yPosition
                    && positions.Contains(x.x)
                    );

                return result == ship.Deck;
            }
            
        }

        public void SetWarship(PlayerValue playerValue, WarshipType type, bool vertical, int xPosition, int yPosition)
        {
            if (!CanSetWarship(playerValue, type, vertical, xPosition, yPosition))
            {
                return;
            }

            var ship = _playersShips[playerValue][type].First();
            var field = GetPlayerField(playerValue);
            var cells = field.GetCellsValues();

            if (vertical)
            {               
                var positions = Enumerable.Range(yPosition, ship.Deck).ToList();
                cells = cells.Where(x =>
                    x.value.CellValue == CellValue.Empty
                    && x.x == xPosition
                    && positions.Contains(x.y));
            }
            else
            {
                var positions = Enumerable.Range(xPosition, ship.Deck).ToList();
                cells = cells.Where(x =>
                    x.value.CellValue == CellValue.Empty
                    && x.y == yPosition
                    && positions.Contains(x.x));
            }

            foreach(var cell in cells)
            {
                field.SetCellShip(cell.x, cell.y, ship, CellValue.Ship);
            }

            _playersShips[playerValue][type].Remove(ship);
        }

        public Field GetPlayerField(PlayerValue player)
        {
            if (player == PlayerValue.First)
            {
                return firstmap;
            }
            return secondmap;
        }
        public Field GetOpponentField(PlayerValue opponent)
        {
            var field = opponent == PlayerValue.First
                ? secondmap
                : firstmap;
            var exceptionmap = new Field();
            var cells = field.GetCellsValues();
            foreach (var call in cells)
            {
                var res = call.value.CellValue == CellValue.Ship ? CellValue.Empty : call.value.CellValue;
                exceptionmap.SetCellShip(call.x, call.y, call.value.Ship, res);
            }

            return exceptionmap;
        }
        public void PlayerMove(byte x, byte y, PlayerValue pv)
        {
            if (pv != _turns.Current)
            {
                return;
            }

            var field = GetPlayerField(pv == PlayerValue.First ? PlayerValue.Second : PlayerValue.First);
            if(!field.Validate(x, y))
            {
                OnErrorMove?.Invoke(x, y, pv);
                return;
            }
            var currentValue = field.GetCellsValue(x, y);
            if (currentValue == CellValue.Hit || currentValue == CellValue.Crash)
            {
                OnPlayerRetry?.Invoke(currentValue, pv);
                return;
            }

            var result = field.CrashValue(x, y);

            OnPlayerMove?.Invoke(result, pv);
        }
        private static IEnumerable<PlayerValue> GameTurns()
        {
            while (true)
            {
                yield return PlayerValue.First;
                yield return PlayerValue.Second;
            }
        }
        public void Start()
        {
            foreach (var player in Enum.GetValues<PlayerValue>())
            {
                var dict = new Dictionary<WarshipType, List<WarShip>>();

                foreach (var shipType in Enum.GetValues<WarshipType>())
                {
                    dict[shipType] = Enumerable
                        .Range(0, 5 - (int)shipType)
                        .Select(x => new WarShip(shipType))
                        .ToList();
                }

                _playersShips[player] = dict;
            }
            _turns.MoveNext();
        }
    }
}
