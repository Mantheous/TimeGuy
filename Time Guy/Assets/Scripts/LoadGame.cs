using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("Level", 1);
    }
    public void LoadScene()
    {
        int level = PlayerPrefs.GetInt("Level");
        SceneManager.LoadScene(level);
    }
}
