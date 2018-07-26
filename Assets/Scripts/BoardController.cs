using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class BoardController : MonoBehaviour {

	public float speed = 10.0f;
	public Rigidbody rb;

	private GameObject gameManager;
	public GameManager GMScript;
	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
	public GameObject parentObject = null;
	Renderer rend;
	Color color;
	float alpha;
	public GameObject KeyPrefab;
	Vector3 key_pos; 

	public float force=1000;
	public float torque=1000;
	private FixedJoint myjoint;

	public GameObject KeyImage;
	public KeyParticle KeyParticleSC;

	Vector3 LeftPos;
	Vector3 RightPos;
	Vector3 BottomPos;
	Vector3 TopPos;

	public float BoardHight = -0.6f;
	Vector3 BoardPos;

	public int BoardTicket = 1;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		rb = GetComponent<Rigidbody>();

		gameManager = GameObject.Find ("GameManager");
		GMScript = gameManager.GetComponent<GameManager> ();
		GMScript.getPositionInfo();
		transform.position = GMScript.appearPosition;
		rend = GetComponentInChildren<Renderer> ();
		alpha = 0;

		key_pos = GetComponent<Transform>().position;
//		KeyParticleSC = KeyImage.GetComponent<KeyParticle> ();

		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

		LeftPos = CharaMoveMscript.LeftPos;
		RightPos = CharaMoveMscript.RightPos;
		BottomPos = CharaMoveMscript.BottomPos;
		TopPos = CharaMoveMscript.TopPos;
//		LeftPos.x += -300; 
//		RightPos.x += 300;
//		BottomPos.z += -300;
//		TopPos.z += 300f;

		BoardPos = transform.position;
	}


	//####################################  Update  ###################################

	void Update () {
		if (CharaMoveMscript.OnBoard) {
//		transform.position = (new Vector3 (
//			Mathf.Clamp (transform.position.x, LeftPos.x, RightPos.x),
//			Mathf.Clamp (transform.position.y, BoardHight, BoardHight+0.1f),
//			Mathf.Clamp (transform.position.z, BottomPos.z, TopPos.z)
//		));

//		transform.position.y = Mathf.Clamp (transform.position.y, BoardHight, BoardHight+0.1f);

			// プレイヤーの座標を取得
//		Vector3 pos = transform.position;
			BoardPos.y = BoardHight;
			BoardPos.x = CharaMoveMscript.Player_pos.x;
			BoardPos.z = CharaMoveMscript.Player_pos.z;
			transform.position = BoardPos;

//			rb.constraints = RigidbodyConstraints.FreezeRotation;
			float angle = 1;
//			transform.Rotate(parentObject.transform.forward, angle);
			rb.velocity = Vector3.zero;
//			gameObject.transform.rotation = Quaternion.Euler (parentObject.transform.forward);
//			gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);

//			transform.Translate(Quaternion.AngleAxis(angle, Vector3.up) * new Vector3(0, 0, 0));

		}
	}

	//####################################  other  ####################################

	public void OnCollisionEnter(Collision other){
//		public void OnTriggerEnter(Collider other){
		Debug.Log ("BoardTicket (衝突時): "+BoardTicket);

		if (other.gameObject.tag == "Player") {
			if (BoardTicket == 1) {

				parentObject = other.gameObject;
				if (parentObject == CharaMoveMscript.activeChara) {

					transform.position = new Vector3 (transform.position.x, 40, transform.position.z);
					GMScript.GetKey ();
//			GMScript.CreateTreasure ();
					rb.velocity = Vector3.zero;
					// ゲットしたプレーヤーの子オブジェクトになる
//			KeyParticleSC.GetKeyParticle();
					this.gameObject.transform.parent = parentObject.transform;
					GetParentName ();
					//			transform.position = new Vector3( 0.0f, 1.0f, 0.0f);
//			float Size = 0.05f;
//			this.transform.localScale = new Vector3(Size, Size, Size);
					transform.localPosition = new Vector3 (0.0f, -10.4f, -1.146f);
//			rend.material.color = new Color(0, 0, 0, 150);
					//transform.rotation = Quaternion.identity;

					//Vector3 localAngle = parentObject.localEulerAngles;
					//transform.localEulerAngles = localAngle;

					float angle = 1;
//					transform.Rotate (parentObject.transform.forward, angle);

					rb.velocity = Vector3.zero;

					rb.constraints = RigidbodyConstraints.FreezeRotation;
					rb.useGravity = false;
					rb.constraints = RigidbodyConstraints.FreezePositionY;
					rb.constraints = RigidbodyConstraints.FreezeRotation;
					Debug.Log ("スケートボードがゲットしたプレーヤーの子オブジェクトになる");
					Debug.Log (CharaMoveMscript.activeChara.name+" Boardに接触：");
					CharaMoveMscript.OnBoard = true;

					BoardTicket -= 1;
				}
			}
		}
	}

	public void GetParentName(){
		//親オブジェクトを取得
		parentObject = transform.root.gameObject;
		Debug.Log ("Parent:" + parentObject.name);
//		GoalM.HoldingKeyPlayer = parentObject.name;
	}

	//#################################################################################

}
// End