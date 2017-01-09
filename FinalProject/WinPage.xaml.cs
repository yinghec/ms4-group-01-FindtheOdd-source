using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FinalProject
{
	public partial class WinPage : ContentPage
	{
		public WinPage()
		{
			InitializeComponent();
			//BackgroundImage = "FinalProject.Default.win.jpg";
			BackGame.Clicked += async (sender, args) =>
			{
				await Navigation.PushModalAsync(new StartPage());
			};
		}
	}
}
