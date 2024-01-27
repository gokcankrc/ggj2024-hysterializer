using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HexagonSockets", menuName = "HexagonSockets")]
public class HexagonSockets : ScriptableObject
{
	public List<Vector2Int> hexLocations;
}