using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AutoGun : MonoBehaviour
{
    public TextMeshProUGUI description;

    private void Start()
    {
        description.gameObject.SetActive(false);    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PickUp());
            description.gameObject.SetActive(true);
            StartCoroutine(FadeTextInAndOut(description));
        }
    }

    IEnumerator PickUp()
    {
        FindObjectOfType<gun>().shootingCooldown = .1f;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(10f);

        FindObjectOfType<gun>().shootingCooldown = .5f;

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
