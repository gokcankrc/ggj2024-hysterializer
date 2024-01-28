using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreatheJuice : MonoBehaviour
{
	[SerializeField] float freq;
	[SerializeField] float mag;
	private void Update()
	{
		transform.localScale = Vector3.one * (1 + Mathf.Sin(Time.time * freq) * mag);
	}
}
