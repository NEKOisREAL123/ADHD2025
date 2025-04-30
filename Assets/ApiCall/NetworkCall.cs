using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NetworkCall : MonoBehaviour
{
    public ApiManager _apiManager;
    public Text GetTime;
    private int levelNumber;
    string difficultyLevel;
    //public Text errortext;
    
    void Start()
    {
        _apiManager = gameObject.AddComponent<ApiManager>();
        difficultyLevel = clickS.setLevel;
        levelNumber = SceneManager.GetActiveScene().buildIndex - 1;
        
    }
    
    public void PostPlayerData()
    {
        PostPlayerDataCoroutine();
    }
    
    // private IEnumerator GetToken()
    // {
    //     var username = "yuuzu";
    //     var password = "qwer";
    //     var endpoint = $"login/token.php?username={username}&password={password}";
    //     bool requestCompleted = false;
    //     
    //     _apiManager.Get<Login, ApiError>(endpoint, result =>
    //     {
    //         requestCompleted = true;
    //         if (result is ApiResult<Login, ApiError>.Success success)
    //         {
    //             Debug.Log("Token: " + success.Data.Token);
    //             Debug.Log("Private Token: " + success.Data.PrivateToken);
    //         }
    //         else if (result is ApiResult<Login, ApiError>.Failure failure)
    //         {
    //             Debug.Log("Error: " + failure.Error);
    //             errortext.text = "Error: " + failure.Error; 
    //         }
    //         else
    //         {
    //             errortext.text = "An unexpected result type was received.";
    //             Debug.Log("An unexpected result type was received.");
    //         }
    //     });
    //     
    //     while (!requestCompleted)
    //     {
    //         yield return null;
    //     }
    // }
    
    private void PostPlayerDataCoroutine()
    {
        PlayerData data = new PlayerData()
        {
            name = Player_Check.getName,
            age = Player_Check.getAge,
            gender = Player_Check.getGender
        };

        _apiManager.Post<PlayerResponse, ApiError>("api/Players", data, result =>
        {
            if (result is ApiResult<PlayerResponse, ApiError>.Success success)
            {
                Debug.Log("Player ID: " + success.Data.id);
                PostLevelData();
            }
            else if (result is ApiResult<PlayerResponse, ApiError>.Failure failure)
            {
                Debug.Log("Error: " + failure.Error.message);
            }
        });
        Debug.Log("POST Request Completed");
    }

    public void PostLevelData()
    {
        Level level = new Level
        {
            playerId = ApiManager.playerid,
            levelNumber = SceneManager.GetActiveScene().buildIndex - 1,
            difficulty = difficultyLevel,
            score = 0,
            time = Convert.ToInt32(GetTime.text)
        };

        //Debug.Log("playerid: " + level.playerId);
        Debug.Log("levelNumber: " + level.levelNumber);
        //Debug.Log("difficulty: " + level.difficulty);
        //Debug.Log("score: " + level.score);
        //Debug.Log("time: " + level.time);

        _apiManager.Post<string, ApiError>("api/Levels", level, result =>
        {
            if (result is ApiResult<string, ApiError>.Success success)
            {
                Debug.Log(success.Data);
            }
            else if (result is ApiResult<string, ApiError>.Failure failure)
            {
                Debug.Log(failure.Error.message);
            }
            else
            {
                Debug.Log("An unexpected result type was received.");
            }
            Debug.Log("POST Request Completed");
            if (SceneManager.GetActiveScene().buildIndex != 4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        });
    }
}