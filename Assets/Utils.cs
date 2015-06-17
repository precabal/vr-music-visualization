using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Utils
	{
		public Utils ()
		{
		}
		public static Vector3 SphericalToCartesian(VectorSpherical pointInShperical)
		{
			float x = pointInShperical.r * (float) Math.Cos (pointInShperical.theta) * (float) Math.Cos (pointInShperical.phi);
			float y = pointInShperical.r * (float) Math.Sin (pointInShperical.theta);
			float z = pointInShperical.r * (float) Math.Cos (pointInShperical.theta) * (float) Math.Sin (pointInShperical.phi);

			return new Vector3 (x, y, z);

		}

		public static VectorSpherical CartesianToSpherical(Vector3 pointInCartesian)
		{
			float elevation = (float) Math.Asin (pointInCartesian.y / pointInCartesian.magnitude);	
			float azimuth = (float)  Math.Atan2 (pointInCartesian.z, pointInCartesian.x);



			return new VectorSpherical(pointInCartesian.magnitude, elevation, azimuth);
		}

	}
}
