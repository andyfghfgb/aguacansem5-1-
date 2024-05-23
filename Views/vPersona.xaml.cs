using aguacansem5.Modelos;
using System.Net;
namespace aguacansem5.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblstatus.Text = "";
        App.PersonRepo.AddNewPerson(txtPersona.Text);
        lblstatus.Text = App.PersonRepo.statusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblstatus.Text = "";
        List<Persona> personas = App.PersonRepo.GetAllPeople();
        listapersonas.ItemsSource = personas;
    }


    //cambiar los nombre de los mtodos
    private void Button_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        if (persona != null)
        {
            txtPersona.Text = persona.Name;
        }

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        //actualizar y elimnar el indice, no se formatea los indices!!!!!!
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        //sender* es un objeto!
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        if (persona != null)
        {
            App.PersonRepo.DeletePerson(persona);

            btnObtener_Clicked(sender, e); //se refresca la lista llamandola otra vez
        }
    }
}