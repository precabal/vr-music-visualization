using System;
using UnityEngine;
using System.Collections.Generic;

namespace AssemblyCSharp
{
	public class MoveEvent : IEvent
	{
		private float _eventTime;

		public float EventTime
		{
			get { return _eventTime; }
			set { _eventTime = value; }
		}

		public MoveEvent (float eventTime, Vector3 finalPosition, float velocity)
		{
			_eventTime = eventTime;
		}

		public void Perform(List<GameObject> objects)
		{
			foreach (GameObject obj in objects)
			{

			}
		}
	}
}

