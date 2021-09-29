using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Genre", order = 1)]
public class Genre_SO : ScriptableObject
{
    public GenreName name;
    public Instrument instrument;
    public Sprite instrumentSprite;
    public Sprite fleaSprite;
    AudioClip clip;
}
