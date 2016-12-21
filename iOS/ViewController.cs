//
// ViewController.cs
//
// Created by Thomas Dubiel on 20.12.2016
// Copyright 2016 Thomas Dubiel. All rights reserved.
//
using System;

using UIKit;
using Foundation;
using AVFoundation;
using System.Collections.Generic;
using System.IO;

namespace MyMusic.iOS
{
	public partial class ViewController : UIViewController
	{

		AVAudioPlayer player;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			List<string> tracks = new List<string>();

			var itemsInDir = Directory.EnumerateFiles("Music/");
			foreach (var item in itemsInDir)
			{
				tracks.Add(item);
			}

			tableView.Source = new TableSource(tracks.ToArray(), this);
		}

		public void PlaySong(string path)
		{
			var trackLocation = path;
			NSError error;

			if (player != null && player.Playing)
				player.Stop();

			player = new AVAudioPlayer(new NSUrl(trackLocation), "mp3", out error);
			player.FinishedPlaying += delegate
			{
				player = null;
			};
			player.Play();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
