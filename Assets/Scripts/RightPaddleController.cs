using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPaddleController : PaddleController
{
    // Override the GetInput method to use arrow keys
    protected override float GetInput()
    {
        return Input.GetAxis("Player2Vertical"); // Ensure "Player2Vertical" is set up in Input Manager
    }
}
