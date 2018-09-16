using UnityEngine;
using System.Collections;

public class RandomTimer : Timer
{
	public float secondTimeToRandomizeBetween;

	public override void Initilize(OnFinish onFinish)
	{
		this.time = Random.Range(this.time, this.secondTimeToRandomizeBetween);
		base.Initilize(onFinish);
	}
}