using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Signal : ScriptableObject
{
	private List<SignalListener> listeners = new List<SignalListener>();

	public void Raise()
	{
		for (int i = listeners.Count - 1; i > 0; i--  )
		{
			listeners[i].OnSignalRaised();
			Debug.Log("raised");
		}
	}
	public void RegisterListener(SignalListener listener)
	{
		listeners.Add(listener);
		Debug.Log(listener);
	}
	public void DeregisterListener(SignalListener listener)
	{
		listeners.Remove(listener);
	}
}
