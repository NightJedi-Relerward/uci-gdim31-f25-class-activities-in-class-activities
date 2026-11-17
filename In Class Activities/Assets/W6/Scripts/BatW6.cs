using UnityEngine;

public class BatW6 : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    public Transform player;
    private bool isChasing = false;

    void Update()
    {
        //StartChase();
        if (isChasing)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }

    public void StartChase()
    {
        isChasing = true;
        Debug.Log("The Bat started chasing.");
    }

    public void StopChase()
    {
        isChasing = false;
        Debug.Log("The Bat stopped chasing.");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") || collision.transform == player)
    //    {
    //        if (!hasHitPlayer)
    //        {
    //            hasHitPlayer = true;
    //            Debug.Log("Ouchy it hurts~");
    //            isChasing = false;
    //        }
    //    }
    //}
}