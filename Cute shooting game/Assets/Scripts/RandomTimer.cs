using UnityEngine;
using System.Collections;

public class RandomTimer : Timer
{
	public float secondTimeToRandomizeBetween;

	public override void StartTimer(OnFinish onFinish = null, OnFinish almostFinish = null, bool startImmedatly = false)
	{
		this.time = Random.Range(this.time, this.secondTimeToRandomizeBetween);
		base.StartTimer(onFinish);
	}
}