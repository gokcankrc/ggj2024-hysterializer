using System;
using System.Collections;
using UnityEngine;

namespace HexagonalGrid
{
	public enum HexCornerDirections
	{
		E = 0,
		NE = 1,
		NW = 2,
		W = 3,
		SW = 4,
		SE = 5
	}

	public enum HexCornerHandiness
	{
		LeftHand = 0,
		RightHand = 1,
	}

	public enum RotationDirection
	{
		CW = -1,
		CCW = 1
	}


	public class HexCorner : MonoBehaviour
	{
		public delegate void OnMarkedFoundHandler();
		public static event OnMarkedFoundHandler OnMarkedFound;

		public static float RotationSpeed = 4f;
		public static float Delay = 0.1f;

		public HexVector[] hexes = new HexVector[3];
		public HexCornerHandiness handiness;

		private SpriteRenderer _spriteRenderer;
		private HexTile[,] _grid;

		private void Awake()
		{
			_spriteRenderer = GetComponent<SpriteRenderer>();
			_grid = HexGrid.Grid;
		}


		public void SetHexes(HexVector hex)
		{
			hexes[0] = new HexVector(hex.q, hex.r);
			for (int i = 0; i < 2; i++)
			{
				hexes[i + 1] = hexes[i].GetNeighbour(2 * (i + 1) - (int)handiness);
			}

			if (handiness == HexCornerHandiness.LeftHand)
			{
				GetComponent<SpriteRenderer>().flipX = true;
			}
		}

		public void Select(bool isSelected)
		{
			_spriteRenderer.enabled = isSelected;
			if (isSelected)
			{
				foreach (var hex in hexes)
				{
					_grid[hex.X, hex.Y].transform.SetParent(this.transform);
				}
			}
			else
			{
				foreach (var hex in hexes)
				{
					_grid[hex.X, hex.Y].transform.SetParent(HexGrid.I.transform);
				}
			}
		}
		private void ReorderGrid(RotationDirection direction)
		{
			// Fix Grid references after rotation 
			SwitchGridLocation(hexes[0], hexes[1 + ((int)direction + 1) / 2]);
			SwitchGridLocation(hexes[1], hexes[2]);
		}

		private void SwitchGridLocation(HexVector h1, HexVector h2)
		{
			HexTile tile = _grid[h1.X, h1.Y];
			_grid[h1.X, h1.Y] = _grid[h2.X, h2.Y];
			_grid[h2.X, h2.Y] = tile;
		}
	}
}