using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyBullet : MonoBehaviour {
    public float E_time = 3;
    GameObject e_damageFill;
    GameObject e_player;
    VultureStatus e_vultureStatus;
    PlayerHealth e_PH;

    private void Start()
    {
        e_player = GameObject.Find("PlayerCharacter");
        FindObjectOfType<PlayerHealth>();
        e_damageFill = GameObject.Find("P_Fill");
        e_PH = e_damageFill.GetComponent<PlayerHealth>();
        FindObjectOfType<VultureStatus>();
        e_vultureStatus = GetComponent<VultureStatus>();
    }

    void Update () {
        E_time -= Time.deltaTime;
        if (E_time <= 1)
        {
            Destroy(gameObject);
            E_time = 3;
        }
	}

    private void OnTriggerEnter(Collider E_hit)
    {
        if (E_hit.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            int E_Attack;
            E_Attack = e_vultureStatus.GetEnemyAttack();
            FindObjectOfType<PlayerHealth>().E_Damage(E_Attack);
        }
    }
}