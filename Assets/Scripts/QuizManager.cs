using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * Manages UI for quiz
 */
public class QuizManager : MonoBehaviour
{
    [SerializeField] Transform buttonGridTransform;
    [SerializeField] GameObject instrumentButtonPrefab;

    List<Button> buttons;

    private void OnEnable()
    {
        EventManager.StartListening(Constants.Events.FLEA_FOCUS, ShowButtons);
    }

    private void OnDisable()
    {
        EventManager.StartListening(Constants.Events.FLEA_UNFOCUS, HideButtons);
    }

    private void Start()
    {
        buttons = GenerateButtons(buttonGridTransform);
        HideButtons();
    }

    List<Button> GenerateButtons(Transform parent)
    {
        List<Button> result = new List<Button>();
        Genre_SO[] genres = GenreManager.GetAllGenres();
        foreach (Genre_SO genre in genres) {
            GameObject instrumentButtonGO = Instantiate(instrumentButtonPrefab, parent);
            Button button = instrumentButtonGO.GetComponent<Button>();
            button.onClick.AddListener( () => OnInstrumentButtonPress(button, genre.instrument) );
            instrumentButtonGO.GetComponent<Image>().sprite = genre.buttonSprite;
            result.Add(button);
        }
        return result;
    }

    void ResetButtons() {
        for (int n = 0; n < buttons.Count; n++) {
            buttons[n].interactable = true;
        }
    }

    void ShowButtons() {
        buttonGridTransform.gameObject.SetActive(true);
        Debug.Log("Showing buttons");
    }

    void HideButtons()
    {
        buttonGridTransform.gameObject.SetActive(false);
        Debug.Log("Hiding buttons");
    }

    void CorrectAnswer(Button button) {
        EventManager.TriggerEvent(Constants.Events.CORRECT_GENRE_SELECTED);
        ResetButtons();
        Debug.Log("Correct!");
    }

    void WrongAnswer(Button button) {
        Debug.Log("Wrong!");
        EventManager.TriggerEvent(Constants.Events.WRONG_GENRE_SELECTED);
        button.interactable = false;
    }

    void OnInstrumentButtonPress(Button button, Instrument instrument) {
        Genre_SO selected = GenreManager.GetGenreByInstrument(instrument);
        Debug.Log(selected.genreName + " selected...");
        if (selected == GameManager.CurrentGenre)
        {
            CorrectAnswer(button);
        }
        else {
            WrongAnswer(button);
        }
    }
}
