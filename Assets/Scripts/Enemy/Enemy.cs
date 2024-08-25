using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Player playerT;
    [SerializeField] float speed = 5f;

    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        AssignPlayer(playerT);
    }

    public void AssignPlayer(Player playerT)
    {
        this.playerT = playerT;
        StartCoroutine(ChaseLogic());
    }

    private void Update()
    {
        ChaseLogic();
    }

    IEnumerator ChaseLogic()
    {
        while (playerT != null)
        {
            Chase();
            yield return null;
        }
    }

    void Chase()
    {
        float dist = Vector3.Distance(transform.position, playerT.transform.position);

        Vector3 rot = playerT.transform.position - transform.position;
        //rot.y = 0;
        //rot.z = 0;

        if (dist > 3f)
        {
            transform.rotation = Quaternion.LookRotation(rot);
            rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
        }
    }
}
