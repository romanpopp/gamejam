using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class returnToMenu : MonoBehaviour
{
    public Button playButton;

    void Start()
    {
        playButton.onClick.AddListener(ReturnToMenu);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("HomeMenu", LoadSceneMode.Single);
    }
}
