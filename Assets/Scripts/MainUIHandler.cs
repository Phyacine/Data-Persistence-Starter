using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainUIHandler : MonoBehaviour
{
    // Start is called before the first frame update

    private GameObject playerName;
    private TMP_InputField inputField;
    void Start()
    {
        playerName = GameObject.Find("Player Input");
        inputField = playerName.GetComponent<TMP_InputField>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
        //MainManager.Instance.PlayerName = 
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void GetName()
    {
        Debug.Log(inputField.text);
        if (playerName != null)
        {
            PlayerDataHandler.instance.currentPlayer = inputField.text;
        }
        
    }

    
}
