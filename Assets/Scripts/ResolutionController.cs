using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class ResolutionController : MonoBehaviour {

	void Awake() {

		// 横画面で開発している場合は以下の用に切り替えます
		float developAspect = 16f / 9f;

		// 実機のサイズを取得して、縦横比取得
		float deviceAspect = (float)Screen.width*1.0f / (float)Screen.height*1.0f;

		// 実機と開発画面との対比
		float scale = deviceAspect / developAspect;

		Camera mainCamera = Camera.main;

		// カメラに設定していたorthographicSizeを実機との対比でスケール
		float deviceSize = mainCamera.orthographicSize;
		// scaleの逆数
		float deviceScale = 1.0f / scale;
		// orthographicSizeを計算し直す
		mainCamera.orthographicSize = deviceSize * deviceScale;

	}
}
