using System;
using System.Collections.Generic;
using System.Text;

namespace BreakOut {
	class BS {
		// Inputs: plane origin, plane normal, ray origin ray vector.
		// NOTE: both vectors are assumed to be normalized
		float intersect(P3 planeOrigin, V3 planeNormal, P3 rayOrigin, V3 rayVector) {
			float d = -(planeNormal * planeOrigin.ToV3());
			float numer = (planeNormal * rayOrigin.ToV3()) + d;
			float denom = (planeNormal * rayVector);
			return -(numer / denom);
		}
		//(the inputs are the ray’s origin and normalized direction vector, as well as the sphere’s origin and radius)
		float intersectSphere(P3 rO, V3 rV, P3 sO, float sR) {
			V3 Q = new V3(sO, rO);
			float c = Q.Magnitude; // length of Q;
			float v = Q * rV;
			float d = sR * sR - (c * c - v * v);

			// If there was no intersection, return -1
			if (d < 0.0F) return -1.0F;
			// Return the distance to the [first] intersecting point
			return v - (float)Math.Sqrt(d);
		}
		//http://www.gamedev.net/reference/articles/article1026.asp
		void collideWithWorld(Mesh2D projectile, float deltaTimeInSec) {
			P3 sourcePoint = projectile.Position;
			V3 velocityVector = projectile.Velocity.Clone() * deltaTimeInSec;
			// How far do we need to go?
			float distanceToTravel = velocityVector.Magnitude; //length of velocityVector;
			// Do we need to bother?
			if (distanceToTravel < float.Epsilon) return;
			// What's our destination?
			P3 destinationPoint = sourcePoint + velocityVector;
			// Whom might we collide with?
			List<Mesh2D> potentialColliders=null; //= GetObstacles(projectile);
			// If there are none, we can safely move to the destination and bail
			if (potentialColliders.Count == 0) {
				projectile.MoveNext(deltaTimeInSec);
				return;
			}
			// Determine the nearest collider from the list potentialColliders
			bool firstTimeThrough = true;
			float nearestDistance = -1.0F;
			Mesh2D nearestCollider = null;
			P3 nearestIntersectionPoint = null;
			P3 nearestPolygonIntersectionPoint = null;
			for (int i = 0; i < potentialColliders.Count; i++) {
				// Plane origin/normal
				P3 pOrigin = potentialColliders[i].Vertices[0]; //any vertex from the current polygon;
				V3 pNormal = potentialColliders[i].Edges[0].GetNormal2DRightHanded().UnitVector; //surface normal from the current polygon;
				// Determine the distance from the plane to the source
				float pDist = intersect(sourcePoint, -pNormal, pOrigin, pNormal);
				//P3 sphereIntersectionPoint;
				P3 planeIntersectionPoint;
				// The radius of the ellipsoid (in the direction of pNormal)
				//V3 directionalRadius = -pNormal * new V3(projectile.BoundingRadius, projectile.BoundingRadius, 0);
				float radius = projectile.BoundingRadius; //directionalRadius.Magnitude;
				// Is the plane embedded?
				if (Math.Abs(pDist) <= radius) {
					// Calculate the plane intersection point
					V3 pN = -pNormal;
					pN.Magnitude = pDist; //-pNormal with length set to pDist
					planeIntersectionPoint = sourcePoint + pN;
				} else {
					// Calculate the ellipsoid intersection point
					V3 pN = -pNormal;
					pN.Magnitude = radius; //-pNormal with length set to radius
					P3 ellipsoidIntersectionPoint = sourcePoint + pN;
					// Calculate the plane intersection point
					//Ray    ray(sphereIntersectionPoint, Velocity);
					float tt = intersect(ellipsoidIntersectionPoint, velocityVector, pOrigin, pNormal);
					// Calculate the plane intersection point
					V3 VV = velocityVector.Clone();
					VV.Magnitude = tt; // velocityVector with length set to t;
					planeIntersectionPoint = ellipsoidIntersectionPoint + VV;
				}
				// Unless otherwise stated, our polygonIntersectionPoint is the
				// same point as planeIntersectionPoint

				P3 polygonIntersectionPoint = planeIntersectionPoint.Clone();
				// So… are they the same?
				if (!potentialColliders[i].Contains(planeIntersectionPoint)) { //planeIntersectionPoint is not within the current polygon) 
					polygonIntersectionPoint = P3.Closest(potentialColliders[i].Vertices, planeIntersectionPoint); //nearest point on polygon's perimeter to planeIntersectionPoint;
				}
				// Invert the velocity vector
				V3 negativeVelocityVector = -velocityVector;
				// Using the polygonIntersectionPoint, we need to reverse-intersect
				// with the ellipsoid
				float t = intersectSphere(polygonIntersectionPoint, negativeVelocityVector, sourcePoint, projectile.BoundingRadius);
				// Was there an intersection with the ellipsoid?
				if (t >= 0.0F && t <= distanceToTravel) {
					V3 VV = negativeVelocityVector.Clone(); //negativeVelocityVector with length set to t;
					VV.Magnitude = t;
					// Where did we intersect the ellipsoid?
					V3 intersectionPoint = (polygonIntersectionPoint + VV).ToV3();
					// Closest intersection thus far?
					if (firstTimeThrough || t < nearestDistance) {
						nearestDistance = t;
						nearestCollider = potentialColliders[i];
						nearestIntersectionPoint = intersectionPoint;
						nearestPolygonIntersectionPoint = polygonIntersectionPoint;
						firstTimeThrough = false;
					}
				}
			}
			// If we never found a collision, we can safely move to the destination
			// and bail
			if (firstTimeThrough) {
				projectile.MoveNext(deltaTimeInSec);
				return;
			}
			// Move to the nearest collision
			V3 V = velocityVector.Clone(); //velocityVector with length set to (nearestDistance - EPSILON);
			V.Magnitude = nearestDistance;
			sourcePoint = sourcePoint + V;

			// Determine the sliding plane (we do this now, because we're about to
			// change sourcePoint)
			P3 slidePlaneOrigin = nearestPolygonIntersectionPoint;
			V3 slidePlaneNormal = new V3(nearestPolygonIntersectionPoint, sourcePoint);
			// We now project the destination point onto the sliding plane
			float time = intersect(destinationPoint, slidePlaneNormal, slidePlaneOrigin, slidePlaneNormal);
			//Set length of slidePlaneNormal to time;
			V3 destinationProjectionNormal = slidePlaneNormal;
			P3 newDestinationPoint = destinationPoint + destinationProjectionNormal;
			// Generate the slide vector, which will become our new velocity vector
			// for the next iteration
			V3 newVelocityVector = new V3(newDestinationPoint, nearestPolygonIntersectionPoint);
			// Recursively slide (without adding gravity)
			projectile.Position = sourcePoint;
			projectile.Velocity = newVelocityVector;
			collideWithWorld(projectile, deltaTimeInSec);
		}
	}
}
