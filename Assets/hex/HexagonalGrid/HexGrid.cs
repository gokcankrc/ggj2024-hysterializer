using RegularDuck._Core.Helpers;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HexagonalGrid
{
	public class HexGrid : Singleton<HexGrid>
	{
		[SerializeField] private Vector2Int gridSize = new Vector2Int(8, 9);
		[SerializeField] private HexNode tileObject;
		[SerializeField] private HexNode emptyTileObject;
		[SerializeField] private float GridScale;

		public static HexNode[,] Grid;
		public static List<HexNode> SocketNodes;

		protected override void Awake()
		{
			base.Awake();
			SocketNodes = new List<HexNode>();
		}

		private void Start()
		{
			FillGrid();
		}

		public void FillGrid()
		{
			HexVector.XScale = GridScale;
			HexVector.YScale = GridScale;
			ClearGrid();
			Grid = new HexNode[gridSize.x, gridSize.y];
			HexVector.Origin = transform.position;
			for (int i = 0; i < gridSize.x; i++)
				for (int j = 0; j < gridSize.y; j++)
					Grid[i, j] = CreateEmptyTile(i, j);
		}

		public void PlaceSocketsInGrid(HexagonSockets socketShape)
		{
			var origin = new Vector2Int(0, 3);
			foreach (Vector2Int relativeLoc in socketShape.hexLocations)
			{
				var loc = origin + relativeLoc;
				Debug.Log(($"socket loc: {loc}"));
				Destroy(Grid[loc.x, loc.y].gameObject);
				Grid[loc.x, loc.y] = CreateSocketTile(loc.x, loc.y);
				SocketNodes.Add(Grid[loc.x, loc.y]);
			}
		}

		public void ClearGrid()
		{
			List<GameObject> children = new List<GameObject>();

			foreach (Transform child in transform)
				children.Add(child.gameObject);
			for (int i = 0; i < children.Count; i++)
				DestroyImmediate(children[i]);

			Grid = null;
		}

		public void Snap()
		{
			transform.position = transform.position.Round();
		}

		public HexNode CreateSocketTile(int x, int y)
		{
			var hexTile = PrefabUtility.InstantiatePrefab(tileObject, transform) as HexNode;
			PositionTile(x, y, hexTile);
			return hexTile;
		}

		public HexNode CreateEmptyTile(int x, int y)
		{
			var hexTile = PrefabUtility.InstantiatePrefab(emptyTileObject, transform) as HexNode;
			PositionTile(x, y, hexTile);
			return hexTile;
		}

		public void PositionTile(int x, int y, HexNode hexTile)
		{
			hexTile.hex = HexVector.FromXY(x, y, hexTile);
			var position = hexTile.hex.GetPosition();
			hexTile.transform.position = position;
		}
	}
}