using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "DashSkill", menuName = "SkillData/Dash")]
public class DashSkill : SkillDataSO
{
    private bool isDashing = false;
    public bool IsDashing => isDashing;

    public override void Execute(GameObject user, Vector3 direction, SkillDataSO data)
    {
        if (user == null) return;

        Vector2 dashDirection = (Vector2)direction;

        // fallback nếu không có input
        if (dashDirection == Vector2.zero)
        {
            SpriteRenderer sr = user.GetComponent<SpriteRenderer>();
            dashDirection = (sr != null && sr.flipX) ? Vector2.left : Vector2.right;
        }

        MonoBehaviour mono = user.GetComponent<MonoBehaviour>();
        if (mono != null)
        {
            mono.StartCoroutine(PerformDash(user, dashDirection));
        }
    }
    private IEnumerator PerformDash(GameObject user, Vector2 dashDirection)
    {
        PlayerController player = user.GetComponent<PlayerController>();
        if (player != null) player.SetDashing(true);

        Rigidbody2D rb = user.GetComponent<Rigidbody2D>();

        float startTime = Time.time;

        while (Time.time < startTime + duration)
        {
            rb.MovePosition(rb.position + dashDirection.normalized * speed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }

        if (player != null) player.SetDashing(false);
    }
}