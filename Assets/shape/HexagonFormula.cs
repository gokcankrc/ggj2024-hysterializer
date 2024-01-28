using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HexagonFormula", menuName = "HexagonFormula")]
public class HexagonFormula : ScriptableObject
{
	public List<FormulaNode> formulaNodes;
	public Effect effect;

	public void Activate(Vector2Int origin, Effect effectIn)
	{
		effectIn.Add(effect);
		Debug.Log($"Activated! {name}");
	}

	public int GetPotency()
	{
		return effect.GetPotency();
	}
}