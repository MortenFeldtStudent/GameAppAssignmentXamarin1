using Minutes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Minutes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteEntryEditPage : ContentPage
    {
        private NoteEntry entry;

        public NoteEntryEditPage(NoteEntry entry)
        {
            InitializeComponent();
            BindingContext = this.entry = entry;
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            if (entry != null)
            {
                await App.Entries.UpdateAsync(entry);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Device.Idiom == TargetIdiom.Desktop
                || Device.Idiom == TargetIdiom.Tablet
                || Device.Idiom == TargetIdiom.Phone)
            {
                textEditor.Focus();
            }
        }
    }
}