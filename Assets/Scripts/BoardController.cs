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
	public GameObject timerManager;
//    TimerManager TimerSC;
	TimerController TimerSC;
//	Timer TimerSC;
	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;
	public GameObject parentObject = null;
	Renderer rend;
	Color color;
	float alpha;
	Color pale = new Color(0, 0, 0, 0.01f);
	 GameObject polygon;
	public FadeScript FadeSC;
	public FadeBoardScript FadeBoSC;
	public GameObject KeyPrefab;
	Vector3 key_pos; 

	public float force=1000;
	public float torque=1000;
	private FixedJoint myjoint;

//	public GameObject KeyImage;
//	public KeyParticle KeyParticleSC;

	Vector3 LeftPos;
	Vector3 RightPos;
	Vector3 BottomPos;
	Vector3 TopPos;

	public float BoardHight = -0.6f;
	Vector3 BoardPos;

	public int BoardTicket = 1;

	public float alfa;
	float FadeSpeed = 0.05f;
	float red, green, blue;
	public bool goFadeIn = false;
	public bool goFadeOut = false;
	public bool RotationBoardFlg = false;
	Quaternion angle = Quaternion.identity;

	public int BoardMode =0;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		rb = GetComponent<Rigidbody>();

		gameManager = GameObject.Find ("GameManager");
		GMScript = gameManager.GetComponent<GameManager> ();
		GMScript.getPositionInfo();
		transform.position = GMScript.appearPosition;
		rend = GetComponentInChildren<Renderer> ();
		alpha = 0;
		//gameObject.transform.FindChild("子の名前").gameObject;
//		polygon = gameObject.transform.FindChild("Polygon").gameObject;
		polygon = GameObject.Find ("Polygon");
		FadeSC = polygon.GetComponent<FadeScript>();
		FadeBoSC = polygon.GetComponent<FadeBoardScript>();
//		timerManager = GameObject.Find ("Timer");
//		timerManager = GameObject.Find ("TimerManager");
		TimerSC = timerManager.GetComponent<TimerController> ();
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

//		Meshrender meshrenderer = GetComponent<MeshRenderer> ();
//		Meshrender meshrender = GetComponent<MeshRenderer> ();
		rend = GetComponent<Renderer> ();
		alpha = 0;
//		red = GetComponent<Image>().color.r;
//		green = GetComponent<Image>().color.g;
//		blue = GetComponent<Image>().color.b;
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
			//BoardPos.y = BoardHight;
			//BoardPos.x = CharaMoveMscript.Player_pos.x;
			//BoardPos.z = CharaMoveMscript.Player_pos.z;
			//transform.position = BoardPos;

//			rb.constraints = RigidbodyConstraints.FreezeRotation;
			float angle = 1;
//			transform.Rotate(parentObject.transform.forward, angle);
			//rb.velocity = Vector3.zero;
//			gameObject.transform.rotation = Quaternion.Euler (parentObject.transform.forward);
//			gameObject.transform.rotation = Quaternion.Euler (0, 0, 0);

//			transform.Translate(Quaternion.AngleAxis(angle, Vector3.up) * new Vector3(0, 0, 0));

		}

		if ((goFadeIn == true)&&(alfa>=0)) {
			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
			alfa -= FadeSpeed;
		}

		if ((goFadeOut == true)&&(alfa<=1)) {
//			GetComponent<Image> ().color = new Color (red, green, blue, alfa);
//			GetComponent<Image> ().color = new Color (0,0,0, alfa);
//			alfa += FadeSpeed;
//			alpha = alpha + Time.deltaTime * 0.5f;
//			rend.material.color = new Color(0f, 0f, 0f, alpha);
		}

		if (RotationBoardFlg) {
			Debug.Log ("RotationBoardFlg: ON");
//			gameObject.transform.rotation = Quaternion.Euler (45, 0, 0);
//			transform.rotation = Quaternion.AngleAxis (90, new Vector3 (0, 1, 0));
			transform.rotation = Quaternion.Euler(0, 90f, 0); 
//			transform.rotation = Quaternion.Euler(0, 45f, 0);
			//angle.eulerAngles = new Vector3(0, 90f, 0);
			//transform.rotation = angle;
//			transform.eulerAngles = new Vector3 (0, 90f, 0);
		}
	}

	//####################################  other  ####################################

