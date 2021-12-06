using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class GameController : MonoBehaviour
{
    AnimationLocation anim;
    Direction direction;
    [SerializeField]
    VideoPlayer repeat;
    [SerializeField]
    VideoPlayer stop;

    [SerializeField]
    GameObject particleObject;
    [SerializeField]
    List<ParticleSystem> particleSystems;
    [SerializeField]
    GameObject[] glass_crack_sprites;

    Direction input;

    bool isFirstReaction = false;

    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<AnimationLocation>();        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.JoystickButton4) && !anim.isVideoPlay())
        {
            int index = Random.Range(0, 4);
            direction = (Direction)index;
            PlayAnimation(index);
            isFirstReaction = true;
        }

        if (anim.isVideoPlay() && isFirstReaction == true)
        {

            if (Input.GetKeyDown(KeyCode.JoystickButton0))    //W
            {
                input = Direction.top;
                isFirstReaction = false;
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton1))    //A
            {
                input = Direction.left;
                isFirstReaction = false;
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton2))    //S
            {
                input = Direction.bottm;
                isFirstReaction = false;
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton3))    //D
            {
                input = Direction.right;
                isFirstReaction = false;
            }
            
            if (isFirstReaction == false)
            {
                CompareToRightAnswer();

            }
        }
        
    }

    void CompareToRightAnswer()
    {
        if (input == direction)
        {
            particleObject.transform.position = new Vector3(Random.Range(-7f, 7f), Random.Range(-4f, 4f), 10);
            foreach (ParticleSystem ps in particleSystems)
            {
                ps.Play();
            }

            count++;
            if (count >= 10)
            {
                stop.enabled = true;
                repeat.enabled = false;
            }
            StartCoroutine("GenerateCrack");
        }
    }
    void PlayAnimation(int index)
    {
        anim.SetAnimationLocation(index);
        anim.PlayVideo();
    }

    IEnumerator GenerateCrack()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject temp = Instantiate(glass_crack_sprites[Random.Range(0, glass_crack_sprites.Length)]);
        temp.transform.position = particleObject.transform.position + new Vector3(0,0,-1);
        temp.transform.localScale = temp.transform.localScale * Random.Range(0.3f, 0.8f);
    }
}
