using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class geoloc : MonoBehaviour {
	Dictionary<string, string> building2loc;

	// Use this for initialization
	void Start () {
		Debug.Log ("geoloc starting");

		//init dict directly with json
		building2loc = new Dictionary<string, string>
		{
			{"block2_building6", "65.014206, 25.467864"},
			{"block2_building4", "65.013903, 25.467357"},
			{"block2_building3", "65.014156, 25.466855"},
			{"block2_building2", "65.014505, 25.467359"},
			{"block2_building1", "65.014635, 25.467708"},
			{"block2_building5", "65.014535, 25.468256"},
		};

		//var loc = building2loc["block2_building6"];
		//Debug.Log ("building loc:" + loc);

		string nearest = findNearest (65.014535f, 25.468255f);
		Debug.Log("findNearest:" + nearest); //near building5 but not exactly
	}

	string findNearest(float lng, float lat)
	{
		string nearest = "";
		double distSqr = -1;
		Vector2 searchpos = new Vector2(lng, lat);

		foreach (KeyValuePair<string, string>  entry in building2loc)
		{
			// use value.Key and value.Value
			//Debug.Log(entry.Key + " -- " + entry.Value);
			string geolocstr = entry.Value;
			string[] coordstrings = geolocstr.Split(',');
			float thislng = (float)Convert.ToDouble(coordstrings[0]);
			float thislat = (float)Convert.ToDouble(coordstrings[1]);
			//Debug.Log(thislng.ToString() + " : " + thislat.ToString());

			Vector2 thispos = new Vector2(thislng, thislat);
			Vector2 diff = thispos - searchpos;
			double thisDistSqr = diff.sqrMagnitude;
			if (distSqr < 0 || thisDistSqr < distSqr) {
				distSqr = thisDistSqr;
				nearest = entry.Key;
			}	
		}

		return nearest;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
