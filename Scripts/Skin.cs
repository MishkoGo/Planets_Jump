using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skin : MonoBehaviour
{
    [SerializeField] private string _description;
    [SerializeField] private List<GameObject> _gameObjects;
    [SerializeField] private List<SpriteRenderer> _spriteRenderers;
    
    public void Activate()
    {
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            _gameObjects[i].SetActive(true);
        }
        for (int i = 0; i < _spriteRenderers.Count; i++)
        {
            _spriteRenderers[i].enabled = true;
        }
    }
    public void Deactivate()
    {
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            _gameObjects[i].SetActive(false);
        }
        for (int i = 0; i < _spriteRenderers.Count; i++)
        {
            _spriteRenderers[i].enabled = false;
        }
    }
}
