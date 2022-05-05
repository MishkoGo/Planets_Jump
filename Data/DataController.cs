using System.Collections.Generic;
using UnityEngine;
using BayatGames.SaveGameFree;
using BayatGames.SaveGameFree.Serializers;


public class DataController : MonoBehaviour
{
    #region VAR
    public IntEvent onSelectedSkin;
    [SerializeField] private IntWithEvent _score;
    [SerializeField] private IntWithEvent _maxHeight;
    [SerializeField] private Skins _skins;
    [SerializeField] private Shop _shop;
    private string _scoreIdentifier = "score";
    private string _heightIdentifier = "height";
    private string _skinIdentifier = "skin";
    private string _purchasedSkinsIdentifier = "purchasedSkins";
    private string _encodePassword = "78656465439";
    private bool _crypto = true;
    #endregion

    #region MONO
    private void Awake()
    {
        Load();
    }
    #endregion

    #region FUNC
    private void InitSaveGame()
    {
        if (_crypto)
        {
            SaveGame.EncodePassword = _encodePassword;
            SaveGame.Encode = true;
            SaveGame.Serializer = new SaveGameJsonSerializer();
        }
        else
            SaveGame.Encode = false;
    }
    public void Save()
    {
        InitSaveGame();
        SaveGame.Save<int>(_scoreIdentifier, _score.Count);
        SaveGame.Save<int>(_heightIdentifier, _maxHeight.Count);
        SaveGame.Save<int>(_skinIdentifier, _skins.GetCurSkinId());
        SaveGame.Save<List<bool>>(_purchasedSkinsIdentifier, _shop._purchasedSkins);
    }
    private void Load()
    {
        InitSaveGame();

        if (SaveGame.Exists(_scoreIdentifier))
        {
            _score.Count = SaveGame.Load<int>(_scoreIdentifier);
        }
        else
        {
            _score.Count = 0;
        }
        
        if (SaveGame.Exists(_heightIdentifier))
        {
            _maxHeight.Count = SaveGame.Load<int>(_heightIdentifier);
        }
        else
        {
            _maxHeight.Count = 0;
        }
        
        if (SaveGame.Exists(_skinIdentifier))
        {
            int selectedSkin = SaveGame.Load<int>(_skinIdentifier);
            _skins.SetSkin(selectedSkin);
            onSelectedSkin?.Invoke(selectedSkin);
        }
        
        if (SaveGame.Exists(_purchasedSkinsIdentifier))
        {
            List<bool> state = SaveGame.Load<List<bool>>(_purchasedSkinsIdentifier);

            for (int i = 0; i < state.Count; i++)
            {
                _shop._purchasedSkins[i] = state[i];
            }
        }
        
        _skins.Init();
        _shop.Init();
    }
    #endregion
}

