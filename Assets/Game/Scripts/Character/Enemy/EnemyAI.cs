using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour, ICharacterInput
{
    [SerializeField] private GameObjectSet playerSet;
    [SerializeField] private float shootDelay = 0.5f;
    [SerializeField] private LayerMask solid;
    [SerializeField] private float visionRange;
    [SerializeField] private bool lookRight = true;

    private bool shooting = false;

    private Transform player;

    public Vector2 Movement { get; set; }
    public Vector2 Look { get; set; }
    public Vector2 SpeedFade { get; set; }
    public event UnityAction Jump;
    public event UnityAction<int> CastAbility;

    private IEnumerator shootRoutine;
    RaycastHit2D[] linecastResults = new RaycastHit2D[1];

    private void Start()
    {
        player = playerSet.Items[0].transform;
        shootRoutine = AimAndShoot();

        if (!lookRight)
        {
            Look = (Vector2)transform.position + Vector2.left * 5 + Vector2.down;
        }
        else
        {
            Look = (Vector2)transform.position + Vector2.right * 5 + Vector2.down;
        }
    }

    private void Update()
    {
        if (ShouldChasePlayer())
        {
            if (!shooting)
            {
                StartCoroutine(shootRoutine);
                shooting = true;
            }
            CalculateMovementInput();
        }
        else
        {
            //StopCoroutine(shootRoutine);
            //shooting = false;
            Movement = new Vector2(0, 0);
        }
    }

    private bool ShouldChasePlayer()
    {
        if (Physics2D.LinecastNonAlloc(transform.position, player.position, linecastResults, solid.value) == 0)
        {
            if (Vector3.Distance(transform.position, player.position) <= visionRange)
            {
                return true;
            }
        }
        return false;
    }

    private void CalculateMovementInput()
    {
        float offset = 0.4f;
        if (transform.position.x > player.position.x + offset)
        {
            Movement = new Vector2(-1, 0);
        }
        else if (transform.position.x < player.position.x - offset)
        {
            Movement = new Vector2(1, 0);
        }
        else
        {
            Movement = new Vector2(0, 0);
        }
        if (Physics2D.Raycast((Vector2)transform.position, Movement, 1.0f, solid))
        {
            Jump.Invoke();
        }
        Look = player.position;
    }

    private IEnumerator AimAndShoot()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            //Vector2 direction = (player.position - transform.position).normalized;
            //GameObject bullet = Instantiate(proyectile, transform.position, Quaternion.identity);
            //bullet.GetComponent<ProjectileController>().Initialize(this.gameObject, direction * bulletSpeed, 0.0f, 10.0f);
            CastAbility.Invoke(0);
            yield return new WaitForSeconds(shootDelay);
        }
    }
}
