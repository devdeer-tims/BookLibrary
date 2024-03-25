using System.Globalization;

using BookLibrary;

using Spectre.Console;

var library = new Library();
var running = true;
// Loop to keep the program running until the user selects to exit.
while (running)
{
    // Clearing the console before displaying the menu.
    AnsiConsole.Clear();
    var selection = AnsiConsole.Prompt(
        new SelectionPrompt<string>().Title("Select what to do:")
            .PageSize(10)
            .AddChoices("Add new book", "Remove an existing book", "Display all books", "Exit"));
    // Switch statement to handle the user's selection.
    switch (selection)
    {
        case "Add new book":
            AnsiConsole.Clear();
            var title = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green bold]title[/]:")
                    .ValidationErrorMessage("[red]Title[/] is required.")
                    .Validate(
                        title => string.IsNullOrWhiteSpace(title)
                            ? ValidationResult.Error("[red]Title[/] is required.")
                            : ValidationResult.Success()));
            var author = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green bold]author[/]:").ValidationErrorMessage("[red]Author[/] is not valid.")
                    .Validate(
                        author => string.IsNullOrEmpty(author)
                            ? ValidationResult.Error("[red]Author[/] is required.")
                            : ValidationResult.Success()));
            var isbn = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter [green bold]ISBN[/]:").ValidationErrorMessage("[red]ISBN[/] is required.")
                    .Validate(
                        isbn => string.IsNullOrWhiteSpace(isbn)
                            ? ValidationResult.Error("[red]ISBN[/] is required.")
                            : ValidationResult.Success()));
            var price = AnsiConsole.Prompt(
                new TextPrompt<double>("Enter [green bold]Price[/]:").ValidationErrorMessage("[red]Price[/] is required.")
                    .Validate(
                        price => string.IsNullOrWhiteSpace(price.ToString(CultureInfo.CurrentCulture)) || price < 0
                            ? ValidationResult.Error("[red]Price[/] is not in a valid format.")
                            : ValidationResult.Success()));
            library.AddBook(title, author, isbn, price);
            break;
        case "Remove an existing book":
            AnsiConsole.Clear();
            var isbnToRemove = AnsiConsole.Prompt(
                new TextPrompt<string>("Enter ISBN of the book to remove:")
                    .ValidationErrorMessage("[red]ISBN[/] is required to remove a book.")
                    .Validate(isbnToRemove => !string.IsNullOrWhiteSpace(isbnToRemove)));
            library.RemoveBook(isbnToRemove);
            break;
        case "Display all books":
            AnsiConsole.Clear();
            library.DisplayBooks();
            break;
        case "Exit":
            running = false;
            break;
    }
}