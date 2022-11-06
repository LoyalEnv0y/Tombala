using System.Text;

namespace Tombala
{
	public static class GameUI
	{
		/// <summary>
		/// <ENG>Prints welcome to tombala to console using ASCII art.</ENG>
		/// <TR>Konsola ASCII sanatını kullanarak hoşgeldin yazdırır.</TR>
		/// </summary>
		public static void PrintWelcome()
		{
			Console.WriteLine("**********************************************************************************************************************");

			Console.WriteLine(" _    _  _____  _      _____  _____ ___  ___ _____   _____  _____   _____  _____ ___  _________   ___   _       ___  \r\n" +
				"| |  | ||  ___|| |    /  __ \\|  _  ||  \\/  ||  ___| |_   _||  _  | |_   _||  _  ||  \\/  || ___ \\ / _ \\ | |     / _ \\ \r\n" +
				"| |  | || |__  | |    | /  \\/| | | || .  . || |__     | |  | | | |   | |  | | | || .  . || |_/ // /_\\ \\| |    / /_\\ \\\r\n" +
				"| |/\\| ||  __| | |    | |    | | | || |\\/| ||  __|    | |  | | | |   | |  | | | || |\\/| || ___ \\|  _  || |    |  _  |\r\n" +
				"\\  /\\  /| |___ | |____| \\__/\\\\ \\_/ /| |  | || |___    | |  \\ \\_/ /   | |  \\ \\_/ /| |  | || |_/ /| | | || |____| | | |\r\n" +
				" \\/  \\/ \\____/ \\_____/ \\____/ \\___/ \\_|  |_/\\____/    \\_/   \\___/    \\_/   \\___/ \\_|  |_/\\____/ \\_| |_/\\_____/\\_| |_/\r\n"
			);

			Console.WriteLine("To See the Manual Please Press 5 After the Setup.\n");

			Console.WriteLine("**********************************************************************************************************************");
			Console.WriteLine();
		}

		/// <summary>
		/// <ENG>Prints the manual.</ENG>
		/// <TR>Manüeli yazdırır.</TR>
		/// </summary>
		public static void PrintManual()
		{
			Console.WriteLine("Hello, This is a guide to how to play the game and understand the UI.\n");

			Console.WriteLine("\n\t\t\t========THE GAME========\n");

			Console.WriteLine("\nSETUP\n");
			Console.WriteLine("There are a total of 24 cards playable in Tombala. Each player can have more than\n" +
				"one card but every player needs to have the exact number of cards.\n"
			);

			Console.WriteLine("For example: If I want to play with 2 of my friends there are a total of 3 players\n" +
				"in the game. We can play a one card game where each player only has one card or a\n" +
				"multiple card game. If we want to play with 2 cards then there will be a total\n" +
				"of 6 cards [number of players * number of cards each player has] in the game.\n"
			);

			Console.WriteLine("\nDRAWING A PIECE\n");
			Console.WriteLine("After the game starts, A single piece with a number written on top of it gets drawn\n" +
				"From the bag and each player checks their cards to see if the number drawn\n" +
				"exists on their card. If it does then they hit the cell. Each cell has a unique\n" +
				"value in a card. However multiple cards can have the same cell with the same value\n" +
				"Since it is possible to play with multiple cards, It is possible to hit two cards\n" +
				"at the same time whether they belong to different players or the same player.\n"
			);

			Console.WriteLine("\nHITTING A CHINKO\n");
			Console.WriteLine("If a player hits all the cells in a row in one of their cards, they score a chinko.\n" +
				"There can only be 3 chinkos in a card but since players can play with multiple\n" +
				"cards, they can score more than 3 chinkos.\n"
			);

			Console.WriteLine("\nSCORING AND FINISHING THE GAME\n");
			Console.WriteLine("After hitting a cell, player earns +5 points. If they score a chinko they earn +20\n" +
				"points. If a player finishes the game, then they earn +50 points. If a player hits\n" +
				"all cells in anyone of thier cards they win the game.\n"
			);

			Console.WriteLine("\n\t\t\t========THE UI========\n");

			Console.WriteLine("\nCARDS\n");
			Console.WriteLine("Each card has a total of 3 rows and each row contains 9 cells. Out of these 9 cells\n" +
				"only 5 of them contain a number others are blank cells that cannot be hit and are\n" +
				"indicated with '00's.\n\n" +
				"Each card has a card number located in the first cell of their 2nd row. This cell\n" +
				"only indicates The id of the card and cannot be hit.\n\n" +
				"After a cell gets hit, it will be marked with 'XX's.\n"
			);
		}

