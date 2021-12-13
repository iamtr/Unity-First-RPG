using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public int speed;
	private Vector3 change;
	private Rigidbody2D myRigidBody;
	private void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		change.x = Input.GetAxisRaw("Horizontal");
		change.y = Input.GetAxisRaw("Vertical");

		if (change != Vector3.zero)
		{
			MoveCharacter();
		}
	}
	public void MoveCharacter()
	{
		myRigidBody.MovePosition (transform.position + change * speed * Time.deltaTime);
		
	}
}
