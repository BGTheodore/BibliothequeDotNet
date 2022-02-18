﻿using Microsoft.Toolkit.Mvvm.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using WPF.Reader.API;
using WPF.Reader.Model;
using WPF.Reader.Service;

namespace WPF.Reader.ViewModel
{
    internal class ListBook : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelectedCommand { get; set; }

        public ICommand GoToGenres { get; set; }
        // n'oublier pas faire de faire le binding dans ListBook.xaml !!!!
        public ObservableCollection<BookLight> Books => Ioc.Default.GetRequiredService<LibraryService>().Books;

        public ListBook()
        {
            ItemSelectedCommand = new RelayCommand(book => {
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<DetailsBook>(book);
                /* the livre devrais etre dans la variable book */ });

            GoToGenres = new RelayCommand(book =>{
                Ioc.Default.GetRequiredService<INavigationService>().Navigate<ListGenres>();
            });

            }



    }
}
