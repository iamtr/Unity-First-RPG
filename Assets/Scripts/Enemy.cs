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
	public int health;
	public int moveSpeed;
	public int baseAttack;
	public string enemyName;

	public void Knock(Rigidbody2D myRigidbody, float knockTime)
	{
		StartCoroutine(KnockCo(myRigidbody, knockTime));
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
}
