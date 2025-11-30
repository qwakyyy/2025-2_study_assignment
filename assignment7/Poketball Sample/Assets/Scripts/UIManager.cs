using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Text MyText;

    Coroutine NowCoroutine;

    void Awake() {
        // MyText를 얻어오고, 내용을 지운다.
        // ---------- TODO ---------- 
        // Canvas 안에 있는 Text 컴포넌트를 가져옵니다.
        MyText = GetComponentInChildren<Text>();
        // 시작할 때는 텍스트를 비워둡니다.
        MyText.text = "";
        // -------------------- 
    }

    public void DisplayText(string text, float duration)
    {
        // NowCoroutine이 있다면 멈추고 새로운 DisplayTextCoroutine을 시작한다.
        // ---------- TODO ---------- 
        // 기존 코루틴이 실행 중이면 멈춥니다.
        if (NowCoroutine != null)
        {
            StopCoroutine(NowCoroutine);
        }
        // 새로운 코루틴 시작
        NowCoroutine = StartCoroutine(DisplayTextCoroutine(text, duration));
        // -------------------- 
    }

    IEnumerator DisplayTextCoroutine(string text, float duration)
    {
        // MyText에 text를 duration초 동안 띄운다.
        // ---------- TODO ---------- 
        // 텍스트 표시
        MyText.text = text;
        // duration 초 동안 유지
        yield return new WaitForSeconds(duration);
        // 텍스트 지우기
        MyText.text = "";
        // 코루틴 참조 초기화
        NowCoroutine = null;
        // -------------------- 
    }
}
