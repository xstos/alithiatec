using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using D3D = Microsoft.DirectX.Direct3D;
using System.Drawing;
using System.Windows.Forms;
namespace BreakOut {
	public sealed class Engine {
		Game game = new Game();
		// Singleton

	    private Engine()
	    {
	        
	    }

	    public static void Init()
	    {
            Instance = new Engine();
	    }

	    public static Engine Instance;

		// Attributes/Properties
		private System.Windows.Forms.Control targetControl;
		public System.Windows.Forms.Control TargetControl {
			get { return targetControl; }
		}

		private Renderer renderer;
		public Renderer Renderer {
			get { return renderer; }
		}
		public void Initialize(System.Windows.Forms.Control targetControl) {
			this.targetControl = targetControl;
			targetControl.MouseMove += new System.Windows.Forms.MouseEventHandler(targetControl_MouseMove);
			targetControl.MouseDown += new System.Windows.Forms.MouseEventHandler(targetControl_MouseDown);
			targetControl.KeyUp += new KeyEventHandler(targetControl_KeyUp);
			targetControl.KeyDown += new KeyEventHandler(targetControl_KeyDown);
			// Initialize Subsystems
			this.renderer = new Renderer(targetControl);
		}

		void targetControl_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Up) DT += 0.0001F;
			else if (e.KeyCode == Keys.Down) DT -= 0.0001F;
			if (DT > 0.014f) DT = 0.014f;
			else if (DT < 0) DT = 0;
		}

		void targetControl_KeyUp(object sender, KeyEventArgs e) {
			
		}

		void targetControl_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e) {
			if (e.Button == MouseButtons.Right) {
				game.TogglePause(); return;
			}
			if (e.Button == MouseButtons.Left && game.IsPaused()) {
				game.UnPause(); return;
			}
			if (e.Button == MouseButtons.Middle) game.NextLevel();
		}
		float newX; public float DT = 0.007F;
		bool render=true;
		void SuppressUpdates() { render = false; }
		void ResumeUpdates() { render = true; }
		void targetControl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e) {
			if (game.IsPaused()) return;
			SuppressUpdates();
			newX = e.X / (float)targetControl.ClientSize.Width;
			if (newX < game.CurrentLevel.PaddleStop) newX = game.CurrentLevel.PaddleStop; //hard coded for simplicity could put this in the collision handler as different cases
			else if (newX > 1.0 - game.CurrentLevel.PaddleStop) newX = 1.0F - game.CurrentLevel.PaddleStop;
			game.CurrentLevel.Paddle.Position=new V3(newX, game.CurrentLevel.Paddle.Position.Y, 0);
			//there's likely a weakness in this method at the walls if the ball happens to travel horizontally and we sandwitch it into the wall... unlikely though
			if (game.CurrentLevel.Paddle.Contains(game.CurrentLevel.Ball.Vertices)) { //since the mouse updates position outside of the game loop we need this to ensure the ball doesn't end up in the paddle... simple way for now... can be upgraded to deal with the collision accurately
				V3 old = game.CurrentLevel.Ball.Velocity;
				game.CurrentLevel.Ball.Velocity=new V3(0,-old.Magnitude,0);
				while (game.CurrentLevel.Paddle.Contains(game.CurrentLevel.Ball.Vertices)) {
					game.CurrentLevel.Ball.MoveNext(DT*0.2f); //move ball back until not in paddle... not elegant or efficient, but easy!
				}
				game.CurrentLevel.Ball.Velocity = old;
				game.CurrentLevel.World.ResolveCollisions2(DT, false);
				//game.CurrentLevel.World.ResolveCollisions2(DT, false);
			}
			ResumeUpdates();
		}
		public void Frame() {
			if (render) {
				Render(!game.IsPaused());
				
			}
		}
		void PauseForDrama(int ms) { // for debugging purposes
			return;
			game.CurrentLevel.World.AddVec(game.CurrentLevel.Ball.Trajectory(), Color.Red);
			System.Threading.Thread.Sleep(ms);
			Render(false);
			targetControl.Invalidate();
		}
		private void Render(bool collisions) {
			renderer.BeginScene();
			List<Mesh2D> cur = game.CurrentLevel.World.Meshes["bricks"];
			for (int i = 0; i < cur.Count; i++) {
				renderer.AddPoly(cur[i].ToScreen(renderer.Factor));
			}
			
			cur = game.CurrentLevel.World.Meshes["walls"];
			for (int i = 0; i < cur.Count; i++) {
				renderer.AddPoly(cur[i].ToScreen(renderer.Factor));
			}
			renderer.AddPoly(game.CurrentLevel.World.Meshes["paddles"][0].ToScreen(renderer.Factor));
			renderer.AddPoly(game.CurrentLevel.World.Meshes["balls"][0].ToScreen(renderer.Factor));
			cur = game.CurrentLevel.World.Meshes["vectors"];
			for (int i = 0; i < cur.Count; i++) {
				renderer.AddPoly(cur[i].ToScreen(renderer.Factor));
			}
			cur.Clear();
			renderer.AddText(string.Format("Score: {0} Lives: {1} Level {2}   [MiddleMouse : level skip] [RightMouse : pause] [UP : speed up] [DOWN : slow down]", game.Score, game.Lives, game.LevelIndex+1), 0, 0, Color.Black.ToArgb());
			if (game.Paused) renderer.AddText("Game Paused, click the mouse to continue...", targetControl.ClientSize.Width/3, targetControl.ClientSize.Height/2, Color.White.ToArgb());
			if (collisions)	game.CurrentLevel.World.NextFrame(DT);
			if (!game.Paused) {
				if (game.CurrentLevel.Ball.Position.Y > game.CurrentLevel.Height * 1.05f) {
					game.LoseLife();
				}
			}
			renderer.EndScene();
			
		}
		
		static Random rand = new Random();
		public static Color RandomColor() {
			int r = rand.Next(0, 255), g = rand.Next(0, 255), b = rand.Next(0, 255);
			return Color.FromArgb(255, r, g, b);
		}
	}
}
