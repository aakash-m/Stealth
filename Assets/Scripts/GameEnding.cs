﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    [SerializeField] float fadeDuration = 1f;
    [SerializeField] float displayImageDuration = 1f;
    [SerializeField] GameObject player = null;

    [SerializeField] CanvasGroup exitBakcgroundImageCanvasGroup = null;
    [SerializeField] AudioSource exitAudio;

    [SerializeField] CanvasGroup caughtBackgroundImageCanvasGroup = null;
    [SerializeField] AudioSource caughtAudio;

    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    bool m_HasAudioPlayed;

    float m_Timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        m_IsPlayerCaught = true;
    }

    private void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBakcgroundImageCanvasGroup, false, exitAudio);
        }

        if (m_IsPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }

    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        m_Timer += Time.deltaTime;
        imageCanvasGroup.alpha = m_Timer / fadeDuration;


        if (m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }

}
