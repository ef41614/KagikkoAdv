using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeSet : MonoBehaviour {

	public int ScreenWidth = 800;
	public int ScreenHeight = 450;

	[RuntimeInitializeOnLoadMethod()]
	static void Init(){
		// PC向けビルドだったらサイズ変更
		if (Application.platform == RuntimePlatform.WindowsPlayer ||
			Application.platform == RuntimePlatform.OSXPlayer ||
			Application.platform == RuntimePlatform.LinuxPlayer )
		{
//			Screen.SetResolution(ScreenWidth, ScreenHeight, false);
			Screen.SetResolution(800, 450, false);
		}

	}

}
