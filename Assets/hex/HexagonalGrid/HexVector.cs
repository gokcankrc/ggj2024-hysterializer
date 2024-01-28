using System;
using HexagonalGrid;
using UnityEngine;

public enum HexNeighbourDirection
{
	E = 0,
	SE = 1,
	SW = 2,
	W = 3,
	NW = 4,
	NE = 5
}

[Serializable]
public struct HexVector
{
	public int q; // hor axis
	public int r; // 60 degree ccw to q
	public int s => -q - r;

	public HexNode parent;


	public int X => q + r / 2;
	public int Y => r;

	// From SE in ccw direction
	public static HexVector[] NeighborDirections { get; } =
	{
		new HexVector(1, -1), new HexVector(1, 0), new HexVector(0, 1),
		new HexVector(-1, 1), new HexVector(-1, 0), new HexVector(0, -1)
	};
	public Vector2Int Vector2int => new Vector2Int(X, Y);
	public static float XScale = 100;
	public static float YScale = 100;

	public static Vector3 Origin = Vector3.zero;

	#region Constructors

	public HexVector(int q, int r)
	{
		this.q = q;
		this.r = r;
		this.parent = null;
	}

	public HexVector(int q, int r, HexNode parent)
	{
		this.q = q;
		this.r = r;
		this.parent = parent;
	}

	public static HexVector FromXY(int x, int y)
	{
		//var q = x;
		//var r = y - x / 2;
		var q = x - y / 2;
		var r = y;
		return new HexVector(q, r);
	}

	public static HexVector FromXY(int x, int y, HexNode parent)
	{
		var hexVector = HexVector.FromXY(x, y);
		hexVector.parent = parent;
		return hexVector;
	}


	#endregion

	public void SetCoord(int q, int r)
	{
		this.q = q;
		this.r = r;
	}

	public Vector2 GetRelativePosition()
	{
		float[][] matrix = HexTransform.Transform;

		float x = matrix[0][0] * q + matrix[1][0] * r;
		float y = matrix[0][1] * q + matrix[1][1] * r;
		x *= XScale;
		y *= YScale;
		return new Vector2(x, y);
	}

	public Vector3 GetPosition()
	{
		var v = GetRelativePosition();
		return Origin + new Vector3(v.x, v.y);
	}

	public HexVector GetNeighbour(HexNeighbourDirection direction)
	{
		return GetNeighbour((int)direction);
	}

	public HexVector GetNeighbour(int direction)
	{
		return this + NeighborDirections[direction % 6];
	}

	#region Operators

	public static HexVector operator +(HexVector h, HexVector o)
	{
		return new HexVector(h.q + o.q, h.r + o.r);
	}

	public static HexVector operator -(HexVector h, HexVector o)
	{
		return new HexVector(h.q - o.q, h.r - o.r);
	}

	#endregion
}