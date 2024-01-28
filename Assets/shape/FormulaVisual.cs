using TMPro;
using UnityEngine;

public class FormulaVisual : MonoBehaviour
{

	public GameObject NodeBg;
	public TextMeshProUGUI Text;

	public void Generate(HexagonFormula formula, float shift, string text)
	{
		transform.position += Vector3.right * shift + Vector3.down * 20;
		foreach (var node in formula.formulaNodes)
		{
			var hexVector = node.hexLocation.GetRelativePosition();
			var a = Instantiate(NodeBg, transform);
			var b = Instantiate(node.TargetMat.NodeMatVisual, transform);
			a.transform.localPosition = (Vector3)hexVector * 0.3f;
			b.transform.localPosition = (Vector3)hexVector * 0.3f;

			a.transform.localScale *= 0.7f;
			b.transform.localScale *= 0.7f;
		}
		Text.text = text;
	}

}