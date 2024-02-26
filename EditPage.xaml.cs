namespace KrutolapovPr12;

public partial class EditPage : ContentPage
{
	public EditPage()
	{
		InitializeComponent();
        entryFIO.Text = App.FIO;
        entryGender.Text = App.Gender;
        entryYearOfBirth.Text = App.YearOfBirth;
        entryPlaceOfBirth.Text = App.PlaceOfBirth;
        entryNationality.Text = App.Nationality;
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        base.OnDisappearing();
        App.FIO = entryFIO.Text;
        App.Gender = entryGender.Text;
        App.YearOfBirth = entryYearOfBirth.Text;
        App.PlaceOfBirth = entryPlaceOfBirth.Text;
        App.Nationality = entryNationality.Text;
    }    
}
