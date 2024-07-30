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

        Debug.Log("�kinci dash baba");

        if (dashCount < maxdashCount)
        {
            canDash = true;
        }

        yield return new WaitForSeconds(dashCooldown - dashTime); // Bekleme s�resi, dashCooldown'dan dashTime'� ��kararak ayarland�.

        isDashing = false;
        controller._rb.useGravity = true;
        canDash = true; // Cooldown s�resi bitti�inde canDash'i s�f�rla
    }

    void ActivateDash()
    {
        if (dashInput && canDash)
        {
            StartCoroutine(DashTimer());
        }
    }
}
