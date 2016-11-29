using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.DirectX.AudioVideoPlayback;
using DX = Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using D3D = Microsoft.DirectX.Direct3D;
using System.IO;
namespace BreakOut {
	public class Sound {
		string[] songs = new string[] { };
		string exepath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
		Audio backmusic;
		Dictionary<string, Audio> sfx = new Dictionary<string, Audio>();
		public Sound() {
			sfx.Add("brickhit", new Audio(Path.Combine(exepath, @"sfx\brickhit.mp3")));
			sfx.Add("wallhit", new Audio(Path.Combine(exepath, @"sfx\wallhit.mp3")));
			RefreshSongList();
			try {
				backmusic = new Audio(GetRandomSong());
				backmusic.Ending += new EventHandler(backmusic_Ending);
				backmusic.Play();
			} catch { }
			
		}

		void backmusic_Ending(object sender, EventArgs e) {
			PlayRandomSong();
		}
		static Random r = new Random();
		int song = 0;
		string GetRandomSong() {
			song = r.Next(0,songs.Length);
			if (songs.Length == 0) return "";
			//song= (song + 1) % songs.Length; //no random straight play
			return songs[song];
		}
		void PlayRandomSong() {
			try {
				backmusic.Open(GetRandomSong());
				backmusic.Play();
			} catch { }
			
		}
		public void PlaySFX(string key) {
			if (sfx.ContainsKey(key)) {
				try {
					sfx[key].SeekCurrentPosition(0, SeekPositionFlags.AbsolutePositioning);
					sfx[key].Play();
				} catch { }
			}
		}
		public void RefreshSongList() {
			songs = Directory.GetFiles(Path.Combine(exepath, @"music"), "*.mp3");
		}
	}
}
