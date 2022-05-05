using UnityEngine;


[CreateAssetMenu(menuName = "Common/CameraLimitPosition")]
public class CameraLimitPosition : ScriptableObject
{
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    Vector3 Pos;

    public Vector3 Limit(Vector3 _Pos)
    {
        Pos = _Pos;

        Pos.x = Mathf.Clamp(Pos.x, minX, maxX);
        Pos.z = Mathf.Clamp(Pos.z, minZ, maxZ);

        return Pos;
    }
}
