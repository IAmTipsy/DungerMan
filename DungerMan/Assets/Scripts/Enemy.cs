﻿using UnityEngine;
using System.Collections;

public abstract class Enemy : MonoBehaviour {

	protected PlayerScript1 cc;
	public ScoreScript ss;


	protected GameObject[] players;
	protected GameObject player;
	protected GameObject player2;

	public float Points = 0;


	protected GameObject playerNum;// variable used to switch between the two player gameobjects

	protected NavMeshAgent agent;

	public int Health;
	protected int Damage;
	protected float Speed;
	protected int AttackRange;
	protected int SeeRange;
	protected int AttackSpeed;

	public int enemyPoint;	// points for kind of enemy killed
	protected float dist;// distance between player 1 and the enemy
	protected float dist2;// distance between player 2 and the enemy
	protected bool canAttack = false;
	protected bool haveWaited = true;

	private float distance; // variable used to switch between the two dist variables

	private int enemyCount = 0; // number of enemies killed

	public abstract void ability ();

	//protected PlayerScript cc = GameObject.Find ("Player(Clone)").GetComponent<PlayerScript>();

	void Update(){

	}


	protected void autoAttack()
		// maybe an array of players can be made so that we only need one player prefab
		{

		// checks if distance between player 1 and the enemy is bigger than the distance between player2 and the enemy:
		if(dist>dist2){
			// if this is true, the distance variable gets assigned the distance between player2 and the enemy
			distance = dist2;
			// and the playerNum variable gets the gameobject of player2
			playerNum = players[1];
		}
		else {
			// else it must be player 1, which is closest:
			distance = dist;
			playerNum = players[0];
		}
		// makes the enemy go to the player which is closest:
		if (distance < SeeRange && distance > AttackRange) {
						agent.SetDestination (playerNum.transform.position);
						canAttack = false;
				} else if (distance <= AttackRange) {
						agent.SetDestination (this.transform.position);	
						canAttack = true;
				} else
						canAttack = false;

		}

	protected void Attack()
	{
		if (haveWaited) {
			StartCoroutine("reload");
				cc.playerHealth -= Damage;
				}
	}


	public void takeDamage(int damage)
	{
	

		networkView.RPC ("net_takeDamage", RPCMode.All, damage);


		if (Health <= 0) {
			die();
				}

	}
	[RPC]
	public void net_takeDamage(int damage){
		Health -= damage;
	}

	protected void die()
	{
		enemyCount += 1;
		ss.addPoint();
		print ("diie");
		Network.Destroy (gameObject);
		Destroy (gameObject);

		}

	IEnumerator reload(){
		haveWaited = false;
		yield return new WaitForSeconds(AttackSpeed);
		haveWaited = true;
		
	}




}
