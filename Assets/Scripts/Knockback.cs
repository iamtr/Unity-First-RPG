using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
	public float knockTime;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		Debug.Log("yes");
		Rigidbody2D enemyRB = collision.GetComponent<Rigidbody2D>();
		if (enemyRB != null)
		{
			enemyRB.GetComponent<Enemy>().currentState = Enemy.EnemyState.stagger;
			Vector2 difference = enemyRB.transform.position - transform.position;
			difference = difference.normalized * thrust;
			enemyRB.AddForce(difference, ForceMode2D.Impulse);
			StartCoroutine(KnockCo(enemyRB));
			
		}
	}

	private IEnumerator KnockCo(Rigidbody2D enemyRB)
	{
		yield return new WaitForSeconds(knockTime);
		enemyRB.velocity = Vector3.zero;
		enemyRB.GetComponent<Enemy>().currentState = Enemy.EnemyState.idle;
	}
}
