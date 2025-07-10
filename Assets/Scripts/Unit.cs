using System;
using UnityEngine;

public class Unit : MonoBehaviour
{

    void Start()
    {
        UnitSelectionManager.instance.allUnits.Add(gameObject);
    }

    private void OnDestroy()
    {
        UnitSelectionManager.instance.allUnits.Remove(gameObject);
    }

    internal void TakeDamage(int damageToInflict)
    {
        throw new NotImplementedException();
    }
}
