using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{


    [SerializeField] private Button Play;
    [SerializeField] private Button Options;
    [SerializeField] private Button Credits;
    [SerializeField] private Button Back;

    [SerializeField] private GameObject mainMenuPanel, creditsPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void GoToLevel1()
    {
       
        SceneManager.LoadScene("MiniRPG Dungeon");

    }

    public void GoToOptions()
    {
        Debug.Log("Aun no hay opciones disponibles");
    }

    public void GoToCredits()
    {
        creditsPanel.SetActive(true);
        mainMenuPanel.SetActive(false);

    }


    public void BackToMainMenu()
    {
        creditsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
