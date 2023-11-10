using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonComponent : MonoBehaviour
{
    private static SingletonComponent instance;
    //static으로 선언되어 이 변수는 단 하나로 모든 SingletonComponet 객체들이 공유하게 된다.
    //private으로 외부에서 함부로 수정할 수 없게 한다. 유일성 확보
    public static SingletonComponent Instance
    //Instance 프로퍼티 선언 instance와는 차이를 둔다.
    //클래스 내부와 외부에서 호출할 수 있게한다.
    {
        get
        {
            if(instance == null)
            //instance가 비어있는지 검사
            {
                var obj = FindObjectOfType<SingletonComponent>();
                if (obj != null)
                //SingletonComponent를 가지고 있는 GameObject가 있다면 그 객체를 instance로 넣는다.
                {
                    instance = obj;
                }
                else
                //없다면 새로 만든다.
                {
                    var newObj = new GameObject().AddComponent<SingletonComponent>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    //중복 검사
    {
        var objs = FindObjectsOfType<SingletonComponent>();
        //Scene에 같은 타입의 오브젝트가 몇개 있는지 검사한다.
        if (objs.Length != 1)
        //1개가 아니라면
        {
            Destroy(gameObject);
            //이미 Scene에 존재한다는 뜻은 먼저 생성된 객체라는 뜻이므로 방금 생성된 객체는 파괴한다.
            return;
        }
        DontDestroyOnLoad(gameObject);
        //Scene이 바뀌어도 SingletonComponent를 가지고 있는 객체가 파괴되지 않도록 한다.
    }

    public void LogText(string text)
    {
        Debug.Log(text);
    }
}
