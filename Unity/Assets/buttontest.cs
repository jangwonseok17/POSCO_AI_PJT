  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttontest : MonoBehaviour //script name(파일명 : buttontest)와 클래스 이름이 같아야 함
{
    public GameObject button; // 게임 오브젝트 중 button을 활성화

    public void changeMaterial() // on click 시 원하는 기능
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue; // 상세 기능

    }
}