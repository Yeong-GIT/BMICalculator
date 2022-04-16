using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMICalculator
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageBmiFlyout : ContentPage
    {
        public ListView ListView;

        public MasterDetailPageBmiFlyout()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageBmiFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class MasterDetailPageBmiFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MasterDetailPageBmiFlyoutMenuItem> MenuItems { get; set; }

            public MasterDetailPageBmiFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<MasterDetailPageBmiFlyoutMenuItem>(new[]
                {
                    new MasterDetailPageBmiFlyoutMenuItem { Id = 0, Title = "BMI Calculator", TargetType=typeof(MainPage)},
                    new MasterDetailPageBmiFlyoutMenuItem { Id = 1, Title = "Information" , TargetType=typeof(Information) },
                    new MasterDetailPageBmiFlyoutMenuItem { Id = 2, Title = "Record" , TargetType=typeof(TabbedRecord) },
              
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}