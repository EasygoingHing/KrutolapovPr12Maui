using System.Collections.ObjectModel;
using System.Reflection;
using System.Text.Json;

namespace KrutolapovPr12
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Anketa> anketas = new ObservableCollection<Anketa>(); 

        public MainPage()
        {
            InitializeComponent();
            anketas.Add(new Anketa
            { FIO = "Гончаров Пётр Дмитриевич", Gender = "Муж", YearOfBirth = "15.11.2000", PlaceOfBirth = "Москва", Nationality = "Русcкий" });
            anketas.Add(new Anketa
            { FIO = "Болдырева Александра Егоровна", Gender = "Жен", YearOfBirth = "15.11.2000", PlaceOfBirth = "Рязань", Nationality = "Русский" });
            anketas.Add(new Anketa
            { FIO = "Корнеева Дарья Егоровна", Gender = "Жен", YearOfBirth = "25.08.2005", PlaceOfBirth = "Кострома", Nationality = "Русский" });
            anketas.Add(new Anketa
            { FIO = "Волков Макар Андреевич", Gender = "Муж", YearOfBirth = "01.01.2010", PlaceOfBirth = "Чита", Nationality = "Русский" });
            anketas.Add(new Anketa
            { FIO = "Соколова Анна Максимовна", Gender = "Жен", YearOfBirth = "12.05.1999", PlaceOfBirth = "Уфа", Nationality = "Русский" });            
            lvAnkenataList.ItemsSource = anketas;            
        }

        Anketa selectedItem;        

        private void lvAnkenataList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                btnOpenPage.IsEnabled = true;
                selectedItem = (Anketa)e.SelectedItem;
                lbText.Text = selectedItem.FIO;
            }
        }          

        async private void btnOpenPage_Clicked(object sender, EventArgs e)
        {            
            App.FIO = selectedItem.FIO;
            App.Gender = selectedItem.Gender;
            App.YearOfBirth = selectedItem.YearOfBirth;
            App.PlaceOfBirth = selectedItem.PlaceOfBirth;
            App.Nationality = selectedItem.Nationality;           
            await Navigation.PushAsync(new ViewingPage());
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {                
            await Navigation.PushAsync(new AddPage());              
        }

        private void btnRemove_Clicked(object sender, EventArgs e)
        {
            Anketa ank = (Anketa)lvAnkenataList.SelectedItem;
            if (anketas != null) anketas.Remove(ank);            
        }     

        private async void btnEdit_Clicked(object sender, EventArgs e)
        {
            App.FIO = selectedItem.FIO;
            App.Gender = selectedItem.Gender;
            App.YearOfBirth = selectedItem.YearOfBirth;
            App.PlaceOfBirth = selectedItem.PlaceOfBirth;
            App.Nationality = selectedItem.Nationality;
            await Navigation.PushAsync(new EditPage());            
        }

        private void btnLoad_Clicked(object sender, EventArgs e)
        {
            selectedItem.FIO = App.FIO;
            selectedItem.Gender = App.Gender;
            selectedItem.YearOfBirth = App.YearOfBirth;
            selectedItem.PlaceOfBirth = App.PlaceOfBirth;
            selectedItem.Nationality = App.Nationality;                     
        }

        string mainDir = FileSystem.Current.AppDataDirectory;

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(Path.Combine(mainDir, "anketa.txt"));
            sw.WriteLine(anketas.Count);
            foreach (Anketa anketa in anketas)
            {
                sw.WriteLine(anketa.FIO);
                sw.WriteLine(anketa.Gender);
                sw.WriteLine(anketa.YearOfBirth);
                sw.WriteLine(anketa.PlaceOfBirth);
                sw.WriteLine(anketa.Nationality);
            }
            sw.Close();
        }

        private void btnOpen_Clicked(object sender, EventArgs e)
        {
            anketas.Clear();
            StreamReader sr = new StreamReader(Path.Combine(mainDir, "anketa.txt"));
            int count;
            Int32.TryParse(sr.ReadLine(), out count);
            for (int i = 1; i <= count; i++)
            {
                Anketa anketa = new Anketa();
                anketa.FIO = sr.ReadLine();
                anketa.Gender = sr.ReadLine();
                anketa.YearOfBirth = sr.ReadLine();
                anketa.PlaceOfBirth = sr.ReadLine();
                anketa.Nationality = sr.ReadLine();
                anketas.Add(anketa);
            }
            sr.Close();
            lvAnkenataList.ItemsSource = anketas;
        }

        bool start;

        protected override void OnAppearing()
        {
            start = App.Apearing;
            base.OnAppearing();              
            if (start) 
            {                
                anketas.Add(new Anketa
                { FIO = App.FIO, Gender = App.Gender, YearOfBirth = App.YearOfBirth, PlaceOfBirth = App.PlaceOfBirth, Nationality = App.Nationality });
                lvAnkenataList.ItemsSource = anketas;
                App.Apearing = false;
            }            
        }        
    }
}
