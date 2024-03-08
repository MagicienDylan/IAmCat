using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void OnStartGameHandler(string sceneName)
    {
        //”√¿¥ªª≥°æ∞
        SceneManager.LoadScene(sceneName);
    }
}
