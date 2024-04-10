using UnityEngine;

public interface ITargetInfo
{
    public float GetTargetAngle(int count);
}
public class TargetInfo : ITargetInfo
{
    public float GetTargetAngle(int count)
    {
        float angle = (360f / count) * Random.Range(0, count);
        return angle;
    }
}
