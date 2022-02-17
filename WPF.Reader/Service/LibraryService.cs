using System;
using System.Collections.ObjectModel;
using WPF.Reader.API;
using WPF.Reader.Model;
using Book = WPF.Reader.API.Book;
using BookLight = WPF.Reader.API.BookLight;

namespace WPF.Reader.Service
{
    public class LibraryService
    {
        String URL = "https://127.0.0.1:5001";
        // A remplacer avec vos propre données !!!!!!!!!!!!!!
        // Pensé qu'il ne faut mieux ne pas réaffecter la variable Books, mais juste lui ajouer et / ou enlever des éléments
        // Donc pas de LibraryService.Instance.Books = ...
        // mais plutot LibraryService.Instance.Books.Add(...)
        // ou LibraryService.Instance.Books.Clear()
        public ObservableCollection<BookLight> Books { get; set; } = new ObservableCollection<BookLight>() {
            new BookLight(),
            new BookLight(),
            new BookLight()
        };

        public async void getBooks()
        {
           var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
           var books = await client.ApiBookGetBooksAsync(null, null, null);
            Books.Clear();
            foreach(BookLight book in books)
            {
                Books.Add(book);
            }
        }

        public ObservableCollection<Book> Book { get; set; } = new ObservableCollection<Book>() {
            new Book(),
            new Book(),
            new Book()
        };
        public async void getBook(int id)
        {
            var client = new API.Client(new System.Net.Http.HttpClient() { BaseAddress = new Uri(URL) });
            var book = await client.ApiBookGetBookByIdAsync(id);
            Book.Clear();
            Book = Book;

        }

        // C'est aussi ici que vous ajouterez les requète réseau pour récupérer les livres depuis le web service que vous avez fait
        // Vous pourrez alors ajouter les livres obtenu a la variable Books !
    }
}
