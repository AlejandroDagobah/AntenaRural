using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public void RestartButton()
    {
        Application.Quit();
    }

    // Update is called once per frame
    public void ExitButton()
    {
        SceneManager.LoadScene("Main_Scene");
    }
}
