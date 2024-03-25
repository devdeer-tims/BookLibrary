namespace BookLibrary
{
    /// <summary>
    /// Represents a book.
    /// </summary>
    public class Book
    {
        #region constructors and destructors

        /// <summary>
        /// The constructor for the book class.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="isbn">The ISBN of the book.</param>
        /// <param name="price">The price of the book.</param>
        public Book(string title, string author, string isbn, double price)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Price = price;
        }

        #endregion

        #region properties

        /// <summary>
        /// The title of the book.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// The author of the book.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// The ISBN of the book.
        /// </summary>
        public string Isbn { get; }

        /// <summary>
        /// The price of the book.
        /// </summary>
        public double Price { get; }

        #endregion
    }
}