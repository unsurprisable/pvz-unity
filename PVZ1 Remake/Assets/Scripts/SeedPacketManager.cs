using System;
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
        GameInput.Instance.OnClickAction += GameInput_OnClickAction;
    }

    private void GameInput_OnClickAction(object sender, EventArgs e)
    {
        // planting seeds
        if (selectedSeed != null && PlantGrid.Instance.TryGetHoveredCell(out PlantGridCell cell)) {
            if (!cell.HasPlant()) {
                PlantGrid.Instance.PlantSeed(selectedSeed.plantMeta, cell);
                selectedSeed.StartCooldown();
            }
            DeselectSeed();
        }
    }

    // called from the seed packets themselves
    public void OnSeedPacketClicked(SeedPacket seed)
    {
        if (seed != selectedSeed) {
            if (selectedSeed != null) DeselectSeed();
            if (!seed.IsOnCooldown()) {
                SelectSeed(seed);
            }
        } else {
            DeselectSeed();
        }
    }

    private void SelectSeed(SeedPacket seed) {
        seed.Select();
        PlantGrid.Instance.Enable();
        selectedSeed = seed;
    }
    private void DeselectSeed() {
        selectedSeed.Deselect();
        PlantGrid.Instance.Disable();
        selectedSeed = null;
    }
}
