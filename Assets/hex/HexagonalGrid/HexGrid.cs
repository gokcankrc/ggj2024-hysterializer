using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HexagonalGrid
{
	public class HexGrid : MonoBehaviour
	{
		[SerializeField] private Vector2Int gridSize = new Vector2Int(8, 9);
		[SerializeField] private HexTile tileObject;

		public static HexTile[,] Grid;
		public static List<HexTile> MarkedTiles = new List<HexTile>();
		public static List<HexCorner> HexCorners = new List<HexCorner>();

		public static HexGrid I => _i;
		private static HexGrid _i;

		private void Awake()
		{
			if (_i != null && _i != this)
				Destroy(this.gameObject);
			else
				_i = this;

			FillGrid();
		}

		public void FillGrid()
		{
			ClearGrid();
			Grid = new HexTile[gridSize.x, gridSize.y];
			HexVector.Origin = transform.position;
			for (int i = 0; i < gridSize.x; i++)
				for (int j = 0; j < gridSize.y; j++)
					Grid[i, j] = CreateHexTile(i, j);
		}

		public void ClearGrid()
		{
			List<GameObject> children = new List<GameObject>();

			foreach (Transform child in transform)
				children.Add(child.gameObject);
			for (int i = 0; i < children.Count; i++)
				DestroyImmediate(children[i]);

			Grid = null;
			HexCorners.Clear();
		}

		public void Snap()
		{
			transform.position = transform.position.Round();
		}

		public HexTile CreateHexTile(int x, int y)
		{
			var hexTile = PrefabUtility.InstantiatePrefab(tileObject, transform) as HexTile;
			hexTile.hex = HexVector.FromXY(x, y, hexTile);
			var position = hexTile.hex.GetPosition();
			hexTile.transform.position = position;
			return hexTile;
		}
	}
}