//	public void OnCollisionEnter(Collision other){
		public void OnTriggerEnter(Collider other){
		Debug.Log ("BoardTicket (衝突時): "+BoardTicket);

		if (other.gameObject.tag == "Player") {
			if (BoardTicket == 1) {

				parentObject = other.gameObject;
				if (parentObject == CharaMoveMscript.activeChara) {
					CharaMoveMscript.RemainingStepsInfo = 0;
					CharaMoveMscript.stepsLeft ();
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
					//transform.localPosition = new Vector3 (0.0f, -0.4f, -1.146f);
					transform.localPosition = new Vector3 (0.0f, -0.5f, 0.0f);
//			rend.material.color = new Color(0, 0, 0, 150);
					//transform.rotation = Quaternion.identity;

					//Vector3 localAngle = parentObject.localEulerAngles;
					//transform.localEulerAngles = localAngle;

//					float angle = 1;
//					transform.Rotate (parentObject.transform.forward, angle);

					rb.velocity = Vector3.zero;

					rb.constraints = RigidbodyConstraints.FreezeRotation;
					rb.useGravity = false;
//					rb.constraints = RigidbodyConstraints.FreezePositionY;
					rb.constraints = RigidbodyConstraints.FreezePosition;
					//rb.constraints = RigidbodyConstraints.FreezeRotationX;
					//rb.constraints = RigidbodyConstraints.FreezeRotationY;
					//rb.constraints = RigidbodyConstraints.FreezeRotationZ;
					Debug.Log ("スケートボードがゲットしたプレーヤーの子オブジェクトになる");
					Debug.Log (CharaMoveMscript.activeChara.name+" Boardに接触：");
					CharaMoveMscript.OnBoard = true;

					BoardTicket -= 1;

					float WaitTime = TimerSC.totalTime;
					Debug.Log ("WaitTime は： "+ WaitTime);
					var sequence = DOTween.Sequence();
//					sequence.InsertCallback(0.5f, () =>(SceneManager.LoadScene ("GameScene")));
					sequence.InsertCallback(WaitTime, () =>(CharaMoveMscript.OnBoard = false));
					sequence.InsertCallback(WaitTime, () =>(GetOffBoard()));

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

	public void GetOffBoard(){
		CharaMoveMscript.RemainingStepsInfo = 0;
		// プレーヤーとの親子関係解消（フリーになる）
		transform.parent = null;
//		rb.constraints = RigidbodyConstraints.None;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
		rb.constraints = RigidbodyConstraints.FreezePosition;

		goFadeOut = true;
//		FadeSC.goFadeOut = true;
		FadeBoSC.goFadeOut = true;

		CharaMoveMscript.RunningInfo = false;
		CharaMoveMscript.ArrivedNextPoint = true;
//		CharaMoveMscript.TicketInfo=0;
//		CharaMoveMscript.RemainingStepsInfo = 0;

		var sequence = DOTween.Sequence();
		sequence.InsertCallback(0.5f, () =>(DestroyBoard ()));
		sequence.InsertCallback(0.6f, () =>(TimerSC.deactivateTimerText()));
	}

	public void DestroyBoard (){
		Debug.Log ("スケートボードが消えます");
		Destroy(this.gameObject);
	}

	public void RotationBoard(){
		if (BoardMode == 0) {
		}
		if (BoardMode == 1) {
		}
		if (BoardMode == 2) {
//		transform.rotation = Quaternion.AngleAxis (90, new Vector3 (0, 1, 0));
			gameObject.transform.rotation = Quaternion.Euler (0, 90, 0);
		}
	}
	//#################################################################################

}
// End