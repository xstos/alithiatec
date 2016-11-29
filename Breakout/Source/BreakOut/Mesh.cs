using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.DirectX.Direct3D;
using System.Drawing;
namespace BreakOut {
	public partial class Mesh2D {
		P3[] relativeVertices;
		public Mesh2D(P3[] relativeVertices, P3 position) {
			Init(relativeVertices, position);
		}
		private Color color = Color.White;
		public Color Color {
			get { return color; }
			set { color = value; }
		}
		public Edge Trajectory() {
			return new Edge(Velocity.UnitVector * this.BoundingRadius * 15F + Position, Position);
		}
		void Init(P3[] relativeVertices, P3 position) {
			if (relativeVertices.Length < 3) throw new Exception("need at least 3 pts for a poly");
			relativeVertices = P3.Clone(relativeVertices);
			this.relativeVertices = relativeVertices;
			this.position = position;
			cache();
		}
		void cache() {
			dirty = true;
			buildVertices();
			buildEdges();
			centerOfGravity = P3.Average(vertices.ToArray());
			boundingRadiusSquared = centerOfGravity.SquaredDistanceTo(P3.Farthest(vertices.ToArray(), centerOfGravity));
		}
		public float BoundingRadius {
			get { return (float)Math.Sqrt(boundingRadiusSquared); }
		}
		private P3 centerOfGravity;
		public P3 CenterOfGravity {
			get { return centerOfGravity; }
		}
		private float boundingRadiusSquared;
		public float BoundingRadiusSquared {
			get { return boundingRadiusSquared; }
		}
		private P3 position;
		public P3 Position {
			get { return position; }
			set {
				position = value;
				cache();
			}
		}
		private V3 velocity=new V3(0,0,0);
		/// <summary>
		/// in world units/sec
		/// </summary>
		public V3 Velocity {
			get { return velocity; }
			set { velocity = value; }
		}
		List<P3> vertices = new List<P3>();
		public P3[] Vertices {
			get { return vertices.ToArray(); }
		}
		void buildVertices() {
			vertices.Clear();
			vertices.AddRange(GenerateVertices());
		}
		List<Edge> edges = new List<Edge>();
		public Edge[] Edges {
			get { return edges.ToArray(); }
		}
		void buildEdges() {
			edges.Clear();
			int l = vertices.Count;
			Edge e;
			//for (int i = 0; i < vertices.Count; i++) {
			//    vertices[i].Parents.Clear();
			//}
			for (int i = 0; i < l; i++) {
				e = new Edge(vertices[i], vertices[(i + 1) % l], this);
				//vertices[i].Parents.Add(e);
				//vertices[(i + 1) % l].Parents.Add(e);
				edges.Add(e);

			}
		}
		P3[] GenerateVertices() {
			P3[] pts = new P3[relativeVertices.Length];
			for (int i = 0; i < pts.Length; i++) {
				pts[i] = relativeVertices[i] + Position;
			}
			return pts;
		}
		private object tag;
		public object Tag {
			get { return tag; }
			set { tag = value; }
		}
		private Attributes attrib = new Attributes();
		public Attributes Attributes {
			get { return attrib; }
		}

