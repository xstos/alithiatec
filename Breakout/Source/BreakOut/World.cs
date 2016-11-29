using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace BreakOut {
	public class World {
		public Dictionary<string, List<Mesh2D>> Meshes = new Dictionary<string, List<Mesh2D>>();
		public Level Level;
		public World(Level parent) { Level = parent; }
		public void AddMesh(string key, Mesh2D mesh) {
			if (Meshes.ContainsKey(key)) {
				Meshes[key].Add(mesh);
			} else {
				Meshes.Add(key, new List<Mesh2D>(new Mesh2D[] { mesh }));
			}
		}
		Bag<Edge> AllEdges = new Bag<Edge>();

		public void RemoveMesh(string key, Mesh2D mesh) {
			Meshes[key].Remove(mesh);
		}
		public void NextFrame(float deltaTimeInSec) {
			ResolveCollisions2(deltaTimeInSec,true);
			
		}
		void Sleep(int ms) {
			System.Threading.Thread.Sleep(ms);
		}
		//1w to 0.625h
		
		/// <returns>true if a collision occured</returns>
		public void ResolveCollisions2(float deltaTimeInSec,bool moveNext) {
			List<Mesh2D> obstacles = new List<Mesh2D>();
			List<Mesh2D> collideable;
			obstacles.AddRange(Meshes["bricks"]);
			obstacles.AddRange(Meshes["walls"]);
			obstacles.AddRange(Meshes["paddles"]);
			Mesh2D next; Mesh2D projectile;
			for (int i = 0; i < Meshes["balls"].Count; i++) {
				projectile = Meshes["balls"][i];
				next = projectile.Clone();
				next.MoveNext(deltaTimeInSec);//AddVec(next.Trajectory(), Color.Blue);
				collideable = GetCollideable(next, obstacles); //find hittable meshes
				if (collideable.Count > 0) {
					List<Mesh2D> collided = GetCollidedMeshes(next, collideable);
					if (collided.Count > 0) {
						float d;
						Edge closest = GetCollisionEdge(next, projectile, collided, out d);
						if (closest != null) {
							projectile.DeflectAgainst(closest.GetNormal2DRightHanded().UnitVector);
							if (closest.Parent.Attributes.Get<string>("name") == "brick") {
								int hp=closest.Parent.Attributes.Get<int>("hitpoints");
								Level.Game.Score += 100* hp;
								hp--;
								if (hp==0) closest.Parent.Position = P3.New(2, 2);
								closest.Parent.Attributes["hitpoints"] = hp;
								Level.Game.Sound.PlaySFX("brickhit");
								Level.BricksLeft--;
								if (Level.BricksLeft == 0) Level.Game.NextLevel();
							} else if (closest.Parent.Attributes.Get<string>("name") == "wall" || closest.Parent.Attributes.Get<string>("name") == "paddle") {
								Level.Game.Sound.PlaySFX("wallhit");
							}
						} else {
							 if (moveNext) projectile.MoveNext(deltaTimeInSec);
						}
					} else { //collided.count==0
						if (moveNext) projectile.MoveNext(deltaTimeInSec);
					}
				} else { //if collideable.count==0
					if (moveNext) projectile.MoveNext(deltaTimeInSec);
				}
			}
		}
		public Edge GetCollisionEdge(Mesh2D next, Mesh2D projectile,List<Mesh2D> collided,out float distance) {
			//create rays leaving each vertex of the projectile in the direction of vel
			//intersect each edge with the target polygon edges and return the closest future bounce pos & deflection edge
			float rayLength = projectile.BoundingRadius * 5F + projectile.Position.DistanceTo(next.Position);
			V3 rayVel = projectile.Velocity.UnitVector * rayLength;
			Dictionary<Edge, float> raysOut = new Dictionary<Edge, float>();//we'll keep the min dist so far per ray in a dictionary
			Dictionary<Edge, float> raysIn = new Dictionary<Edge, float>();
			Edge ray;
			for (int j = 0; j < projectile.Vertices.Length; j++) {
				ray = new Edge(projectile.Vertices[j] + rayVel, projectile.Vertices[j]);//AddVec(ray, Color.Blue);
				if (!raysOut.ContainsKey(ray)) raysOut.Add(ray, float.MaxValue);
			}
			//for (int k = 0; k < collided.Count; k++) {
			//    for (int j = 0; j < collided[k].Vertices.Length; j++) {
			//        ray = new Edge(collided[k].Vertices[j] + rayVel.Clone().Flip(), collided[k].Vertices[j], collided[k]);
			//        if (!raysIn.ContainsKey(ray)) raysIn.Add(ray, float.MaxValue);//AddVec(ray, Color.Blue);
			//    }
			//}
			P3 isect;
			#region Projectile to Polygon
			float d; // iterate over each collided mesh edge and pick the closest intersection point (bounce pt)
			List<Edge> keys = new List<Edge>(raysOut.Keys);
			foreach (Edge edge in keys) {
				for (int k = 0; k < collided.Count; k++) {
					for (int j = 0; j < collided[k].Edges.Length; j++) {
						if (edge.IntersectsWith(collided[k].Edges[j], out isect) == Edge.Result.Intersecting) {
							d = edge.Tail.DistanceTo(isect);
							if (d < raysOut[edge]) {
								edge.Tag = collided[k].Edges[j];
								raysOut[edge] = d;
							}
						}
					}
				}
			}
			d = float.MaxValue; Edge closest = null;
			foreach (Edge edge in keys) {
				if (raysOut[edge] < d) {
					d = raysOut[edge];
					closest = edge;
				}
			}
			#endregion
			//float d2;
			//keys = new List<Edge>(raysIn.Keys);
			//foreach (Edge edge in keys) {
			//    for (int j = 0; j < projectile.Edges.Length; j++) {
			//        if (edge.IntersectsWith(projectile.Edges[j], out isect) == Edge.Result.Intersecting) {
			//            d2 = edge.Tail.DistanceTo(isect);
			//            if (d2 < raysIn[edge]) {
			//                raysIn[edge] = d2; //this is useless for now since we don't know what edges the vertex is attached to
			//            }
			//        }
			//    }
			//}
			//d2 = d;
			//foreach (Edge edge in keys) {
			//    if (raysIn[edge] < d2) {
			//        d2 = raysIn[edge];
			//    }
			//}
			distance = d;
			return (Edge)closest.Tag;
		}
		List<Mesh2D> GetCollidedMeshes(Mesh2D projectile, List<Mesh2D> collideable) {
			List<Mesh2D> results = new List<Mesh2D>();
			for (int i = 0; i < collideable.Count; i++) {
				if (projectile.Intersects(collideable[i])) {
					results.Add(collideable[i]);
				}
			}
			return results;
		}

		List<Edge> GetCollideable(Mesh2D projectile, List<Edge> candidates) {
			List<Edge> found = new List<Edge>();
			for (int i = 0; i < candidates.Count; i++) {
				if (candidates[i].IsCollideableWith(projectile)) {
					found.Add(candidates[i]);
				}
			}
			return found;
		}
		List<Mesh2D> GetCollideable(Mesh2D target, List<Mesh2D> candidates) {
			List<Mesh2D> found = new List<Mesh2D>();
			for (int i = 0; i < candidates.Count; i++) {
				if (target.IsCollideableWith(candidates[i])) {
					found.Add(candidates[i]);
				}
			}
			return found;
		}
		
		public void AddVec(Edge e, Color c) {
			Mesh2D sideV = Mesh2D.Vector(e, 0.002F);
			sideV.Color = c;
			//System.Threading.Thread.Sleep(10);
			AddMesh("vectors", sideV);
		}

	}
}
