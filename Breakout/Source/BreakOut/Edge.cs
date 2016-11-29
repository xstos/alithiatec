using System;
using System.Collections.Generic;
using System.Text;

namespace BreakOut {
	public class Edge : IEquatable<Edge> {
		public P3 Head, Tail;
		public Mesh2D Parent;
		public Edge(P3 head, P3 tail) {
			Head = head; Tail = tail;
		}
		public Edge(P3 head, P3 tail, Mesh2D parent) {
			Head = head; Tail = tail; this.Parent = parent;
		}
		public V3 ToVector() {
			return new V3(Head, Tail);
		}
		public bool IsCollideableWith(Mesh2D target) {
			float d1 = MidPoint().SquaredDistanceTo(target.CenterOfGravity);
			float rad = Length() / 2F;
			float d2 = (rad*rad + target.BoundingRadiusSquared);
			return d1 < d2;
		}
		public bool IsCollideableWith(Edge target) {
			float d1 = MidPoint().SquaredDistanceTo(target.MidPoint());
			float ourrad = Length() / 2F;
			float targetrad = target.Length() / 2F;
			float d2 = (ourrad * ourrad + targetrad * targetrad);
			return d1 < d2;
		}
		public enum Result { Parallel, Coincident, NotIntersecting, Intersecting }
		public Result IntersectsWith(Edge other, out P3 intersectionPoint) {
			intersectionPoint = null;
			float denom = ((other.Tail.Y - other.Head.Y) * (Tail.X - Head.X)) - ((other.Tail.X - other.Head.X) * (Tail.Y - Head.Y));
			float numeA = ((other.Tail.X - other.Head.X) * (Head.Y - other.Head.Y)) - ((other.Tail.Y - other.Head.Y) * (Head.X - other.Head.X));
			float numeB = ((Tail.X - Head.X) * (Head.Y - other.Head.Y)) - ((Tail.Y - Head.Y) * (Head.X - other.Head.X));
			if (denom == 0) {
				if (numeA == 0 && numeB == 0) { //find out if coincident seg touches us
					V3 n = other.ToVector().Perpendicular2DLeftHanded().UnitVector;
					Edge perp = new Edge(other.Head + n, other.Head);
					Edge perp2 = new Edge(other.Tail+n, other.Tail);
					P3 o;
					if (Edge.Result.Intersecting == perp.IntersectsWith(this,out o)) {
						intersectionPoint = o;
						return Edge.Result.Intersecting;
					}
					if (Edge.Result.Intersecting == perp2.IntersectsWith(this,out o)) {
						intersectionPoint = o;
						return Edge.Result.Intersecting;
					}
					return Result.Coincident;
				}
				return Result.Parallel;
			}
			float ua = numeA / denom;
			float ub = numeB / denom;
			if (ua >= 0 && ua <= 1.0 && ub >= 0 && ub <= 1.0) {
				// Get the intersection point.
				intersectionPoint = V3.New(Head.X + ua * (Tail.X - Head.X), Head.Y + ua * (Tail.Y - Head.Y), 0);
				return Result.Intersecting;
			}
			return Result.NotIntersecting;
		}
		public Edge GetNormal2DAsEdgeRightHanded() {
			return new Edge(this.MidPoint() + GetNormal2DRightHanded(), this.MidPoint());
		}
		public V3 GetNormal2DRightHanded() {
			return ToVector().Perpendicular2DLeftHanded().Flip();
		}
		public override int GetHashCode() {
			return Head.GetHashCode() ^ Tail.GetHashCode();
		}
		public override bool Equals(object obj) {
			Edge e = obj as Edge;
			if (e == null) return false;
			return Equals(e);
		}
		public P3 MidPoint() {
			return Tail + (P3)(this.ToVector() * 0.5F);
		}
		public float Length() {
			return this.ToVector().Magnitude;
		}
		#region IEquatable<Edge> Members

		public bool Equals(Edge other) {
			return this.Head.Equals(other.Head) && this.Tail.Equals(other.Tail)
				|| this.Head.Equals(other.Tail) && this.Tail.Equals(other.Head);
		}
		#endregion
		private object tag;
		public object Tag {
			get { return tag; }
			set { tag = value; }
		}
	}
}
