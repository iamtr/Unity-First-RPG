using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
	public bool needText;
	public GameObject text;
	public Text placeText;
	public string placeName;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (needText)
		{
			StartCoroutine(PlaceNameCo());
		}
	}

	IEnumerator PlaceNameCo()
	{
		text.SetActive(true);
		placeText.text = placeName;
		yield return new WaitForSeconds(4f);
		text.SetActive(false);
	}
}	

