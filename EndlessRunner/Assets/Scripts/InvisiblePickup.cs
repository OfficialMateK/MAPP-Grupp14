using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePickup : MonoBehaviour
{
    public float speed;
    public float pickupDuration;

    private GameObject player;
    private SpriteRenderer playerSpriteRenderer;
    private BoxCollider2D playerBoxCollider;
    private Color playerVisibleColor;
    private Color playerInvisibleColor;

    IEnumerator SetPlayerVisible()
    {
        yield return new WaitForSeconds(pickupDuration);
        playerSpriteRenderer.color = playerVisibleColor;
        playerBoxCollider.enabled = true;
    }

    private void SetPlayerInvisible()
    {
        playerSpriteRenderer.color = playerInvisibleColor;
        playerBoxCollider.enabled = false;

        StartCoroutine(SetPlayerVisible());
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DisableGameObject();
            GetPlayer(other);
            SetPlayerInvisible();
        }
    }

    private void GetPlayer(Collider2D other)
    {
        player = other.gameObject;
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
        playerBoxCollider = player.GetComponent<BoxCollider2D>();

        playerVisibleColor = playerSpriteRenderer.color;
        playerInvisibleColor = playerVisibleColor;

        playerInvisibleColor.a = 0.1f;
    }

    private void DisableGameObject()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
