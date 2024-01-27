using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEndLevel : MonoBehaviour
{
    private List<CharacterController> _playersController;


    public void Init()
    {
        _playersController = LevelController.Instance.AllCharacterController;

        SpawnMarkers();
    }

    private void SpawnMarkers()
    {
        for (int i = 0; i < _playersController.Count; i++)
        {
            
        }
    }
}
