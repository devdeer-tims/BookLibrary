namespace BookLibrary
{
    using Spectre.Console;

    /// <summary>
    /// Reprents a library of books.
    /// </summary>
    public class Library
    {
        #region member vars

        /// <summary>
        /// List to store the books.
        /// </summary>
        private readonly List<Book> _books = new();

        #endregion

        #region methods

        /// <summary>
        /// Adds a book to the library.
        /// </summary>
        /// <param name="author">The author of the book to add.</param>
        /// <param name="title">The title of the book to add.</param>
        /// <param name="isbn">The ISBN of the book to add.</param>
        /// <param name="price">The price of the book to add.</param>
        public void AddBook(string author, string title, string isbn, double price)
        {
            if (_books.Any(book => book.Isbn == isbn))
            {
                AnsiConsole.MarkupLineInterpolated($"A book with [red]ISBN: {isbn}[/] already exists in the library.");
                AnsiConsole.Markup("Press [green]any key[/] to continue.");
                Console.ReadKey();
                return;
            }
            _books.Add(new Book(author, title, isbn, price));
        }

        /// <summary>
        /// Displays a table of all books in the library.
        /// </summary>
        public void DisplayBooks()
        {
            var table = new Table
            {
                Title = new TableTitle("[orange3 bold]Books[/]"),
                Border = TableBorder.HeavyEdge
            };
            table.Expand();
            table.AddColumn("[bold]Title[/]");
            table.AddColumn("[bold]Author[/]");
            table.AddColumn("[bold]ISBN[/]");
            table.AddColumn("[bold]Price[/]");
            table.Columns[3].Alignment = Justify.Right;
            foreach (var book in _books)
            {
                table.AddRow(book.Title, book.Author, book.Isbn, $"{book.Price:C}");
            }
            table.Caption(
                $"There {(_books.Count == 1 ? $"is [green bold]{_books.Count} book" : $"are [green bold]{_books.Count} books")}[/] in the library. The total value of the library is [green bold]{GetTotalPrice():C}[/].");
            AnsiConsole.Write(table);
            AnsiConsole.Markup("Press [green]any key[/] to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// Removes a book from the library.
        /// </summary>
        /// <param name="isbn">The ISBN of the book to remove.</param>
        public void RemoveBook(string isbn)
        {
            if (_books.Any(book => book.Isbn == isbn))
            {
                _books.RemoveAll(book => book.Isbn == isbn);
                AnsiConsole.MarkupLineInterpolated($"Book with [red]ISBN: {isbn}[/] was removed from the library.");
                AnsiConsole.Markup("Press [green]any key[/] to continue.");
                Console.ReadKey();
            }
            else
            {
                AnsiConsole.MarkupLineInterpolated($"There is not book with an ISBN of [red]{isbn}[/] in the library.");
                AnsiConsole.Markup("Press [green]any key[/] to continue.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Calculates the total price of all books in the library.
        /// </summary>
        /// <returns>The total price of all books in the library.</returns>
        private double GetTotalPrice()
        {
            return _books.Sum(book => book.Price);
        }

        #endregion
    }
}