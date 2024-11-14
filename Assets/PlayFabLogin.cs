using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayFabLogin : MonoBehaviour
{
    [Header("LOGIN")]
    private string userEmailLogin;
    private string userPasswordLogin;
    // Start is called before the first frame update
    public void Start()
    {
        // Tarkistetaan ettei TitleID ole tyhjä eli null
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            // Lisää oma TitleID,jonka löydät PlayFab pilven Game Managerista
            PlayFabSettings.TitleId = "";
        }
        // API-kutsu (GET) sähköpostikirjautumista varte
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("Congratulations, you made your first successful API call!");
    }

    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }

    public void GetUserPasswordLogin(string passwordIn)
    {
        userPasswordLogin = passwordIn;
    }
    public void  GetUserEmailLogin(string emailIn)
    {
        userEmailLogin = emailIn;
    }
    // Login -painikkeen koodi eli tässä tehdään API-kutsu Playfab pilveen ja selvitetään onko käyttäjä olemassa
    public void LogIn()
    {
        var request = new LoginWithEmailAddressRequest { Email = userEmailLogin, Password = userPasswordLogin };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailure);
    }
    
}
