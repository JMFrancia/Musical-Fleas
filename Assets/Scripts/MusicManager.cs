using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Manager in charge of playing instrument clips and final song
 */
public class MusicManager : MonoBehaviour
{
    [SerializeField] float _fadeTime = 3f;
    [SerializeField] AudioClip _finale;

    int _SFXID = -1;

    private void OnEnable()
    {
        EventManager.StartListening(Constants.Events.CORRECT_GENRE_SELECTED, PlayFinale);
        EventManager.StartListeningClass(Constants.Events.BEGIN_GENRE, PlayGenre);
    }

    private void OnDisable()
    {
        EventManager.StopListening(Constants.Events.CORRECT_GENRE_SELECTED, PlayFinale);
        EventManager.StopListeningClass(Constants.Events.BEGIN_GENRE, PlayGenre);
    }

    void PlayFinale() {
        PlayInternal(_finale);
    }

    void PlayGenre(Genre_SO genre)
    {
        PlayInternal(genre.instrumentClip);
    }

    void StopClip() {
        if (_SFXID == -1)
            return;
        SFXManager.Instance.FadeOutSFX(_SFXID, _fadeTime);
        _SFXID = -1;
    }

    void PlayInternal(AudioClip clip)
    {
        StopClip();
        _SFXID = SFXManager.Instance.FadeInLoopingSFX(clip, 1f, _fadeTime);
    }

}
