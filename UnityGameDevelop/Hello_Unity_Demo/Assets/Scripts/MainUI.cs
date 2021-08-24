using UnityEngine;
using System.Collections;

public class MainUI : MonoBehaviour {

	//背景
	private Texture2D loadBg;

	private bool isLoad = false;
	void Start () 
	{
		//从Resources这个文件夹下导入bg这张图片，注意不要有后缀名
		loadBg = Resources.Load ("images/bg") as Texture2D;
	}
	

	void OnGUI () 
	{
		if(!isLoad)
		{
			GUI.DrawTexture( new Rect (0,0,Screen.width,Screen.height),loadBg);
			
			if (GUI.Button (new Rect (Screen.width / 2, Screen.height / 2, 100, 60), "Load...."))
			{
				isLoad = true;
			}
		}

	}
}
