using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log : Enemy
{
	public Transform target;
	public Transform homePosition;
	public float attackRadius;
	public float chaseRadius;

	private void Start()
	{
		target = GameObject.FindWithTag("Player").transform;
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
			transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
		}
	}
}
