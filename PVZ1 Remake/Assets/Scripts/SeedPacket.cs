
using UnityEngine;
using UnityEngine.UI;

public class SeedPacket : MonoBehaviour
{
    [SerializeField] private PlantMetaSO plantMeta;
    [Space]
    [SerializeField] private int cost;
    [SerializeField] private float cooldown;
    [Space]
    [SerializeField] private GameObject selectedVisual;

    private Button button;

    private float cooldownLeft = 0;
    private bool isOnCooldown = false;
    private bool isSelected = false;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Start()
    {
        button.onClick.AddListener(() => {
            SeedPacketManager.Instance.OnSeedPacketClicked(this);
        });
    }

    public void Select() {
        isSelected = true;
        selectedVisual.SetActive(true);
    }
    public void Deselect() {
        isSelected = false;
        selectedVisual.SetActive(false);
    }

}
