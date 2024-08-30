using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedPacketCooldown : MonoBehaviour
{
    [SerializeField] private Slider slider;

    public void Enable() {
        gameObject.SetActive(true);
        slider.value = 1;
    }
    public void Disable() {
        gameObject.SetActive(false);
    }
    public void UpdateProgress(float progress, float cooldownTime) {
        progress = Mathf.Clamp01(progress / cooldownTime);
        slider.value = progress;
    }
}
