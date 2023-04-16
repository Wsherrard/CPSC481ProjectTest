using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC481ProjectTest
{
    public enum ItemType
    {
        Book,
        Journal,
        Paper,
        Article
    }
    public struct Item
    {
        public string imagePath;
        public ItemType type;
        public string title;
        public List<string> author;
        public string yearOfPublication;
        public string publisher;
        public string subject;
        public HashSet<string> tags;
        public bool isAvailable;
        public string location;
        public bool isPeerReviewed; // Will only display peer reviewed if true.

        public Item(string imagePath, ItemType type, string title, List<string> author, string yearOfPublication, string publisher, string subject, HashSet<string> tags, bool isAvailable, string location, bool isPeerReviewed)
        {
            this.imagePath = imagePath;
            this.type = type;
            this.title = title;
            this.author = author;
            this.yearOfPublication = yearOfPublication;
            this.publisher = publisher;
            this.subject = subject;
            this.tags = tags;
            this.isAvailable = isAvailable;
            this.location = location;
            this.isPeerReviewed = isPeerReviewed;
        }
    }

    public static class Database
    {
        public static Item[] items = new Item[]
        {
            new Item("images\\Cryptography_Buchanan.jpg", ItemType.Book, "Cryptography" , new List<string>{ "Buchanan, William" }, "2017", "River Publishers", "Cryptography", new HashSet<string>{"#crypto", "#cryptography", "#cryptanalysis", "#cryptology"}, true, "A100", false),
            new Item("images\\Cryptography_Rubinstein.jpg", ItemType.Book, "Cryptography", new List<string>{ "Rubinstein-Salzedo, Simon" }, "2018", "Springer", "Cryptography, Number Theory", new HashSet<string>{"#crypto", "#cryptography",  "#numbertheory"}, true, "A101", false),
            new Item("images\\Cryptography_Stinson.jpg", ItemType.Book, "Cryptography : Theory and Practice", new List <string> { "Stinson, Douglas Robert" },"2018", "Boca Raton", "Cryptography, Coding Theory", new HashSet<string>{"#crypto", "#cryptography", "#coding"}, true, "A102", false),
            new Item("images\\Post_quantum_cryptography.png", ItemType.Journal, "Journal of discrete mathematical sciences & cryptography", new List<string>{""}, "1998", "Taru Publications", "Cryptography, Discrete Math", new HashSet<string>{"#crypto", "#cryptography", "#math"}, true, "A103", true),
            new Item("images\\Post_quantum_cryptography.png", ItemType.Article, "Post-quantum cryptography", new List <string>{ "Bernstein, D.J", "Lange, T" }, "2017", "Heidelberg", "Cryptography, Quantum Computing", new HashSet<string>{"#crypto", "#cryptography", "#quantum", "#computing"}, false, "A104", true),
            new Item("images\\HCI_Maurtua.jpg", ItemType.Book, "Human-Computer Interaction", new List<string>{ "Maurtua, Inaki" }, "2009", "IntechOpen", "Human Computer Interaction, Artificial Intelligence", new HashSet<string>{"#hci", "#human", "$ai"}, true, "B200", false),
            new Item("images\\HCI_Preece.jpg", ItemType.Book, "Human-computer Interaction", new List<string>{ "Preece, Jenny" }, "1994", "Wokingham", "Human Computer Interaction", new HashSet<string>{"#hci", "#human"}, true, "B201", false),
            new Item("images\\icon_book.png", ItemType.Book, "Human Computer Interaction", new List<string>{ "Pavlidis, Ioannis" }, "2008", "IntechOpen", "Human Computer Interaction", new HashSet<string>{"#hci", "#human"}, false, "B201", false),
            new Item("images\\HCI_INTERACT.jpg", ItemType.Journal, "Human-computer interaction--INTERACT", new List<string>{ "IFIP Conference on Human-Computer Interaction." }, "1984-1987", "Amsterdam; North-Holland", "Human Computer Interaction", new HashSet<string>{"#hci", "#human"}, true, "B202", false)
        };
    }

    public static class HoldDatabase
    {
        public static Item[] hold = new Item[]
        {
            new Item("databaseImages\\Cryptography_Buchanan.jpg", ItemType.Book, "Cryptography" , new List<string>{ "Buchanan, William" }, "2017", true, "A100", false),
        };
    }

    public static class SavedDatabase
    {
        public static Item[] Saved = new Item[]
        {
            new Item("databasesImages\\Post_quantum_cryptography.png", ItemType.Journal, "Journal of discrete mathematical sciences & cryptography", new List<string>{""}, "1998-", true, "A103", true),
        };
    }
}
