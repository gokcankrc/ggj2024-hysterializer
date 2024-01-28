using RegularDuck._Core.Helpers;
using System;
using TMPro;
using UnityEngine;

public class EnemyDescriptionHandler : Singleton<EnemyDescriptionHandler>
{
	[SerializeField] TextMeshProUGUI textMesh;
	[SerializeField] Being Candidate;

	public void SetEnemy(Being candidate)
	{
		Candidate = candidate;
		RefreshVisuals();
	}

	public void RefreshVisuals()
	{
		var text = "";
		text += Candidate.Requirements.GetBeingPower();

		var formulas = RecruitButton.OnlyCalculateEffect();
		var potency = 0;
		foreach (var f in formulas)
			potency += f.GetPotency();
		text += $"Current potency: {potency}";

		textMesh.text = text;
	}
}
