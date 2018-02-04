using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
public class PlayerSetup : NetworkBehaviour {


    [SerializeField]
    Behaviour[] componentsToDisable;
    [SerializeField]
    GameObject[] gameObjectComponentsToDisable;
    void Start () {

        if (!isLocalPlayer) {

            for (int i = 0; i < componentsToDisable.Length; i++) {


                componentsToDisable[i].enabled = false;

            }

        }


       
	}


    public override void PreStartClient()
    {
        GetComponent<NetworkAnimator>().SetParameterAutoSend(0, true);
        Debug.Log("Anim set");
    }

}
