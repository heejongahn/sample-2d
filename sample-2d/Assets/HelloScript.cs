using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelloScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [ContextMenu("Start Game")]
    public void startGame()
    {
        Debug.Log("Loading Scene");
        SceneManager.LoadScene("GameScene");
    }
}
