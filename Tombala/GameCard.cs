namespace Tombala
{
	/// <summary>
	/// <ENG>
	/// GameCard is the primal component that the game will be played on. Every game will 
	/// have up to 24 game cards. 
	/// 
	/// GameCard stores data about a list of three <c>Row</c>s, a number that will also be
	/// prompted on the first cell of it's second row, wheter or not the card is active and
	/// the player that owns the card.
	/// </ENG>
	/// 
	/// <TR>
	/// GameCard(OyunKartı) Tombala oyununun oynanacağı ana parça. Her oyun 24'e kadar 
	/// GameCard'a sahip olacak.
	/// 
	/// OyunKartı içerisinde 3 tane <c>Row</c>(Satır) olan bir listeye, Kartın ikinici 
	/// satırında birinci hücrede de yazılacak olan kart numarasına, kartın aktif olup 
	/// olmadığına ve son olarak da kartın oyuncusuna dair bilgiler bulunur.
	/// </TR>
	/// </summary>
	public class GameCard
	{
		public List<Row> Rows { get; }
		public int CardNum { get; }
		public bool Active { get; set; }
		public Player? Player { get; set; }

		/// <summary>
		/// <ENG>
		/// Creates a new instance of a GameCard with the given card number (it should 
		/// be 1 based since it will be also used in the display). Sets the activity to false
		/// and Player to be null.
		/// 
		/// It also creates a list of three <c>Row</c>s and fills the list.
		/// </ENG>
		/// 
		/// <TR>
		/// Verilen numara ile yeni bir GameCard(OyunKartı) yaratır. Kart numarası birden
		/// başlamalıdır çünkü kartı yazdırırken de kullanılacak. Kartın aktifliğini false
		/// ve Player(Oyuncu)'sunu da null olarak ayarlar.
		/// 
		/// Ayrıca içerisinde üç tane <c>Row</c>(Satır) olan bir lsite yaratır ve içini 
		/// doldurur.
		/// </TR>
		/// </summary>
		/// <param name="cardNum"></param>
		public GameCard(int cardNum)
		{
			Rows = new List<Row>(3);
			CardNum = cardNum;
			Active = false;
			Player = null;

			for (int i = 0; i < Rows.Capacity; i++)
			{
				Rows.Add(new Row(i));
			}
		}

		/// <summary>
		/// <ENG>
		/// Checks all the rows in the Rows list. If all of the rows are set to chinko then
		/// it returns true otherwise returns false.
		/// </ENG>
		/// 
		/// <TR>
		/// Rows(Satırlar) içerisindeki tüm satırları kontrol eder ve eğer hepsi çinko ise 
		/// true, değilse false döner.
		/// </TR>
		/// </summary>
		/// <returns>Whether or not all the rows are set to chinko.</returns>
		public bool CheckTombala()
		{
			foreach (Row row in Rows)
			{
				if (!row.Chinko) return false;
			}

			return true;
		}
	}
}
