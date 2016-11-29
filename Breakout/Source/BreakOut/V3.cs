using System;
using System.Collections.Generic;
using System.Text;

namespace BreakOut {
	/// <remarks>
	/// * operator is cross product when 2 input vectors
	/// ^ operator is dot product when 2 input vectors
	/// </remarks>
	public class V3 : P3 {
		#region Constructors
		public V3(V3 v) : base((P3)v) { }
		public V3(P3 v) : base(v) { }
		public V3(float x, float y, float z) : base(x, y, z) { }
		public V3(P3 head, P3 tail) {
			Set(head.X - tail.X, head.Y - tail.Y, head.Z - tail.Z);
		}

		public static V3 New(Edge edge) {
			return new V3(edge.Head, edge.Tail);
		}
		public static V3 New(V3 v) {
			return new V3(v);
		}
		public static new V3 New(P3 p) {
			return new V3(p);
		}
		#endregion

		public V3 UnitVector {
			get {
				float magInv = (float)(1.0 / (double)Magnitude);
				return new V3(X * magInv, Y * magInv, Z * magInv);
			} //faster to mult
		}
		public void Normalize() {
			this.Magnitude = 1.0F;
		}
		public static float Mag(float x, float y, float z) { //rename to distance to origin
			return (float)Math.Sqrt(x * x + y * y + z * z);
		}
		public static float Mag(V3 v) { //rename to distance to origin
			return (float)Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
		}
		public float Magnitude {
			get { return V3.Mag(X, Y, Z); }
			set {
				Set(UnitVector * (float)Math.Abs(value));
			}
		}
		public V3 Perpendicular2DLeftHanded() {
			return new V3(Y, -X, 0);
		}
		public static V3 Perpendicular2DLeftHanded(V3 v) {
			return new V3(v.Y, -v.X, 0);
		}

		public static V3 CrossProduct(V3 a, V3 b) {
			return new V3(a.Y * b.Z - a.Z * b.Y, a.Z * b.X - a.X * b.Z, a.X * b.Y - a.Y * b.X);
		}
		public void CrossProduct(V3 other) {
			V3.CrossProduct(this, other);
		}

		public static float operator *(V3 v1, V3 v2) {
			return DotProduct(v1, v2);
		}
		public float DotProduct(V3 other) {
			return DotProduct(this, other);
		}
		public static float DotProduct(V3 v1, V3 v2) {
			return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z; //dot product
		}
		public static V3 operator ^(V3 a, V3 b) { //cross product
			return CrossProduct(a, b);
		}
		public static V3 operator *(V3 v, float number) {
			return (V3)v.Clone().ScaleBy(number);
		}
		public static V3 operator -(V3 v) {
			return v.Clone().Flip();
		}
		public static V3 operator -(V3 a, V3 b) {
			return (a + (-b)).ToV3();
		}
		public float AngleBetween(V3 v) {
			if (this.Magnitude == 0 || v.Magnitude == 0) return 0;
			return (float)Math.Acos((this.UnitVector * v.UnitVector));
		}
		float theta;
		const float PiBy2 = (float)Math.PI / 2.0F;
		public float AngleBetweenFirstQuadrant(V3 v) {
			theta = AngleBetween(v);
			if (theta > PiBy2) return theta - PiBy2;
			else return theta;
		}
		public bool IsOrthogonalTo(V3 v) {
			if (this.AngleBetween(v) == (Math.PI / 2D)) return true;
			else return false;
		}
		public bool IsOrthogonalTo(V3 v, float epsilon) {
			if (Math.Abs(this.AngleBetween(v) - (Math.PI / 2D)) < epsilon)
				return true;
			else return false;
		}

		public void ProjectOnTo(V3 v) {
			float d = ProjectionDistance(v);
			this.Set(v.UnitVector * d);
		}
		public V3 Project(V3 v) {
			this.ProjectOnTo(v);
			return this;
		}
		public float ProjectionDistance(V3 v) {
			return (this * v.UnitVector);
		}
		public override string ToString() {
			return string.Format("({0:#.###},{1:#.###},{2:#.###})", Math.Round(X, 3), Math.Round(Y, 3), Math.Round(Z, 3));
		}
		public V3 Flip() {
			Set(-X, -Y, -Z);
			return this;
		}
		public P3 ToPoint() {
			return New(this);
		}
		public new V3 Clone() {
			return (V3)New(this);
		}
		public static V3[] Clone(V3[] array) {
			array = (V3[])array.Clone(); //shallow copy array structure
			for (int i = 0; i < array.Length; i++) {
				array[i] = array[i].Clone(); //duplicate each ref variable
			}
			return array;
		}
		/// <summary>
		/// represented as x1,y1,z1;x2,y2,z2;...;xn,yn,zn
		/// </summary>
		/// <param name="vectors"></param>
		/// <returns></returns>
		public static V3[] TryParse(string vectors) {
			try {
				string[] vectorarray = vectors.Split(';');
				V3[] vector3array = new V3[vectorarray.Length];
				for (int i = 0; i < vectorarray.Length; i++) {
					vector3array[i] = TryParseSingle(vectorarray[i]);
				}
				return vector3array;
			} catch { return null; }
		}
		/// <summary>
		/// represented as x,y,z
		/// </summary>
		/// <param name="vector"></param>
		/// <returns></returns>
		private static V3 TryParseSingle(string vector) {
			try {
				string[] coords = vector.Split(',');
				return new V3((float)Convert.ToDouble(coords[0]), (float)Convert.ToDouble(coords[1]), (float)Convert.ToDouble(coords[2]));
			} catch { return null; }
		}
		private static Random r = new Random();
		public static V3 Random() {
			float r1, r2, r3, z;
			do {
				r1 = 1F - 2F * (float)r.NextDouble(); r2 = 1F - 2F * (float)r.NextDouble(); r3 = 1F - 2F * (float)r.NextDouble();
				z = r1 + r2 + r3;
			} while (z >= 1);
			z = 1F / z;
			return new V3(r1 * z, r2 * z, r3 * z);
		}
	}

}
