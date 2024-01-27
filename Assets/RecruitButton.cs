using HexagonalGrid;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitButton : MonoBehaviour
{

	public void RecruitInitiate()
	{
		// Get current stats
		var formulas = FormulaManager.I._formulas;
		foreach (var formula in formulas)
		{
			foreach (var sockedNode in HexGrid.SocketNodes)
			{
				if (sockedNode.CurrentAttachedIndex == -1) continue;

				bool thereIsFormula = true;
				var origin = sockedNode.hex.Vector2int;
				var originHex = sockedNode.hex;
				foreach (var formulaNode in formula.formulaNodes)
				{
					var hexTotal = originHex + formulaNode.hexLocation;

					var node = HexGrid.Grid[hexTotal.X, hexTotal.Y];
					if (formulaNode.MatIndex != node.CurrentAttachedIndex)
					{
						thereIsFormula = false;
						break;
					}
				}

				if (thereIsFormula)
					formula.Activate(origin);
			}
		}
	}
}
