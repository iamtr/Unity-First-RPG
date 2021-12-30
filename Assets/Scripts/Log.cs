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
				Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
				myRB.MovePosition(temp);
				ChangeState(EnemyState.walk);
			}	
		}
	}

	private void ChangeState(EnemyState newState)
	{
		if (currentState != newState)
		{
			currentState = newState;
		}
	}
}
