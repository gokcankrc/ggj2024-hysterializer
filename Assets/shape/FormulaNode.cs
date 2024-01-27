

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class FormulaNode
{
	public HexVector hexLocation;
	public int MatIndex => TargetMat.Index;
	public MatData TargetMat;
}