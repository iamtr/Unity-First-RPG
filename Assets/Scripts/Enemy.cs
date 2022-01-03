using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	public enum EnemyState
	{
		idle, 
		walk,
		attack, 
		stagger
	}

	public EnemyState currentState;
	public float health;
	public FloatValue maxHealth;
	public int moveSpeed;
	public int baseAttack;
	public string enemyName;

	private void Awake()
	{
		health = maxHealth.initialValue;
	}
	public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
	{
		StartCoroutine(KnockCo(myRigidbody, knockTime));
		TakeDamage(damage);
	}

	public IEnumerator KnockCo(Rigidbody2D myRigidbody, float knockTime)
	{
		if(myRigidbody != null)
		{
			yield return new WaitForSeconds(knockTime);
			myRigidbody.velocity = Vector3.zero;
			myRigidbody.GetComponent<Enemy>().currentState = Enemy.EnemyState.idle;
		}
	}

	private void TakeDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			gameObject.SetActive(false);
		}
	}
}
