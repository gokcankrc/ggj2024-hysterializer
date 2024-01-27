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

	public void HexNodeHasBeenSelected(HexNode hexNode)
	{
		if (CurrentlySelectedMatButton = null) return;
		AttachMatToNode(hexNode, CurrentlySelectedMatButton);
	}

	private void AttachMatToNode(HexNode hexNode, MatSelectionButton selection)
	{
		hexNode.DetachMat();
		hexNode.AttachMat(selection);
	}
}
