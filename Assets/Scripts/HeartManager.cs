using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
	public Image[] hearts;
	public Sprite fullHeart, halfFullHeart, emptyHeart;
	public FloatValue heartContainers;
	public FloatValue playerCurrentHealth;
	
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

	public void UpdateHearts()
	{
		Debug.Log("update hearts");
		float tempHealth = playerCurrentHealth.runtimeValue / 2;
		for (int i = 0; i < heartContainers.initialValue; i++)
		{
			if (i <= tempHealth - 1)
			{
				hearts[i].sprite = fullHeart;
			}
			
			else if (i >= tempHealth)
			{
				hearts[i].sprite = emptyHeart;
			}

			else
			{
				hearts[i].sprite = halfFullHeart;
			}
		}
	}
}
