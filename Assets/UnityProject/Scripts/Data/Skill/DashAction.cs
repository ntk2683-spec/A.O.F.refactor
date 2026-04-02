using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "Dash Action", menuName = "SkillData/Actions/Dash")]
public class DashAction : SkillAction
{
    [SerializeField] private float dashSpeed = 12f;
    [SerializeField] private float dashDuration = 0.2f;
    private bool isDashing = false;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public bool IsDashing => isDashing;
    public float DashSpeed => dashSpeed;
    public float DashDuration => dashDuration;
    public override void Execute(GameObject user, Vector3 targetPos, SkillDataSO data)
    {
        if (isDashing || user == null)
            return;
        rb = user.GetComponent<Rigidbody2D>();
        spriteRenderer = user.GetComponent<SpriteRenderer>();
        if (rb == null)
        {
            Debug.LogError("DashAction: Player không có Rigidbody2D component!");
            return;
        }
        user.GetComponent<MonoBehaviour>().StartCoroutine(PerformDash(user, targetPos));
    }
    private IEnumerator PerformDash(GameObject user, Vector3 targetPos)
    {
        isDashing = true;
        Vector2 dashDirection = GetDashDirection(user, targetPos);
        Debug.Log($"DashAction: dashDirection = {dashDirection}, magnitude = {dashDirection.magnitude}");
        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            rb.velocity = dashDirection.normalized * dashSpeed;
            yield return new WaitForFixedUpdate();
        }
        rb.velocity = Vector2.zero;
        isDashing = false;
    }
    private Vector2 GetDashDirection(GameObject user, Vector3 targetPos)
    {
        // Lấy hướng di chuyển cuối cùng từ PlayerController
        PlayerController playerController = user.GetComponent<PlayerController>();
        if (playerController != null)
        {
            return playerController.GetLastNonZeroMovement();
        }
        
        // Fallback: sử dụng velocity nếu đang di chuyển
        if (rb.velocity.magnitude > 0.1f)
            return rb.velocity.normalized;
        
        if (spriteRenderer == null)
            return Vector2.right;
        return spriteRenderer.flipX ? Vector2.left : Vector2.right;
    }
}