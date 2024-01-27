

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FormulaNode
{
	public Vector2Int hexLocation;
	public int MatIndex => TargetMat.Index;
	public MatData TargetMat;
}