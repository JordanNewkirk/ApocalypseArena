using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Heal : MonoBehaviour
{
    public TextMeshProUGUI description;
    public float heal = 40f;

    private void Start()
    {
        description.gameObject.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (FindObjectOfType<HealthManager>().healthAmount < 100)
            {
                description.gameObject.SetActive(true);
                StartCoroutine(FadeTextInAndOut(description));
                FindObjectOfType<HealthManager>().healPlayer(heal);

                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Collider>().enabled = false;

                Destroy(this.gameObject, 2f);
            }
        }
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
