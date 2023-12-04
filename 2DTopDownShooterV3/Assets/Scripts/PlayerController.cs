using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed;
    private Rigidbody2D rb;
    [SerializeField] private GameObject crosshair;
    private Transform playerTransform;
    private HealthSystem healthSystem;
    public AK47 ak47; // Referencia al script AK47
    public Pistol pistol; // Referencia al script AK47
    public bool ak47Activated; // Indica si el AK47 ha sido activado
    public PlayerController pcreferecxd;
    public GameObject gameController;


    [SerializeField] private float collisionForceMultiplier = 0.8f; // Factor de multiplicación para reducir la fuerza de la colisión

    private void Start()
    {
        pcreferecxd = GetComponent<PlayerController>();
        Cursor.visible = false;
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        healthSystem = GetComponent<HealthSystem>();
        ak47 = GetComponent<AK47>();
        pistol = GetComponent<Pistol>(); 
        ak47Activated = false; // Inicialmente, el AK47 no está activado
        ak47.enabled = false; // Desactivar el script AK47 al inicio
    }

    public void desactivatePlayerController()
    {
        pcreferecxd.enabled = false;
    }
    public void ActivateWeapon()
    {
        ak47Activated = true;
        ak47.enabled = true;
    }

    public void addHealth(int healthToAdd)
    {
        healthSystem.Heal(healthToAdd);
    }

    public int getPlayerCurrentHealth()
    {
        Debug.Log("returning health: " + healthSystem.getCurrentHealth());
        return healthSystem.getCurrentHealth();
    }

    public Pistol GetPistol()
    {
        return pistol;
    }

    public AK47 GetAK47()
    {
        return ak47;
    }

    private void Update()
    {
        playerMovement();
        mouseFollowCrosshair();
        RotatePlayerTowardsMouse();
    }

    void mouseFollowCrosshair()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        crosshair.transform.position = new Vector3(mousePosition.x, mousePosition.y, 0f);
    }

    void playerMovement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement * speed;
    }

    void RotatePlayerTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - playerTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        playerTransform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Calcular la fuerza de la colisión y reducir su magnitud
        Vector2 collisionForce = collision.relativeVelocity * collisionForceMultiplier;

        // Aplicar una fuerza contraria a la dirección de la colisión al jugador
        rb.AddForce(-collisionForce, ForceMode2D.Impulse);
    }

}
