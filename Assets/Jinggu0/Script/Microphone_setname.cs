using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Microphone_setname : MonoBehaviour
{
    GameObject child = null;
    // Start is called before the first frame update

    public void Setname(){
        string[] myMic = Microphone.devices;
        Debug.Log(myMic.Length.ToString());
        if(myMic.Length != 0){
            for(int i=0; i<myMic.Length; i++){
                child = transform.GetChild(i).gameObject;
                child.GetComponent<SetMicname>().Micname = myMic[i].ToString();
                child.GetComponent<SetMicname>().Index = i;
            }
        }
    }
}
