using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(CharacterController), typeof(Collider))]
public class PchanController : MonoBehaviour {

	CharacterController m_charCtrl;

	// あと何マス動けるか
	public int RemainingSteps = 0;

	public Vector3 Player_pos; 

	public Rigidbody rb;
	public Animator myAnimator;

	public bool PIsRunning = false;
	[SerializeField]
	RectTransform rectTran;

	private GameObject DiceB; 
	public DiceButtonController DiceC;
	private GameObject ArrowB;
	public arrowButtonsController ArrowC;

	public bool ArrivedNextPoint = false;

	GameObject turnmanager;
	TurnManager TurnMscript;
	GameObject charamovemanager;
	CharaMoveManager CharaMoveMscript;

	public int PDiceTicket = 1;
	float timeleft =0;
	GameObject _child;
	public KeyController keySC;
	public GameObject Key;

	public GameObject gameManager;
	GameManager GMScript;

	//☆################☆################  Start  ################☆################☆
	void Start () {
		m_charCtrl = GetComponent<CharacterController>();

		Debug.Log ("Pちゃんスクリプト出席確認");

		Player_pos = GetComponent<Transform>().position; //最初の時点でのプレイヤーのポジションを取得
		rb = GetComponent<Rigidbody>();
		this.myAnimator = GetComponent<Animator>();
		this.myAnimator.SetBool ("isRunning", false);

		DiceB = GameObject.Find ("DiceBox");
		DiceC = DiceB.GetComponent<DiceButtonController>(); 
		ArrowB = GameObject.Find ("ArrowsBox");
		ArrowC = ArrowB.GetComponent<arrowButtonsController>();

		turnmanager = GameObject.Find ("turnmanager");
		TurnMscript = turnmanager.GetComponent<TurnManager>(); 
		charamovemanager = GameObject.Find ("charamovemanager");
		CharaMoveMscript = charamovemanager.GetComponent<CharaMoveManager> ();

		ArrivedNextPoint = true;
		Debug.Log("開始 PDiceTicket :"+PDiceTicket);
		GMScript = gameManager.GetComponent<GameManager> ();
	}

	//####################################  Update  ###################################

	void Update () {
		timeleft -= Time.deltaTime;
		if (timeleft <= 0.0) {
			timeleft = 1.0f;
			//			Debug.Log("PDiceTicket :"+PDiceTicket);
		}

		if (TurnMscript.canMove2P == true) {
			if (ArrivedNextPoint == true) {
				// 走行中状態がOFF（＝停止状態）の時
				this.myAnimator.SetBool ("isRunning", false);  
				PIsRunning = false;

			} else {
				this.myAnimator.SetBool ("isRunning", true);
				PIsRunning = true;
				ArrivedNextPoint = false;

			}
		} else {
			// 走行中状態がOFF（＝停止状態）の時
			this.myAnimator.SetBool ("isRunning", false);  
			PIsRunning = false;
		}
	}

	//####################################  other  ####################################

	public void OnTriggerEnter(Collider other){
		if (TurnMscript.canMove2P == true) {
			if (other.gameObject.tag == "guideM") {
				ArrivedNextPoint = true;
			}
		}
	}

	void OnTriggerExit(Collider other){
		if (TurnMscript.canMove2P == true) {
			if (other.gameObject.tag == "guideM") {
				ArrivedNextPoint = false;
			}
		}
	}

	public void OnCollisionEnter(Collision other){
		if (TurnMscript.canMove2P == true) {
			if (other.gameObject.tag == "Player") {
				UnityChanController uc = other.gameObject.GetComponent<UnityChanController> ();
				PchanController pc = other.gameObject.GetComponent<PchanController> ();
				if (uc) {
					int rnd = Random.Range (1, 5);
					uc.Move (transform.forward, rnd* 3.0f);
					Debug.Log("Pちゃんの体当たりだ！");
					if (rnd <= 2) {
						GMScript.CrashOtherPlayer_weak ();
					} else if (rnd > 2) {
						GMScript.CrashOtherPlayer_strong ();
					}
				}

			}
		}
	}

	//相手に体当たりされ、吹っ飛ばされた時の処理
	public void Move(Vector3 direction, float distance){
		//_child = transform.FindChild ("KeyPrefab*").gameObject;
		//子オブジェクトにカギが存在するかどうかを判定する
		if (GameObject.Find ("KeyPrefab(Clone)").transform.IsChildOf (transform)) {
			Key = this.transform.Find("KeyPrefab(Clone)").gameObject;
			keySC = Key.GetComponent<KeyController> ();
			keySC.DropKey ();
		}
		Vector3 moveVector = direction.normalized * distance;
		rb.AddForce(moveVector*200);
		Debug.Log("2P吹っ飛んだ！");
	}
	//---------------------------------------------------

	//#################################################################################

}
// End
