




Book book1 = new Book();
Book book2 = new Book();
Book book3 = new Book();
Book book4 = new Book();
Magazine mag1 = new Magazine();
Magazine mag2 = new Magazine();
Magazine mag3 = new Magazine();
Magazine mag4 = new Magazine();
DVD dvd1 = new DVD();
DVD dvd2 = new DVD();
DVD dvd3 = new DVD();
DVD dvd4 = new DVD();

book1.Author = "Марк Твен";
book2.Author = "Даниель Дефо";
book3.Author = "Гоголь";
book4.Author = "Федор Достоевский";
book1.Title = "Приключения Тома Сойера";
book2.Title = "Робинзон Крузо";
book3.Title = "Лошадинная фамилия";
book4.Title = "Подросток";
book1.PageCount = 350;
book2.PageCount = 500;
book3.PageCount = 88;
book4.PageCount = 150;
mag1.Author = "MGZNauthor1";
mag2.Author = "MGZNauthor2";
mag3.Author = "MGZNauthor3";
mag4.Author = "MGZNauthor4";
mag1.Title = "Playboy";
mag2.Title = "Forbes";
mag3.Title = "Cosmopolitan";
mag4.Title = "Vogue";
mag1.IssueNumber = 1021;
mag2.IssueNumber = 1022;
mag3.IssueNumber = 1023;
mag4.IssueNumber = 1024;
dvd1.Author = "DVDauthor1";
dvd2.Author = "DVDauthor2";
dvd3.Author = "DVDauthor3";
dvd4.Author = "DVDauthor4";
dvd1.Title = "DVDtitle1";
dvd2.Title = "DVDtitle2";
dvd3.Title = "DVDtitle3";
dvd4.Title = "DVDtitle4";
dvd1.Duration = 60;
dvd2.Duration = 120;
dvd3.Duration = 75;
dvd4.Duration = 90.5;

Library library = new Library();
library.AddItem(book1);
library.AddItem(book2);
library.AddItem(book3);
library.AddItem(book4);
library.AddItem(mag1);
library.AddItem(mag2);
library.AddItem(mag3);
library.AddItem(mag4);
library.AddItem(dvd1);
library.AddItem(dvd2);
library.AddItem(dvd3);
library.AddItem(dvd4);

while (true)
{
    Console.WriteLine("Меню:");
    Console.WriteLine("1. Добавить книгу");
    Console.WriteLine("2. Добавить журнал");
    Console.WriteLine("3. Добавить DVD");
    Console.WriteLine("4. Показать все элементы");
    Console.WriteLine("5. Удалить элемент (по заголовку)");
    Console.WriteLine("6. Выход");

    Console.Write("Выберите опцию: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            {
                Console.Write("Введите название книги: ");
                string title = Console.ReadLine();
                Console.Write("Введите автора книги: ");
                string author = Console.ReadLine();
                Console.Write("Введите количество страниц: ");
                int pageCount = int.Parse(Console.ReadLine());

                Book book = new Book { Title = title, Author = author, PageCount = pageCount };
                library.AddItem(book);
            }
            break;
        case 2:
            {
                Console.Write("Введите название журнала: ");
                string title = Console.ReadLine();
                Console.Write("Введите автора журнала: ");
                string author = Console.ReadLine();
                Console.Write("Введите номер выпуска: ");
                int issueNumber = int.Parse(Console.ReadLine());

                Magazine magazine = new Magazine { Title = title, Author = author, IssueNumber = issueNumber };
                library.AddItem(magazine);
            }
            break;
        case 3:
            {
                Console.Write("Введите название DVD: ");
                string title = Console.ReadLine();
                Console.Write("Введите режиссера DVD: ");
                string author = Console.ReadLine();
                Console.Write("Введите продолжительность (в минутах): ");
                double duration = double.Parse(Console.ReadLine());

                DVD dvd = new DVD { Title = title, Author = author, Duration = duration };
                library.AddItem(dvd);
            }
            break;
        case 4:
            {
                library.DisplayItems();
            }
            break;
        case 5:
            {
                Console.Write("Введите название элемента для удаления: ");
                string title = Console.ReadLine();

                LibraryItem itemToRemove = library.Items.Find(item => item.Title == title);
                if (itemToRemove != null)
                {
                    library.RemoveItem(itemToRemove);
                }
                else
                {
                    Console.WriteLine("Элемент не найден.");
                }
            }
            break;
        case 6:
            {
                return; 
            }
        default:
            {
                Console.WriteLine("Неверный выбор. Попробуйте еще раз.");
            }
            break;
    }
}


abstract class LibraryItem //абстрактный класс LibraryItem - общие свойства и методы для всех типов материалов.
{
    public string Title
    { get; set; }
    public string Author
    { get; set; }
    public virtual string GetInfo()
    {
        return $"Title: {Title}, Author: {Author}";
    }
}

class Book : LibraryItem
{
    public int PageCount { get; set; } 
    public override string GetInfo()
    {
        return $"Book Title: {Title}\n Author: {Author}\n Pages: {PageCount}\n";
    }
}
class Magazine : LibraryItem
{
    public int IssueNumber { get; set; }
    public override string GetInfo()
    {
        return $"Magazine Title: {Title}\n Author: {Author}\n Issue Number: {IssueNumber}\n";
    }
}
class DVD : LibraryItem
{
    public double Duration { get; set; }
    public string GetInfo()
    {
        return $"DVD Title: {Title}\n Author: {Author}\n Duration: {Duration} minutes\n";
    }
}

class Library
{
    public List<LibraryItem> Items { get; set; }

    public Library()
    {
        Items = new List<LibraryItem>();
    }

        public void AddItem(LibraryItem item)
    {
        Items.Add(item);
        Console.WriteLine($"Добавлено в библиотеку");
    }
    public void RemoveItem(LibraryItem item) 
    {
    Items.Remove(item);
        Console.WriteLine($"Удалено");
    }
    public void DisplayItems()
    {
        foreach (LibraryItem item in Items) 
        {
            Console.WriteLine(item.GetInfo());
        }
    }
}