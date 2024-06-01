using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public Slider progressbar;
    public Text loadText;

    public static string loadScene;


    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScenehandle(string _name)
    {
        loadScene = _name;
        SceneManager.LoadScene("Loading");
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadScene);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            yield return null;
            if(progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if(operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }

            if (progressbar.value >= 1f)
            {
                loadText.text = "Press SpaceBar";
            }

            if(Input.GetKeyDown(KeyCode.Space) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
    /*operation.isDone; 진행완료 여부를 boolean형으로 반환
    operation.progress; 진행정도를 float형 0/1 로 반환 0 = 진행중, 1- 진행완료
    operation.allowSceneActivation; true = 신 전환, false = progress가 0.9f 에서 정지*/
}
