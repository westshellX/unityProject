using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class HelloWorld : MonoBehaviour
{
    [DllImport("testDll")]
    private static extern void test_HelloVR();

    [DllImport("testDll")]
    private static extern int disPlayNum();

    [DllImport("UsingVRCom")]
    private static extern double pi();

    [DllImport("UsingVRCom")]
    private static extern bool InitWestVRCom();

    [DllImport("UsingVRCom")]
    private static extern void ClearWestVRCom();

    [DllImport("UsingVRCom")]
    private static extern void CreateWestClient();

    struct WestCustomCmdData
    {
        public char [] szCmd;
    };

    [DllImport("UsingVRCom")]
    private static extern bool PopupStr2CltWest(WestCustomCmdData receivData);

    //[DllImport("YNet64")]
    //private static extern void ClearNet();

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello world!");
        test_HelloVR();
        print("Hello world Haha!");

        if (InitWestVRCom())
        {
            CreateWestClient();
        }

    }

    // Update is called once per frame
    void Update()
    {
        print("Heheh!");
        test_HelloVR();
        int i = disPlayNum();
        print(disPlayNum().ToString());

        print(pi().ToString());
        WestCustomCmdData cmdData;
        //cmdData.szCmd = new char[256];
        //if(PopupStr2CltWest(cmdData))
        //{
        //    print(szCmd.szCmd);
        //}
    }
    void OnDestroy()
    {
        print("Hi");
        ClearWestVRCom();
    }
}
