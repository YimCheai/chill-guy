using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Error_Fadeout : MonoBehaviour
{
    TextMeshProUGUI tmpro;
    float Fade_speed = 0.25f;
    void Start()
    {
        tmpro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        Color color = tmpro.color;
        if(color.a > 0){
            color.a -= Fade_speed * Time.deltaTime;
            this.tmpro.color = color;
            Fade_speed += 1 * Time.deltaTime;
        }
        else{
            Destroy(this.gameObject);
        }
    }
}
