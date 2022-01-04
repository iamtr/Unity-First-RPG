using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
	public Image[] hearts;
	public Sprite fullHeart, halfFullHeart, emptyHeart;
	public FloatValue heartContainers;
	private void Start()
	{
		InitHearts();
	}
	public void InitHearts()
	{
		for (int i = 0; i < heartContainers.initialValue; i++)
		{
			hearts[i].gameObject.SetActive(true);
		}
	}
}
