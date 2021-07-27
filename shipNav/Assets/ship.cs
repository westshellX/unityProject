using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        load();
        print("Hello world!");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerable load()
    {
        WWW www = new WWW("https://imgm.gmw.cn/attachement/jpg/site2/20210727/f44d3075896c226a0c4c02.JPG");
        while(!www.isDone)
        {
            print("模型加载中");
            yield return null;
        }
        yield return www;
        if(www.error!=null)
        {
            Debug.Log("error:" + www.url + "\n" + www.error);
        }
        if (www.isDone)
        {
            print("模型加载wancheng");
            print(www.text);
        }
        print(www.url);
    }
}
