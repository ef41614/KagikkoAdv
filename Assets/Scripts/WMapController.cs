using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WMapController : MonoBehaviour {

	private GameObject unitychan;
	private UnityChanController Uscript;
	GameObject pchan; 
	PchanController Pscript; 
	GameObject turnmanager;
	TurnManager TurnMscript;
	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
	public Vector3 NextGuidePos;
	[SerializeField]
	RectTransform rectTran;
	Vector3 NGP;
	public GameObject P1;
	public GameObject P2;
	public GameObject P3;
	public GameObject P4;
	public GameObject Key;
	public GameObject Peke;
	public Vector3 IconPos;

    GameObject guidanceBack;

    //	RectTransform rectTransform = null;
    //	[SerializeField] Transform target = null;

    //	void Awake(){
    //		rectTransform = GetComponent<RectTransform> ();
    //	}

    //☆################☆################  Start  ################☆################☆
    void Start () {
		this.unitychan = GameObject.Find ("unitychan");
		Uscript = unitychan.GetComponent<UnityChanController>();
		pchan = GameObject.Find ("pchan"); 
		Pscript = pchan.GetComponent<PchanController>(); 
		turnmanager = GameObject.Find ("turnmanager");
		TurnMscript = turnmanager.GetComponent<TurnManager>(); 
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();
        guidanceBack = GameObject.Find("guidanceBack");

    }

	//####################################  Update  ###################################
	void Update () {

	}

	//####################################  other  ####################################

	public void ShowIconPos_InWMap(){
		Debug.Log ("飛んできた＿WMapにプレーヤー位置を反映させます");
		ShowPlayer1_InWMap ();
	}

	public void ShowPlayer1_InWMap(){
		//		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, IconPos.target.position);
//		IconPos = Uscript.Player_pos;
		//		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, IconPos);
//		rectTransform.position = RectTransformUtility.WorldToScreenPoint (Camera.main, target.position);

		Debug.Log ("プレーヤーIconPos："+IconPos);
		Debug.Log ("プレーヤーIconPos.x："+IconPos.x);
		Debug.Log ("プレーヤーIconPos.y："+IconPos.y);
		Debug.Log ("プレーヤーIconPos.z："+IconPos.z);
		IconPos.x = IconPos.x * 0.03f;
		IconPos.y = 0;
		IconPos.z = IconPos.z * 0.03f;
		P1.transform.position = IconPos;
		Debug.Log ("プレーヤーIconPos："+IconPos);
		Debug.Log ("プレーヤーIconPos.x："+IconPos.x);
		Debug.Log ("プレーヤーIconPos.y："+IconPos.y);
		Debug.Log ("プレーヤーIconPos.z："+IconPos.z);
	}

    public void CloseGuidance()
    {
        Destroy(guidanceBack);
    }


    //#################################################################################

}
// End