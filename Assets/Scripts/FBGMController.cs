using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBGMController : MonoBehaviour {

    GameObject turnmanager;
    TurnManager TurnMscript;
    public AudioClip fieldBGM;
    AudioSource audioSource;
    public bool WMapExist;

    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        Debug.Log(" FBGMController スクリプト出席確認");

        turnmanager = GameObject.Find("turnmanager");
        TurnMscript = turnmanager.GetComponent<TurnManager>();
        audioSource = gameObject.GetComponent<AudioSource>();
//        audioSource.PlayOneShot(fieldBGM);
    }

    //####################################  Update  ###################################

    void Update()
    {

    }

    //####################################  other  ####################################

    public void FBGMStart()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
//        audioSource.PlayOneShot(fieldBGM);
        audioSource.Play();
    }



    public void FBGMStop()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.Stop();
    }

    //#################################################################################

}
// End
