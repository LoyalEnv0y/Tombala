namespace Tombala
{
	class PieceAlreadyFoundException : Exception
	{
		public PieceAlreadyFoundException()
		{

		}

		public PieceAlreadyFoundException(string message)
			: base(message)
		{

		}
	}
}
