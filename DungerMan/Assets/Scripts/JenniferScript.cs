﻿using UnityEngine;
using System.Collections;

public class JenniferScript : Enemy {
	
	public override void ability ()
	{
		Debug.Log ("hello");
		
	}
	
	// Use this for initialization
	void Start () {
		
		ss = GameObject.Find ("Score(Clone)").GetComponent<ScoreScript>();
		
		players = GameObject.FindGameObjectsWithTag("Player");
		
		// gives all the variables from the enemy class some values:
		//player = GameObject.Find ("Player 1(Clone)");
		//player2 = GameObject.Find ("Player 2(Clone)");
		agent = GetComponent<NavMeshAgent>();
		
		
		Health = 100;
		Damage = 30;
		Speed = 3.5f;
		AttackRange = 6;
		AttackSpeed = 2;
		SeeRange = 1000;
		canAttack = false;
		enemyPoint = 10;
		
		
		// sets the speed, as this is defined by the nav mesh agent:
		agent.speed = Speed;
		
	}
	
	// Update is called once per frame
	public void Update () 
	{
		
		//takeDamage();
		//OnGUI (); THIS DOES SO THEY WONT ATTACK GOD DAMMIT MIKE.
		
		
		if (players [0] != null) {
			dist = Vector3.Distance (this.transform.position, players[0].transform.position);
			if (playerNum == players[0]) {
				// sets the cc to be the Playerscript of player 2
				cc = players[0].GetComponent<PlayerScript1> ();
			}		
		}
		if (players[1] != null) {
			// updates the dist2(distance between player2 and enemy) variable for use in the enemy class.
			dist2 = Vector3.Distance (this.transform.position, players[1].transform.position);
			if (playerNum == players[1]) {
				// sets the cc to be the Playerscript of player 2
				cc = players[1].GetComponent<PlayerScript1> ();
			}
		}
		
		
		
		// runs the autoattack function from the enemy class
		autoAttack ();
		
		
		if (canAttack) {
			// runs the attack function from the enemy class, if the enemy is close enough to attack
			Attack();
		}
		
	}
	
	void OnCollisionEnter(Collision col)
	{
		// if the player collides with the key, following triggers:
		if (col.gameObject.name == "Player 1(Clone)") 
		{
			
		}
		
		
		
	}
	
	
	IEnumerator diee(){
		yield return new WaitForSeconds(5);
		die();
	}
	
}