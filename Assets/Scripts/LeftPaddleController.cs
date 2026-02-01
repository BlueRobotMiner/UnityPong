using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPaddleController : PaddleController
{
    // Override the GetInput method to use W/S keys
    protected override float GetInput()
    {
        return Input.GetAxis("Player1Vertical"); // Ensure "Player1Vertical" is set up in Input Manager
    }
}
