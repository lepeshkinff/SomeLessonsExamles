namespace ChessLibrary
{
	public abstract class ChessShape
	{
		private int _ShapeType;
		public bool Color { get; set; }
		public int ShapeType
		{
			get
			{
				return _ShapeType;
			}
			set
			{
				if (value < 0) return;
				if (value > 100) return;
				_ShapeType = value;
			}
		}


		public abstract int[] GetMoves(int x);

	}

	public class ChessShapePawn : ChessShape
	{
		public override int[] GetMoves(int x)
		{
			if (ShapeType < 2)
			{
				return new[] { 1 * x, 2 * x };
			}

			if (ShapeType >= 2 && ShapeType < 10)
			{
				return new[] { 1 * x, 2 * x, 3 * x, 4 * x, 5 * x };
			}

			return new[] { 15 * x };
		}
	}

	public class ChessShapeHorse : ChessShape
	{
		public override int[] GetMoves(int x)
		{
			return new[] { 1 * x, 2 * x };
		}
	}

}