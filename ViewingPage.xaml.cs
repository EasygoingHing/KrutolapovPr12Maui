namespace KrutolapovPr12;

public partial class ViewingPage : ContentPage
{	
	public ViewingPage()
	{
		InitializeComponent();
		lbFIO.Text = App.FIO;
		lbGender.Text = App.Gender;
		lbYearOfBirth.Text = App.YearOfBirth;
		lbPlaceOfBirth.Text = App.PlaceOfBirth;
		lbNationality.Text = App.Nationality;      
    }
}