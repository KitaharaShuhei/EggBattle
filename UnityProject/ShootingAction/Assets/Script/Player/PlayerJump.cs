using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

    private CharacterController controller;
    private Vector3 moveDirection;

	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	void Update () {
        if (controller.isGrounded)
        {
            if (Input.GetMouseButtonDown(0))
            {
                moveDirection.y = 8;
            }
            
        }
        moveDirection.y -= 14 * Time.deltaTime; //重力計算
        controller.Move(moveDirection * Time.deltaTime);
	}

    private void OnControllerColliderHit(Collision E_hit)
    {
        if (E_hit.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
