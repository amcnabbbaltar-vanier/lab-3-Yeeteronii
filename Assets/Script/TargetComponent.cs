using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetComponent : MonoBehaviour
{
    private Renderer targetRenderer;
    private Color originalColour;
    public Color hitColour = Color.black;
    // Start is called before the first frame update
    private void Start()
    {
        targetRenderer = GetComponent<Renderer>();
        if (targetRenderer != null )
        {
            originalColour = targetRenderer.material.color;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            GameManager.Instance.IncrementScore();

            if (targetRenderer != null)
            {
                targetRenderer.material.color = hitColour;
            }
            Invoke("ResetColour", 5f);
        }
    }

    private void ResetColour()
    {
        if (targetRenderer != null)
        {
            targetRenderer.material.color = originalColour;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
