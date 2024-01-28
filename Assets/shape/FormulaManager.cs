using RegularDuck._Core.Helpers;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FormulaManager : Singleton<FormulaManager>
{
	public List<HexagonFormula> _formulas;
	public Transform FormulaVisualContainer;
	public FormulaVisual FormulaVisualPrefab;
	public float Spacing;

	protected override void Awake()
	{
		base.Awake();
		GenerateAllFormulas();
	}

	private void GenerateAllFormulas()
	{
		for (int i = 0; i < _formulas.Count; i++)
		{
			var formula = _formulas[i];
			var effect = formula.effect;
			var formulaVisual = Instantiate(FormulaVisualPrefab, FormulaVisualContainer);
			var text = "";
			if (effect.PotencyAdd != 0)
				text += $"Adds {effect.PotencyAdd} Potency\n";
			if (effect.ResistancesPenetrated != ResistanceTypes.None)
				text += $"Penetrates {effect.ResistancesPenetrated}";

			formulaVisual.Generate(formula, 50 + i * Spacing, text);
		}
	}
}
