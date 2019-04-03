using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDestroyBullet : MonoBehaviour {
    public float P_time = 3;
    GameObject t_damageFill;
    GameObject t_enemy;
    CoccoStatus t_coccoStatus;
    EnemyHealth t_EH;

    private void Start()
    {
        t_enemy = GameObject.Find("EnemyCharacter");
        FindObjectOfType<EnemyHealth>();
        t_damageFill = GameObject.Find("E_Fill");
        t_EH = t_damageFill.GetComponent<EnemyHealth>();
        FindObjectOfType<CoccoStatus>();
        t_coccoStatus = GetComponent<CoccoStatus>();
    }

    void Update () {
        P_time -= Time.deltaTime;
        if (P_time <= 1)
        {
            Destroy(gameObject);
            P_time = 3;
        }
	}

    private void OnCollisionEnter(Collision P_hit)
    {
        if (P_hit.gameObject.CompareTag("Enemy"))
        {
            
            int P_Attack;
            P_Attack = t_coccoStatus.GetPlayerAttack();
            FindObjectOfType<EnemyHealth>().Damage(P_Attack);
            Destroy(this.gameObject);
        }
    }
}
