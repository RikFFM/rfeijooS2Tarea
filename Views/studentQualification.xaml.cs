namespace rfeijooS2tarea.Views;

public partial class studentQualification : ContentPage
{
	public studentQualification()
	{
		InitializeComponent();
	}

    private void btnCalculate_Clicked(object sender, EventArgs e)
    {
        try
        {
            string student = pkNombre.Items[pkNombre.SelectedIndex].ToString();
            double nota1 = double.Parse(nt1.Text);
            double exa1 = double.Parse(ex1.Text);
            double nota2 = double.Parse(nt2.Text);
            double exa2 = double.Parse(ex2.Text);
            double nota3 = double.Parse(nt3.Text);
            double exa3 = double.Parse(ex3.Text);
            string fecha = date.Date.ToString();
            //Calculo
            double parcial1 = (nota1 * 0.3) + (exa1 * 0.2);
            double parcial2 = (nota2 * 0.3) + (exa2 * 0.2);
            double parcial3 = (nota3 * 0.3) + (exa3 * 0.2);

            double notafinal = parcial1 + parcial2 + parcial3;

            string estado = "";
            if (notafinal >= 7)
            {
                estado = "Aprobado";
            }
            else if (notafinal >= 5 && notafinal <= 6.9)
            {
                estado = "Complementario";
            }
            else
            {
                estado = "Reprobado";
            }
            
            string resultado = $"Nota Parcial 1:{parcial1}\nNota Parcial 2:{parcial2}\nNota Parcial 3:{parcial3}\nNota Final: {notafinal}\nEstado:{estado}\nFecha:"+fecha;
            DisplayAlert("Resultados", resultado, "Aceptar");
        }catch(Exception ex)
        {
            DisplayAlert("Error","Se produjo un error","Aceptar");
        }
    }

    private void Entry_Text(object sender, TextChangedEventArgs e)
    {
        if(sender is Entry entry)
        {
            if(!string.IsNullOrEmpty(entry.Text))
            {
                bool esNumeroValido = double.TryParse(entry.Text, out double valor);
                if (!esNumeroValido || valor <0 || valor > 10)
                {
                    entry.Text = e.OldTextValue ?? "";
                }
            }

        }
    }
}