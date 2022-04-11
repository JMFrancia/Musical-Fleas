using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*
 * Manages overall game state
 */
public class GameManager : MonoBehaviour
{
    public static Genre_SO CurrentGenre { get; private set; }

    Queue<Genre_SO> _genreQueue;

    private void OnEnable()
    {
        EventManager.StartListening(Constants.Events.CORRECT_GENRE_SELECTED, OnCorrectAnswer);
    }

    private void OnDisable()
    {
        EventManager.StopListening(Constants.Events.CORRECT_GENRE_SELECTED, OnCorrectAnswer);
    }

    void OnCorrectAnswer() {
        
        NextGenre();
    }

    private void Start()
    {
        _genreQueue = GenerateGenreQueue();
        NextGenre();
    }

    void NextGenre() {
        if (_genreQueue.Count > 0)
        {
            CurrentGenre = _genreQueue.Dequeue();
            Debug.Log("Genre: " + CurrentGenre.genreName);
            EventManager.TriggerEvent(Constants.Events.BEGIN_GENRE, CurrentGenre);
        }
        else {
            GameOver();
        }
    }

    void GameOver() {
        EventManager.TriggerEvent(Constants.Events.GAME_OVER);
        Debug.Log("Game over!");
    }

    Queue<Genre_SO> GenerateGenreQueue()
    {
        Queue<Genre_SO> result = new Queue<Genre_SO>();
        System.Random random = new System.Random();
        List<Genre_SO> shuffledGenres = GenreManager.GetAllGenres().OrderBy(n => random.Next()).ToList();
        shuffledGenres.ForEach(genre => result.Enqueue(genre));
        return result;
    }
}
