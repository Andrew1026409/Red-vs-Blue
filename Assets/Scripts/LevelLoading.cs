using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoading : MonoBehaviour
{
    [SerializeField] private string levelToLoad;

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
