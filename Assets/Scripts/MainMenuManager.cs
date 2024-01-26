using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private Image _soundImage;
    [SerializeField]
    private Image _musicImage;

    [SerializeField]
    private Sprite _activeSoundSprite, _inactiveSoundSprite;

    [SerializeField]
    private Text highScoreText;

    private void Start()
    {
        bool sound = (PlayerPrefs.HasKey(Constants.DATA.SETTINGS_SOUND) ?
           PlayerPrefs.GetInt(Constants.DATA.SETTINGS_SOUND) : 1) == 1;
        _soundImage.sprite = sound ? _activeSoundSprite : _inactiveSoundSprite;

        SetSprite();

        highScoreText.text = "High score: " + PlayerPrefs.GetInt(Constants.DATA.HIGH_SCORE);

        AudioManager.Instance.AddButtonSound();
    }

    public void ClickedPlay()
    {
        SceneManager.LoadScene(Constants.DATA.GAMEPLAY_SCENE);
    }

    public void ToggleSound()
    {
        bool sound = (PlayerPrefs.HasKey(Constants.DATA.SETTINGS_SOUND) ? PlayerPrefs.GetInt(Constants.DATA.SETTINGS_SOUND)
             : 1) == 1;
        sound = !sound;
        PlayerPrefs.SetInt(Constants.DATA.SETTINGS_SOUND, sound ? 1 : 0);
        _soundImage.sprite = sound ? _activeSoundSprite : _inactiveSoundSprite;
        AudioManager.Instance.ToggleSound();
    }

    public void ToggleMusic()
    {
        if (PlayerPrefs.GetInt(Constants.DATA.SETTINGS_MUSIC) == 1)
        {
            PlayerPrefs.SetInt(Constants.DATA.SETTINGS_MUSIC, 0);
            _musicImage.sprite = _inactiveSoundSprite;
            AudioManager.Instance.PauseMusic();
        }
        else
        {
            PlayerPrefs.SetInt(Constants.DATA.SETTINGS_MUSIC, 1);
            _musicImage.sprite = _activeSoundSprite;
            AudioManager.Instance.PlayMusic();
        }
    }

    private void SetSprite()
    {
        if (PlayerPrefs.GetInt(Constants.DATA.SETTINGS_MUSIC) == 1)
        {
            _musicImage.sprite = _activeSoundSprite;
        }
        else
        {
            _musicImage.sprite = _inactiveSoundSprite;
        }
    }
}
