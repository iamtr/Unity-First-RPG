using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
	public Transform target;
	public Transform homePosition;
	public float attackRadius;
	public float chaseRadius;
	public Animator animator;
	public Rigidbody2D myRB;

	private void Start()
	{
		target = GameObject.FindWithTag("Player").transform;
		animator = GetComponent<Animator>();
		myRB = GetComponent<Rigidbody2D>();
		currentState = EnemyState.idle;
	}
	private void FixedUpdate()
	{
		CheckDistance();
	}

	private void CheckDistance()
	{
		if(Vector3.Distance(transform.position, target.position) < chaseRadius && 
			Vector3.Distance(transform.position, target.position) > attackRadius)
		{
			if ((currentState == EnemyState.idle || currentState == EnemyState.walk) && currentState != EnemyState.stagger)
			{
				animator.SetBool("wakeUp", true);
				Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
				ChangeAnim(temp - transform.position);
				myRB.MovePosition(temp);
				ChangeState(EnemyState.walk);
			}	
		} 
		else if (Vector3.Distance(transform.position, target.position) > chaseRadius)
		{
			animator.SetBool("wakeUp", false);
		}
	}

	private void ChangeState(EnemyState newState)
	{
		if (currentState != newState)
		{
			currentState = newState;
		}
	}

	private void ChangeAnim(Vector2 direction)
	{
		//Debug.Log("changeanim called");
		if (Mathf.Abs(direction.x) > (Mathf.Abs(direction.y)))
		{
			if(direction.x > 0)
			{
				SetAnimFloat(Vector2.right);
			}
			else if (direction.x < 0)
			{
				SetAnimFloat(Vector2.left);
			}
		} 

		else if (Mathf.Abs(direction.x) < (Mathf.Abs(direction.y)))
		{
			if (direction.y > 0)
			{
				SetAnimFloat(Vector2.up);
			}
			else if (direction.y < 0)
			{
				SetAnimFloat(Vector2.down);
			}
		}
	} 

	private void SetAnimFloat(Vector2 setVector)
	{
		animator.SetFloat("moveX", setVector.x);
		animator.SetFloat("moveY", setVector.y);
	}
}
