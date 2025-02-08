using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_change : MonoBehaviour
{
    public void Onclick(){
        SceneManager.LoadScene("Select Scene");
    }
}
