using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp
{
	public class Orchestra
	{
		private List<GameObject> _performers = new List<GameObject>();
		private List<Track> _tracks = new List<Track>();

		public Orchestra ()
		{
			InitializeStage ();
		}

		public void InitializeStage()
		{
			_tracks.Add (	new BaseSounds ()		);
			_tracks.Add (	new Cymbal_1 ()			);
			_tracks.Add (	new Cymbal_2 ()			);
			_tracks.Add (	new Hihat_1 ()			);
			_tracks.Add (	new Hihat_2 ()			);
			_tracks.Add (	new LeadSynth_L ()		);
			_tracks.Add (	new LeadSynth_R ()		);
			_tracks.Add (	new Snare_1 ()			);
			_tracks.Add (	new Snare_2 ()			);
			_tracks.Add (	new Snare_3 ()			);
			_tracks.Add (	new pingpongBass_L () 	);
			_tracks.Add (	new pingpongBass_R () 	);

			foreach (Track track in _tracks) 
			{
				_performers.Add (track.SoundSource);
				_performers.AddRange (InitializePerformersAssociatedToTrack (track));
			}
			
		}

		private List<GameObject> InitializePerformersAssociatedToTrack (Track track)	{

			List<GameObject> associatedObjects = new List<GameObject> ();
			if (track.hasAssociatedObjects)
			{

				associatedObjects.AddRange( ObjectFactory.InitializeRandomPrefabsInSphere(track.associatedObjectsPrefabType, track.CenterPosition, 22, 4.0f, 20.0f, 30.0f) );

				foreach (GameObject associatedObject in associatedObjects) 
				{
					associatedObject.tag = String.Concat(track.GetTag (),"_group");
					associatedObject.transform.parent = track.GetTransform();
				}
			}

			return associatedObjects;

		}

		public List<GameObject> GetObjects(String specifier, bool includeGroupedObjects = true)
		{
			List<GameObject> selectedObjects = null;

			switch(specifier)
			{
			case "all":
				selectedObjects = _performers;
				break;
			case "pingpongBass":
				selectedObjects = GameObject.FindGameObjectsWithTag("pingpongBass_L").ToList();
				selectedObjects.AddRange( GameObject.FindGameObjectsWithTag("pingpongBass_R").ToList() );
				break;
			default:
				selectedObjects = GameObject.FindGameObjectsWithTag(specifier).ToList();
				if(includeGroupedObjects)
				{
					selectedObjects.AddRange(  GameObject.FindGameObjectsWithTag( String.Concat(specifier,"_group")).ToList()   );
				}

				break;
				
			}
			return selectedObjects;	
		}


		public void DestroyObjects()
		{
			foreach (GameObject obj in _performers)
			{
				MonoBehaviour.Destroy(obj);
			}
		}
	}
}