		/// <summary>
		/// <ENG>Gets a name from the user and returns it.</ENG>
		/// <TR>Kullanıcdan bir isim alıp ismi geri döner.</TR>
		/// </summary>
		/// <param name="playerId">Player Number</param>
		/// <returns>The name given by user input</returns>
		public static string GetName(int playerId)
		{
			Console.WriteLine("Enter Player #" + playerId + "'s Name");
			Console.Write("> ");

			string? userName = Console.ReadLine();
			return userName;
		}

		/// <summary>
		/// <ENG>Gets the number of the users that will play the game.</ENG>
		/// <TR>Oyunu oynayacak oyuncu sayısını kullanıcıdan alır.</TR>
		/// </summary>
		/// <returns>The number of players given by user input</returns>
		public static int GetNumberOfPlayers()
		{
			while (true)
			{
				Console.WriteLine("How Many Players? [1-24]");
				Console.Write("> ");

				string? playerCountUnparsed = Console.ReadLine();

				bool success = int.TryParse(playerCountUnparsed, out int playerCount);

				if (!success)
				{
					Console.WriteLine("Please write a whole number");
				}
				else if (playerCount < 1 || playerCount > 24)
				{
					Console.WriteLine("Please Write a number between 1 and 24 (inclusive)");
				}
				else
				{
					return playerCount;
				}
			}
		}

		/// <summary>
		/// <ENG>Gets the card number that each player will be playing with from the user.</ENG>
		/// <TR>Her oyuncunun oynayacağı kart sayısını kullanıcdan alır.</TR>
		/// </summary>
		/// <param name="playerCount">The amouth of players in the game</param>
		/// <returns>The given TOTAL number of cards that will be played in the game</returns>
		public static int GetNumberOfCards(int playerCount)
		{
			int cardsForEach, totalCards;

			while (true)
			{
				Console.WriteLine("How many cards do you want each player to play with?\n" +
					"\t(Number of cards multiplied by number of players [" + playerCount + "] " +
					"must be higher than 0 and less than 25)");
				Console.Write("> ");

				try
				{
					cardsForEach = Convert.ToInt16(Console.ReadLine());
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message + " Please write a whole number.");
					continue;
				}

				totalCards = cardsForEach * playerCount;

				if (totalCards < 1 || totalCards > 24)
				{
					Console.WriteLine("Number of cards specified [" + playerCount + "] must be higher than 0 " +
						"and less then 25. Please write again.");
				}
				else
				{
					return totalCards;
				}
			}
		}

		/// <summary>
		/// <ENG>
		/// Prints a menu of choices to the console. Choices differ with the satate of the game.
		/// Gets the user choice and returns it.
		/// </ENG>
		/// 
		/// <TR>
		/// Konsola oyunun durumuna göre değişen seçenek menüsünü yazdırır ve kullanıcadan alınan
		/// seçeneği geri döner.
		/// </TR>
		/// </summary>
		/// <param name="gameActive">The state of the game</param>
		/// <returns>The choice given by the user</returns>
		public static int GetChoice(bool gameActive)
		{
			int choiceCount = (gameActive) ? 5 : 7;

			while (true)
			{
				Console.WriteLine();

				if (gameActive)
				{
					Console.WriteLine("Please enter:\n" +
						"1 -> Draw A Piece From The Pieces\n" +
						"2 -> See Player Cards\n" +
						"3 -> To See ScoreBoard\n" +
						"4 -> Clear The Console\n" +
						"5 -> Quit The Game"
					);
				}
				else
				{
					Console.WriteLine("Please enter:\n" +
						"1 -> To See Player Cards\n" +
						"2 -> To See All Cards\n" +
						"3 -> To See Players\n" +
						"4 -> Start The Game\n" +
						"5 -> See The Manual\n" +
						"6 -> Clear The Console\n" +
						"7 -> Quit The Game"
					);
				}

				Console.Write("> ");

				string? choiceUnparsed = Console.ReadLine();
				bool success = int.TryParse(choiceUnparsed, out int choice);

				if (!success)
				{
					Console.WriteLine("Please write a whole number.");
				}
				else if (choice < 1 || choice > choiceCount)
				{
					Console.WriteLine("Please write a number between [1, " + choiceCount + "] (inclusive)");
				}
				else
				{
					return choice;
				}
			}
		}

