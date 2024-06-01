using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;// ���ӽ����̽� �߰�

public class BtnType : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler// �������̽� �߰�
{
    public ButtonType currentType;

    public string changeSceneName;

    public Transform buttonScale;
    Vector3 defaultScale;

    private void Start()
    {
        defaultScale = buttonScale.localScale;
    }

    public void OnBtnClick() //button �� OnClick() �Լ��� ����
    {
        switch (currentType)
        {
            case ButtonType.SelectGame:
                ChangeScene.LoadScenehandle(changeSceneName);
                break;
            case ButtonType.Option:
                break;
            case ButtonType.Quit:
                Application.Quit();
                break;
            case ButtonType.Back:
                ChangeScene.LoadScenehandle(changeSceneName);
                break;
            case ButtonType.Sound:
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData) 
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }
}
