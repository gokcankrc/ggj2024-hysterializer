using UnityEngine;

[CreateAssetMenu(fileName = "MatData", menuName = "MatData")]
public class MatData : ScriptableObject
{
	public Mat Mat;
	public NodeMatVisual NodeMatVisual;
	public MatSelectionButton MatSelectionButton;
	public int Index;
	public MatType MatType;
}


public enum MatType
{
	Eye = 0,
	Finger = 1,
	Tooth = 2,
	D = 3,
}