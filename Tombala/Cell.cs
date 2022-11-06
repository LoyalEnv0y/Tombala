using Microsoft.VisualBasic;

namespace Tombala
{
	/// <summary>
	/// 
	/// <ENG>
	/// Cell is the smallest component of the Tombala game. Each row in the card will have
	/// nine cells. Out of the nine cells five of them are targets and four of them are just
	/// blank.
	/// 
	/// Every card also contains a cell that stores the card's number and it is located int the
	/// first cell of the second row.
	/// 
	/// Each cell contains data about thier value, state (hit or not hit) and type 
	/// (Number, Blank, CardNumber). A cell is hit when it is located in a player's card and
	/// the value that has drawn from the bag has the same value as that cell's.
	/// </ENG>
	/// 
	/// <TR>
	/// Tombala'nın en küçük yapı taşı Cell(Hücre)'dir. Her satırda dokuz adet hücre bulunur.
	/// Bu dokuz adet hücrelerden beş tanesi hedef olup geri kalan dört tanesi boştur.
	/// 
	/// Her kartın ikinci satır, birinci hücresinde kartın numarasını belli eden bir sayı
	/// hücresi bulunur.
	/// 
	/// Her hücre değerini, durumunu (vuruldu ya da vurulmadı) ve tipini tutan değişkenlere
	/// sahiptir. Bir hücrenin vurulabilmesi için oyuncu kartlarından birinde olması ve 
	/// torbadan çekilen sayının hücre ile aynı değere sahip olması gerekir.
	/// </TR>
	/// 
	/// </summary>
	public class Cell
	{
		public int Value { get; set; }
		public bool IsHit { get; set; }
		public CellTypes CellType { get; set; }

		/// <summary>
		/// 
		/// <ENG>
		/// Initializes a new instance of the Cell class with the given value and type.
		/// Sets the IsHit property to false.
		/// </ENG>
		/// 
		/// <TR>
		/// Verilen değer ve tiple yeni bir hücre nesnesi yaratır. 
		/// IsHit(vurulduMu) niteliğine false değerini verir.
		/// </TR>
		/// 
		/// </summary>
		/// <param name="value">Value of the Cell</param>
		/// <param name="type">Type of the cell (Number, Blank, CardNum)</param>
		public Cell(int value, CellTypes type)
		{
			Value = value;
			CellType = type;
			IsHit = false;
		}

		/// <summary>
		/// <ENG>
		/// Changes the isHit property to true.
		/// </ENG>
		/// 
		/// <TR>
		/// isHit(vurulduMu) niteliğine true değerini verir.
		/// </TR>
		/// </summary>
		/// 
		/// <exception cref="CellAlreadyHitException">
		/// If cell is already hit it can't be hit again.
		/// </exception>
		public void Hit()
		{
			if (IsHit)
			{
				throw new CellAlreadyHitException(
					"Cannot hit an already hit cell."
				);
			}

			IsHit = true;
		}
	}
}
