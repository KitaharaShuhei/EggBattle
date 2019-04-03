using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int Playerhp = 100;
    public Slider PlayerSlider;
    public Image P_FillImage;
    public GameObject LoseImage;
    public GameObject enemycharacter;
    public GameObject playerobj;
    public GameObject p_sliderobj;
    public GameObject enemy;
    public GameObject enemyslider;
    
    public GameObject p_rematchbutton;

    [Header("Color")]
    public Color FullHealthColor = Color.green;
    public Color ZeroHealthColor = Color.red;

    void Start()
    {
        LoseImage.SetActive(false);
        p_rematchbutton.SetActive(false);
        enemycharacter = GameObject.Find("EnemyCharacter");
        PlayerSlider = GetComponent<Slider>();
        enemycharacter = GetComponent<GameObject>();
        PlayerSlider.value = Playerhp;
    }

    public void Update()
    {
        GameOver();
    }

    public void E_Damage(int P_Attack)
    {
        PlayerSlider.value -= P_Attack;
    }

    public void GameOver()
    {
        if (PlayerSlider.value == 0)
        {
            LoseImage.SetActive(true);
            p_rematchbutton.SetActive(true);
            Destroy(playerobj);
            Destroy(p_sliderobj);
            Destroy(enemy);
            Destroy(enemyslider);
         
        }
    }

}
