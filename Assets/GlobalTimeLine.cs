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
	public class GlobalTimeLine
	{
		
		public Orchestra orchestra;
		public SingleTimeLine[] timeLines;
		private int numberOfTimelines;
		private static float simulationLength = 60f; 
		
		public GlobalTimeLine ()
		{
			orchestra = new Orchestra();
			//crea Objetos: Cubo, Venado, linea
			orchestra.initialize();   
			
			timeLines = new SingleTimeLine[4];
			populateTimelines();
		}
		
		
		private void populateTimelines()
		{
			
			timeLines[0] = new SingleTimeLine(orchestra.getObjects("beacons"));
			timeLines[0].addEvent( new EventDescriptor(4.0f, EventKind.show) );
			timeLines[0].addEvent( new EventDescriptor (51.0f, EventKind.hide) ); 
			
			timeLines[1] = new SingleTimeLine(orchestra.getObjects("swarm"));
			timeLines[1].addEvent( new EventDescriptor(8.0f, EventKind.show) );
			
			timeLines[2] = new SingleTimeLine(orchestra.getObjects("room"));
			timeLines[2].addEvent( new EventDescriptor(2.0f, EventKind.show) );
			
			timeLines[3] = new SingleTimeLine(orchestra.getObjects("all"));
			timeLines[3].addEvent( new EventDescriptor(200.0f, EventKind.hide) );
			
		}
		
		public SingleTimeLine getSingleTimeLine(int i)
		{
			//TODO check for array indexes boundaries
			return timeLines[i];
		}
		
		public int getNumberOfTimeLines()
		{
			return numberOfTimelines;
		}

		public float getSimulationLength()
		{
			return simulationLength;
		}

		public void destroyObjects()
		{
			orchestra.destroyObjects();
		}

	}
}

