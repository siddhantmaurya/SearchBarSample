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
            "Blue","Green","Red","Yellow","Light Blue","Magenta","Cyan"
        };
        ObservableCollection<string> SearchList = new ObservableCollection<string>();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void search_clicked(object sender, EventArgs e)
        {

        }

        private void search_text_changed(object sender, TextChangedEventArgs e)
        {
            var keyword = SearchBar.Text as string;
            var result = Colors.Where(c => c.ToLower().Contains(keyword.ToLower()));
        }
    }
}
