using System;
using System.Collections.Generic;
using System.Text;

namespace BreakOut {
	public partial class Mesh2D {
		static double[] paddleVerts = new double[] { //made these in excel to define the paddle curve
			0,0.031781446,0.058453773,0.08113891,0.100585154,0.117316578,0.1317136,0.144059691,0.154570025,0.163409831,0.170706555,0.17655812,0.181038625,
0.184202289,0.186086132,0.186711719,0.186086132,0.184202289,0.181038625,0.17655812,0.170706555,0.163409831,0.154570025,0.144059691,0.1317136,0.117316578,0.100585154,
0.08113891,0.058453773,0.031781446,0};
		public static Mesh2D Paddle(P3 topLeft, float width, float height, P3 position, float roofPct) {
			P3[] vertices = new P3[paddleVerts.Length + 2];

			int i; float dx = width / (paddleVerts.Length - 1), dy = roofPct * height;
			for (i = 0; i < paddleVerts.Length; i++) {
				vertices[i] = V3.New(topLeft.X + dx * i, topLeft.Y + dy * (1 - (float)paddleVerts[i]), 0);
			}
			vertices[i] = new V3(topLeft.X + width, topLeft.Y + height, 0); //br
			vertices[i + 1] = new V3(topLeft.X, topLeft.Y + height, 0); //bl
			return new Mesh2D(vertices, position);
		}
		public static Mesh2D Rectangle(P3 topLeft, float width, float height, P3 position) {
			P3[] vertices = new P3[4];
			vertices[0] = topLeft;
			vertices[1] = new P3(topLeft.X + width, topLeft.Y, 0); //tr
			vertices[2] = new P3(topLeft.X + width, topLeft.Y + height, 0); //br
			vertices[3] = new P3(topLeft.X, topLeft.Y + height, 0); //bl
			return new Mesh2D(vertices, position);
		}
		public static Mesh2D Circle(float radius, int numPoints, P3 position) {
			float theta = 2.0F * (float)(Math.PI / (double)numPoints); //2*pi rad
			P3[] vertices = new P3[numPoints];
			for (int i = 0; i < numPoints; i++) {
				vertices[i] = new P3((float)Math.Cos(i * theta) * radius, (float)Math.Sin(i * theta) * radius, 0);
			}
			return new Mesh2D(vertices, position);
		}
		public static Mesh2D Ball(float radius, P3 position, V3 velocity) {
			Mesh2D c = Mesh2D.Circle(radius, 16, position);
			c.Velocity = velocity;
			return c;
		}
		public static Mesh2D Vector(V3 direction, P3 position, float width) {
			P3[] vertices = new P3[3];
			V3 perp = direction.Perpendicular2DLeftHanded();
			perp.Magnitude=width;
			V3 perp2 = perp.Clone().Flip();
			vertices[0] = direction.ToPoint();
			vertices[2] = perp.ToPoint();
			vertices[1] = perp2.ToPoint();
			Mesh2D c = new Mesh2D(vertices, position);
			c.Color = System.Drawing.Color.Magenta;
			return c;
		}
		public static Mesh2D Vector(Edge e, float width) {
			return Vector(e.ToVector(),e.Tail,width);
		}
	}
}
