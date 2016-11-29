using System;
using System.Collections.Generic;
using System.Text;

namespace BreakOut {
	public class P3 : IEquatable<P3> {
		public float X = 0, Y = 0, Z = 0;
		#region Constructors
		public P3() { }
		public static P3 Zero {
			get {
				return new P3();
			}
		}
		public P3(float x, float y, float z) {
			Set(x, y, z);
		}
		public P3(P3 v) {
			Set(v.X, v.Y, v.Z);
		}
		public static P3 New(float x, float y, float z) {
			return new P3(x, y, z);
		}
		public static P3 New(P3 p) {
			return new P3(p);
		}
		public static P3 New(float x, float y) {
			return new P3(x, y, 0);
		}
		#endregion
		public P3 Set(float x, float y, float z) {
			this.X = x;
			this.Y = y;
			this.Z = z;
			return this;
		}
		public P3 Set(P3 v) {
			return Set(v.X, v.Y, v.Z);
		}
		public float SquaredDistanceTo(P3 p) {
			float dx = X - p.X,dy=Y-p.Y,dz=Z-p.Z;
			return dx*dx + dy*dy + dz*dz;
		}
		public float DistanceTo(P3 p) {
			return new V3(this, p).Magnitude;
		}
		public P3 ScaleBy(float amount) {
			return Set(X * amount, Y * amount, Z * amount);
		}
		public P3 ScaleBy(float xAmount, float YAmount, float ZAmount) {
			return Set(X * xAmount, Y * YAmount, Z * ZAmount);
		}
		//public List<Edge> Parents = new List<Edge>();
		/// <summary>
		/// scales by the reciprocal of amount
		/// Exceptions: DivideByZeroException
		/// </summary>
		/// <returns></returns>
		public P3 ScaleByInv(float amount) {
			amount = 1.0F / amount;
			return ScaleBy(amount);
		}
		public void RotateBy2D(double angle) {
			Set((float)Math.Cos(angle) * X - (float)Math.Sin(angle) * Y, (float)Math.Cos(angle) * Y + (float)Math.Sin(angle) * X, 0);
		}
		public static P3 operator +(P3 a, P3 b) {
			return New(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}
		public static P3 operator +(P3 a, V3 b) {
			return New(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}
		public static P3 operator -(P3 a, P3 b) {
			return New(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}
		public static P3 operator -(P3 a) {
			return New(-a.X, -a.Y, -a.Z);
		}
		public static bool operator ==(P3 a, P3 b) {
			if ((object)a == null || (object)b == null) {
				return (object)a == (object)b;
			}
			return FloatEqual(a.X,b.X) && FloatEqual(a.Y,b.Y) && FloatEqual(a.Z,b.Z);
		}
		const float epsilon = 0.0001f;
		static bool FloatEqual(float a, float b) {
			return Math.Abs(a - b) < epsilon;
		}
		static bool FloatNotEqual(float a, float b) {
			return Math.Abs(a - b) >= epsilon;
		}
		public static bool operator !=(P3 a, P3 b) {
			if ((object)a == null || (object)b == null) {
				return (object)a != (object)b;
			}
			return FloatNotEqual(a.X, b.X) || FloatNotEqual(a.Y, b.Y) || FloatNotEqual(a.Z, b.Z);
		}
		public static P3 operator *(P3 v, float amount) {
			return v.Clone().ScaleBy(amount);
		}
		public static P3 operator /(P3 v, float amount) {
			return v.Clone().ScaleByInv(amount);
		}
		#region IEquatable<P3> Members
		public bool Equals(P3 other) {
			return (this == other);
		}
		#endregion
		public override bool Equals(object obj) {
			P3 v = obj as P3;
			if (v == null) return false;
			return Equals(v);
		}
		public override int GetHashCode() {
			return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
		}
		public static implicit operator System.Drawing.Point(P3 p) {
			return new System.Drawing.Point((int)p.X, (int)p.Y);
		}
		public static implicit operator System.Drawing.PointF(P3 p) {
			return new System.Drawing.PointF((float)p.X, (float)p.Y);
		}
		public P3 Clone() {
			return New(X, Y, Z);
		}
		public static P3[] Clone(P3[] array) {
			array = (P3[])array.Clone(); //copy array structure
			for (int i = 0; i < array.Length; i++) {
				array[i] = array[i].Clone(); //duplicate each ref variable
			}
			return array;
		}
		public static P3 Average(P3[] points) {
			float c=points.Length;
			float x = 0, y = 0, z = 0;
			for (int i = 0; i < c; i++) {
				x += points[i].X;
				y += points[i].Y;
				z += points[i].Z;
			}
			return new P3(x / c, y / c, z / c);
		}
		public static P3 Farthest(P3[] points, P3 from) {
			float maxRadSqSoFar = -1; float temp; int ix = 0;
			for (int i = 0; i < points.Length; i++) {
				temp = from.SquaredDistanceTo(points[i]);
				if (temp > maxRadSqSoFar) {
					maxRadSqSoFar = temp;
					ix = i;
				}
			}
			return points[ix];
		}
		public static P3 Closest(P3[] points, P3 to) {
			float minRadSqSoFar = float.MaxValue; float temp; int ix = 0;
			for (int i = 0; i < points.Length; i++) {
				temp = to.SquaredDistanceTo(points[i]);
				if (temp < minRadSqSoFar) {
					minRadSqSoFar = temp;
					ix = i;
				}
			}
			return points[ix];
		}
		public V3 ToV3() {
			return V3.New(this);
		}
		public override string ToString() {
			return string.Format("({0:#.###},{1:#.###},{2:#.###})", Math.Round(X, 3), Math.Round(Y, 3), Math.Round(Z, 3));
		}
	}
}