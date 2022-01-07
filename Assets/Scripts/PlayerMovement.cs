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
		interact,
		stagger
	}

	public int speed;
	private Vector3 change;
	private Animator animator;
	private Rigidbody2D myRigidBody;
	public PlayerState currentState;
	public float animationWaitTime;
	public Signal playerHealthSignal;
	public FloatValue currentHealth;

	private void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponent<Animator>();
		currentState = PlayerState.walk;
		animator.SetFloat("moveX", 0);
		animator.SetFloat("moveY", -1);
	}
	private void FixedUpdate()
	{
		change = Vector3.zero;
		change.x = Input.GetAxisRaw("Horizontal");
		change.y = Input.GetAxisRaw("Vertical");
		
		if (currentState == PlayerState.walk || currentState == PlayerState.idle) 
		{
			UpdateAnimationAndMove();
		}
	}

	private void Update()
	{
		if (Input.GetButtonDown("attack") && currentState != PlayerState.attack && currentState != PlayerState.stagger)
		{
			StartCoroutine(AttackCo());
			//Debug.Log("press space");
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
		//Debug.Log("coroutine started");
		currentState = PlayerState.attack;
		animator.SetBool("attacking", true);
		yield return null;
		animator.SetBool("attacking", false);
		yield return new WaitForSeconds(animationWaitTime);
		currentState = PlayerState.walk;
	}

	public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
	{
		currentHealth.runtimeValue -= damage;
		Debug.Log("health:" + currentHealth.runtimeValue);
		playerHealthSignal.Raise();
		if(currentHealth.runtimeValue > 0)
		{
			StartCoroutine(KnockCo(myRigidbody, knockTime));
			//Debug.Log("coroutine started");
		}
		else
		{
			this.gameObject.SetActive(false);
		}
		
	}

	public IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
	{
		if (myRigidbody != null)
		{
			yield return new WaitForSeconds(knockTime);
			myRigidbody.velocity = Vector3.zero;
			myRigidbody.GetComponent<PlayerMovement>().currentState = PlayerState.idle;
		}
	}
}
