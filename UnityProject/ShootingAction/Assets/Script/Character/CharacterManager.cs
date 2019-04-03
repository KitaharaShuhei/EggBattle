using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class CharacterManager {

    public Transform SpawnPoint;
    [HideInInspector] public GameObject Instance;

    private PlayerHealth Health;

    public void Setup()
    {
        Health = Instance.GetComponent<PlayerHealth>();
    }

}
