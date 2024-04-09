using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider _musicSlider, _sfxSlider;
    public Image _musicImage, _sfxImage;
    public Sprite _musicOnSprite, _musicOffSprite, _sfxOnSprite, _sfxOffSprite;

    public void ToggleMusic()
    {
        AudioManager.Instance.ToggleMusic();
        UpdateMusicImage();
    }
    public void ToggleSFX()
    {
        AudioManager.Instance.ToggleSFX();
        UpdateSFXImage();
    }
    private void UpdateMusicImage()
    {
        if (AudioManager.Instance.IsMusicMuted())
        {
            _musicImage.sprite = _musicOffSprite;
        }
        else
        {
            _musicImage.sprite = _musicOnSprite;
        }
    }
    private void UpdateSFXImage()
    {
        if (AudioManager.Instance.IsSFXMuted())
        {
            _sfxImage.sprite = _sfxOffSprite;
        }
        else
        {
            _sfxImage.sprite = _sfxOnSprite;
        }
    }
    public void MusicVolume()
    {
        AudioManager.Instance.MusicVolume(_musicSlider.value);
    }
    public void SFXVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value);
    }

}
