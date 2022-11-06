namespace Tombala
{
	/// <summary>
	/// <ENG>
	/// Row is the Middle piece of a Tombala card. Each card has exactly three Rows.
	/// 
	/// A row stores data of it's <c>Cell</c>s, number and whether or not it is a chinko.
	/// A row can be marked as chinko when all the cells with values in it are hit.
	/// </ENG>
	/// 
	/// <TR>
	/// Row(Satır) Tombala kartının orta parçasıdır. Her bir kart üç satıra sahiptir.
	/// 
	/// Her satır içerisinde <c>Cell</c>(Hücre)'lerini tutan bir listeye, Satır numarasına, 
	/// ve çinko olup olmadığına dair bilgileri tutar. Bir satırın çinko olabilmesi için
	/// içerisindeki numaraya sahip olan tüm hücrelerin vurulmuş olması gerekir.
	/// </TR>
	/// </summary>
	public class Row
	{
		public List<Cell> Cells { get; }
		public int RowNum { get; }
		private bool chinko;

		/// <summary>
		/// <ENG>
		/// Creates a new instance of Row with the given number as their number.
		/// Initializes the list that stores <c>Cell</c>s and fill's the list
		/// with blank cells.
		/// </ENG>
		/// 
		/// <TR>
		/// Verilen numara ile yeni bir Row(Satır) yaratır. İçerisinde bulunacak olan
		/// <c>Cell</c>(Hücre)'leri tutmak için bir liste yaratır ve tüm listeyi boş
		/// hücreler ile doldurur.
		/// </TR>
		/// </summary>
		/// <param name="rowNum">Number of row (should be stored as 0 based)</param>
		public Row(int rowNum)
		{
			Cells = new List<Cell>(9);
			RowNum = rowNum;

			for (int i = 0; i < 9; i++)
			{
				Cells.Add(new Cell(0, CellTypes.Blank));
			}
		}

		/// <summary>
		/// <ENG>
		/// Everytime the Chinko property is referenced, the getter of the property updates
		/// it's value. If it is already set to true then there is no need to check if all 
		/// the cells are hit since a cell cannot be unhit once it is hit. 
		/// 
		/// If it is set to false then it checks if all the cells that has values are hit.
		/// If they are then chinko property gets set to true.
		/// chinko. 
		/// </ENG>
		/// 
		/// <TR>
		/// Çinko niteliği her bahsedildiğinde niteliğin getter'ı değeri günceller. Eğer değer
		/// true olarak girildiyse bir şey değiştirmeden true döner çünkü bir kere vurulan bir
		/// hücrenin vurulmadı olarak işaretlenmesi imkansızdır.
		/// 
		/// Eğer değer false ise değeri olan tüm hücreleri tek tek kontol eder. Eğer hepsi
		/// vurulduysa Satırı çinko olarak işaretler.
		/// </TR>
		/// </summary>
		public bool Chinko
		{
			get
			{
				if (chinko) return true;

				List<Cell> fullCells = Cells.Where(cell => cell.CellType == CellTypes.Number).ToList();

				foreach (Cell cell in fullCells)
				{
					if (!cell.IsHit)
					{
						return false;
					}
				}

				chinko = true;
				return true;
			}
		}
	}
}