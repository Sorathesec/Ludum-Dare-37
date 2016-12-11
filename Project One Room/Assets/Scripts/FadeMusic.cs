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
        for (int i = 0; i < 200; i++)
        {
            masterMixer.GetFloat("GameRoomVol", out gameRoomVol);
            if (gameRoomVol < -10)
            {
                gameRoomVol += 1f;
                masterMixer.SetFloat("GameRoomVol", gameRoomVol);
            }

            masterMixer.GetFloat("MainRoomVol", out mainRoomVol);
            mainRoomVol -= 1f;
            masterMixer.SetFloat("MainRoomVol", mainRoomVol);

            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ToRoom()
    {
        for (int i = 0; i < 200; i++)
        {
            masterMixer.GetFloat("GameRoomVol", out gameRoomVol);
            gameRoomVol -= 1f;
            masterMixer.SetFloat("GameRoomVol", gameRoomVol);

            if (mainRoomVol < -10)
            {
                masterMixer.GetFloat("MainRoomVol", out mainRoomVol);
                mainRoomVol += 1f;
                masterMixer.SetFloat("MainRoomVol", mainRoomVol);
            }

            yield return new WaitForSeconds(0.01f);
        }
    }
}