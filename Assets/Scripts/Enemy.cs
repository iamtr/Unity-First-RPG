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
}
