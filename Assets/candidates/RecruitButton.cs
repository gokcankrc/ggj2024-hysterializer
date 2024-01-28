using HexagonalGrid;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitButton : MonoBehaviour
{
	public void RecruitInitiate()
	{
		var Effect = new Effect();
		CalculateEffect(Effect);
		bool success = CompareEffect(Effect, LevelManager.I.Candidate.Requirements);
		if (success)
		{
			MapManager.I.SelectedMap.Finish();
			GameManager.I.SwitchToMap();
		}
		else
		{
		}
	}

	public static List<HexagonFormula> OnlyCalculateEffect()
	{
		var formulasInEffect = new List<HexagonFormula>();
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
					formulasInEffect.Add(formula);
			}
		}
		return formulasInEffect;
	}

	private static void CalculateEffect(Effect Effect)
	{
		var formulas = FormulaManager.I._formulas;
		foreach (var formula in formulas)
		{
			foreach (var sockedNode in HexGrid.SocketNodes)
			{
				if (sockedNode.CurrentAttachedIndex == -1) continue;

				bool thereIsFormula = true;
				Vector2Int origin = sockedNode.hex.Vector2int;
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
					formula.Activate(origin, Effect);
			}
		}
	}

	private static bool CompareEffect(Effect effect, Effect requirements)
	{
		bool success = (requirements.ResistancesPenetrated & ~effect.ResistancesPenetrated) == ResistanceTypes.None;
		success &= effect.PotencyAdd >= requirements.PotencyAdd;
		return success;
	}
}
