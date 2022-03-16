using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoaderScene : MonoBehaviour
{
    public GameObject loadAsyncLabel;
    public Slider loadingSlider;
    public TextMeshProUGUI progessText;

    public void LoadScene(int sceneIndex)
    {
        loadAsyncLabel.SetActive(true);
        StartCoroutine(LoadSceneAsync(sceneIndex));
    }

    IEnumerator LoadSceneAsync(int sceneIndex)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneIndex);
        
        while (!async.isDone)
        {
            loadingSlider.value = async.progress;
            float progess = Mathf.Clamp01(async.progress / 0.9f);
            progessText.text = progess * 100 + "%";
            yield return null;
        }
    }
}
