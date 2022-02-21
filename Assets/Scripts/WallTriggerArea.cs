using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTriggerArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameEvents.current.WallTriggerEnter();
    }

    private void OnTriggerExit(Collider other)
    {
        GameEvents.current.WallTriggerExit();
    }
}
