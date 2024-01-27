using RegularDuck._Core.Helpers;
using System;

public class MatSelectionManager : Singleton<MatSelectionManager>
{
	public MatSelectionButton CurrentlySelectedMatButton;

	public void MatHasBeenSelected(MatSelectionButton matSelectionButton)
	{
		if (CurrentlySelectedMatButton != null)
			CurrentlySelectedMatButton.Deselect();

		CurrentlySelectedMatButton = matSelectionButton;
	}

	public void HexNodeHasBeenSelected(HexNode hexNode, int matIndex)
	{
		if (CurrentlySelectedMatButton == null) return;
		if (hexNode.CurrentAttachedIndex != CurrentlySelectedMatButton.index)
		{
			AttachMatToNode(hexNode, CurrentlySelectedMatButton);
		}
		else
		{
			hexNode.DetachMat();
		}
	}

	private void AttachMatToNode(HexNode hexNode, MatSelectionButton selection)
	{
		hexNode.DetachMat();
		if (selection.CurrentResource == 0) return;
		hexNode.AttachMat(selection);
	}
}
