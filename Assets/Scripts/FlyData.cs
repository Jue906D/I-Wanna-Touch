using UnityEngine;

[CreateAssetMenu(fileName = "Fly Data", menuName = "Scriptable Object/Fly Data", order = int.MaxValue)]
public class FlyData : ScriptableObject
{
    [SerializeField] public float flyTime;
    [SerializeField] public float flySpeed;
    [SerializeField] public float rawGrav;
    [SerializeField] public float minDis;
    [SerializeField] public float minTime;

    [SerializeField] public float shakeRange;
    [SerializeField] public float startRadius;
    //[SerializeField] CharacterType characterType;
}