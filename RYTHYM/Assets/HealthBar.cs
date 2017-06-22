using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    Transform[] units;
    public int health;
    public bool removeHealth;
    SpriteRenderer spriteRenderer;
    Color alphaZero;
    Color originalColor = Color.white;
    public float fadeOutDuration = 5f;
    float smooth = .02f;
    float t;
    SpriteRenderer[] childSpriteRenderers;

	void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        childSpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        alphaZero = new Color(1, 1, 1, 0);
        int health = transform.childCount;
        units = new Transform[health];
        for (int i = 0; i < health; i++)
        {
            units[i] = transform.GetChild(i);
        }      
	}

    private void Update()
    {
        if (removeHealth)
        {
            RemoveHealthUnit();
            Task task = new Task(FadeOut());
            task.Start();
            //StartCoroutine(FadeOut());
            //t = 0;
        }
    }

    void RemoveHealthUnit()
    {
        if (health > 0)
        {
            health--;
            units[health].gameObject.SetActive(false);
        }
        removeHealth = false;
    }
    IEnumerator FadeOut()
    {
        Debug.Log("Coroutine Start");
        yield return new WaitForSeconds(2f);
        t = 0; //This float will serve as the 3rd parameter of the lerp function.
        spriteRenderer.color = originalColor;
        foreach (SpriteRenderer renderer in childSpriteRenderers)
        {
            renderer.color = originalColor;
        }
        float increment = smooth / fadeOutDuration; //The amount of change to apply.
        while (t < 1)
        {
            spriteRenderer.color = Color.Lerp(originalColor, Color.clear, t);
            foreach (SpriteRenderer renderer in childSpriteRenderers)
            {
                renderer.color = Color.Lerp(originalColor, Color.clear, t);
            }
            t += increment;
            yield return new WaitForSeconds(smooth);
        }
        Debug.Log("Coroutine Finish");
        yield return null;
    }
}
