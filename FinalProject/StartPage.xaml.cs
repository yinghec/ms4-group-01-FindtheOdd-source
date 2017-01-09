using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FinalProject
{
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{
			InitializeComponent();
			/*StartGame.Clicked += async (sender, args) =>
			{
				await Navigation.PushModalAsync(new FinalProjectPage());
			};*/
		}
		void NextPage(object sender, EventArgs ea)
		{	
			Button button = (Button)sender;
			if (button == Normal)
			{
				Navigation.PushModalAsync(new GamerPage(3, 10));
			}
			else if (button == Hard)
			{
				Navigation.PushModalAsync(new GamerPage(7, 7));
			}
			else 
			{
				Navigation.PushModalAsync(new GamerPage(10, 5));
			}
		}
	}
}
