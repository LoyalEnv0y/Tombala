using System.Text.RegularExpressions;

namespace Tombala
{
	/// <summary>
	/// <ENG>
	/// Every player is represented by this class. It holds information of
	/// the playerId, name, score and their chinko count.
	/// </ENG>
	/// 
	/// <TR>
	/// Tüm oyuncular Player(Oyuncu) sınıfı ile temsil edilir. Id, isim,
	/// skor ve çinko sayısı gibi değerleri tutar.
	/// </TR>
	/// </summary>
	public class Player
	{
		private static int instance = 0;
		private readonly int playerId;
		private string name;
		public int Score { get; set; }
		public int ChinkoCount { get; private set; }

		/// <summary>
		/// <ENG>
		/// Creates a new instance of the Player class with the given name.
		/// It increments the instance count and sets the score and chinko
		/// count as 0. playerId is also set as the instance count.
		/// </ENG>
		/// 
		/// <TR>
		/// Verilen isim ile yeni bir Player(Oyuncu) nesnesi oluşturur.
		/// Yaratılan Oyuncu sayısını arttırır, scoru ve çinkoSayısı'nı 0
		/// olarak ayarlar. Id'yi ise yaratılan oyuncu sayısına eşitler.
		/// </TR>
		/// </summary>
		/// <param name="name">Name to be given to the player.</param>
		public Player(string name)
		{
			instance++;
			Name = name;
			Score = 0;
			ChinkoCount = 0;

			playerId = instance;
		}

		public int PlayerId
		{
			get { return playerId; }
		}

		/// <summary>
		/// <ENG>
		/// Setter will take the name, trim any white spaces and check if the 
		/// given name is empty. If it is empty then it sets the name to be 
		/// 'Player#'[playerId]. If the name is longer then 25 characters it 
		/// will throw an ArgumentException. If the name contains any characters
		/// other then letters and numbers (non ASCII letters are fine), it will
		/// throw another ArgumentException.
		/// </ENG>
		/// 
		/// <TR>
		/// Setter isimi alır ve herhangi gereksiz boşluklardan sildikten sonra
		/// isimin boş olup olmadığını kontrol eder. Eğer boş ise isimi 
		/// 'Player#'[playerId] olarak atar. Eğer isimin uzunluğu 25 karakteri 
		/// geçerse ArgumentException hatası verir. Eğer isimde harf ve numara 
		/// dışında (ASCII olmayan dile özel karakterler kullanılabilir.) bir
		/// karakter varsa yine ArgumetException hatası verir.
		/// </TR>
		/// </summary>
		public string Name
		{

			get { return name; }
			set
			{
				string formatted = value.Trim();

				// This regex will find any characters that are not numbers or letters.
				// Bu regex numara ve sayı olmayan bütün karakterleri bulur.
				Regex regex = new("[^A-Za-z0-9\\p{L}]+");
				if (formatted == "")
				{
					name = "Player#" + PlayerId;
					return;
				}

				if (formatted.Length >= 25)
				{
					throw new ArgumentException(
						"Player name must have less then 25 characters. " +
						"It has " + formatted.Length
					);
				}
				else if (regex.IsMatch(formatted))
				{
					throw new ArgumentException(
						"Player name must not have any " +
						"character other than numbers and letters");
				}

				name = formatted;
			}
		}

		/// <summary>
		/// <ENG>This method will add the given score to player and print a message.</ENG>
		/// <TR>Bu method kendisine verilen skoru oyuncuya verir ve bir mesaj yazdırır.</TR>
		/// </summary>
		/// <param name="score"></param>
		public void AddScore(int score)
		{
			switch (score)
			{
				case 5:
					Console.WriteLine(Name + " Has Hit A Cell! (+" + score + " Points)");
					break;

				case 20:
					ChinkoCount++;
					Console.WriteLine(Name + " Has hit A Chinko! (+" + score + " Points). They have " + ChinkoCount + " Chinko(s) So Far");
					break;

				case 50:
					Console.WriteLine(Name + " Has Won The Game! (+" + score + " Points)");
					break;
			}

			Score += score;
		}

		public override string ToString()
		{
			return "Player #" + playerId + "\t[" + Name + "]";
		}
	}
}
