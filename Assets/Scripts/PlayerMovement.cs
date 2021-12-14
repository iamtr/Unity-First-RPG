using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public int speed;
	private Vector3 change;
	private Animator animator;
	private Rigidbody2D myRigidBody;
	private void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
	}
	private void FixedUpdate()
	{
		change = Vector3.zero;
		change.x = Input.GetAxisRaw("Horizontal");
		change.y = Input.GetAxisRaw("Vertical");
		UpdateAnimationAndMove();
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
}
