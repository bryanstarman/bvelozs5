using bvelozs5.Modelos;

namespace bvelozs5.Vistas;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
	}
    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.PersonRepo.AddNewPerson(txtNombre.Text);
        statusMessage.Text = App.PersonRepo.statusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
       
        statusMessage.Text = "";
        List<Persona> people = App.PersonRepo.GetAlllPeople();
        listaPersona.ItemsSource = people;

    }

    private void btnEditar_Clicked(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(txtEditarId.Text);
        string nombre = txtEditarNombre.Text;
        App.PersonRepo.UpdatePerson(id, nombre);
        txtEditarId.Text = "";
        txtEditarNombre.Text = "";
        DisplayAlert("Alert","Registro Editado","Ok");

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        int id= Convert.ToInt32(txtEditarId.Text);
        App.PersonRepo.DeletePerson(id);
        txtEditarId.Text = "";
        DisplayAlert("Alert", "Registro Eliminado", "Ok");
    }
}