using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBird", menuName = "Theme/Bird")]
public class ScriptableBird : ScriptableObject
{
    public List<Sprite> birdSprs = new List<Sprite>();
}
