using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject enemyeggbullet;
    public Transform enemymuzzle;
    public float enemyspeed = 1000;
    private float counttime;

    void Start()
    {

    }

    public void updata()
    {
        
    }

    void Update()
    {
        counttime += Time.deltaTime;
        if (counttime >= 3)
        {
            GameObject enemybullet = Instantiate(enemyeggbullet) as GameObject;
            counttime = 0;

            Vector3 enemyforce;

            enemyforce = this.gameObject.transform.forward * enemyspeed;

            // Rigidbodyに力を加えて発射
            enemybullet.GetComponent<Rigidbody>().AddForce(enemyforce);

            // 弾丸の位置を調整
            enemybullet.transform.position = enemymuzzle.position;
        }
    }

   
}
