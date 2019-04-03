using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoccoStatus : MonoBehaviour
{
   public int Speed = 20;
   public int Attack = 10;

    public int GetPlayerAttack()
    {
        return Attack;
    }

    public int GetPlayerSpeed()
    {
        return Speed;
    }

}


