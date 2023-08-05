using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonController : MonoBehaviour
{
     public List<FruitSpawnInfo> FruitsArr = new List<FruitSpawnInfo>();
     
     public void CreateJson()
     {
          PlayerData playerData = new PlayerData();

          playerData.spaceList = FruitsArr;

          string json = JsonUtility.ToJson(playerData);
          Debug.Log(json);
          Debug.Log(Application.dataPath);
          File.WriteAllText(Application.dataPath + "/FruitsInfo.json", json);
     }
}

[System.Serializable]
public class PlayerData
{   
     public List<FruitSpawnInfo> spaceList;

}
