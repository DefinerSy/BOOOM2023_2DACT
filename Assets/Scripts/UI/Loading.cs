using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public GameObject panel;
    public Slider slider;
    

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        panel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync("SkillSystem");
        while (!operation.isDone)
        {
            slider.value = operation.progress;
            yield return null;
        }
    }
}
