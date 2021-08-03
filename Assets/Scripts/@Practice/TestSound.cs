using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSound : MonoBehaviour
{
    public AudioClip clip;
    /*public AudioClip clipSecond;*/

    int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        /*AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(clip);
        audio.PlayOneShot(clipSecond);

        float lifeTime = Mathf.Max(clip.length, clipSecond.length);

        GameObject.Destroy(gameObject, lifeTime);*/

        if (i++ % 2 == 0)
        {
            Managers.Sound.Play(clip, Define.Sound.Bgm);
        } 
        else
        {
            Managers.Sound.Play("Sounds/UnityChan/univ0002", Define.Sound.Bgm);
        }
    }
}
