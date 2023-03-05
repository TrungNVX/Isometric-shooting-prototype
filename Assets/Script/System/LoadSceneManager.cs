using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneManager : BYSingleton<LoadSceneManager>
{
    public GameObject uiObject;
    public Slider progress_sl;
    public Text progress_lb;
    private int index = -1;
    private string name_scene = string.Empty;
    private Action callback;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadScene(int index, Action callback)
    {
        this.index = index;
        this.callback = callback;
        StopCoroutine("LoadSceneProgress");
        StartCoroutine("LoadSceneProgress");
    }
    public void LoadScene(string name_Scene, Action callback)
    {
        this.name_scene = name_Scene;
        this.callback = callback;
        StopCoroutine("LoadSceneProgress");
        StartCoroutine("LoadSceneProgress");
    }
    IEnumerator LoadSceneProgress()
    {
        progress_sl.value = 0;
        progress_lb.text = "0%";
        uiObject.SetActive(true);
        AsyncOperation asyncOperation = null;
        if (index >= 0)
            asyncOperation= SceneManager.LoadSceneAsync(index, LoadSceneMode.Single);
        else
            asyncOperation=SceneManager.LoadSceneAsync(name_scene, LoadSceneMode.Single);
        float count=0;
        while (count <= 50)
        {
            count++;
            yield return new WaitForSeconds(0.1f);
            progress_sl.value = count/100f;
            progress_lb.text = (count).ToString() + "%";
        }
        yield return new WaitUntil(() => asyncOperation.progress >= 0.5f);

        while (!asyncOperation.isDone)
        {
            yield return new WaitForSeconds(0.1f);
            progress_sl.value = asyncOperation.progress;
            progress_lb.text = (asyncOperation.progress*100).ToString()+ "%";
        }
        progress_sl.value = 1;
        progress_lb.text = "100%";
        uiObject.SetActive(false);
        callback?.Invoke();
        index = -1;
        name_scene = string.Empty;
    }
}
