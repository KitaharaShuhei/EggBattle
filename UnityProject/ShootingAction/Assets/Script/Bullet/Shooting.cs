using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    public GameObject EggBullet;

    public Transform muzzle;

    public float speed = 1000;
    
	void Update () {
        
        //Spaceキーが押されたとき
		if (Input.GetMouseButtonDown(1))
        {
            //エッグバレットの複製
            GameObject bullets = Instantiate(EggBullet) as GameObject;
            bullets.name = EggBullet.name;

            Vector3 force;

            force = this.gameObject.transform.forward * speed;

            // Rigidbodyに力を加えて発射
            bullets.GetComponent<Rigidbody>().AddForce(force);

            // 弾丸の位置を調整
            bullets.transform.position = muzzle.position;
        }
	}

}
