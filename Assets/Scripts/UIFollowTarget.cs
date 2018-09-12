using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFollowTarget : MonoBehaviour {

	RectTransform rectTransform = null;
	[SerializeField] Transform target = null;

	void Awake()
	{
		rectTransform = GetComponent<RectTransform> ();
	}

	void Update()
	{
		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, target.position);
	}
}