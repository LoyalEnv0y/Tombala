namespace Tombala
{
	/// <summary>
	/// <ENG>
	/// Tombala is the main class of this program. Everything will work with this class.
	/// It holds information of Cards, Player used cards, Players, Pieces, Drawn pieces
	/// and whether the game is active or not.
	/// </ENG>
	/// 
	/// <TR>
	/// Tombala bu programın main sınıfıdır. Her şey bu sınıf ile çalışmakta.
	/// Kartlar, Oyuncu kartları, Oyuncular, Taşlar, Çekilmiş taşlar ve oyunun
	/// başlayıp başlamamış olmasına dair bilgileri tutar.
	/// </TR>
	/// </summary>
	public class Tombala
	{
		public List<GameCard> Cards { get; }
		public List<GameCard> ActiveCards { get; }
		public List<Piece> Pieces { get; }
		public List<Piece> DrawnPieces { get; }
		public List<Player> Players { get; }
		private bool isGameActive;
		private readonly Random random;

		/// <summary>
		/// <ENG>
		/// Initializes ne new instance of the Tombala game. It also declares the lists
		/// of components then calls the appropriate methods to fill those lists.
		/// </ENG>
		/// 
		/// <TR>
		/// Yeni bir Tombala nesnesi yaratır. Oyun için gerekli olan listeleri inşa edip
		/// bunları doldurmak için uygun methodları çağırır.
		/// </TR>
		/// </summary>
		public Tombala()
		{
			Cards = new List<GameCard>(24);
			ActiveCards = new List<GameCard>(24);
			Pieces = new List<Piece>(99);
			DrawnPieces = new List<Piece>(99);
			Players = new List<Player>(24);
			isGameActive = false;
			random = new Random();

			InitComponents();
			GameConstructer.FillCards(Cards);
		}

		/// <summary>
		/// <ENG>Fills the game cards with the numbers from one to the length of the list.</ENG>
		/// <TR>Oyun kartlarını birden listenin uzunluğuna kadar olan sayılarla doldurur.</TR>
		/// </summary>
		private void InitComponents()
		{
			for (int i = 1; i <= Cards.Capacity; i++)
			{
				Cards.Add(new GameCard(i));
			}

			for (int i = 1; i <= Pieces.Capacity; i++)
			{
				Pieces.Add(new Piece(i));
			}
		}

		/// <summary>
		/// <ENG>
		/// Greets the players, Gets the number of players to play the game and keeps asking
		/// user the player's names until all the players have names. It then asks the user 
		/// number of cards to play with, shuffles and activates the cards. Finally calls
		/// the setup method.
		/// </ENG>
		/// 
		/// <TR>
		/// Oyuncuları selamlar. Oyunu oynayacak olan oyuncu sayısını alır ve tüm oyuncuların
		/// isimlerini alana kadar kullanıcıya isimleri sorar. Sonrasında kullanıcıya kaç kart
		/// ile oynanacağını sorar ve kartları karıp aktive eder. Son olarak da setup methodunu
		/// çağırır.
		/// </TR>
		/// </summary>
		public void Start()
		{
			GameUI.PrintWelcome();

			int numberOfPlayers = GameUI.GetNumberOfPlayers();
			for (int i = 1; i <= numberOfPlayers; i++)
			{
				string name = GameUI.GetName(i);

				try
				{
					Players.Add(new Player(name));
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					i--;
				}
			}

			int numberOfCards = GameUI.GetNumberOfCards(numberOfPlayers);
			ShuffleList<GameCard>(Cards);

			for (int i = 0; i < numberOfCards; i++)
			{
				Cards[i].Active = true;
				ActiveCards.Add(Cards[i]);
			}

			Setup();
		}

		/// <summary>
		/// <ENG>
		/// Shuffles the actived cards. Draws an equal number of cards to each
		/// player from the active cards. Finally calls <c>ProcessPreGameChoice</c>
		/// to get player choices.
		/// </ENG>
		/// 
		/// <TR>
		/// Aktif kartları karar ve bu kartlardan her oyuncuya eşit sayıda dağıtır.
		/// Son olarak oyuncunun seçimlerini almak için <c>ProcessPreGameChoice</c>
		/// (OyunÖncesiSeçenekleri)'ni çağırır.
		/// </TR>
		/// </summary>
		private void Setup()
		{
			Console.WriteLine();
			Console.WriteLine("Shuffing Cards..");
			ShuffleList<GameCard>(ActiveCards);

			Console.WriteLine("Drawing Cards For Each Player..");
			DrawCards();

			ProcessPreGameChoice();
		}

		/// <summary>
		/// <ENG>
		/// Gets the player choice with the help of <c>GetChoice</c> method from the GameIU
		/// class. Calls other usefull methods in the class according to the given choice.
		/// </ENG>
		/// 
		/// <TR>
		/// GameUI sınıfının <c>GetChoice</c> methodu yardımı ile oyuncudan seçenek alır
		/// ve bu seçeneğe bağlı olarak sınıfın içerisindeki diğer methodları çağırır.
		/// </TR>
		/// </summary>
		private void ProcessPreGameChoice()
		{
			while (true)
			{
				int choice = GameUI.GetChoice(isGameActive);
				Console.WriteLine();

				switch (choice)
				{
					case 1:
						Console.WriteLine("Player Cards..");
						PrintActiveCards();
						break;
					case 2:
						Console.WriteLine("All Game Cards..");
						PrintCards();
						break;
					case 3:
						Console.WriteLine("Players..");
						PrintPlayers();
						break;
					case 4:
						Console.Clear();
						Console.WriteLine("Starting the Game..");
						BeginGame();
						break;
					case 5:
						GameUI.PrintManual();
						break;
					case 6:
						Console.Clear();
						break;
					case 7:
						Console.WriteLine("Quiting the game");
						GameUI.PrintGoodBye();
						Environment.Exit(0);
						break;
				}
			}
		}

		/// <summary>
		/// <ENG>
		/// Starts the game and calls the <c>ProcessAfterGameChoice</c> method to
		/// start getting user choices after the game started
		/// </ENG>
		/// 
		/// <TR>
		/// Oyunu başlatır ve kullanıcının seçimlerini almak için 
		/// <c>ProcessAfterGameChoice</c> methodunu çağırır.
		/// </TR>
		/// </summary>
		private void BeginGame()
		{
			isGameActive = true;
			ProcessAfterGameChoice();
		}

		/// <summary>
		/// <ENG>
		/// Gets the player choice with the help of <c>GetChoice</c> method from the GameIU
		/// class. Calls other usefull methods in the class according to the given choice.
		/// </ENG>
		/// 
		/// <TR>
		/// GameUI sınıfının <c>GetChoice</c> methodu yardımı ile oyuncudan seçenek alır
		/// ve bu seçeneğe bağlı olarak sınıfın içerisindeki diğer methodları çağırır.
		/// </TR>
		/// </summary>
		private void ProcessAfterGameChoice()
		{
			while (true)
			{
				int choice = GameUI.GetChoice(isGameActive);
				Console.WriteLine();
				switch (choice)
				{
					case 1:
						Console.WriteLine("Drawing a Piece..");
						DrawAPiece();
						break;
					case 2:
						Console.WriteLine("Player Cards..");
						PrintActiveCards();
						break;
					case 3:
						Console.WriteLine("ScoreBoard..");
						PrintScoreBoard();
						break;
					case 4:
						Console.Clear();
						break;
					case 5:
						Console.WriteLine("Quiting the game");
						GameUI.PrintGoodBye();
						Environment.Exit(0);
						break;
				}
			}
		}

		/// <summary>
		/// <ENG>
		/// Shuffles the given list by using the Knut's Shuffling algorithm.
		/// You can watch this video to understand how it is done. -> 
		/// https://www.youtube.com/watch?v=i8kD33wx9Mo
		/// </ENG>
		/// 
		/// <TR>
		/// Bir liste alır ve bunları Knut'un karma algoritmasını kullanarak karar.
		/// Algoritmayı anlamak için bu videoya bakabilirsiniz. -> 
		/// https://www.youtube.com/watch?v=i8kD33wx9Mo
		/// </TR>
		/// </summary>
		/// <typeparam name="T">Type of values inside the list</typeparam>
		/// <param name="list"></param>
		private void ShuffleList<T>(List<T> list)
		{
			for (int i = list.Count - 1; i > 0; i--)
			{
				int randomIndex = random.Next(0, i);
				// Instead of using a temp variable to switch the values, use tuple swap.

				// Değerleri değiştirmek için geçiçi bir değişken
				// kullanmak yerine tuple swap syntax'ını kullan.
				(list[randomIndex], list[i]) = (list[i], list[randomIndex]);
			}
		}

		/// <summary>
		/// <ENG>
		/// Find how many cards will the each player have and distrubutes the 
		/// cards to them.
		/// </ENG>
		/// 
		/// <TR>
		/// Her oyuncuya kaç kart verilmesi gerektiğini bulur ve kartları dağıtır.
		/// </TR>
		/// </summary>
		private void DrawCards()
		{
			int cardsForEach = ActiveCards.Count / Players.Count;
			int cardIndex = 0;

			for (int i = 0; i < Players.Count; i++)
			{
				for (int j = cardIndex; j < cardsForEach + cardIndex; j++)
				{
					ActiveCards[j].Player = Players[i];
				}
				cardIndex += cardsForEach;
			}
		}

		/// <summary>
		/// <ENG>Prints all the cards using <c>ProcessCardsOutput</c> from GameUI class</ENG>
		/// 
		/// <TR>
		/// Tüm kartları GameUI sınıfından <c>ProcessCardsOutput</c> methodunu kullanarak yazdırır.
		/// </TR>
		/// </summary>
		public void PrintCards()
		{
			Console.WriteLine(GameUI.ProcessCardsOutput(Cards));
		}

		/// <summary>
		/// <ENG>Prints all the active cards using <c>ProcessCardsOutput</c> from GameUI class</ENG>
		/// 
		/// <TR>
		/// Tüm aktif kartları GameUI sınıfından <c>ProcessCardsOutput</c> methodunu kullanarak yazdırır.
		/// </TR>
		/// </summary>
		public void PrintActiveCards()
		{
			Console.WriteLine(GameUI.ProcessCardsOutput(ActiveCards));
		}

		/// <summary>
		/// <ENG>Prints the scoreboard useing <c>ProcessScoreBoardOutput</c> from GameUI class</ENG>
		/// 
		/// <TR>
		/// Scoreboard'u GameUI sınıfından <c>ProcessScoreBoardOutput</c> methodunu kullanarak yazdırır.
		/// </TR>
		/// </summary>
		public void PrintScoreBoard()
		{
			Console.WriteLine(GameUI.ProcessScoreBoardOutput(Players));
		}

		/// <summary>
		/// <ENG>Prints every player in the Players list</ENG>
		/// <TR>Players listesindeki tüm oyuncuları yazdırır.</TR>
		/// </summary>
		private void PrintPlayers()
		{
			foreach (Player player in Players)
			{
				Console.WriteLine(player);
			}
			Console.WriteLine();
		}

		/// <summary>
		/// <ENG>
		///	Since the pieces list was already shuffled before just drawing the 
		///	first item in the pieces list is fine. Removes the item from the 
		///	Pieces list and adds it to the drawnPieces list. Prints the drawn 
		///	piece and searches it inside the cards. Afterwards sorts the players
		///	by score and finalizes the game if the game is set to not active.
		/// </ENG>
		/// 
		/// <TR>
		/// Taşlar zaten karıldığı için bir kere daha karmadan Pieces(Taşlar)
		/// listesinin birinci elemanını çeker. Çektiği elemanı Taşlar listesinden
		/// çıkartıp DrawnPieces(ÇekilmişTaşlar) listesine ekler. Çektiği taşı 
		/// yazdırır. Daha sonra oyuncuları puanlarına göre sıralar ve son olarak
		/// eğer oyun aktif olarak işaretlenmemiş ise oyunu bitirir.
		/// </TR>
		/// </summary>
		private void DrawAPiece()
		{
			ShuffleList<Piece>(Pieces);
			Piece drawnPiece = Pieces[0];

			DrawnPieces.Add(drawnPiece);
			Pieces.Remove(drawnPiece);

			Console.WriteLine(drawnPiece.Value + " Has Been Drawn.");

			SearchValueAndHit(drawnPiece.Value);

			SortPlayersByScore();

			if (!isGameActive)
			{
				FinalizeTheGame();
			}
		}

		/// <summary>
		/// <ENG>
		/// Searches every active card in the game one by one to find the cells that have
		/// the same value as the given value. If it finds one It sets the cell to be hit
		/// and adds +5 points to the player. If there happens to be a chinko after the hit
		/// it will give +20 points to the player. If the someone hits Tombala, gives them
		/// +50 points and it sets the game to non-active and returns early.
		/// </ENG>
		/// 
		/// <TR>
		/// verilen değer ile aynı değere sahip olan hücreleri bulmak için oyundaki tüm
		/// aktif kartları tek tek arar. Eğer bulursa o hücreyi vurur ve satırın çinko
		/// olup olmadığını kontrol eder, buna göre puan verir. Eğer biri Tombala yaptıysa
		/// o kişiye +50 puan verip oyunu aktif değil diye işeretler ve erkenden geri döner.
		/// </TR>
		/// </summary>
		/// <param name="value">Value to be searched inside cards.</param>
		private void SearchValueAndHit(int value)
		{
			foreach (GameCard card in ActiveCards)
			{
				foreach (Row row in card.Rows)
				{
					foreach (Cell cell in row.Cells)
					{
						if (cell.CellType == CellTypes.CardNumber)
						{
							continue;
						}

						if (!cell.IsHit && cell.Value == value)
						{
							Player player = card.Player;

							player.AddScore(5);
							cell.Hit();

							if (row.Chinko)
							{
								player.AddScore(20);
							}

							if (card.CheckTombala())
							{
								player.AddScore(50);
								isGameActive = false;
								return;
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// <ENG>
		/// Since the maximum number of players wont be more then 24, There is no need to
		/// use Quick or Merge Sort. That is why i used Shell Sort to sort the players.
		/// </ENG>
		/// 
		/// <TR>
		/// Maximum oyuncu sayısı 24'ün üzerine çıkmayacağı için Quick ya da Merge sort
		/// kullanmaya gerek yok. Bu nedenle Shell Sort kullanmayı tercih ettim.
		/// </TR>
		/// </summary>
		private void SortPlayersByScore()
		{
			int interval = Players.Count / 2;

			while (interval > 0)
			{
				for (int i = interval; i < Players.Count; i++)
				{
					for (int j = i; j >= interval && Players[j].Score > Players[j - interval].Score; j -= interval)
					{
						(Players[j], Players[j - interval]) = (Players[j - interval], Players[j]);
					}
				}
				interval /= 2;
			}
		}

		/// <summary>
		/// <ENG>
		/// Finishes the game by first printing active cards, then printing scoreboard
		/// and finally printing the goodbye message.
		/// </ENG>
		/// 
		/// <TR>
		/// Oyunu ilk önce aktif kartları yazdırdıktan, daha sonra scoreboardu yazdırdıktan
		/// sonra güle güle mesajını yazarak bitirir.
		/// </TR>
		/// </summary>
		public void FinalizeTheGame()
		{
			Console.WriteLine("Player Cards..");
			PrintActiveCards();
			Console.WriteLine();

			Console.WriteLine("ScoreBoard..");
			PrintScoreBoard();
			Console.WriteLine();

			Console.WriteLine("Quiting the game");
			GameUI.PrintGoodBye();
			Environment.Exit(0);
		}
	}
}
