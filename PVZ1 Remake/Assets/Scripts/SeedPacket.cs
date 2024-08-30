
using UnityEngine;
using UnityEngine.UI;

public class SeedPacket : MonoBehaviour
{
    public PlantMetaSO plantMeta;
    [Space]
    [SerializeField] private int cost;
    [SerializeField] private float cooldown;
    [Space]
    [SerializeField] private GameObject selectedVisual;
    [SerializeField] private SeedPacketCooldown cooldownVisual;

    private Button button;

    private float cooldownLeft = 0;
    private bool isOnCooldown = false;
    private bool isSelected = false; // remember to remove this if its not needed

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

    private void Update()
    {
        if (isOnCooldown) {
            cooldownLeft -= Time.deltaTime;
            cooldownVisual.UpdateProgress(cooldownLeft, cooldown);
            if (cooldownLeft <= 0) {
                EndCooldown();
            }
        }
    }

    public void StartCooldown() {
        isOnCooldown = true;
        cooldownLeft = cooldown;
        cooldownVisual.Enable();
    }

    private void EndCooldown() {
        isOnCooldown = false;
        cooldownVisual.Disable();
    }

    public void Select() {
        isSelected = true;
        selectedVisual.SetActive(true);
    }
    public void Deselect() {
        isSelected = false;
        selectedVisual.SetActive(false);
    }

    public bool IsOnCooldown() {
        return isOnCooldown;
    }

}
