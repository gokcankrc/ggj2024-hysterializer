using RegularDuck._Core.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
	public AudioListener listener;
	public AudioSource sourcePrefab;
	[Range(0, 1)] public float Volume = 0.6f;

	protected override void Awake()
	{
		base.Awake();
	}

	public void PlaySound(AudioClip clip)
	{
		var newSource = Instantiate(sourcePrefab, transform);
		newSource.clip = clip;
		newSource.volume = Volume;
		newSource.Play();
	}

	internal static void Play(AudioClip audioClip)
	{
		I.PlaySound(audioClip);
	}
}