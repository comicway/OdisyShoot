using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    [SerializeField] private GameObject character;
    //[SerializeField] private Moving characterShip;

    public void Moving(float speed)
    {
       
        float mHorizontal = Input.GetAxis("Horizontal");
        float mVertical = Input.GetAxis("Vertical");

        character.transform.position += new Vector3(mHorizontal, 0, mVertical) * speed * Time.deltaTime;

    }
 
}