		/// <summary>
		/// <ENG>
		/// Creates a string of a visual representation of the given list of <c>GameCard</c>s
		/// to be displayed on terminal and returns it.
		/// </ENG>
		/// 
		/// <TR>
		/// Terminalde görüntülenmek üzere verilen GameCard listesinin görsel temsilinden oluşan 
		/// bir string oluşturur ve geri döner.
		/// </TR>
		/// </summary>
		/// <param name="cards">The list of cards to be visualized</param>
		/// <returns>the visual representation as string</returns>
		public static string ProcessCardsOutput(List<GameCard> cards)
		{
			StringBuilder sb = new();
			int[] borderCharMap = new int[] { 1, 44, 1 };

			foreach (GameCard card in cards)
			{
				// Add the name of the player that owns the card.
				// Kartın sahibinin ismini ekliyor.
				if (card.Active)
				{
					sb.AppendLine("[" + card.Player.Name + "]");
				}

				// Adds a border and values of each the row. If the row is a chinko, it will also add that.
				// Her bir sütun için sınır ve sütunun değerlerini ekler. Eğer sütun çinko ise bunu da ekler.
				foreach (Row row in card.Rows)
				{
					AddHorizontalBorders(sb, borderCharMap, true);
					AddCellValues(sb, row.Cells);

					if (row.Chinko)
					{
						sb.Append(" < Chinko!");
					}
					sb.AppendLine();
				}

				// Adds the bottom corner of the card
				// Kartın taban sınırını ekler.
				AddHorizontalBorders(sb, borderCharMap, true);
				sb.AppendLine();
			}

			return sb.ToString();
		}

		// 
		/// <summary>
		/// <ENG>
		/// Adds a horizontal border to the given StringBuilder object. It knows
		/// what to add with a given int array. The array maps the amounth of
		/// '+'s and '-'s. The character starts as '+' sign and switches with
		/// each value of the array.
		/// 
		/// For example; If the charCountMap is [1, 27, 1, 7, 1] then it will add
		/// the following chars. +---------------------------+-------+
		/// </ENG>
		/// 
		/// <TR>
		/// Verilen StringBuilder nesnesine yatay bir kenarlık ekler. Verilen bir
		/// int array'i ile hangi karakterden kaç tane eklemesi gerektiğini bilir.
		/// Array koyulacak '+'ları ve '-'leri tutmaktadır. '+' karakteri ile başlayıp
		/// arrayin herbir değerinde değişir.
		/// 
		/// Örneğin; Eğer charCountMap [1, 27, 1, 7, 1] ise, bu karakterleri ekler.
		/// +---------------------------+-------+
		/// </TR>
		/// </summary>
		/// <param name="sb">Borders will be added to this container</param>
		/// <param name="charCountMap">Map of the number of each character</param>
		/// <param name="adLine">Controls wheter to add a line at the end or not</param>
		private static void AddHorizontalBorders(StringBuilder sb, int[] charCountMap, bool adLine)
		{
			// Always start with a '+' sign
			// Her zaman '+' işareti ile başla
			bool isPlusSign = true;

			foreach (int i in charCountMap)
			{
				// Loops the value of each element in the array and adds the current sign.
				// Array içerisindeki herbir elementin değeri kadar döner ve mevcut işareti ekler.
				for (int j = 0; j < i; j++)
				{
					if (isPlusSign)
					{
						sb.Append('+');
						continue;
					}

					sb.Append('-');
				}
				// Switches the sign. If it is a '+' makes it '-' and vice versa.
				// İşaretin değiştirir. Eğer '+' ise '-' yapar. Tersine de çalışır.
				isPlusSign = !isPlusSign;
			}

			if (adLine)
			{
				sb.AppendLine();
			}
		}

