using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VultureStatus : MonoBehaviour {
    public int E_Speed = 15;
    public int E_Attack = 50;

    public int GetEnemyAttack()
    {
        return E_Attack;
    }

    public int GetEnemySpeed()
    {
        return E_Speed;
    }

}
