using IndiceMC.Conexion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        int pesoMaximo;

        private void btnCalcular_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtAltura.Text)&& !string.IsNullOrEmpty(txtPeso.Text))
            {
                calcularIMC();
                insertar_imc();
            }
            else
            {
                DisplayAlert("Datos vacios", "Llene los campos vacios", "Ok");
            }
            
        }

        private void insertar_imc()
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_imc", CONEXIONMAESTRA.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Altura", txtAltura.Text);
                cmd.Parameters.AddWithValue("@Peso", txtPeso.Text);
                cmd.Parameters.AddWithValue("@Resultado", txtResultado.Text);
                cmd.ExecuteNonQuery();
                CONEXIONMAESTRA.cerrar();
            }
            catch (Exception ex)
            {

                DisplayAlert("Error en Base de datos", ex.Message, "Ok");
            }
            
        }
        private void calcularIMC()
        {
            double altura = Convert.ToDouble(txtAltura.Text);
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
            else if (resultado >= 25 && resultado <= 29.9)
            {
                mensaje = "Tienes sobrepeso";
            }
            else
            {
                mensaje = "Tienes sobrepeso";
            }

            DisplayAlert("Resultado", mensaje, "Ok");
        }

        private void btnObtenerDatos_Clicked(object sender, EventArgs e)
        {
            try
            {
                CONEXIONMAESTRA.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_peso_mas_alto", CONEXIONMAESTRA.conectar);
                pesoMaximo = Convert.ToInt32(cmd.ExecuteScalar());
                CONEXIONMAESTRA.cerrar();
                DisplayAlert("Peso Maximo", pesoMaximo.ToString(), "Ok");
            }
            catch (Exception ex)
            {

                DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}
