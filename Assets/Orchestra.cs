// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace AssemblyCSharp
{
	public class Orchestra
	{
		private ObjectFactory objectFactory;
		private GameObject[] gameObjects;


		public Orchestra ()
		{
			objectFactory = new ObjectFactory ();
			gameObjects = new GameObject[1];
		}

		public void initialize()
		{
			//call ObjectFactory to instantiate prefabs
			gameObjects[0] = objectFactory.CreateCube();
			gameObjects[0].AddComponent<Rigidbody>();
			gameObjects[0].transform.position = new Vector3 (5, 5, 5);
			
		}
		
		public GameObject[] getObjects(String specifier)
		{
			GameObject[] selectedObjects = null;
			switch(specifier)
			{
			case "swarm":
				//return swarm labeled objects
				break;
			case "room":
				//return objects that compose the room
				break;
			case "beacons":
				//return beacon labeled objects
				break;
			case "all":
					selectedObjects = gameObjects;
				break;
			default:
				//TODO igual que all
				break;
				
			}
			return selectedObjects;
			
		}
		public void destroyObjects()
		{
			foreach (object o in gameObjects) {
			}
				//destroy object.
		}
	}
}

