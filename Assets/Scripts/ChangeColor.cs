using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//アタッチするオブジェクトのRendererのComponentを取得する
		Renderer coloring = this.GetComponent<Renderer>();

		//RendererのMaterialにランダムな色を入れる
		coloring.material.color = new Color(Random.value, Random.value, Random.value, 1.0f); ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
