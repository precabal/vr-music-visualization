using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp
{
	public class ObjectFactory
	{
		public GameObject CreateCube()
		{
			return GameObject.CreatePrimitive(PrimitiveType.Cube);
		}

		public GameObject CreateSphere()
		{
			return GameObject.CreatePrimitive(PrimitiveType.Sphere);
		}

		public static GameObject CreateFromPrefab(GameObject objectPrefab, Vector3 atPosition, String withTag, float withScale=0.0f)
		{
			GameObject result = MonoBehaviour.Instantiate (objectPrefab, atPosition, Quaternion.identity) as GameObject;
			result.transform.localScale += new Vector3(withScale, withScale, withScale);
			result.tag = withTag;
			return result;
		}

		public GameObject CreateFromPrefab(GameObject objectPrefab)
		{
			return MonoBehaviour.Instantiate (objectPrefab, new Vector3(0,0,0), Quaternion.identity) as GameObject;
		}
		public static List<GameObject> InitializeRandomSpheres(int numberOfSpheres=100, float length=100f, Vector3 center = default(Vector3))
		{
			List<GameObject> shperes = new List<GameObject> ();
		
			GameObject _spherePrefab = Resources.Load("sphere_prefab") as GameObject;
			
			System.Random random = new System.Random();

			Vector3 position;
			for (int i = 0; i < numberOfSpheres; i++)
			{
				position = new Vector3(0.5f * ((float)random.NextDouble()  - 0.5f) , (float)random.NextDouble(), 0.5f * ((float)random.NextDouble()  - 0.5f));
				position *= length;
				position += center;

				//scale goes between [-0.27, 0.63) 
				float scale = 0.9f*((float)random.NextDouble() - 0.3f);
				
				GameObject sphere = CreateFromPrefab(_spherePrefab, position, "spheres", scale);
				shperes.Add(sphere);
			}

			return shperes;
			
			//TODO: see if we can unload asset here: Resources.UnloadAsset(_spherePrefab);
			
		}

		public static List<GameObject> InitializeRandomSpheresInSphere(Vector3 centerPoint = default(Vector3),
		                                                               int numberOfSpheres=100, 
		                                                               float thickness = 2f,
		                                                               float azimuthWidthDegrees = 20f,
		                                                               float elevationWidthDegrees =80f
		                                                               )
		{
			List<GameObject> shperes = new List<GameObject> ();
			
			GameObject _spherePrefab = Resources.Load("sphere_prefab") as GameObject;
			
			System.Random random = new System.Random();

			Vector3 positionCartesian;
			VectorSpherical positionSpherical = Utils.CartesianToSpherical (centerPoint);
			VectorSpherical tempVector;

			for (int i = 0; i < numberOfSpheres; i++)
			{

				tempVector.r =  thickness*((float)random.NextDouble()  - 0.5f);
				tempVector.theta =  (float)Math.PI*elevationWidthDegrees*((float)random.NextDouble()  - 0.5f)/180f;
				tempVector.phi = (float)Math.PI*azimuthWidthDegrees*((float)random.NextDouble()  - 0.5f)/180f;

				tempVector.r += positionSpherical.r;
				tempVector.theta += positionSpherical.theta;
				tempVector.phi += positionSpherical.phi;

				positionCartesian = Utils.SphericalToCartesian(tempVector);



				//scale goes between [-0.27, 0.63) 
				float scale = 0.9f*((float)random.NextDouble() - 0.3f);
				
				GameObject sphere = CreateFromPrefab(_spherePrefab, positionCartesian, "spheres", scale);
				shperes.Add(sphere);
			}
			
			return shperes;
			
			//TODO: see if we can unload asset here: Resources.UnloadAsset(_spherePrefab);
		}

	}
}

