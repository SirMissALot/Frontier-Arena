using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public Heroes hero;

	[Header("Character Status")]
	public float turnSpeed = 1f;	
	
	// Player Stats variable
	private string heroName;
	private float maxHealth;
	private float currentHealth;
	private float healthRegen;
	private float movementSpeed;
	private float jumpForce;
	private bool isAlive;

	// Getters
	public float GetMovementSpeed{ get { return movementSpeed; } set { movementSpeed = value; }}
	public float GetJumpForce{ get { return jumpForce; } set { jumpForce = value; }}
	public bool GetIsAlive{ get { return isAlive; } set { isAlive = value; }}

	


	void Init(){
		heroName = hero.heroName;
		maxHealth = currentHealth = hero.health;
		healthRegen = hero.healthRegen;
		movementSpeed = hero.movementSpeed;
		jumpForce = hero.jumpForce;
		isAlive = true;
	}

	void OnEnable(){
		Init();
	}
}
