using UnityEngine;
using UnityEngine.UI;

public class MicInput : MonoBehaviour
{
    [SerializeField]
    private Text decibelText;

    private AudioClip micClip;
    private string device;
    void Start()
    {
        //마이크 장치 확인
        if(Microphone.devices.Length > 0)
        {
            device = Microphone.devices[1];
            micClip = Microphone.Start(device, true, 1, 44100);
            Debug.Log($"Device : {device}");
        }
        else
        {
            Debug.LogError("마이크 장치를 찾을 수 없습니다!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (micClip == null) return;

        float loudness = GetDecibel(0.05f);
        if(decibelText != null)
        {
            decibelText.text = "Decibel : " + loudness.ToString("F2") + "DB";
        }
    }
    public float GetDecibel(float _ref = 1.0f)
    {
        int sampleSize = 1024;
        float[] samples = new float[sampleSize];

        int micPosition = Microphone.GetPosition(device) - sampleSize;
        if (micPosition < 0) return 0;

        micClip.GetData(samples, micPosition); // 마이크 샘플 데이터 가져오기

        //RMS(Root Mean Square) 계산
        float sum = 0;
        for(int i = 0; i < sampleSize; i++)
        {
            sum += samples[i] * samples[i];
        }
        float rms = Mathf.Sqrt(sum /  sampleSize);

        //데시벨 변환
        float db = 20 * Mathf.Log10(rms / _ref);
        return db > 0 ? db : 0;
    }
}
