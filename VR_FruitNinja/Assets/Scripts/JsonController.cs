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
          /*playerData.SliedFruitName = GameManager.gm_Instance.scoreController.SliedFruitName;
          playerData.MissedFruitName = GameManager.gm_Instance.scoreController.MissedFruitName;
          playerData.FruitSlicedTime = GameManager.gm_Instance.scoreController.FruitSlicedTime;
          playerData.SwordVelocity = GameManager.gm_Instance.scoreController.SwardVelocity; */


          string json = JsonUtility.ToJson(playerData);
          Debug.Log(json);
          Debug.Log(Application.dataPath);
          File.WriteAllText(Application.dataPath + "/SpawnedObjectInfo.json", json);

          //FruitsArr.Clear();
     }
}

[System.Serializable]
public class PlayerData
{
   /*   public List<string> SliedFruitName;
     public List<string> MissedFruitName;
     public List<string> FruitSlicedTime;
     public List<float> SwordVelocity; */
     public List<FruitSpawnInfo> spaceList;

}
