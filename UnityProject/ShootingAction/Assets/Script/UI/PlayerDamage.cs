using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {
    //プレイヤーのダメージ処理

    //敵のステータスを利用するため、持ってくる。
    public VultureStatus vulturestatus;

    GameObject player;
    GameObject P_Damage; //プレイヤーが受けたダメージ
    PlayerHealth PH; //PlayerHealthのスクリプト略称


    public void Start()
    {
        //PlayerCharacterのオブジェクトを見つけ、OfTypeでスクリプトを参照する。
        player = GameObject.Find("PlayerCharacter");
        FindObjectOfType<PlayerHealth>();

        //プレイヤーのHPUIの子であるFillを見つけ、その中にEHを参照する。
        P_Damage = GameObject.Find("P_Fill");
        PH = P_Damage.GetComponent<PlayerHealth>();

       // vulturestatus = GetComponent<VultureStatus>();
    }

    public void TestOnClick()
    {
        vulturestatus = GetComponent<VultureStatus>();

        int E_Attack;
        E_Attack = vulturestatus.GetEnemyAttack();
        FindObjectOfType<EnemyHealth>().Damage(E_Attack);
    }

    void EnemyStartCoroutine()
    {
       // StartCoroutine("EnemyAttackSelect");
    }

    //コルーチン処理

    /*public IEnumerator EnemyAttackSelect()
    {
        yield return new WaitForEndOfFrame();
        Debug.Log("test");
    }*/

}
