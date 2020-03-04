using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppClima
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            Inicializar();
        }

        private void Inicializar()
        {
            btnText.Clicked += BtnText_Clicked;
            btnOtraPag.Clicked += BtnOtraPag_Clicked;
        }

        private void BtnOtraPag_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new OtraPagina());
        }

        private void BtnText_Clicked(object sender, EventArgs e)
        {
            lblText.Text = entryText.Text;
        }
    }
}
