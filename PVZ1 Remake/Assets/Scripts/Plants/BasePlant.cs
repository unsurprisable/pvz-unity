using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasePlant : MonoBehaviour
{
    [Space]
    [Header("---Base Attributes---")]
    [SerializeField] private PlantMetaSO plantMeta;
    [SerializeField] protected int health;

    public virtual void OnBite() {}
}
