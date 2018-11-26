using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFollow : MonoBehaviour {
	GameObject[] objs;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GameObject closestPart = null;
		float min_dist = Mathf.Infinity;
		objs = GameObject.FindGameObjectsWithTag("ShipPart");
		//Debug.Log(objs.Length);
		foreach(GameObject part in objs)
		{
			float dist = Vector3.Distance(transform.position, part.transform.position);
			if (dist < min_dist)
			{
				min_dist = dist;
				closestPart = part;
			}
		}
		//Debug.Log(closestPart.name);
		transform.LookAt(closestPart.transform);
		transform.Rotate(-90,90,0);
	}
}
