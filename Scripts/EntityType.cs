using UnityEngine;

namespace EathDefend
{
    [CreateAssetMenu(menuName = "Common/EntityType")]
    public class EntityType : ScriptableObject
    {
        #region VAR
        public int Score => _score;
        public float Factor => _factor;
        [Space(10)] 
        [SerializeField] private int _score;
        [SerializeField] private float _factor;
        #endregion  
    }
}
