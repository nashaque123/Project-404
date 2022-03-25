using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyWithTraps : MonoBehaviour
{
    public GameObject TrapPrefab;
    [SerializeField]
    private float TrapRechargeTime;
    private bool canSetTrap = true;

    public void SetTrap()
    {
        Instantiate(TrapPrefab, transform.position, Quaternion.identity);
        StartCoroutine(RechargeTrap());
    }

    private IEnumerator RechargeTrap()
    {
        canSetTrap = false;
        yield return new WaitForSeconds(TrapRechargeTime);
        canSetTrap = true;
    }

    public bool CanSetTrap
    {
        get
        {
            return canSetTrap;
        }
    }
}
