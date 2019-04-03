using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;		// Json

public class CharaDataModel : MonoBehaviour {

    public static List<CharaData> DeserializeFromJson(string sStrJson)
    {
        List<CharaData> ret = new List<CharaData>();
        CharaData tmp = null;

        // JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト      
        IList jsonList = (IList)Json.Deserialize(sStrJson);

        // リストの内容はオブジェクトなので、辞書型の変数に一つ一つ代入しながら、処理
        foreach (IDictionary jsonOne in jsonList)
        {

            //新レコード解析開始
            tmp = new CharaData();

            if (jsonOne.Contains("Id"))
            {
                tmp.Id = (int)(long)jsonOne["Id"];
            }
            if (jsonOne.Contains("Name"))
            {
                tmp.Name = (string)jsonOne["Name"];
            }
            if (jsonOne.Contains("Speed"))
            {
                tmp.Speed = (int)(long)jsonOne["Speed"];
            }
            if (jsonOne.Contains("Attack"))
            {
                tmp.Attack = (int)(long)jsonOne["Attack"];
            }

            //現レコード解析終了
            ret.Add(tmp);
            tmp = null;
        }
        return ret;
    }
}