		public bool IsCollideableWith(Mesh2D target) {
			float d1 = centerOfGravity.SquaredDistanceTo(target.centerOfGravity);
			float d2 = (boundingRadiusSquared + target.boundingRadiusSquared);
			return d1 < d2 * 4F;
		}
		public List<Edge> CollidesWith(Mesh2D other) {
			int tec = other.edges.Count; P3 var;
			List<Edge> collided = new List<Edge>();
			for (int i = 0; i < edges.Count; i++) {
				for (int j = 0; j < tec; j++) {
					if (edges[i].IntersectsWith(other.edges[j], out var) == Edge.Result.Intersecting) {
						edges[i].Tag = var;
						collided.Add(edges[i]);
					}
				}
			}
			return collided;
		}
		public bool Intersects(Mesh2D other) {
			int tec = other.edges.Count; P3 var;
			for (int i = 0; i < edges.Count; i++) {
				for (int j = 0; j < tec; j++) {
					if (edges[i].IntersectsWith(other.edges[j], out var) == Edge.Result.Intersecting) {
						return true;
					}
				}
			}
			return false;
		}
		public bool IsMoving() {
			return !velocity.Equals(P3.Zero);
		}
		public bool Contains(P3[] points) {
			int numverts = vertices.Count;
			float[] xp = new float[numverts];
			float[] yp = new float[numverts];
			for (int i = 0; i < numverts; i++) {
				xp[i] = vertices[i].X;
				yp[i] = vertices[i].Y;
			}
			for (int i = 0; i < points.Length; i++) {
				if (pnpoly(numverts, xp, yp, points[i].X, points[i].Y)) return true;
			}
			return false;
		}
		public bool Contains(P3 point) {
			int numverts = vertices.Count;
			float[] xp = new float[numverts];
			float[] yp = new float[numverts];
			for (int i = 0; i < numverts; i++) {
				xp[i] = vertices[i].X;
				yp[i] = vertices[i].Y;
			}
			return pnpoly(numverts, xp, yp, point.X, point.Y);
		}
		// lifted from http://www.ecse.rpi.edu/Homepages/wrf/Research/Short_Notes/pnpoly.html
		static bool pnpoly(int npol, float[] xp, float[] yp, float x, float y) {
			int i, j; bool c = false;
			for (i = 0, j = npol - 1; i < npol; j = i++) {
				if ((((yp[i] <= y) && (y < yp[j])) || ((yp[j] <= y) && (y < yp[i]))) && (x < (xp[j] - xp[i]) * (y - yp[i]) / (yp[j] - yp[i]) + xp[i]))
					c = !c;
			}
			return c;
		}
		bool dirty = true;
		CustomVertex.TransformedColored[] cachedScreenPts;
		float oldScalefactor = 0;
		public CustomVertex.TransformedColored[] ToScreen(float scaleFactor, Color color) {
			if (!dirty && oldScalefactor == scaleFactor) return cachedScreenPts;
			oldScalefactor = scaleFactor;
			dirty = false;
			int nv = vertices.Count;
			cachedScreenPts = new CustomVertex.TransformedColored[nv + 2]; //center pt + closed poly
			cachedScreenPts[0] = Make(centerOfGravity.Clone().ScaleBy(scaleFactor), Jitter(color, 5));
			for (int i = 0; i < nv + 1; i++) {
				cachedScreenPts[i + 1] = Make(vertices[i % nv].Clone().ScaleBy(scaleFactor), Jitter(color, 5));
			}
			return cachedScreenPts;
		}
		static Random random = new Random();
		public static Color Jitter(Color input, int delta) {
			int r = random.Next(input.R - delta, input.R + delta);
			int g = random.Next(input.G - delta, input.G + delta);
			int b = random.Next(input.B - delta, input.B + delta);
			if (r > 255) r = 255; if (r < 0) r = 0;
			if (g > 255) g = 255; if (g < 0) g = 0;
			if (b > 255) b = 255; if (b < 0) b = 0;
			return Color.FromArgb(r, g, b);
		}
		public CustomVertex.TransformedColored[] ToScreen(float scaleFactor) {
			return ToScreen(scaleFactor, this.color);
		}
		CustomVertex.TransformedColored Make(P3 point, Color color) {
			return new CustomVertex.TransformedColored(point.X, point.Y, point.Z, 1F, color.ToArgb());
		}
		CustomVertex.TransformedColored Make(float x, float y, float z, Color color) {
			return new CustomVertex.TransformedColored(x, y, z, 1F, color.ToArgb());
		}
		/// <summary>
		/// returns the new position after a 'deltaTimeInSec'-long time increment
		/// </summary>
		public P3 NextPoint(float deltaTimeInSec) {
			V3 distance = Velocity * deltaTimeInSec; //d=vt (*=scalar mult)
			return position + distance;
		}
		/// <summary>
		/// moves the mesh to its new position after a 'deltaTimeInSec'-long time increment
		/// </summary>
		public void MoveNext(float deltaTimeInSec) {
			this.Position = NextPoint(deltaTimeInSec);
		}
		public void DeflectAgainst(Edge edge) {
			V3 V = Velocity.Clone();
			V3 N = edge.GetNormal2DRightHanded();
			float dot = (V * N) * 2F;
			V3 vec = (V3)N.ScaleBy(dot);
			V3 newvel = Velocity - vec;
			Velocity = newvel;
		}
		public void DeflectAgainst(V3 normal) {
			V3 V = Velocity.Clone();
			V3 N = normal;
			float dot = (V * N) * 2F;
			V3 vec = (V3)N.ScaleBy(dot);
			V3 newvel = Velocity - vec;
			Velocity = newvel;
		}
		public override string ToString() {
			string[] res = new string[vertices.Count];
			for (int i = 0; i < vertices.Count; i++) {
				res[i] = vertices[i].ToString();
			}
			return string.Join(" ", res);
		}

		Mesh2D trash;
		public Mesh2D Clone() {
			trash = new Mesh2D(P3.Clone(relativeVertices), position.Clone());
			trash.velocity = this.velocity.Clone();
			return trash;
		}
	}
}
