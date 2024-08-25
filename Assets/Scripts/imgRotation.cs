using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imgRotation : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (!PuzzleManager.youWin)
        {
            transform.Rotate(0, 0, 90);
        }
    }
}
