using UnityEngine;


public interface IHaveSpeed
{
    #region VAR

    float Speed { get; set; }

    #endregion

    #region FUNC

    float GetSpeed();

    #endregion
}

