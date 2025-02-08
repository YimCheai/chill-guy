using UnityEngine;
using UnityEngine.UI;

public class MicInput : MonoBehaviour
{
    private AudioClip micClip;
    private string device;
    void Start()
    {
        //마이크 장치 확인(추가 조건 : PlayerPrefs에 오디오 장치 인덱스가 현재 디바이스 배열에 존재하는지 확인)
        if(Microphone.devices.Length > 0)
        {
            //추후 머지 후 PlayerPrefs로 데이터 로드 삽입
            device = Microphone.devices[1];
            micClip = Microphone.Start(device, true, 1, 44100);
            Debug.Log($"Device : {device}");
        }
        else
        {
            Debug.LogError("마이크 장치를 찾을 수 없습니다!");
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
