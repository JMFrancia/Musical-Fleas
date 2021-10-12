using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenreManager : MonoBehaviour
{
    [SerializeField] Genre_SO[] _genres;

    static Dictionary<GenreName, Genre_SO> _genreByNameDict;
    static Dictionary<Instrument, Genre_SO> _genreByInstrumentDict;

    public static Genre_SO GetGenreByName(GenreName name) {
        return _genreByNameDict[name];
    }

    public static Genre_SO GetGenreByInstrument(Instrument instrument) {
        return _genreByInstrumentDict[instrument];
    }

    public static Genre_SO[] GetAllGenres() {
        Genre_SO[] result = new Genre_SO[_genreByNameDict.Values.Count];
        _genreByNameDict.Values.CopyTo(result, 0);
        return result;
    }

    private void Awake()
    {
        _genreByNameDict = new Dictionary<GenreName, Genre_SO>();
        _genreByInstrumentDict = new Dictionary<Instrument, Genre_SO>();
        for (int n = 0; n < _genres.Length; n++) {
            _genreByNameDict.Add(_genres[n].genreName, _genres[n]);
            _genreByInstrumentDict.Add(_genres[n].instrument, _genres[n]);
        }
    }
}
