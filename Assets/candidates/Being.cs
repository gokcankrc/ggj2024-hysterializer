using UnityEngine;

[CreateAssetMenu(fileName = "Being", menuName = "Being")]
public class Being : ScriptableObject
{
	public Sprite Portrait;
	public Sprite PortraitLaugh;
	public Effect Requirements;
	public AudioClip LaughAudioClip;
}