using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HexagonFormula", menuName = "HexagonFormula")]
public class HexagonFormula : ScriptableObject
{
	public List<FormulaNode> formulaNodes;
}