using UnityEngine;

[CreateAssetMenu(menuName = "Common/LimitPosition")]
public class LimitPosition : ScriptableObject
{
    [SerializeField]
    bool limitX;
    [SerializeField]
    float minX;
    [SerializeField]
    float maxX;
    [Space(10)]
    [SerializeField]
    bool limitY;
    [SerializeField]
    float minY;
    [SerializeField]
    float maxY;
    [Space(10)]
    [SerializeField]
    bool limitZ;
    [SerializeField]
    float minZ;
    [SerializeField]
    float maxZ;


    Vector3 newPos;


    public Vector3 LimitPos(Vector3 originalPos)
    {
        newPos = originalPos;

        if (limitX)
            newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        if (limitY)
            newPos.y = Mathf.Clamp(newPos.y, minY, maxY);
        if (limitZ)
            newPos.z = Mathf.Clamp(newPos.z, minZ, maxZ);

        return newPos;
    }
   
}
