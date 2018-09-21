using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SECommon : MonoBehaviour {

    public AudioClip OK_SE;
    public AudioClip cancel_SE;
    AudioSource audioSource;


    //☆################☆################  Start  ################☆################☆

    void Start()
    {
        Debug.Log(" SECommon スクリプト出席確認");

        audioSource = gameObject.GetComponent<AudioSource>();
        //        audioSource.PlayOneShot(fieldBGM);
    }

    //####################################  Update  ###################################

    void Update()
    {

    }

    //####################################  other  ####################################

    public void OK_SE_Play()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(OK_SE);
    }

    public void cancel_SE_Play()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(cancel_SE);
    }


    //#################################################################################

}
// End
