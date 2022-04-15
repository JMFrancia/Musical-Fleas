using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants : MonoBehaviour
{
    public static class Events {
        public const string BEGIN_GENRE = "BeginGenre";
        public const string FLEA_FOUND = "FleaFound";
        public const string FLEA_FOCUS = "FleaFocus";
        public const string FLEA_UNFOCUS = "FleaUnfocus";
        public const string TARGET_PLACED = "TargetPlaced";
        public const string CORRECT_GENRE_SELECTED = "CorrectGenreSelected";
        public const string WRONG_GENRE_SELECTED = "WrongGenreSelected";
        public const string GAME_START = "GameStart";
        public const string GAME_OVER = "GameOver";
    }

    public static class Tags {
        public const string FLEA = "Flea";
    }

    public static class Layers {
        public const string DROPCOLLIDER = "DropCollider";
    }
}
