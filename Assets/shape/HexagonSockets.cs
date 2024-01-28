using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HexagonSockets", menuName = "HexagonSockets")]
public class HexagonSockets : ScriptableObject
{
	public Vector2 OriginShift;
	public List<Vector2Int> hexLocations;
}