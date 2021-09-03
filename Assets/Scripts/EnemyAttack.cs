using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 40f;
    PlayerHealth player;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
        target = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AttackHitEvent()
    {
        if(target == null) { return; }
        player.ReceiveDamage(damage);
    }
}
