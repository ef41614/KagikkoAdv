using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	private GameObject gameManager;
	public GameManager GMScript;
	public GameObject parentObject = null;
	Renderer rend;
	Color color;
	float alpha;
	public GameObject KeyPrefab;
	GameObject CanvasGoal;
	GoalManager GoalM;
	Rigidbody rb;
	Vector3 key_pos; 

	public float force=1000;
	public float torque=1000;
	private FixedJoint myjoint;

	public GameObject KeyImage;
	public KeyParticle KeyParticleSC;

	//☆################☆################  Start  ################☆################☆

	void Start () {
		gameManager = GameObject.Find ("GameManager");
		GMScript = gameManager.GetComponent<GameManager> ();
		GMScript.getPositionInfo();
		transform.position = GMScript.appearPosition;
		rend = GetComponentInChildren<Renderer> ();
		alpha = 0;
		CanvasGoal = GameObject.Find ("CanvasGoal");
		GoalM = CanvasGoal.GetComponent<GoalManager> ();
		rb = GetComponent<Rigidbody>();
		key_pos = GetComponent<Transform>().position;

		KeyParticleSC = KeyImage.GetComponent<KeyParticle> ();
	}

	//####################################  Update  ###################################

	void Update () {
			gameObject.transform.rotation = Quaternion.Euler (45, 0, 0);
	}

	//####################################  other  ####################################

	void OnCollisionEnter(Collision other){
		if (other.gameObject.tag == "Player") {

			transform.position = new Vector3 (transform.position.x, 2.8f, transform.position.z);

//			myjoint = gameObject.AddComponent<FixedJoint>();
//			myjoint.connectedBody = other.rigidbody;

//			myjoint.breakForce = force;
//			myjoint.breakTorque = torque;
//			print("breakForce=\n" + gameObject.GetComponent<FixedJoint>().breakForce);
//			print("breakTorque=\n" + gameObject.GetComponent<FixedJoint>().breakTorque);

			parentObject = other.gameObject;
			GMScript.GetKey ();
			GMScript.CreateTreasure ();
			rb.velocity = Vector3.zero;
			// ゲットしたプレーヤーの子オブジェクトになる
			KeyParticleSC.GetKeyParticle();
			this.gameObject.transform.parent = parentObject.transform;
			GetParentName ();
//			transform.position = new Vector3( 0.0f, 1.0f, 0.0f);
			float Size = 0.05f;
			this.transform.localScale = new Vector3(Size, Size, Size);
			transform.localPosition = new Vector3( 0.0f, 1.8f, 0.0f);
			rend.material.color = new Color(0, 0, 0, 150);

			rb.velocity = Vector3.zero;
			rb.constraints = RigidbodyConstraints.FreezeRotation;
			rb.useGravity = false;

			rb.constraints = RigidbodyConstraints.FreezePosition;
//			transform.Translate (0, 0, 0);
//			Destroy (this.gameObject);
		}

	}

	public void GetParentName(){
		//親オブジェクトを取得
		parentObject = transform.root.gameObject;
		Debug.Log ("Parent:" + parentObject.name);
		GoalM.HoldingKeyPlayer = parentObject.name;
	}

	public void DropKey(){
		// プレーヤーとの親子関係解消（フリーになる）
		transform.parent = null;
		rb.constraints = RigidbodyConstraints.None;
		rb.constraints = RigidbodyConstraints.FreezeRotation;
		float Size = 0.2f;
		this.transform.localScale = new Vector3(Size, Size, Size);
//		transform.localPosition = new Vector3( 0.0f, 1.8f, 0.0f);
		rend.material.color = new Color(0.8f, 0.36f, 0.09f, 255);
		float x = 0;
		float y = 300;
		float z = 0;
//		rb.AddForce(moveVector*200);
		rb.AddForce(x,y,z);
		rb.useGravity = true;
//		GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		FixPosition();
	}

	void FixPosition(){
		Debug.Log ("カギ位置修正中");
		key_pos.x = Mathf.RoundToInt ( ((key_pos.x)/3)*3);
		Debug.Log ("key_pos.x % 3 は"+ key_pos.x % 3);
		if ((key_pos.x % 3 == 2)||(key_pos.x % 3 == -1)) {
			key_pos.x ++;
			Debug.Log ("ｘ++修正完了");
		} else if ((key_pos.x % 3 == 1)||(key_pos.x % 3 == -2)) {
			key_pos.x --;
			Debug.Log ("ｘ--修正完了");
		}

		key_pos.z = Mathf.RoundToInt ( ((key_pos.z)/3)*3);
		if ((key_pos.z % 3 == 2)||(key_pos.z % 3 == -1)) {
			key_pos.z ++;
			Debug.Log ("ｚ++修正完了");
		} else if ((key_pos.z % 3 == 1)||(key_pos.z % 3 == -2)) {
			key_pos.z --;
			Debug.Log ("ｚ--修正完了");
		}
	}

	public void DestroyKey (){
		Destroy(this.gameObject);
	}

	//#################################################################################

}
// End