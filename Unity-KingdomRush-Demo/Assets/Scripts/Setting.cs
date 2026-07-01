using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    [SerializeField] Slider bgmSlider;
    [SerializeField] Toggle sfxToggle;
    [SerializeField] Toggle bgmToggle;

    public void OnBGMSliderChanged()
    {
        AudioManager.Instance.SetBGMVolume(bgmSlider.value);
    }
    public void OnSFXToggleChanged()
    {
        AudioManager.Instance.SetSFXEnabled(sfxToggle.isOn);
    }
    public void OnBGMToggleChanged()
    {
        AudioManager.Instance.SetBGMEnabled(bgmToggle.isOn);
    }
}
