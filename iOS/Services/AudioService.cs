
using System;
using Xamarin.Forms;
using FinalProject;
using FinalProject.iOS;
using System.IO;
using Foundation;
using AVFoundation;

[assembly: Dependency(typeof(AudioService))]
namespace FinalProject.iOS
{

	public class AudioService : IPlatformSound
	{
		AVAudioPlayer backgroundmusic;
		double currentTime = 0.0;
		double musicPlayInterval = 10000.0;
		public AudioService() { }



		public string GenerateSound()
		{
			String fileName = "find.mp3";
			NSError error = null;
			AVAudioSession.SharedInstance().SetCategory(AVAudioSession.CategoryPlayback, out error);
	
			NSUrl url = new NSUrl("Sounds/" + fileName);
		    backgroundmusic = AVAudioPlayer.FromUrl(url);
			backgroundmusic.Volume = 1.0f;

			backgroundmusic.PrepareToPlay();
			backgroundmusic.BeginInterruption += (object sender, EventArgs e) =>
			 {
				 backgroundmusic.Play();
				 Device.StartTimer(TimeSpan.FromSeconds(1), OnTimerTick);

			 };
			backgroundmusic.FinishedPlaying += (object sender, AVStatusEventArgs e) =>
			{
				backgroundmusic = null;
			};
			backgroundmusic.NumberOfLoops = -1;
			backgroundmusic.Play();

			return "iOS sound got called!";
		}
		public void StopSound()
		{
			backgroundmusic.Stop();
			backgroundmusic.Dispose();
		}


			bool OnTimerTick()
		{
			currentTime += 1;
			if (currentTime >= musicPlayInterval)
			{
				currentTime = 0.0;
				backgroundmusic.Stop();
				return false;
			}
			return true;
		}

		//public void Dispose()
		//{
			
	//	}
			/*AVAudioPlayer backgroundMusic;
			var session = AVAudioSession.SharedInstance();
			session.SetCategory(AVAudioSessionCategory.Ambient);
			session.SetActive(true);
			NSUrl songURL;
			songURL = new NSUrl("Resources/" + fileName);
			NSError err;
			backgroundMusic = new AVAudioPlayer(songURL, "wav", out err);
			backgroundMusic.FinishedPlaying += delegate
			{
				// backgroundMusic.Dispose(); 
				backgroundMusic = null;
			};
			backgroundMusic.NumberOfLoops = -1;
			backgroundMusic.Volume = 1.0f;
			backgroundMusic.Play();*/

		}
	}
