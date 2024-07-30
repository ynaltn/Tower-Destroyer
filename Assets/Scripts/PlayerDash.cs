using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField] private float dashSpeed = 15f;
    [SerializeField] private float dashTime = 0.5f;
    [SerializeField] private float dashCooldown = 2f;
    bool isDashing = false;
    bool dashInput = false;
    PlayerController controller;
    private bool canDash = true;
    private int dashCount = 0;
    private int maxdashCount = 2;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        GatherInput();
        ActivateDash();
    }

    void GatherInput()
    {
        dashInput = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Jump");
    }

    IEnumerator DashTimer()
    {
        isDashing = true;
        canDash = false;
        dashCount++;

        controller._rb.useGravity = true;
        controller._rb.AddForce(transform.forward * dashSpeed, ForceMode.Impulse);

        Debug.Log("Dash baba");

        yield return new WaitForSeconds(dashTime);

        Debug.Log("Ýkinci dash baba");

        if (dashCount < maxdashCount)
        {
            canDash = true;
        }

        yield return new WaitForSeconds(dashCooldown - dashTime); // Bekleme süresi, dashCooldown'dan dashTime'ý çýkararak ayarlandý.

        isDashing = false;
        controller._rb.useGravity = true;
        canDash = true; // Cooldown süresi bittiðinde canDash'i sýfýrla
    }

    void ActivateDash()
    {
        if (dashInput && canDash)
        {
            StartCoroutine(DashTimer());
        }
    }
}
