using UnityEngine;

namespace EathDefend
{
    public abstract class Entity : MonoBehaviour
    {
        #region VAR
        public EntityType EntityType => _entityType;
        [SerializeField] private EntityType _entityType;
        #endregion

        #region FUNC
        #endregion
    }
}