		/// <summary>
		/// <ENG>
		/// AddCellValues is responsible for adding the cells in between the horizontal borders.
		/// It takes into account the cardnumber and hit cells. Values inside the cells are 
		/// always added in two digits so that 2 will be written as 02 in the output. This is
		/// done because I wanted to make a smooth output.
		/// </ENG>
		/// 
		/// <TR>
		/// AddCellValues yatay sınırlar arasındaki hücre değerlerini çıktıya eklemekle sorumlu.
		/// Kart numaralarını eklemek ve vurulmuş kartları 'XX' olarak gösterme işini de halleder.
		/// Hücre değerleri her zaman iki basamaklı olarak girilir yani 2 yerine 02 yazılır.
		/// Bunu yapmamın sebebi çıktının her zaman düzenli olarak yazdırılması.
		/// </TR>
		/// </summary>
		/// <param name="sb">Values will be added to this container</param>
		/// <param name="cells">Values will be taken from this list of cells</param>
		private static void AddCellValues(StringBuilder sb, List<Cell> cells)
		{
			foreach (Cell cell in cells)
			{
				if (cell.CellType == CellTypes.CardNumber)
				{
					sb.Append("|-" + cell.Value.ToString("D2") + "-");
					continue;
				}

				if (cell.IsHit)
				{
					sb.Append("| XX ");
					continue;
				}

				sb.Append("| " + cell.Value.ToString("D2") + " ");
			}

			sb.Append('|');
		}

		/// <summary>
		/// <ENG>
		/// Creates a string of a visual representation of the given list of<c>Player</c>s
		/// to be displayed on terminal and returns it.
		/// </ENG>
		/// 
		/// <TR>
		/// Terminalde görüntülenmek üzere verilen <c>Player</c>(Oyuncu) listesinin görsel
		/// temsilinden oluşan bir string oluşturur ve geri döner.
		/// </TR>
		/// </summary>
		/// <param name="players">Players will be added to the scoreboard from this list.</param>
		/// <returns>The visual representation as string</returns>
		public static string ProcessScoreBoardOutput(List<Player> players)
		{
			StringBuilder sb = new();
			int[] borderCharMap = new int[] { 1, 27, 1, 7, 1 };

			AddHorizontalBorders(sb, borderCharMap, true);

			sb.AppendLine("|        PLAYER NAME        | SCORE |");
			AddHorizontalBorders(sb, borderCharMap, true);

			foreach (Player player in players)
			{
				FillScoreBoard(sb, player, 27);
				AddHorizontalBorders(sb, borderCharMap, true);
			}

			return sb.ToString();
		}

		/// <summary>
		/// <ENG>Fills a row of the scoreboard with the given players information.</ENG>
		/// <TR>Verilen oyuncu bilgileri ile scoreboard'un bir satırını doldurur.</TR>
		/// </summary>
		/// <param name="sb">Player information will be added to this container</param>
		/// <param name="player">Player to be added </param>
		/// <param name="nameBorderLenght">
		/// Spaces will be added after each
		/// name according to the border lenght
		/// </param>
		private static void FillScoreBoard(StringBuilder sb, Player player, int nameBorderLenght)
		{
			int spaceCount = nameBorderLenght - player.Name.Length - 1;

			sb.Append("| ");
			sb.Append(player.Name);

			for (int i = 0; i < spaceCount; i++)
			{
				sb.Append(' ');
			}

			sb.Append('|');

			sb.AppendLine(" " + player.Score.ToString("D4") + "  |");
		}


		/// <summary>
		/// <ENG>Prints goodbye to the console with ASCII art.</ENG>
		/// <TR>Konsola ASCII sanatını kullanarak güle güle yazdırır.</TR>
		/// </summary>
		public static void PrintGoodBye()
		{
			Console.WriteLine("**********************************************************************************************************************");

			Console.WriteLine("                            _____                    _  _                  \r\n" +
				"                           |  __ \\                  | || |                 \r\n" +
				"                           | |  \\/  ___    ___    __| || |__   _   _   ___ \r\n" +
				"                           | | __  / _ \\  / _ \\  / _` || '_ \\ | | | | / _ \\\r\n" +
				"                           | |_\\ \\| (_) || (_) || (_| || |_) || |_| ||  __/\r\n" +
				"                            \\____/ \\___/  \\___/  \\__,_||_.__/  \\__, | \\___|\r\n" +
				"                                                                __/ |      \r\n" +
				"                                                               |___/       "
			);

			Console.WriteLine("**********************************************************************************************************************");
		}
	}
}
