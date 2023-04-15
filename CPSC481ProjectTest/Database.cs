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
        public bool isAvailable;
        public string location;
        public bool isPeerReviewed; // Will only display peer reviewed if true.

        public Item(string imagePath, ItemType type, string title, List<string> author, string yearOfPublication, bool isAvailable, string location, bool isPeerReviewed)
        {
            this.imagePath = imagePath;
            this.type = type;
            this.title = title;
            this.author = author;
            this.yearOfPublication = yearOfPublication;
            this.isAvailable = isAvailable;
            this.location = location;
            this.isPeerReviewed = isPeerReviewed;
        }
    }

    public static class Database
    {
        public static Item[] items = new Item[]
        {
            new Item("images\\Cryptography_Buchanan.jpg", ItemType.Book, "Cryptography" , new List<string>{ "Buchanan, William" }, "2017", true, "A100", false),
            new Item("images\\Cryptography_Rubinstein.jpg", ItemType.Book, "Cryptography", new List<string>{ "Rubinstein-Salzedo, Simon" }, "2018", true, "A101", false),
            new Item("images\\Cryptography_Stinson.jpg", ItemType.Book, "Cryptography : Theory and Practice", new List <string> { "Stinson, Douglas Robert" },"2018", true, "A102", false),
            new Item("images\\Post_quantum_cryptography.png", ItemType.Journal, "Journal of discrete mathematical sciences & cryptography", new List<string>{""}, "1998-", true, "A103", true),
            new Item("images\\Post_quantum_cryptography.png", ItemType.Article, "Post-quantum cryptography", new List <string>{ "Bernstein, D.J", "Lange, T" }, "2017", false, "A104", true),
            new Item("images\\HCI_Maurtua.jpg", ItemType.Book, "Human-Computer Interaction", new List<string>{ "Maurtua, Inaki" }, "2009", true, "B200", false),
            new Item("images\\HCI_Preece.jpg", ItemType.Book, "Human-computer Interaction", new List<string>{ "Preece, Jenny" }, "1994", true, "B201", false),
            new Item("images\\icon_book.png", ItemType.Book, "Human Computer Interaction", new List<string>{ "Pavlidis, Ioannis" }, "2008", false, "B201", false),
            new Item("images\\HCI_INTERACT.jpg", ItemType.Journal, "Human-computer interaction--INTERACT", new List<string>{ "IFIP Conference on Human-Computer Interaction." }, "1984-1987", true, "B202", false)
        };
    }
}
