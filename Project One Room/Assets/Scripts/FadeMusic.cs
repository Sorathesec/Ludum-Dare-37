using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class FadeMusic : MonoBehaviour
{
    public AudioMixer masterMixer;

    float gameRoomVol;
    float mainRoomVol;

    public static FadeMusic instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(instance);
    }

    void Start()
    {
        masterMixer.GetFloat("MainRoomVol", out mainRoomVol);
        masterMixer.GetFloat("GameRoomVol", out gameRoomVol);
    }

    public void switchToGame()
    {
        StartCoroutine(ToGame());
    }

    public void switchToRoom()
    {
        StartCoroutine(ToRoom());
    }

    IEnumerator ToGame()
    {
        for (int i = 0; i < 100; i++)
        {
            if (gameRoomVol < -10)
            {
                gameRoomVol += 1f;
                masterMixer.SetFloat("GameRoomVol", gameRoomVol);
            }

            if (mainRoomVol > -80)
            {
                mainRoomVol -= 1f;
                masterMixer.SetFloat("MainRoomVol", mainRoomVol);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ToRoom()
    {
        for (int i = 0; i < 100; i++)
        {
            if (gameRoomVol > -80)
            {
                gameRoomVol -= 1f;
                masterMixer.SetFloat("GameRoomVol", gameRoomVol);
            }

            if (mainRoomVol < -10)
            {
                mainRoomVol += 1f;
                masterMixer.SetFloat("MainRoomVol", mainRoomVol);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}