using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedPacketManager : MonoBehaviour
{
    public static SeedPacketManager Instance { get; private set; }

    private SeedPacket selectedSeed = null;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    // called from the seed packets themselves
    public void OnSeedPacketClicked(SeedPacket seed)
    {
        if (seed != selectedSeed) {
            if (selectedSeed != null) selectedSeed.Deselect();
            seed.Select();
            selectedSeed = seed;
        } else {
            seed.Deselect();
            selectedSeed = null;
        }

        if (selectedSeed != null) {
            PlantGrid.Instance.Enable();
        } else {
            PlantGrid.Instance.Disable();
        }
    }
}
