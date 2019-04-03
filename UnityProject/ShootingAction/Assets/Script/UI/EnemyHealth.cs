using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    public int hp = 100;
    public Slider Slider;
    public Image E_FillImage;
    GameObject playercharacter;
    public GameObject WinImage;
    public GameObject enemyobj;
    public GameObject e_sliderobj;
    public GameObject playerobj;
    public GameObject p_sliderobj;
    public GameObject e_titlebutton;

    [Header("Color")]
    public Color FullHealthColor = Color.green;
    public Color ZeroHealthColor = Color.red;

    public void Start()
    {
        WinImage.SetActive(false);
        e_titlebutton.SetActive(false);
        playercharacter = GameObject.Find("PlayerCharacter");
        Slider = GetComponent<Slider>();
        playercharacter = GetComponent<GameObject>();
        Slider.value = hp;
        FindObjectOfType<Shooting>();
    }

    public void Update()
    {
        GameClear();
    }

    public void Damage(int E_Attack)
    {
        //PlayerDamageで返した値(E_Attackの数値)分をスライダーの現在値から減らす。
        Slider.value = Slider.value - E_Attack;
    }

    public void GameClear()
    {
        if (Slider.value == 0)
        {
            WinImage.SetActive(true);
            e_titlebutton.SetActive(true);
            Destroy(enemyobj);
            Destroy(e_sliderobj);
            Destroy(playerobj);
            Destroy(p_sliderobj);
         }

    }
    
}
