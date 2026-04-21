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
    [SerializeField] private Joystick joystick;
    public bool IsDashing => isDashing;
    public float DashSpeed => dashSpeed;
    public float DashDuration => dashDuration;
    public override void Execute(GameObject user, Vector3 targetPos, SkillDataSO data)
    {
        if (isDashing || user == null)
            return;
        rb = user.GetComponent<Rigidbody2D>();
        spriteRenderer = user.GetComponent<SpriteRenderer>();
        joystick = FindObjectOfType<Joystick>();
        if (rb == null)
        {
            Debug.LogError("DashAction: Player không có Rigidbody2D component!");
            return;
        }
        user.GetComponent<MonoBehaviour>().StartCoroutine(PerformDash(user));
    }
    private IEnumerator PerformDash(GameObject user)
    {
        isDashing = true;
        Vector2 dashDirection = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (dashDirection == Vector2.zero)
        {
            dashDirection = spriteRenderer.flipX ? Vector2.left : Vector2.right;
        }
        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            rb.MovePosition(rb.position + dashDirection.normalized * dashSpeed * Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
        isDashing = false;
    }
}