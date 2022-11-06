namespace Tombala
{
	/// <summary>
	/// <ENG>
	/// Piece is the class that holds the values to be hit in the cells.
	/// The class keeps track of pieces values and whether or not they are hit.
	/// </ENG>
	/// 
	/// <TR>
	/// Piece(Taş), hücrelerde vurulacak değerleri tutan sınıftır. Sınıf, 
	/// taşların değerlerini ve vurulup vurulmadıklarını tutar.
	/// </TR>
	/// </summary>
	public class Piece
	{
		public int Value { get; }
		public bool IsDrawn { get; set; }

		/// <summary>
		/// <ENG>
		/// Initializes a new instance of the Piece with the given value.
		/// Sets the IsDrawn property to false
		/// </ENG>
		/// 
		/// <TR>
		/// Verilen değer ile yeni bir Piece(Taş) nesnesi oluşturur.
		/// IsDrawn(ÇekildiMi) niteliğini false olarak atar.
		/// </TR>
		/// </summary>
		/// <param name="value">value of the piece</param>
		public Piece(int value)
		{
			Value = value;
			IsDrawn = false;
		}

		/// <summary>
		/// <ENG>Set the piece to be drawn. If it is already drawn, throws an exception</ENG>
		/// 
		/// <TR>
		/// Piece(Taş)'ı çekildi olarak ayarlar. Eğer zaten çekilmiş bir taş
		/// çekilmeye kalkılırsa Bir hata fırlatır.
		/// </TR>
		/// </summary>
		/// <exception cref="PieceAlreadyFoundException">
		/// Throws when user tries to draw a piece that is already drawn
		/// </exception>
		public void Draw()
		{
			if (IsDrawn)
			{
				throw new PieceAlreadyFoundException(
					"This piece has already been drawn and cannot be drown again"
				);
			}
			IsDrawn = true;
		}
	}
}
