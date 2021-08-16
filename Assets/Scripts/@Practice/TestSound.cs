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
        // PlayOneShot은 중복해서 재생이 가능하다.
        // ( 즉, Second를 재생해도 앞에 재생된 First가 꺼지진 않는다. )
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
