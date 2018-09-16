using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public static class PercentageHelper
{
	public static bool ChanceOfDoingAction(float percentage, UnityAction method)
	{
		float random = Random.Range(percentage, 1f);
		float rounded = Mathf.Round(random);
		Debug.Log("Rounded: " + rounded);
		if(rounded == percentage)
		{
			method.Invoke();
			return true;
		}

		return false;
	}
}