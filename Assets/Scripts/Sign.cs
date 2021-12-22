using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
	public GameObject dialogBox;
	public Text dialogText;
	public bool playerInRange;
	public string dialog;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
		{
			if (dialogBox.activeInHierarchy)
			{
				dialogBox.SetActive(false);
			}
			else
			{
				dialogBox.SetActive(true);
				dialogText.text = dialog;
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		playerInRange = true;
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		playerInRange = false;
	}
}
