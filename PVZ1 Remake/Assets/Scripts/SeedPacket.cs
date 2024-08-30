
using UnityEngine;

public class SeedPacket : MonoBehaviour
{
    [SerializeField] private PlantMetaSO plantMeta;
    [Space]
    [SerializeField] private int cost;
    [SerializeField] private float cooldown;

    private float cooldownLeft = 0;
    private bool isOnCooldown = false;
    private bool isSelected = false;
}
