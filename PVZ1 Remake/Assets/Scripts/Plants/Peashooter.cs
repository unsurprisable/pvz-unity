using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peashooter : PeriodicPlant
{
    public override void OnCycleComplete()
    {
        Debug.Log("shoot!!!");
    }
}
