using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int damage = 2;
    public LayerMask enemyLayer;

    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, 0.1f, enemyLayer);
        if (hit.Length > 0)
        {
            if (hit[0].gameObject.tag == Tags.ENEMY_TAG)
            {
                print("ALE GOBELUN");
            }
        }
    }
}
