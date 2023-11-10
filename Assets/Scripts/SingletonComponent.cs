using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonComponent : MonoBehaviour
{
    private static SingletonComponent instance;
    //static���� ����Ǿ� �� ������ �� �ϳ��� ��� SingletonComponet ��ü���� �����ϰ� �ȴ�.
    //private���� �ܺο��� �Ժη� ������ �� ���� �Ѵ�. ���ϼ� Ȯ��
    public static SingletonComponent Instance
    //Instance ������Ƽ ���� instance�ʹ� ���̸� �д�.
    //Ŭ���� ���ο� �ܺο��� ȣ���� �� �ְ��Ѵ�.
    {
        get
        {
            if(instance == null)
            //instance�� ����ִ��� �˻�
            {
                var obj = FindObjectOfType<SingletonComponent>();
                if (obj != null)
                //SingletonComponent�� ������ �ִ� GameObject�� �ִٸ� �� ��ü�� instance�� �ִ´�.
                {
                    instance = obj;
                }
                else
                //���ٸ� ���� �����.
                {
                    var newObj = new GameObject().AddComponent<SingletonComponent>();
                    instance = newObj;
                }
            }
            return instance;
        }
    }

    private void Awake()
    //�ߺ� �˻�
    {
        var objs = FindObjectsOfType<SingletonComponent>();
        //Scene�� ���� Ÿ���� ������Ʈ�� � �ִ��� �˻��Ѵ�.
        if (objs.Length != 1)
        //1���� �ƴ϶��
        {
            Destroy(gameObject);
            //�̹� Scene�� �����Ѵٴ� ���� ���� ������ ��ü��� ���̹Ƿ� ��� ������ ��ü�� �ı��Ѵ�.
            return;
        }
        DontDestroyOnLoad(gameObject);
        //Scene�� �ٲ� SingletonComponent�� ������ �ִ� ��ü�� �ı����� �ʵ��� �Ѵ�.
    }

    public void LogText(string text)
    {
        Debug.Log(text);
    }
}
