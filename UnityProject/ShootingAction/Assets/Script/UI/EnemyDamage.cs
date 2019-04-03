using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    //エネミーのダメージ処理

    public CoccoStatus coccoStatus;
    GameObject enemy;
    GameObject E_Damage;
    EnemyHealth EH;

    private void Start()
    {
        enemy = GameObject.Find("EnemyCharacter");
        FindObjectOfType<EnemyHealth>();
       // E_Damage = GameObject.Find("E_Fill");
        EH = E_Damage.GetComponent<EnemyHealth>();
    }

    public void PlayerOnClick()
    {
        coccoStatus = GetComponent<CoccoStatus>();
        
        int P_Attack;
        P_Attack = coccoStatus.GetPlayerAttack();
        FindObjectOfType<EnemyHealth>().Damage(P_Attack);
    }
}