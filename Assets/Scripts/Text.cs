using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text : MonoBehaviour
{
    private void Start()
    {
        SingletonComponent.Instance.LogText("싱글톤 패턴인 텍스트 출력");
    }
}
