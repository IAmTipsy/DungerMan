﻿using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject brah = Instantiate(Resources.Load("Posh")) as GameObject; 

		Vector3 temp = transform.position; // copy to an auxiliary variable...
		temp.y = 5.0f; // modify the component you want in the variable...
		temp.x = 5.0f;

		brah.transform.position = temp; // and save the modified value 

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
