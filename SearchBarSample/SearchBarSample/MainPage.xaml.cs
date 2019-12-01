using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SearchBarSample
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        List<string> Colors = new List<string>
        {
            "Blue","Green","Red","Yellow","Light Blue","Magenta","Cyan","White","Black","Orange"
        };

        private ObservableCollection<string> myColors;

        public ObservableCollection<string> MyColors
        {
            get { return myColors; }
            set
            {
                myColors = value;
                OnPropertyChanged(nameof(MyColors));
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
            MyColors = new ObservableCollection<string>();

        }

        private void search_clicked(object sender, EventArgs e)
        {

        }

        private void search_text_changed(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchBar.Text as string;
            if (keyword.Length > 0)
            {
                var result = Colors.Where(c => c.ToLower().Contains(keyword.ToLower()));
                SuggestionListView.ItemsSource = result;
                SuggestionListView.IsVisible = true;
            }
            else
            {
                SuggestionListView.IsVisible = false;
            }
            
        }

        private void SuggestionListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedColor = e.Item as string;
            MyColors.Add(selectedColor);
            
            SuggestionListView.IsVisible = false;
        }
    }
}
