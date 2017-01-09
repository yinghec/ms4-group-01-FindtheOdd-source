using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FinalProject
{
	public partial class StartGame : ContentPage
	{
		public StartGame()
		{
			InitializeComponent();
			StartGame.Clicked += async (sender, args) =>
			{
				await Navigation.PushModalAsync(new FinalProjectPage());
			};
		}
	}
}
