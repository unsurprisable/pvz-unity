
using UnityEngine;

public abstract class DestructiblePlant : BasePlant
{
    [Space]
    [Header("---Destructible Attributes---")]
    [SerializeField] private Sprite[] spriteStages;
    [SerializeField] private int[] healthIntervals;
    private int nextStage = 0;

    public override void OnBite()
    {
        if (nextStage >= healthIntervals.Length) return;
        if (health <= healthIntervals[nextStage]) {
            // change the sprite (not implemented yet)
            Debug.Log("i changed to a new sprite stage! wow");
            nextStage++;
        }
    }
}
