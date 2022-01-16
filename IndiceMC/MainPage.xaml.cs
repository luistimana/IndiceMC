using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IndiceMC
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            double altura = Convert.ToDouble(txtAlltura.Text);
            double peso = Convert.ToDouble(txtPeso.Text);
            double resultado = peso / (altura * altura);
            txtResultado.Text = resultado.ToString();

            string mensaje = "";

            if (resultado < 18.5)
            {
                mensaje = "Tienes bajo peso";
            } 
            else if (resultado >= 18.5 && resultado <= 24.9)
            {
                mensaje = "Tu peso es normal";
            }
            else if (resultado >=25 && resultado <= 29.9)
            {
                mensaje = "Tienes sobrepeso";
            }
            else
            {
                mensaje = "Tienes sobrepeso";
            }

            DisplayAlert("Resultado", mensaje, "Ok");
        }
    }
}
