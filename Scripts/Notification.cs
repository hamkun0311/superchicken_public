using System;
using UnityEngine;
using Firebase;
using Firebase.Messaging;

public class Notification : MonoBehaviour
{
    FirebaseApp _app;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StartFirebase");
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
            {
                if(task.Result == DependencyStatus.Available)   
                {
                    _app = FirebaseApp.DefaultInstance;
                    
                    Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
                    Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;

                }
                else
                {
                    Debug.LogError("[FIREBASE] Could not resolve all dependencies : " + task.Result);
                }
            });

    }

    public void OnTokenReceived(object sender, TokenReceivedEventArgs e)
    {
        if(e != null)
        {
            Debug.LogFormat("[FIREBASE] Token: {0} ",e.Token);
        }
        
    }

    public void OnMessageReceived(object sender, MessageReceivedEventArgs e) 
    {
        if(e != null && e.Message != null && e.Message.Notification != null)
        {
            Debug.LogFormat("[FIREBASE] From: {0}, Title: {1}, Text: {2}", e.Message.From, e.Message.Notification.Title, e.Message.Notification.Body);
        }
        
    }


}
