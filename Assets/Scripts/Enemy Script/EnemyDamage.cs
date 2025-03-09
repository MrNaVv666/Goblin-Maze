using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 2;
    public LayerMask playerLayer;

    void Update()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, 0.1f, playerLayer);
        if(hit.Length > 0 )
        {
            if(hit[0].gameObject.tag == Tags.PLAYER_TAG)
            {
                hit[0].gameObject.GetComponent<PlayerHealth>().ApplyDamage(damage);
            }
        }
    }
}
