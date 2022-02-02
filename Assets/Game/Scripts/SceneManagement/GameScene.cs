using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scene Management/Game Scene")]
public class GameScene : ScriptableObject
{
    [Header("Information")]
    public string sceneName;
    public string description;
}
