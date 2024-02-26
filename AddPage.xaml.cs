namespace KrutolapovPr12;

public partial class AddPage : ContentPage
{    
    public AddPage()
    {
        InitializeComponent();
    }    

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        base.OnDisappearing();
        App.Apearing = true;
        App.FIO = entryFIO.Text;
        App.Gender = entryGender.Text;
        App.YearOfBirth = entryYearOfBirth.Text;
        App.PlaceOfBirth = entryPlaceOfBirth.Text;
        App.Nationality = entryNationality.Text;        
    }    
}