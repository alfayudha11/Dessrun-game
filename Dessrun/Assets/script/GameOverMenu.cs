using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("Assets/Scenes/SampleScene.unity");

    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Assets/Scenes/MainMenu.unity");
    }
}
