using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeController : MonoBehaviour
{
    private Slider slider;
    public TMP_Text value;
    private const string key = "volume";

    void Start()
    {
        slider = GetComponent<Slider>();
        float savedVolume = PlayerPrefs.GetFloat(key, 1f);
        slider.value = savedVolume;
        changeVolume();
    }

    public void changeVolume()
    {
        value.text = Mathf.Floor(slider.value * 100f).ToString() + "%";
        PlayerPrefs.SetFloat(key, slider.value);
    }
}
