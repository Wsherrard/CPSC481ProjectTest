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
            new Item("images\\HCI_Maurtua.jpg", ItemType.Book, "Human-Computer Interaction", new List<string>{ "Maurtua, Inaki" }, "2009", "IntechOpen", "Human Computer Interaction, Artificial Intelligence", new HashSet<string>{"#hci", "#human", "#ai"}, true, "B200", false),
            new Item("images\\HCI_Preece.jpg", ItemType.Book, "Human-computer Interaction", new List<string>{ "Preece, Jenny" }, "1994", "Wokingham", "Human Computer Interaction", new HashSet<string>{"#hci", "#human"}, true, "B201", false),
            new Item("images\\icon_book.png", ItemType.Book, "Human Computer Interaction", new List<string>{ "Pavlidis, Ioannis" }, "2008", "IntechOpen", "Human Computer Interaction", new HashSet<string>{"#hci", "#human"}, false, "B201", false),
            new Item("images\\HCI_INTERACT.jpg", ItemType.Journal, "Human-computer interaction--INTERACT", new List<string>{ "IFIP Conference on Human-Computer Interaction." }, "1984-1987", "Amsterdam; North-Holland", "Human Computer Interaction", new HashSet<string>{"#hci", "#human"}, true, "B202", false),
            new Item("images\\GoogleGlass.png", ItemType.Book, "Google Glass: A Retrospective on Design", new List<string>{"Hill, Hank"}, "2023", "Propane Publishing", "Google Glass, Design Theory", new HashSet<string>{"#google glass", "#design", "#hope the prof finds this funny"}, false, "G00G13", false)
        };
    }
    
    public static class ItemSummaries
    {
        public static string[] summaries = new string[]
        {
            "Cryptography has proven to be one of the most contentious areas in modern society. For some, it protects the rights of individuals to privacy and security. For others, it puts up barriers against the protection of our society. This book aims to develop a deep understanding of cryptography and provide understanding of how privacy, identity provision, and integrity can be enhanced with the usage of encryption",
            "This text introduces cryptography, from its earliest roots to cryptosystems used today for secure online communication. Beginning with classical ciphers and their cryptanalysis, this book proceeds to focus on modern public key cryptosystems such as Diffie-Hellman, ElGamal, RSA, and elliptic curve cryptography with an analysis of vulnerabilities of these systems and underlying mathematical issues such as factorization algorithms. ",
            "Through three editions, Cryptography: Theory and Practice, has been embraced by instructors and students alike. It offers a comprehensive primer for the subject’s fundamentals while presenting the most current advances in cryptography.The authors offer comprehensive, in-depth treatment of the methods and protocols that are vital to safeguarding the seemingly infinite and increasing amount of information circulating around the world.",
            "The Journal of Discrete Mathematical Sciences & Cryptography (JDMSC) is published in one volume per year of eight issues in the months of February, March, April, June, August, September, October and December. This is a world leading journal dedicated to publishing high quality, rigorously peer reviewed, original papers in all areas of Discrete Mathematical Sciences, Cryptography and related topics since 1998. The journal publishes both theoretical and applied research. ",
            "This book constitutes the refereed proceedings of the 8th International Workshop on Post-Quantum Cryptography, PQCrypto 2017, held in Utrecht, The Netherlands, in June 2017. The 23 revised full papers presented were carefully reviewed and selected from 67 submissions. The papers are organized in topical sections on code-based cryptography, isogeny-based cryptography, lattice-based cryptography, multivariate cryptography, quantum algorithms, and security models.",
            " In this book the reader will find a collection of 31 papers presenting different facets of Human Computer Interaction, the result of research projects and experiments as well as new approaches to design user interfaces. The book is organized according to the following main topics in a sequential order: new interaction paradigms, multimodality, usability studies on several interaction mechanisms, human factors, universal design and development methodologies and tools.",
            "This book includes 23 chapters introducing basic research, advanced developments and applications. The book covers topics such us modeling and practical realization of robotic control for different applications, researching of the problems of stability and robustness, automation in algorithm and program developments with application in speech signal processing and linguistic research, system's applied control, computations, and control theory application in mechanics and electronics",
            "INTERACT '87 : proceedings of the Second IFIP Conference on Human-Computer Interaction, held at the University of Stuttgart, Federal Republic of Germany",
            " This book includes 23 chapters introducing basic research, advanced developments and applications. The book covers topics such us modeling and practical realization of robotic control for different applications, researching of the problems of stability and robustness, automation in algorithm and program developments with application in speech signal processing and linguistic research, system's applied control, computations, and control theory application in mechanics and electronics.",
            "A full-color guide to everything you need to know about Google Glass! With this easy-to-use guide, you can wear your Google Glass with confidence! From setup and configuration, to learning how to tap into the amazing features of Google Glass, this book has it all, I tell you hwhat."
        };
    }

    public static class HoldDatabase
    {
        public static List<Item> hold = new List<Item>
        {
           new Item("images\\Cryptography_Buchanan.jpg", ItemType.Book, "Cryptography" , new List<string>{ "Buchanan, William" }, "2017", "River Publishers", "Cryptography", new HashSet<string>{"#crypto", "#cryptography", "#cryptanalysis", "#cryptology"}, true, "A100", false)
        };
        
    }

    public static class SavedDatabase
    {
        public static List<Item> saved = new List<Item>
        {
           new Item("images\\HCI_INTERACT.jpg", ItemType.Journal, "Human-computer interaction--INTERACT", new List<string>{ "IFIP Conference on Human-Computer Interaction." }, "1984-1987", "Amsterdam; North-Holland", "Human Computer Interaction", new HashSet<string>{"#hci", "#human"}, true, "B202", false)
        };

    }

}
