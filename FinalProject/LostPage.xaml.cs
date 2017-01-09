using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FinalProject
{
	public partial class LostPage : ContentPage
	{
		public LostPage()
		{
			InitializeComponent();
			//BackgroundImage = "FinalProject.Default.lose.png";
			BackGame.Clicked += async (sender, args) =>
			{
				await Navigation.PushModalAsync(new StartPage());
			};
		}
	}
}
