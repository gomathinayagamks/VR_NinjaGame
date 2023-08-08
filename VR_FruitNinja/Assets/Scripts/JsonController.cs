using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;


public class JsonController : MonoBehaviour
{
    public List<FruitSpawnInfo> FruitsArr = new List<FruitSpawnInfo>();

    private string serverUrl = "https://8aaa000o0i.execute-api.eu-north-1.amazonaws.com/test/s3put";

    public void CreateJson()
    {
        PlayerData playerData = new PlayerData();
        playerData.spaceList = FruitsArr;

        string json = JsonUtility.ToJson(playerData);        
        StartCoroutine(PostJsonData(json));

        //File.WriteAllText(Application.dataPath + "/FruitsInfo.json", json);
    }

    IEnumerator PostJsonData(string json)
    {
        using (UnityWebRequest webRequest = new UnityWebRequest(serverUrl, "POST"))
        {
            byte[] jsonBytes = System.Text.Encoding.UTF8.GetBytes(json);
            webRequest.uploadHandler = new UploadHandlerRaw(jsonBytes);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");

            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("JSON data successfully posted to server.");
                string response = webRequest.downloadHandler.text;
                byte[] results = webRequest.downloadHandler.data;

                Debug.Log(response.ToString());
            }
            else
            {
                Debug.LogError("Error posting JSON data: " + webRequest.error);
            }
        }
        /*WWWForm form = new WWWForm();
        
        using (UnityWebRequest webRequest = UnityWebRequest.Post(serverUrl, form))
        {
            Debug.Log(serverUrl);

            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequest.error);
            }
            else
            {
                string response = webRequest.downloadHandler.text;
                byte[] results = webRequest.downloadHandler.data;

                Debug.Log(response.ToString());

            }
        }*/
    }
}

[System.Serializable]
public class PlayerData
{
    public List<FruitSpawnInfo> spaceList;

}
