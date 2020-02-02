using UnityEngine;

public class PointInTime
{
    public Vector2 position;
    public Quaternion rotation;
    public Vector2 scale;

    public PointInTime (Vector2 _postion, Quaternion _rotation , Vector2 _scale)
    {
        position = _postion;
        rotation = _rotation;
        scale = _scale;
    }
}
