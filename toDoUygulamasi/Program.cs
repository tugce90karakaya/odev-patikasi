
class Program
{
    static Dictionary<int, TeamMember> teamMembers = new Dictionary<int, TeamMember>()
    {
        {1, new TeamMember(1, "Ahmet")},
        {2, new TeamMember(2, "Ayşe")},
        {3, new TeamMember(3, "Mehmet")}
    };

    static Board board = new Board();

    static void Main()
    {
        // Varsayılan 3 kart
        board.Todo.Add(new Card("Temizlik", "Oda süpürülecek", teamMembers[1], Size.S));
        board.InProgress.Add(new Card("Rapor", "Sunum hazırlanıyor", teamMembers[2], Size.M));
        board.Done.Add(new Card("Toplantı", "Yapıldı", teamMembers[3], Size.XL));

        while (true)
        {
            Console.WriteLine("\nLütfen yapmak istediğiniz işlemi seçiniz :)");
            Console.WriteLine("*******************************************");
            Console.WriteLine("(1) Board Listelemek");
            Console.WriteLine("(2) Board'a Kart Eklemek");
            Console.WriteLine("(3) Board'dan Kart Silmek");
            Console.WriteLine("(4) Kart Taşımak");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    board.ListBoard();
                    break;
                case "2":
                    AddCard();
                    break;
                case "3":
                    DeleteCard();
                    break;
                case "4":
                    MoveCard();
                    break;

                default:
                    Console.WriteLine("Gecerli secim yap.");
                    break;
            }
        }
    }

    static void AddCard()
    {
        Console.Write("Başlık Giriniz: ");
        string title = Console.ReadLine();

        Console.Write("İçerik Giriniz: ");
        string content = Console.ReadLine();

        Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5): ");
        bool sizeParsed = int.TryParse(Console.ReadLine(), out int sizeChoice);
        if (!sizeParsed || sizeChoice < 1 || sizeChoice > 5)
        {
            Console.WriteLine("Hatalı büyüklük seçimi.");
            return;
        }

        Console.WriteLine("Kişi Seçiniz:");
        foreach (var member in teamMembers)
        {
            Console.WriteLine($"{member.Key}: {member.Value.Name}");
        }

        bool idParsed = int.TryParse(Console.ReadLine(), out int personId);
        if (!idParsed || !teamMembers.ContainsKey(personId))
        {
            Console.WriteLine("Hatalı girişler yaptınız!");
            return;
        }

        Card newCard = new Card(title, content, teamMembers[personId], (Size)sizeChoice);
        board.Todo.Add(newCard);
        Console.WriteLine("Kart başarıyla eklendi.");
    }

    static void DeleteCard()
{
    Console.WriteLine("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.");
    Console.Write("Lütfen kart başlığını yazınız: ");
    string title = Console.ReadLine();

    // Tüm listeleri bir araya getiriyoruz
    List<Card> allCards = board.Todo.Concat(board.InProgress).Concat(board.Done).ToList();
    var foundCards = allCards.Where(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase)).ToList();

    if (foundCards.Count == 0)
    {
        Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
        Console.WriteLine("* Silmeyi sonlandırmak için : (1)");
        Console.WriteLine("* Yeniden denemek için      : (2)");
        string choice = Console.ReadLine();
        if (choice == "2") DeleteCard();
        return;
    }

    foreach (var card in foundCards)
    {
        board.Todo.Remove(card);
        board.InProgress.Remove(card);
        board.Done.Remove(card);
    }

    Console.WriteLine("Kart(lar) başarıyla silindi.");
}
static void MoveCard()
{
    Console.WriteLine("Taşımak istediğiniz kartı seçmeniz gerekiyor.");
    Console.Write("Lütfen kart başlığını yazınız: ");
    string title = Console.ReadLine();

    // Kartı tüm kolonlarda ara
    Card card = board.Todo.FirstOrDefault(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
    string currentLine = "TODO";

    if (card == null)
    {
        card = board.InProgress.FirstOrDefault(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        currentLine = "IN PROGRESS";
    }

    if (card == null)
    {
        card = board.Done.FirstOrDefault(c => c.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        currentLine = "DONE";
    }

    if (card == null)
    {
        Console.WriteLine("Aradığınız kriterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.");
        Console.WriteLine("* İşlemi sonlandırmak için : (1)");
        Console.WriteLine("* Yeniden denemek için     : (2)");
        string choice = Console.ReadLine();
        if (choice == "2") MoveCard();
        return;
    }

    // Kart bulundu, bilgileri göster
    Console.WriteLine("\nBulunan Kart Bilgileri:");
    Console.WriteLine("**************************************");
    Console.WriteLine($"Başlık      : {card.Title}");
    Console.WriteLine($"İçerik      : {card.Content}");
    Console.WriteLine($"Atanan Kişi : {card.AssignedPerson.Name}");
    Console.WriteLine($"Büyüklük    : {card.Size}");
    Console.WriteLine($"Line        : {currentLine}");

    // Yeni line seçimi
    Console.WriteLine("\nLütfen taşımak istediğiniz Line'ı seçiniz:");
    Console.WriteLine("(1) TODO");
    Console.WriteLine("(2) IN PROGRESS");
    Console.WriteLine("(3) DONE");

    string lineChoice = Console.ReadLine();

    // Önce bulunduğu yerden sil
    board.Todo.Remove(card);
    board.InProgress.Remove(card);
    board.Done.Remove(card);

    switch (lineChoice)
    {
        case "1":
            board.Todo.Add(card);
            Console.WriteLine("Kart TODO Line'a taşındı.");
            break;
        case "2":
            board.InProgress.Add(card);
            Console.WriteLine("Kart IN PROGRESS Line'a taşındı.");
            break;
        case "3":
            board.Done.Add(card);
            Console.WriteLine("Kart DONE Line'a taşındı.");
            break;
        default:
            Console.WriteLine("Hatalı bir seçim yaptınız!");
            return;
    }

    // Son durumda board'u göster
    board.ListBoard();
}


}

public enum Size
{
    XS = 1,
    S,
    M,
    L,
    XL
}
public class TeamMember
{
    public int Id { get; set; }
    public string Name { get; set; }

    public TeamMember(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

public class Card
{
    public string Title { get; set; }
    public string Content { get; set; }
    public TeamMember AssignedPerson { get; set; }
    public Size Size { get; set; }

    public Card(string title, string content, TeamMember person, Size size)
    {
        Title = title;
        Content = content;
        AssignedPerson = person;
        Size = size;
    }
}

public class Board
{
    public List<Card> Todo = new List<Card>();
    public List<Card> InProgress = new List<Card>();
    public List<Card> Done = new List<Card>();

    public void ListBoard()
    {
        Console.WriteLine("\nTODO Line\n************************");
        PrintCards(Todo);
        
        Console.WriteLine("\nIN PROGRESS Line\n************************");
        PrintCards(InProgress);

        Console.WriteLine("\nDONE Line\n************************");
        PrintCards(Done);
    }

    private void PrintCards(List<Card> cards)
    {
        if (cards.Count == 0)
        {
            Console.WriteLine("~ BOŞ ~");
        }
        else
        {
            foreach (var card in cards)
            {
                Console.WriteLine($"Başlık      : {card.Title}");
                Console.WriteLine($"İçerik      : {card.Content}");
                Console.WriteLine($"Atanan Kişi : {card.AssignedPerson.Name}");
                Console.WriteLine($"Büyüklük    : {card.Size}");
                Console.WriteLine("-");
            }
        }
    }
}


