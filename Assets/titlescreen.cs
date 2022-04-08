using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class titlescreen : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start()
    {
        SceneManager.LoadScene("menu");
    }

    public void title()
    {
        SceneManager.LoadScene("title");
    }

    public void settings()
    {
        SceneManager.LoadScene("settings");
    }

    public void credits()
    {
        SceneManager.LoadScene("credits");
    }

    public void exit()
    {
        Application.Quit();
    }

    public void game()
    {
        SceneManager.LoadScene("Game");
    }
}
