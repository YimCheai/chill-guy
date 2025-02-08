using System.Collections;
using System.Collections.Generic;
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
    }
}
