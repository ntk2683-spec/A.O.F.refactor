using UnityEngine;
using System.Collections;
[CreateAssetMenu(fileName = "Shield Action", menuName = "SkillData/Actions/Shield")]
public class ShieldAction : SkillAction
{
    [SerializeField] private GameObject shieldPrefab;
    [SerializeField] private float shieldDuration = 3f;
    public override void Execute(GameObject user, Vector3 targetPos, SkillDataSO data)
    {
        if (shieldPrefab == null)
        {
            Debug.LogError("Shield Prefab is not assigned!");
            return;
        }
        Vector3 spawnPosition = user.transform.position;
        GameObject shieldInstance = Instantiate(shieldPrefab, spawnPosition, Quaternion.identity, user.transform);
        Destroy(shieldInstance, shieldDuration);
    }
}