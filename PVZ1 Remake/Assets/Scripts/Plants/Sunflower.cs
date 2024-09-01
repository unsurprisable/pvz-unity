using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sunflower : PeriodicPlant
{
    public override void OnCycleComplete()
    {
        Debug.Log("spawned a sun (sunflower)");
    }
}
