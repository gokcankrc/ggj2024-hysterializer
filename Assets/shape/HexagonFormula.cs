using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HexagonFormula", menuName = "HexagonFormula")]
public class HexagonFormula : ScriptableObject
{
	public List<FormulaNode> formulaNodes;
	[SerializeReference] public Effect effect;

	public void Activate(Vector2Int origin)
	{
		Debug.Log($"Activated! {name}");
	}
}