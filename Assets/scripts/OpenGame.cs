using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void openGameScene()
    {
        SceneManager.LoadScene(2);
    }
}
