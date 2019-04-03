using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour {

    public string scene_name;

    // ボタンを押すとselectシーンへ遷移
    public void OnClick()
    {
        SceneManager.LoadScene(scene_name);
    }
}
