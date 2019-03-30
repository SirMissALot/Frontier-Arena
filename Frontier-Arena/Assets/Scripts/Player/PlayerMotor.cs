using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMotor : MonoBehaviour {

	public LayerMask whatIsGround;	
	public float gravity = 12.0f;	
	public float sphereRadius;

	private float verticalVelocity, forwardInput, turnInput;
	private bool m_Grounded, m_Hopping;
	private Vector3 moveVector = Vector3.zero;
	
	CharacterController controller;
	PlayerStats myStats;

	void Start(){
		
		controller = GetComponent<CharacterController>();
		myStats = GetComponent<PlayerStats>();
		
	}

	void Update(){

		if(IsGrounded() && myStats.GetIsAlive){
			m_Grounded = true;
			// verticalVelocity = -gravity * Time.deltaTime;

			MoveInput();

			moveVector = new Vector3(0,0,forwardInput);
			moveVector = transform.TransformDirection(moveVector);
        	moveVector = moveVector * myStats.GetMovementSpeed; 

			if(Input.GetKeyDown(KeyCode.Space) || m_Hopping){
				// Jump
				verticalVelocity = myStats.GetJumpForce;
					
			}

		} else{

			MoveInput();

			moveVector = new Vector3(0,0,forwardInput);
			moveVector = transform.TransformDirection(moveVector);
        	moveVector = moveVector * myStats.GetMovementSpeed; 

			m_Grounded = false;
			verticalVelocity -= gravity * Time.deltaTime;
		}

		if(myStats.GetIsAlive)
		TurnInput();
		
		moveVector.y = verticalVelocity;
		// Rotate Player
		transform.Rotate(0,turnInput*myStats.turnSpeed,0);
		// Move Player
		controller.Move(moveVector * Time.deltaTime);
		m_Hopping = false;
	}

	// Gizmo
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(transform.position,sphereRadius);
	}

	// Check if ground
	bool IsGrounded(){
		return Physics.CheckSphere(transform.position,sphereRadius,whatIsGround);
	}

	// Player Movement
	// For Windows. No joystick input yet
	void MoveInput(){
		float originalSpeed = myStats.GetMovementSpeed;
		forwardInput = Input.GetAxis("Vertical");

		if(forwardInput < 0 )
			myStats.GetMovementSpeed = 2f;
		else
			myStats.GetMovementSpeed = originalSpeed;
		
	}

	void TurnInput(){
		turnInput = Input.GetAxis("Horizontal");
	}

}

