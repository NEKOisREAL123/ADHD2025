using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.SceneManagement;

public class ApiManager : MonoBehaviour
{
    private readonly string _baseUrl = "https://yuuzu.net/";
    public static string playerid;

    // Make a GET request
    public void Get<TD, TE>(string endpoint, Action<ApiResult<TD, TE>> callback) where TE : Error
    {
        UnityWebRequest request = UnityWebRequest.Get(new StringBuilder(_baseUrl).Append(endpoint).ToString());
        request.certificateHandler = new CertificateWhore();
        request.SendWebRequest().completed += _ =>
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                string data = request.downloadHandler.text;
                TD result = JsonUtility.FromJson<TD>(data);
                Debug.Log("Result: " + (result == null ? "null" : "not null"));
                callback(new ApiResult<TD, TE>.Success(result));
            }
            else
            {
                string errorJson = request.downloadHandler.text;
                TE error = JsonUtility.FromJson<TE>(errorJson);
                callback(new ApiResult<TD, TE>.Failure(error));
            }
        };
    }

    // for form data
    public void Post<TD, TE>(string endpoint, WWWForm data, Action<ApiResult<TD, TE>> callback) where TE : Error
    {
        UnityWebRequest request = UnityWebRequest.Post(new StringBuilder(_baseUrl).Append(endpoint).ToString(), data);
        request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");
        request.downloadHandler = new DownloadHandlerBuffer();
        request.certificateHandler = new CertificateWhore();
        
        request.SendWebRequest().completed += _ =>
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                string respondData = request.downloadHandler.text;
                TD result = JsonUtility.FromJson<TD>(respondData);
                ExtractPlayerId(respondData); // 提取playerid
                callback(new ApiResult<TD, TE>.Success(result));
            }
            else
            {
                string errorJson = request.downloadHandler.text;
                TE error = JsonUtility.FromJson<TE>(errorJson);
                callback(new ApiResult<TD, TE>.Failure(error));
            }
        };
    }

    // for json data
    public void Post<TD, TE>(string endpoint, object payload, Action<ApiResult<TD, TE>> callback) where TE : Error
    {
        string jsonData = JsonUtility.ToJson(payload);
        UnityWebRequest request = new UnityWebRequest(new StringBuilder(_baseUrl).Append(endpoint).ToString(), "POST");
        byte[] jsonToSend = new UTF8Encoding().GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(jsonToSend);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.certificateHandler = new CertificateWhore();
        
        request.SendWebRequest().completed += _ =>
        {
            if (request.result == UnityWebRequest.Result.Success)
            {
                string responseData = request.downloadHandler.text;
                Debug.Log(responseData);
                TD result = JsonUtility.FromJson<TD>(responseData);
                if (typeof(TD) == typeof(PlayerResponse))
                {
                    ExtractPlayerId(responseData); // 提取playerid
                }
                callback(new ApiResult<TD, TE>.Success(result));
            }
            else
            {
                string errorJson = request.downloadHandler.text;
                Debug.LogError("Error: " + errorJson); // 更改為使用Debug.LogError以標記錯誤
                TE error = JsonUtility.FromJson<TE>(errorJson);
                callback(new ApiResult<TD, TE>.Failure(error));
            }
        };
    }

    private void ExtractPlayerId(string responseData)
    {
        var json = JsonUtility.FromJson<PlayerResponse>(responseData);
        playerid = json.id;
        Debug.Log("Player ID: " + playerid);
    }
}

[Serializable]
public class PlayerResponse
{
    public string id;
}

[Serializable]
public class PlayerRequest
{
    public string playerId;
}