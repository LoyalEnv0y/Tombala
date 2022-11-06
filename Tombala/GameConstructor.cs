namespace Tombala
{
	/// <summary>
	/// <ENG>
	/// Holds valuable methods to Fill the game cards with unique, random values.
	/// </ENG>
	/// 
	/// <TR>
	/// Oyun kartlarını eşsiz ve rastgele değerlerle doldurmak için işe yarar methodlara
	/// ev sahipliği yapar.
	/// </TR>
	/// </summary>
	public static class GameConstructer
	{
		/// <summary>
		/// <ENG>
		/// FillCards just calls the <c>FillRows</c> method for everycard in the given
		/// list of cards.
		/// </ENG>
		/// 
		/// <TR>
		/// FillCards methodu kendisine verilen listedeki her bir kart için <c>FillRows</c>
		/// methodunu çağırır.
		/// </TR>
		/// </summary>
		/// <param name="cards">List of cards to be filled</param>
		public static void FillCards(List<GameCard> cards)
		{
			foreach (GameCard gameCard in cards)
			{
				FillRows(gameCard.Rows, gameCard.CardNum);
			}
		}
		/// <summary>
		/// <ENG>
		/// FillRows just calls the <c>FillCells</c> method for row in the given list of rows.
		/// </ENG>
		/// 
		/// <TR>
		/// FillRows methodu kendisine verilen listedeki her bir row için <c>FillCells</c>
		/// methodunu çağırır.
		/// </TR>
		/// </summary>
		/// <param name="rows">The rows to be filled</param>
		/// <param name="cardNumber">The card number that will be put on the card</param>
		private static void FillRows(List<Row> rows, int cardNumber)
		{
			/*
			 * I preconstructed the array that will be used in the FillCells method here.
			 * It holds numbers from 0 to 101. These numbers will be put inside cells.
			 * 
			 * Hücrelerin içerisine konulması için 0'den 101'e kadar olan sayıların olduğu
			 * bir array hazırladım. 
			 */
			int[] numbers = new int[101];
			FillArray(numbers);

			foreach (Row row in rows)
			{
				FillCells(row.Cells, numbers, row.RowNum, cardNumber);
			}
		}

		/// <summary>
		/// <ENG>
		/// FillCells fills the given list of cells with values from the given array.
		/// It also puts the card number in the first cell of the second row.
		/// since the values differ on different rows we also need the row number as well.
		/// </ENG>
		/// 
		/// <TR>
		/// FillCells kendisine verilen cell(hücre) dolu listeyi yine kendisine verilen
		/// array ile doldurur. Kartlardaki ikinci satırın birinci hücresine verilen kart
		/// numarasını koyar. Hücrelere verilen değerlerin satır numarasına göre değişmesinden
		/// dolayı satır numarasına da ihtiyacı var.
		/// </TR>
		/// </summary>
		/// <param name="cells">List of cells to be filled</param>
		/// <param name="numbers">Holds the numbers to fill the cells</param>
		/// <param name="rowNum">The number of row</param>
		/// <param name="cardNumber">The number of cart</param>
		private static void FillCells(List<Cell> cells, int[] numbers, int rowNum, int cardNumber)
		{
			/*
			 * Since the celltype will always be a number on the last cell in every row no matter what, 
			 * I set the celltype here instead of in the switch statement. Also the reason why I didn't
			 * set it in the second switch statement is because not every loop there will hit the last 
			 * cell of the row.
			 * 
			 * Her satırın son hücresi her zaman bir numara ile dolu olacağı için bunu altlarda yapmak
			 * yerine burada yapmayı daha mantıklı buldum.
			 */
			cells[8].CellType = CellTypes.Number;

			// This switch will iron out the edge cases of rows.
			// Bu switch'i ince durumların üstesinden gelmek için kullandım.
			switch (rowNum)
			{
				/*
				 * If the row number is 0 then the first cell will be filled with a random number
				 * between 1 and 9. And the last cell will be filled with a random number
				 * between 70 and 79.
				 * 
				 * Eğer satır numarası 0 ise ilk hücre 1 ile 9 arasında, son hücre 70 ile 79 arasında
				 * rastgele bir tamsayı ile doldurulacak.
				 */
				case 0:
					cells[0].CellType = CellTypes.Number;
					cells[0].Value = GetAUniqueValueInRange(numbers, 1, 9);
					cells[8].Value = GetAUniqueValueInRange(numbers, 70, 79);
					break;

				/*
				 * If the row number is 1 then the first cell will be card number.
				 * And the last cell will be filled with a random number between 80 and 89.
				 * 
				 * Eğer satır numarası 1 ise ilk hücre kart numarası olarak atanacak ve son
				 * hücre 80 ile 89 arasında rastgele bir tamsayı ile doldurulacak.
				 */
				case 1:
					cells[0].CellType = CellTypes.CardNumber;
					cells[0].Value = cardNumber;
					cells[8].Value = GetAUniqueValueInRange(numbers, 80, 89);
					break;
				/*
				 * If the row number is 2 then the first cell will be filled with a random number
				 * between 1 and 9. And the last cell will be filled with a random number
				 * between 90 and 99.
				 * 
				 * Eğer satır numarası 2 ise ilk hücre 1 ile 9 arasında, son hücre 90 ile 99 arasında
				 * rastgele bir tamsayı ile doldurulacak.
				 */
				case 2:
					cells[0].CellType = CellTypes.Number;
					cells[0].Value = GetAUniqueValueInRange(numbers, 1, 9);
					cells[8].Value = GetAUniqueValueInRange(numbers, 90, 99);
					break;
			}


			/*
			 * The random number will be in a different range every cell. For example at 
			 * the first cell of the first row the number will be between 1 and 9 but at
			 * the second cell of the second row the number will be between 10 and 19.
			 * 
			 * In order to keep track of what range the random number will be in, low and
			 * high variables will be used.
			 * 
			 * Seçilicek rastgele sayı farklı satırlara ve hücrelere göre farklı aralıklarda
			 * olacağı için aralıkları low(düşük) ve high(yüksek)'de tutmak gerekiyor.
			 * 
			 * Mesela ilk satırın ilk hücresinde rastgele seçilen değer 1 ile 9 arasında olması
			 * gerekirken ikinci satırın ilk hücresinde 10 ile 19 arasında olması gerekiyor.
			 * 
			 */
			int low, high;

			/* Since the arithmatics of the numbers inside cells change according to the row number
			 * I wrote this switch statement.
			 * 
			 * Bu switch'i sütunlardaki aritmatiğin farklı olması nedeni ile yazdım.
			 */
			switch (rowNum)
			{
				/*
				 * If the row number is 0 or 2, it will start filling the cells from the 3rd cell and
				 * and skip one everytime. The range of the random numbers will start with 20-29 and 
				 * will be incremented by 20 with every cell. It will stop after filling sixth cell.
				 * 
				 * Eğer satır numarası 0 veya 2 ise, üçüncü hücreden başlayıp her seferinde bir hücre
				 * atlayarak hücreleri doldurmaya başlayacak. Rastgele numaraların sınırları 20-29 ile
				 * başlayıp her seferinde 20 artacak. Altıncı hücreyi doldurduktan sonra duracak.
				 */
				case 0:
				case 2:
					low = 20;
					high = 29;

					for (int i = 2; i < cells.Count - 1; i += 2)
					{
						cells[i].CellType = CellTypes.Number;
						cells[i].Value = GetAUniqueValueInRange(numbers, low, high);

						low += 20;
						high += 20;
					}
					break;
				/*
				 * If the row number is 1, it will start filling the cells from the 1st cell and
				 * and skip one everytime. The range of the random numbers will start with 10-19 and 
				 * will be incremented by 20 with every cell. It will stop after filling last cell.
				 * 
				 * Eğer satır numarası 1 ise, birinci hücreden başlayıp her seferinde bir hücre
				 * atlayarak hücreleri doldurmaya başlayacak. Rastgele numaraların sınırları 10-19 ile
				 * başlayıp her seferinde 20 artacak. Son hücreyi doldurduktan sonra duracak.
				 */
				case 1:
					low = 10;
					high = 19;

					for (int i = 1; i < cells.Count; i += 2)
					{
						cells[i].CellType = CellTypes.Number;
						cells[i].Value = GetAUniqueValueInRange(numbers, low, high);

						low += 20;
						high += 20;
					}
					break;
			}
		}

		/// <summary>
		/// <ENG>
		/// This method will return a unique value between the given range.
		/// </ENG>
		/// 
		/// <TR>
		/// Bu method verilen sınırlarda daha önce çekilmemiş bir random sayı 
		/// bulup geri dönecek.
		/// </TR>
		/// </summary>
		/// <param name="arr">Stores drawn and undrawn values.</param>
		/// <param name="low">Low boundry of the range</param>
		/// <param name="high">High boundry of the range</param>
		/// <returns></returns>
		private static int GetAUniqueValueInRange(int[] arr, int low, int high)
		{
			Random random = new();
			int randomIndex = random.Next(low, high);

			// This loop will keep running until it finds a value other then 0 in array.
			// Bu döngü değeri 0 olmayan bir bir sayı bulana kadar dönücek.
			while (arr[randomIndex] == 0)
			{
				randomIndex = random.Next(low, high);
			}

			/* 
			 * When it finds a value other then 0 it will assign it to the toReturn
			 * variable. Also it will assign the number to be 0 so that it won't be 
			 * drawn again.
			 * 
			 * 0 dışında bir sayı bulunduğunda bunu toReturn(dönülecek) değişkenine
			 * atıyor ve bulduğu sayıyı 0'a atıyor. Böylece bir kere seçtiği sayıyı
			 * bir kere daha seçmiyor.
			 */
			int toReturn = arr[randomIndex];
			arr[randomIndex] = 0;

			return toReturn;
		}

		/// <summary>
		/// <ENG>
		/// Just fills given array with the numbers from 0 to 101 (inclusive).
		/// </ENG>
		/// 
		/// <TR>
		/// Verilen array'i 0 ile 101 arasındaki rakamlar (0 ve 101 dahil) ile doldurur.
		/// </TR>
		/// </summary>
		/// <param name="arr">Array to be filled</param>
		private static void FillArray(int[] arr)
		{
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = i;
			}
		}
	}
}
