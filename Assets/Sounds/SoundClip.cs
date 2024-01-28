using UnityEngine;

public class SoundClip : MonoBehaviour
{
	public AudioClip audioClip;

	public void Play()
	{
		SoundManager.Play(audioClip);
	}
}
