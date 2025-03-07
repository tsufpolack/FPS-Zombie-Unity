﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimplePlayerHealth : HealthManager
{
    public float health = 100f;
    public Transform canvas;
    public GameObject hurtPrefab;
    public float decayFactor = 0.8f;

    private HurtHUD hurtUI;
    public KillCounter killCounter; // Reference to the KillCounter script
    private bool dead = false; // Add this to track the death status

    private void Awake()
    {
        AudioListener.pause = false;
        hurtUI = this.gameObject.AddComponent<HurtHUD>();
        hurtUI.Setup(canvas, hurtPrefab, decayFactor, this.transform);
    }

    public override void TakeDamage(Vector3 location, Vector3 direction, float damage, Collider bodyPart, GameObject origin)
    {
        health -= damage;

        if (hurtPrefab && canvas)
            hurtUI.DrawHurtUI(origin.transform, origin.GetHashCode());
    }

    public void OnGUI()
    {
        if (health > 0f)
        {
            GUIStyle textStyle = new GUIStyle
            {
                fontSize = 50
            };
            textStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(0, Screen.height - 60, 30, 30), health.ToString(), textStyle);
        }
        else if (!dead)
        {
            dead = true;
            HandleDeath();
            StartCoroutine(nameof(ReloadScene));
        }
    }

    private void HandleDeath()
    {
        // Decrease the kill count when the player dies
        if (killCounter != null)
        {
            killCounter.DecreaseKillCount();

            if (killCounter.killCount < 0)
            {
                killCounter.ResetKillCount();
                SceneManager.LoadScene(4);
            }
        }
    }

    private IEnumerator ReloadScene()
    {
        SendMessage("PlayerDead", SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds(0.5f);
        canvas.gameObject.SetActive(false);
        AudioListener.pause = true;
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
        Camera.main.cullingMask = LayerMask.GetMask();

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(2);
    }
}
