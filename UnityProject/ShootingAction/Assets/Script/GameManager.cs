using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject PlayerCharacterPrefab;
    public GameObject EnemyCharacterPrefab;
    public CharacterManager[] Characters;
    public EnemyDamage enemydamage;
    public CoccoStatus coccoStatus;
    public VultureStatus vultureStatus;
    public string scene_name;
    

    bool judge = false;

    private void Start () {
        enemydamage = GetComponent<EnemyDamage>();


        coccoStatus = GetComponent<CoccoStatus>();
        FindObjectOfType<CoccoStatus>();

        vultureStatus = GetComponent<VultureStatus>();
        FindObjectOfType<VultureStatus>();

        //characterを生成
        SpawnAllCharacters();
    }


    public void  SpawnAllCharacters()
    {
        //PlayerCharacterPrefabを指定のposition,rotationにクローン生成する
        GameObject Playercharacter = Instantiate(PlayerCharacterPrefab, Characters[0].SpawnPoint.position, Characters[0].SpawnPoint.rotation) as GameObject;
        Playercharacter.name = PlayerCharacterPrefab.name;
        Characters[0].Instance = Playercharacter;
        coccoStatus = Playercharacter.gameObject.GetComponent<CoccoStatus>();

        //EnemyCharacterPrefabを指定のposition,rotationにクローン生成する
        GameObject Enemycharacter = Instantiate(EnemyCharacterPrefab, Characters[1].SpawnPoint.position, Characters[1].SpawnPoint.rotation) as GameObject;
        Enemycharacter.name = EnemyCharacterPrefab.name;
        Characters[1].Instance = Enemycharacter;
        vultureStatus = Enemycharacter.gameObject.GetComponent<VultureStatus>();

        Characters[1].Setup();
    }

    /*void Turn()
    {
      yield return  StartCoroutine("StartPhase");
      yield return StartPhase();
      //DamagePhase();
      //CheckJudge();
      //Turn();
    }*/

    IEnumerator StartPhase() {
        //PlayerがAttackボタンを押す
        //Speedを比較

        //ActionPhase()のSpeedの比較が終わるまでAttackボタンの処理を中断
        enemydamage.PlayerOnClick();
        //PlayerとenemyのAttackを選択。処理はDamagePhase()まで中断する
        yield return new WaitForSeconds(2.0f);
    }

    void CheckJudge() {
      
    }

}
