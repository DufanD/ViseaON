// <copyright file="SigninSampleScript.cs" company="Google Inc.">
// Copyright (C) 2017 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations

namespace SignInSample {
  using System;
  using System.Collections.Generic;
  using System.Threading.Tasks;
  using Google;
  using UnityEngine;
  using UnityEngine.UI;
  using Firebase;
  using Firebase.Auth;
  using Firebase.Database;
  using Firebase.Unity.Editor;
  using UnityEngine.SceneManagement;


  public class SigninSampleScript : MonoBehaviour {

    private GoogleSignInConfiguration configuration;
    public GameObject window;
    public GameObject windowLogin;
    public GameObject buttonBack;
    public GameObject buttonOk;
    public Text messageField;
    public string webClientId = "<your we client id here>";
    FirebaseAuth auth;
    FirebaseUser user;
    DatabaseReference mDBreference;

        // Defer the configuration creation until Awake so the web Client ID
        // Can be set via the property inspector in the Editor.
    void Awake() {
      configuration = new GoogleSignInConfiguration {
            WebClientId     = webClientId,
            RequestIdToken  = true
      };
      auth = FirebaseAuth.DefaultInstance;
      FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://viseaon-db.firebaseio.com/");
      mDBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }

    void Start(){
      user = auth.CurrentUser;
    }

    public void OnSignIn() {
      
            if (user == null)
            {
                GoogleSignIn.Configuration = configuration;
                GoogleSignIn.Configuration.UseGameSignIn = false;
                GoogleSignIn.Configuration.RequestIdToken = true;
                GoogleSignIn.DefaultInstance.SignIn().ContinueWith(OnAuthenticationFinished);
            }
            else
            {
                SceneManager.LoadScene("ModeOption");
            }
    }

    public void OnSignOut()
    {
            GoogleSignIn.DefaultInstance.SignOut();
            auth.SignOut();
            PlayerPrefs.SetInt("vrLevel", 0);
            PlayerPrefs.SetInt("vrAllow", 1);
            SceneManager.LoadScene("login");
    }
    
    internal void OnAuthenticationFinished(Task<GoogleSignInUser> task) {
      if (task.IsFaulted) {
        using (IEnumerator<System.Exception> enumerator = task.Exception.InnerExceptions.GetEnumerator()) {
          if (enumerator.MoveNext()) {
            GoogleSignIn.SignInException error = (GoogleSignIn.SignInException)enumerator.Current;
            Show("SingIn Failed" , false);
          } else {
            Show("SingIn Failed", false);
          }
        }
      } else if(task.IsCanceled) {
        Show("SignIn Canceled", false);
      } else  {
        Credential credential   = GoogleAuthProvider.GetCredential(((Task<GoogleSignInUser>)task).Result.IdToken, null);
        auth.SignInWithCredentialAsync(credential).ContinueWith(authTask => {
            if (authTask.IsCanceled)
            {
                Show("SignIn Canceled", false);
            }
            else if (authTask.IsFaulted)
            {
                Show("SingIn Failed", false);
            }
            else
            {
                Show("Welcome: \n" + authTask.Result.DisplayName, true);
                User usr = new User(authTask.Result.Email, authTask.Result.DisplayName);
                FirebaseDatabase.DefaultInstance.GetReference("users").GetValueAsync().ContinueWith(userTask =>
                    {
                        DataSnapshot snapshot = userTask.Result;
                        if (!snapshot.HasChild(auth.CurrentUser.UserId))
                        {
                            string json = JsonUtility.ToJson(usr);
                            mDBreference.Child("users").Child(auth.CurrentUser.UserId).SetRawJsonValueAsync(json);
                        }
                        
                    }
                );
            }
          
        });
      }
    }

    public void Show(string message, Boolean status)
    {
        messageField.text = message;
        windowLogin.SetActive(false);
        window.SetActive(true);
        if (status == true) {
           buttonOk.SetActive(true);
           buttonBack.SetActive(false);
        }
        else {
            buttonBack.SetActive(true);
            buttonOk.SetActive(false);
        }
    }

    void OnApplicationQuit()
    {
        GoogleSignIn.DefaultInstance.SignOut();
    }
  }
}
