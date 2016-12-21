using Android.App;
using Android.Widget;
using Android.OS;
using Android.Media;
using System.Collections.Generic;

namespace MyMusic.Droid
{
	[Activity(Label = "My Music", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		MediaPlayer player;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			List<string> tracks = new List<string>();

			var fields = typeof(Resource.Raw).GetFields();
			foreach (var field in fields)
			{
				tracks.Add(field.Name);
			}

			var listView = FindViewById<ListView>(Resource.Id.listView);

			var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, tracks.ToArray());
			listView.Adapter = adapter;
			listView.ItemClick += (sender, e) =>
			{
				var item = tracks[e.Position];
				playSong(item);
			};
		}

		public void playSong(string name)
		{
			var resId = Resources.GetIdentifier(name, "raw", PackageName);

			if (player != null && player.IsPlaying)
			{
				player.Stop();
			}

			player = MediaPlayer.Create(this, resId);

			player.Completion += delegate
			{
				player = null;
			};
			player.Start();
		}
	}
}

