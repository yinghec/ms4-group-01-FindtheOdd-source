using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net;
using Xamarin.Forms;
//using System.ComponentModel;
using System.IO;
using System.Reflection;

namespace FinalProject
{
	public partial class GamerPage : ContentPage
	{
		IPlatformSound platformSound;
		int count = 1;
		int answer;
		int round = 1;
		int totalTime;
		int totalTimeStore;
		bool running = false;
		int gameLevel;
		public GamerPage(int gameLevel, int currtotalTime)
		{
			this.gameLevel = gameLevel;
			totalTime = currtotalTime;
			totalTimeStore = currtotalTime;
			InitializeComponent();
			timer.Text = totalTimeStore + "s";
			LocalImage(ResetImage, "FinalProject.Default.reset1.png");
			LocalImage(StartButton, "FinalProject.Default.play.png");

			//


			platformSound = DependencyService.Get<IPlatformSound>();

			//platformSound.GenerateSound();

			//
			Device.StartTimer(TimeSpan.FromSeconds(1), () =>
			{
				if (running)
				{
					totalTime--;
					timer.Text = "" + totalTime + "s";
				}
				if (totalTime <= 0)
				{
					//Task task = DisplayAlert("YOU LOSE!",
					// "Your Reaction is too SLOW.", "OK");

					running = false;
					totalTime = 1;
					platformSound.StopSound();
					Navigation.PushModalAsync(new LostPage());

				}
				return true;
			});
		}

		//Change all image into Paused Images
		void blockimage()
		{
			LocalImage(Image1, "FinalProject.Default.Paused.jpg");
			LocalImage(Image2, "FinalProject.Default.Paused.jpg");
			LocalImage(Image3, "FinalProject.Default.Paused.jpg");
			LocalImage(Image4, "FinalProject.Default.Paused.jpg");
		}
		//Update the current level of game to i level
		void updateImage(int i)
		{
			Image1.BackgroundColor = Color.Navy;
			Image2.BackgroundColor = Color.Navy;
			Image3.BackgroundColor = Color.Navy;
			Image4.BackgroundColor = Color.Navy;
			Random rnd = new Random();
			bool has2 = false;
			int dotpic = rnd.Next(1, 5);
			if (dotpic == 2)
			{
				LocalImage(Image1, "FinalProject.Images." + i + ".2.png");
				has2 = true;
				answer = 1;
			}
			else
			{ LocalImage(Image1, "FinalProject.Images." + i + ".1.png"); }
			dotpic = rnd.Next(1, 4);
			if (dotpic == 2 && has2 == false)
			{
				LocalImage(Image2, "FinalProject.Images." + i + ".2.png");
				has2 = true;
				answer = 2;
			}
			else
			{
				LocalImage(Image2, "FinalProject.Images." + i + ".1.png");
			}
			dotpic = rnd.Next(1, 3);
			if (dotpic == 2 && has2 == false)
			{
				LocalImage(Image3, "FinalProject.Images." + i + ".2.png");
				has2 = true;
				answer = 3;
			}
			else
			{
				LocalImage(Image3, "FinalProject.Images." + i + ".1.png");
			}
			//dotpic = rnd.Next(1, 3);
			if (has2 == false)
			{
				LocalImage(Image4, "FinalProject.Images." + i + ".2.png");
				has2 = true;
				answer = 4;
			}
			else
			{
				LocalImage(Image4, "FinalProject.Images." + i + ".1.png");
			}
		}
		//Reset all features into original set
		void ResetTapped(object sender, EventArgs args)
		{
			MusicSwitch.IsToggled = false;
			platformSound.StopSound();
			LocalImage(StartButton, "FinalProject.Default.play.png");
			round = 1;
			count = 1;
			running = false;
			totalTime = totalTimeStore;
			timer.Text = totalTimeStore + "s";
			blockimage();
		}
		//change the start button to be pasue and vice versa
		void StartTapped(object sender, EventArgs args)
		{
			if (count % 2 == 1)
			{
				LocalImage(StartButton, "FinalProject.Default.pause.png");
				running = true;
				updateImage(round);
			}
			if (count % 2 == 0)
			{
				LocalImage(StartButton, "FinalProject.Default.play.png");
				running = false;
				blockimage();
			}
			count++;
		}

		//check if the selected image is correct
		void ImageTapped(object sender, EventArgs args)
		{
			if (sender == Image1)
			{
				if (answer == 1)
				{
					Image1.BackgroundColor = Color.Green;
					round++;
					totalTime = totalTimeStore;
					if (round > gameLevel)
					{
						Navigation.PushModalAsync(new WinPage());
						platformSound.StopSound();
						running = false;
					}
					else { updateImage(round); }
				}
				else {
					Image1.BackgroundColor = Color.Red;
					totalTime -= 3;
				}
			}
			if (sender == Image2)
			{
				if (answer == 2)
				{
					Image2.BackgroundColor = Color.Green;
					round++;
					totalTime = totalTimeStore;
					if (round > gameLevel)
					{
						Navigation.PushModalAsync(new WinPage());
						platformSound.StopSound();
						running = false;
					}
					else { updateImage(round); }
				}
				else {
					Image2.BackgroundColor = Color.Red;
					totalTime -= 3;
				}
			}
			if (sender == Image3)
			{
				if (answer == 3)
				{
					Image3.BackgroundColor = Color.Green;
					round++;
					totalTime = totalTimeStore;
					if (round > gameLevel)
					{
						Navigation.PushModalAsync(new WinPage());
						platformSound.StopSound();
						running = false;
					}
					else { updateImage(round); }
				}
				else {
					Image3.BackgroundColor = Color.Red;
					totalTime -= 3;
				}
			}
			if (sender == Image4)
			{
				if (answer == 4)
				{
					Image4.BackgroundColor = Color.Green;
					round++;
					totalTime = totalTimeStore;
					if (round > gameLevel)
					{
						Navigation.PushModalAsync(new WinPage());
						platformSound.StopSound();
						running = false;
					}
					else { updateImage(round); }
				}
				else {
					Image4.BackgroundColor = Color.Red;
					totalTime -= 3;
				}
			}
		}

		//change button image
		void LocalImage(Image currentImage, String resourceID)
		{
			currentImage.Source = ImageSource.FromStream(() =>
			{
				Assembly assembly = GetType().GetTypeInfo().Assembly;
				Stream stream = assembly.GetManifestResourceStream(resourceID);
				return stream;
			});
		}

		//Implement music switch
		void OnSwitchToggled(object sender, ToggledEventArgs args)
		{
			if (args.Value)
			{
				platformSound.GenerateSound();

			}
			else {
				platformSound.StopSound();
			}
		}
	}
}
