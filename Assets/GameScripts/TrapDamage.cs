using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDamage : MonoBehaviour
{
    public float DamageDealt;

    private void OnTriggerEnter(Collider other)
    {
        Transform collisionObject = GameObjectExtension.GetParentFromCollision(other);

        if (collisionObject.gameObject.GetComponent<Animal>() != null)
        {
            collisionObject.gameObject.GetComponent<Animal>().Health -= DamageDealt;
        }
    }
}
