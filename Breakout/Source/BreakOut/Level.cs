using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace BreakOut {
	public class Level {

		public Mesh2D Paddle, Ball;
		public World World;
		public Game Game;
		string[][] data;
		public float BrickWidth, BrickHeight, PaddleStop;
		public int BricksLeft;
		public float Width, Height;
		static Random r = new Random();
		public void ResetBall() {
			Ball.Position = new P3(Width / 2F, Height - BrickHeight, 0);
			Ball.Velocity= new V3(new P3((float)r.NextDouble() * Width, Height / 2F, 0), Ball.Position); //set random init direction
			Ball.Velocity.Magnitude = 1.0F;
		}
		public Level(Game parent, string[][] data) {
			Game = parent;
			World = new World(this);
			buildHpColors();
			this.data = data;
			float pwid, ph; int nrows, ncols;
			Width = 1.0F;
			Height = 0.625F;
			nrows = data.Length;
			ncols = data[0].Length;
			BrickWidth = Width / (float)ncols; //100%
			BrickHeight = Height / (float)nrows; //100%
			pwid = Width * 0.1F; ph = Height * 0.15F;
			Paddle = Mesh2D.Paddle(new P3(-pwid / 2F, -ph / 2.0F, 0), pwid, ph, new P3(Width / 2.0F, Height - ph / 2F, 0), 0.98f);
			Paddle.Color = Color.Blue;
			CreatePaddle(Paddle);
			World.AddMesh("paddles",Paddle);
			PaddleStop = BrickWidth + pwid / 2F;
			World.Meshes.Add("vectors", new List<Mesh2D>());
			P3 ballStart = new P3(Width / 2F, Height - BrickHeight, 0);
			V3 vel = new V3(new P3((float)r.NextDouble() * Width, Height / 2F, 0), ballStart); //set random init direction
			vel.Magnitude = 1.0F;
			Ball = Mesh2D.Ball(Width / 200.0F, ballStart, vel);
			CreateBall(Ball);
			World.AddMesh("balls", Ball);
			string type;
			Mesh2D m;
			for (int i = 0; i < data.Length; i++) {
				for (int j = 0; j < data[i].Length; j++) {
					m = Mesh2D.Rectangle(P3.Zero, BrickWidth, BrickHeight, P3.New(BrickWidth * j, BrickHeight * i));
					type = data[i][j];
					if (type == "W") {
						CreateWall(m);
						World.AddMesh("walls", m);
						continue;
					}
					int hp=int.Parse(type);
					if (hp==0) continue;
					CreateBrick(m, hp);
					BricksLeft++;
					World.AddMesh("bricks",m);
				}
			}

		}
		static Random rand = new Random();
		public static Color RandomColor() {
			int r = rand.Next(0, 255), g = rand.Next(0, 255), b = rand.Next(0, 255);
			return Color.FromArgb(255, r, g, b);
		}
		public static Color RandomBlue() {
			int r =0, g = 0, b = rand.Next(100, 255);
			return Color.FromArgb(255, r, g, b);
		}
		public static Color RandomGreen() {
			int r = 0, g = rand.Next(100, 255), b = 0;
			return Color.FromArgb(255, r, g, b);
		}
		public static Color RandomRed() {
			int r = rand.Next(100, 255), g = 0, b = 0;
			return Color.FromArgb(255, r, g, b);
		}
		Color[] hp = new Color[10];
		void buildHpColors() {
			for (int i = 0; i < hp.Length; i++) {
				hp[i] = RandomColor();
			}
		}
		public void CreateBrick(Mesh2D mesh,int hitpoints) {
			Attributes a = mesh.Attributes;
			a["hitpoints"] = hitpoints;
			a["destroyable"] = true;
			a["name"] = "brick";
			if (hitpoints==1) mesh.Color = RandomBlue();
			else if (hitpoints == 2) mesh.Color = RandomGreen();
			else mesh.Color = RandomRed();
		}
		Color wc = Color.Gainsboro;
		public void CreateWall(Mesh2D mesh) {
			Attributes a = mesh.Attributes;
			a["name"] = "wall";
			mesh.Color = wc;
		}
		public void CreatePaddle(Mesh2D mesh) {
			Attributes a = mesh.Attributes;
			a["name"] = "paddle";
			mesh.Color = Color.White;
		}
		public void CreateBall(Mesh2D mesh) {
			Attributes a = mesh.Attributes;
			a["projectile"] = true;
			a["name"] = "ball";
			mesh.Color = Color.Red;
		}
		public Level Clone() {
			return new Level(Game,data);
		}
	}
}
