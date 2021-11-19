using UnityEngine;

public class FPSController : MonoBehaviour
{

    // Контролёр ФПС и оптимизация графики
    private void Awake()

    {
        // Урезание пикселей на 20%
        if (!PlayerPrefs.HasKey("SetResolution"))
        {
            Screen.SetResolution((int)(Screen.width * 0.8), (int)(Screen.height * 0.8), true);

            //Debug.Log("Resolution!");

            PlayerPrefs.SetInt("SetResolution", 1);
        }
        else
        {
            //Debug.Log("None Resolution!");
        }

        // Увеличение ФПС до 60 кадров в секунду
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
}
