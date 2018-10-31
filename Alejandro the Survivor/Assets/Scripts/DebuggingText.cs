using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebuggingText : MonoBehaviour {
	public static float x, y, z, a, b, c;
	Text text;
	GameObject cam;

	// Use this for initialization
	void Start () {
		text = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Enemy Left: " + (HUDControl.totalEnemyAmount - HUDControl.currEnemyAmount);
	}
}
