
using System.Collections;
using UnityEngine;

public abstract class PeriodicPlant : BasePlant
{
    [Space]
    [Header("---Periodic Attributes---")]
    [SerializeField] private float initialDelay;
    [SerializeField] private float period;

    public abstract void OnCycleComplete();

    private void OnEnable() {
        StartCoroutine(PeriodicBehavior());
    }

    IEnumerator PeriodicBehavior()
    {
        yield return new WaitForSeconds(initialDelay);
        while (true) {
            OnCycleComplete();
            yield return new WaitForSeconds(period);
        }
    } 
}
