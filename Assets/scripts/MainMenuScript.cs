using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuScript : MonoBehaviour
{
    public GameObject loadingScreen;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
    }
    public void PlayGame()
    {
        StartCoroutine(WaitToLoad());
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }
}