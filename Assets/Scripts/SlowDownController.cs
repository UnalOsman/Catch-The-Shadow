using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownController : MonoBehaviour
{
    public SlowDown slowDown;

    public void OnSuccessfulCatch()
    {
        slowDown.OnSuccessfulCatch();
    }
}
