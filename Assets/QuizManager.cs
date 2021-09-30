using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] Transform buttonGridTransform;
    [SerializeField] GameObject instrumentButtonPrefab;

    private void Start()
    {
        GenerateButtons(buttonGridTransform);
    }

    void GenerateButtons(Transform parent) {
        Genre_SO[] genres = GenreManager.GetAllGenres();
        foreach (Genre_SO genre in genres) {
            GameObject instrumentButtonGO = Instantiate(instrumentButtonPrefab, parent);
            instrumentButtonGO.GetComponent<Button>().onClick.AddListener( () => OnInstrumentButtonPress(genre.instrument) );
            instrumentButtonGO.GetComponent<Image>().sprite = genre.buttonSprite;
            
        }
    }

    void OnInstrumentButtonPress(Instrument instrument) {
        Genre_SO selected = GenreManager.GetGenreByInstrument(instrument);
        Debug.Log("Selected " + selected.genreName);
    }
}
