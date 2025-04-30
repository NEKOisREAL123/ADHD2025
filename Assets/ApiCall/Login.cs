using UnityEngine;

[System.Serializable]
public class Login
{
    [SerializeField]
    private string token;
    public string Token { get => token; set => token = value; }
    
    [SerializeField]
    public string privatetoken;
    public string PrivateToken { get => privatetoken; set => privatetoken = value; }
}