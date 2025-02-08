using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Return_Button : MonoBehaviour
{
    public void Onclick(){
        SceneManager.LoadScene("Opening Scenes");
    }
}
