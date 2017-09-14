using System.Collections.Generic;
using Xamarin.Forms;

namespace AccordianView.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
            list.ItemsSource = new List<UserEntity>
            {
                new UserEntity
                {
                    Age = 27,
                    Name = "Dinesh",
                    Number = 101
                },
                new UserEntity
                {
                    Age = 24,
                    Name = "Sawan",
                    Number = 121
                },
                new UserEntity
                {
                    Age = 27,
                    Name = "Rohit",
                    Number = 100
                }
            };
        }
    }
}
