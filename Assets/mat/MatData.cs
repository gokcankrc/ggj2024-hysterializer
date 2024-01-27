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
	A = 0,
	B = 1,
	C = 2,
	D = 3,
}