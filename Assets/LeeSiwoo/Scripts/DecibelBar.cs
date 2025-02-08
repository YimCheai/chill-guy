using UnityEngine;
using UnityEngine.UI;

public class DecibelBar : MonoBehaviour
{
    [SerializeField]
    private MicInput micInput;

    private Slider bar;

	private void Start()
	{
		bar = GetComponent<Slider>();
	}

	void Update()
    {
        bar.value = micInput.GetDecibel(0.05f);
		float value = bar.value;
		
		Color lerpedColor = Color.Lerp(Color.white, Color.red, bar.value / 20);
		bar.transform.GetChild(1).GetChild(0).GetComponent<Image>().color = lerpedColor;
	}   
}
