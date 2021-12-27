using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
	private Animator animator;
	[SerializeField]private float waitTime;

	private void Start()
	{
		animator = GetComponent<Animator>();
	}
	public void Smash()
	{
		animator.SetBool("smash", true);
		StartCoroutine(BreakCo());
	}

	IEnumerator BreakCo()
	{
		yield return new WaitForSeconds(waitTime);
		this.gameObject.SetActive(false);
	}

}
