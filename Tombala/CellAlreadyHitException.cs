namespace Tombala
{
	class CellAlreadyHitException : Exception
	{
		public CellAlreadyHitException()
		{
		}

		public CellAlreadyHitException(string message)
			: base(message)
		{
		}
	}
}
