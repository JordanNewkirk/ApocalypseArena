using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public TextMeshProUGUI description;

    private void Start()
    {
        description.gameObject.SetActive(false);
    }
    //public GameObject pickupEffect;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp(other));
            description.gameObject.SetActive(true);
            StartCoroutine(FadeTextInAndOut(description));
        }
    }

    IEnumerator PickUp(Collider player)
    {
        player.GetComponent<PlayerController>().moveSpeed = 10f;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(10f);

        player.GetComponent<PlayerController>().moveSpeed = 5.2f;

        Destroy(gameObject);
    }

    IEnumerator FadeTextInAndOut(TextMeshProUGUI text)
    {
        float fadeInDuration = 1f; // adjust the duration to your liking
        float fadeOutDuration = 1f; // adjust the duration to your liking
        float elapsedTime = 0f;

        while (elapsedTime < fadeInDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInDuration);
            Color color = text.color;
            color.a = alpha;
            text.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(1f); // adjust the wait time to your liking

        elapsedTime = 0f;

        while (elapsedTime < fadeOutDuration)
        {
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutDuration);
            Color color = text.color;
            color.a = alpha;
            text.color = color;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}

