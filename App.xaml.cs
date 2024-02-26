

namespace KrutolapovPr12
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new NavigationPage(new MainPage());
        }     
        
        private static bool _appearing = false;       
        
        public static bool Apearing
        {
            get { return _appearing; }
            set { _appearing = value; }
        }
        public static string FIO { get; set; }
        public static string Gender { get; set; }
        public static string YearOfBirth { get; set; }
        public static string PlaceOfBirth { get; set; }
        public static string Nationality { get; set; }        
    }
}
