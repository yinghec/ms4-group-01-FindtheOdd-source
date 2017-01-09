using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using Android.OS;
using Xamarin.Forms;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Media;

[assembly: Dependency(typeof(FinalProject.Droid.PlatformSound))]

namespace FinalProject.Droid
{
    public class PlatformSound : IPlatformSound
    {
       string mp3TestFile = "http://66.90.91.26/ost/mario-luigi-paper-jam-bros.-gamerip-" +
			"/hbsenhkeay/02.-choose-your-adventure-file-select-.mp3";
		double musicPlayInterval = 1000.0; //in seconds
		double currentTime = 0.0;//in seconds
		static bool playerInitHappened = false;
		static MediaPlayer player = new MediaPlayer();
		void playerInit()
		{
			player.SetAudioStreamType(Android.Media.Stream.Music);

			player.Prepared += (sender, args) =>
			{
				player.Start();
			};
			//When we have reached the end of the song stop ourselves, however you could signal next track here.
			player.Completion += (sender, args) =>
			{
				player.Stop();
				player.Prepare(); //play again
			};
			player.Error += (sender, args) =>
			{
				//playback error
				Console.WriteLine("Error in playback resetting: " + args.What);
				player.Stop();//this will clean up and reset properly.
			};
			player.SetDataSource(Android.App.Application.Context, Android.Net.Uri.Parse(mp3TestFile));
		}
		public String GenerateSound()
		{
			if (!player.IsPlaying)
			{
				if (playerInitHappened == false)
				{
					playerInitHappened = true;
					playerInit();
				}
				player.Prepare();
			}
			return "Android sound got called!";
		}

		public void StopSound()
		{
			
			if (playerInitHappened == true)
			{
				if (player.IsPlaying)
					player.Stop();
			}
		}
	}
}