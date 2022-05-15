using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Activador : MonoBehaviour
{
    private string nameUser;
    public InputField nameInputField;
    public Text nameText;
    public GameObject Principal;
    public GameObject Mision;
    public GameObject Information;
    public GameObject Warning;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
    }

    public void Init(){
        WriteName();
        Mision.SetActive(true);
        Principal.SetActive(false);
        Information.SetActive(false);
        Warning.SetActive(false);
    }

    public void Exit(){
        Application.Quit();
    }

    public void ContinueInformation(){
        Mision.SetActive(false);
        Principal.SetActive(false);
        Information.SetActive(true);
        Warning.SetActive(false);
    }

    public void ContinueWarning(){
        Mision.SetActive(false);
        Principal.SetActive(false);
        Information.SetActive(false);
        Warning.SetActive(true);
    }

    public void Play(){
        SceneManager.LoadScene("Game");
    }

    public void ReadName(){
       nameUser = nameInputField.text;
    }

    public void WriteName(){
        nameText.text = nameUser;
    }
}
