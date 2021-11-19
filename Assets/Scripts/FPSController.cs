using UnityEngine;

public class FPSController : MonoBehaviour
{

    // �������� ��� � ����������� �������
    private void Awake()

    {
        // �������� �������� �� 20%
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

        // ���������� ��� �� 60 ������ � �������
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
}
