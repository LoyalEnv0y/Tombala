namespace Tombala
{
	/// <summary>
	/// <ENG>
	/// There are 3 different cell types in the game.
	/// Number: Holds a value and can be hit.
	/// Blank: Doesn't hold a value and cannot be hit.
	/// CardNumber: Stores the number of the card and cannot be hit.
	/// </ENG>
	/// 
	/// <TR>
	/// Oyunda üç farklı hücre tipi var.
	/// Number: (Sayı) İçerisinde bir değer tutar ve vurulabilir.
	/// Blank: (Boş) İçerisinde bir sayı tutmaz ve vurulamaz.
	/// CardNumber: (KartSayısı) İçerisinde kart numarasının değerini tutar ve vurulamaz.
	/// </TR>
	/// </summary>
	public enum CellTypes
	{
		Number,
		Blank,
		CardNumber
	}
}
