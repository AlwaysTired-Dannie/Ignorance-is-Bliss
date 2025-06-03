using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class CursorInteractManager : MonoBehaviour
{
    private bool ftCanvasOpen = false;

    public void OpenFriendTech()
    {
        //CursorController.instance.enabled = false;
        CursorController.canInteract = false;
    }

    public void CloseFriendTech()
    {
        //CursorController.instance.enabled = true;
        CursorController.canInteract = true;
    }

}
