using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    Image image;
    float Fade_speed = 0.25f;
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Color color = image.color;
        if(color.a > 0){
            color.a -= Fade_speed * Time.deltaTime;
            this.image.color = color;
            Fade_speed += 4 * Time.deltaTime;
        }
        else{
            color.a = 0;
            this.gameObject.SetActive(false);
        }
    }
}
