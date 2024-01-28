using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HexagonSockets", menuName = "HexagonSockets")]
public class HexagonSockets : ScriptableObject
{
	public GameObject GunVisual;
	public Vector3 GunVisualShift;
	public Vector2 OriginShift;
	public float ScaleOverride = 60;
	public List<Vector2Int> hexLocations;

	public void PlaceVisual(Transform visualTr)
	{
		visualTr.localPosition += GunVisualShift;
	}
}