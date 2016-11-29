using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace BreakOut {
	public class Game {
		public Sound Sound = new Sound();
		public List<Level> Levels = new List<Level>();
		public int LevelIndex, Score, Lives=3;
		public Level CurrentLevel;
		public bool Paused=true;
		public void LoadLevels() {
			FileInfo loc = new FileInfo(System.Reflection.Assembly.GetCallingAssembly().Location);
			string s = Path.Combine(loc.Directory.FullName, @"levels\levels.csv");
			FileInfo fi = new FileInfo(s);
			string levelData;
			using (TextReader tr = fi.OpenText()) {
				levelData = tr.ReadToEnd();
				tr.Close();
			}
			string[] levels = levelData.Split(new string[] { "LEVEL" }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < levels.Length; i++) {
				string[] rows = levels[i].Trim(',').Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
				string[][] data = new string[rows.Length][];
				for (int j = 0; j < rows.Length; j++) {
					data[j] = rows[j].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
				}
				Level l = new Level(this, data);
				Levels.Add(l);
			}
		}
		public Game() {
			LoadLevels();
			Restart(false);
			Pause();
		}
		public void Restart(bool prompt) {
			if (prompt) if (System.Windows.Forms.MessageBox.Show("Are you sure you want to restart?", "Restart Game?", System.Windows.Forms.MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No) return;
			CurrentLevel = Levels[LevelIndex].Clone();
		}
		public bool IsPaused() {
			return Paused;
		}
		public void Pause() {
			Paused = true;
		}
		public void UnPause() {
			Paused = false;
		}
		public void TogglePause() {
			Paused = !Paused;
		}
		public void NextLevel() {
			Pause();
			LevelIndex = (LevelIndex + 1) % Levels.Count;
			CurrentLevel = Levels[LevelIndex].Clone();
		}
		public void GameOver() {
			LevelIndex = 0;
			Lives = 3;
			Score = 0;
			Restart(false);
			Pause();
		}
		public void LoseLife() {
			Lives--;
			CurrentLevel.ResetBall();
			Pause();
			if (Lives == 0) GameOver();
		}
	}
}
