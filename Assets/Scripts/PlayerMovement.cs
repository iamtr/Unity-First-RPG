using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public enum PlayerState
	{
		idle,
		walk,
		attack, 
		interact
	}

	public int speed;
	private Vector3 change;
	private Animator animator;
	private Rigidbody2D myRigidBody;
	public PlayerState currentState;
	public float animationWaitTime;
	private void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		currentState = PlayerState.walk;
	}
	private void FixedUpdate()
	{
		change = Vector3.zero;
		change.x = Input.GetAxisRaw("Horizontal");
		change.y = Input.GetAxisRaw("Vertical");
		
		if (currentState == PlayerState.walk) 
		{
			UpdateAnimationAndMove();
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
		{
			StartCoroutine(AttackCo());
			Debug.Log("press space");
		}
	}

	public void MoveCharacter()
	{
		change.Normalize();
		myRigidBody.MovePosition (transform.position + change * speed * Time.deltaTime);
	}
	public void UpdateAnimationAndMove()
	{
		if (change != Vector3.zero)
		{
			MoveCharacter();
			animator.SetFloat("moveX", change.x);
			animator.SetFloat("moveY", change.y);
			animator.SetBool("moving", true);
		}
		else
		{
			animator.SetBool("moving", false);
		}
	}	

	IEnumerator AttackCo()
	{
		Debug.Log("coroutine started");
		currentState = PlayerState.attack;
		animator.SetBool("attacking", true);
		yield return null;
		animator.SetBool("attacking", false);
		yield return new WaitForSeconds(animationWaitTime);
		currentState = PlayerState.walk;
	}
}
