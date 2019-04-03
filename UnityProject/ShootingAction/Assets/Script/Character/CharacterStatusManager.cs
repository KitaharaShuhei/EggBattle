using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterStatusManager : MonoBehaviour
{
    CharaData charadata;

    private void Start()
    {
        GetJsonFromWww();
        charadata = GetComponent<CharaData>();
        int Id = charadata.Id;
        Debug.Log(Id);
        string Name = charadata.Name;
        int Speed = charadata.Speed;
        int Attack = charadata.Attack;
    }

    public void GetJsonFromWww()
    {
        //APIが設置しているURLパス
        string sTgtURL = "http://localhost/charastatus/charastatus/getCharaStatus";

        //Wwwを利用してjsonデータ取得をリクエストする
        StartCoroutine(GetMessages(sTgtURL, CallbackWwwSuccess, CallbackWwwFailed));
    }

    private IEnumerator GetMessages(string sTgtURL, Action<string> cbkSuccess = null, Action cbkFailed = null)
    {
        //WWWを利用してリクエストを送る
        WWW www = new WWW(sTgtURL);

        //WWWレスポンス待ち
        yield return StartCoroutine(ResponceCheckForTimeOutWWW(www, 5.0f));

        if (www.error != null)
        {
            //レスポンスエラーの場合
            Debug.LogError(www.error);
            if (null != cbkFailed)
            {
                cbkFailed();
            }
        }
        else
        if (www.isDone)
        {
            // リクエスト成功の場合
            Debug.Log(string.Format("Success:{0}", www.text));
            if (null != cbkSuccess)
            {
                cbkSuccess(www.text);
            }
        }
    }

    private void CallbackWwwSuccess(string response)
    {
        //json データ取得が成功したのでデシリアライズして整形し画面に表示する
        List<CharaData> charaList = CharaDataModel.DeserializeFromJson(response);

        string sStrOutput = "";
        foreach (CharaData charaData in charaList)
        {
            sStrOutput += string.Format("Id:{0}\n", charaData.Id);
            sStrOutput += string.Format("Name:{0}\n", charaData.Name);
            sStrOutput += string.Format("Speed:{0}\n", charaData.Speed);
            sStrOutput += string.Format("Attack:{0}\n", charaData.Attack);

            //CreateResultContent(resultData);
        }
        Debug.Log("sStrOutput");
    }

    private IEnumerator ResponceCheckForTimeOutWWW(WWW www, float timeout)
    {
        float requestTime = Time.time;

        while (!www.isDone)
        {
            if (Time.time - requestTime < timeout)
            {
                yield return null;
            }
            else
            {
                Debug.LogWarning("TimeOut"); //タイムアウト
                break;
            }
        }
        yield return null;
    }

    private void CallbackWwwFailed()
    {
        Debug.Log("sStrOutput");
    }
}
