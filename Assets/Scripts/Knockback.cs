using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public float thrust;
	public float knockTime;
	public float damage;

	private void OnTriggerEnter2D(Collider2D collision)
	{

		if (collision.CompareTag("Breakable") && this.gameObject.CompareTag("Player"))
		{
			collision.GetComponent<Pot>().Smash();
		}

		//Debug.Log("yes");
		if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
		{
			Rigidbody2D hit = collision.GetComponent<Rigidbody2D>();
			if (hit != null)
			{
				Vector2 difference = hit.transform.position - transform.position;
				difference = difference.normalized * thrust;
				hit.AddForce(difference, ForceMode2D.Impulse);

				if (hit.gameObject.CompareTag("Enemy") && collision.isTrigger)
				{
					hit.GetComponent<Enemy>().currentState = Enemy.EnemyState.stagger;
					hit.gameObject.GetComponent<Enemy>().Knock(hit, knockTime, damage);
				}

				if (hit.gameObject.CompareTag("Player") && collision.isTrigger)
				{
					hit.GetComponent<PlayerMovement>().currentState = PlayerMovement.PlayerState.stagger;
					hit.gameObject.GetComponent<PlayerMovement>().Knock(hit, knockTime);
				}

			}
		}
	}


}
