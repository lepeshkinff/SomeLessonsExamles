using System;
using System.Collections.Generic;
using System.Text;

namespace morskoyboy
{
    public class WarShip
    {
        public delegate void WarShipEvent(WarShip warShip);

        public event WarShipEvent OnCrach;
        public int Deck { get; private set; }
        public WarshipType Type { get; }

        public WarShip(WarshipType type)
        {
            Deck = (int)type;
            Type = type;
        }

        public void Crash()
        {
            if(Deck <= 0)
            {
                return;
            }

            Deck -= 1;

            OnCrach?.Invoke(this);
        }
    }
}
