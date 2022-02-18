using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button btnStart;
    public Button btnExit;
    public Label lbMainMenu;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        btnStart = root.Q<Button>("btnStart");
        btnExit = root.Q<Button>("btnExit");
        lbMainMenu = root.Q<Label>("lbMainMenu");

        btnStart.clicked += StartButtonPressed;
        btnExit.clicked += ExitButtonPressed;
    }

    void StartButtonPressed() {
        SceneManager.LoadScene("MainScene");
    }

    void ExitButtonPressed() {
        ExitGame();
       
    } 

    void ExitGame() {
        UnityEditor.EditorApplication.isPlaying = false;
        // Exit for development mode

        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
