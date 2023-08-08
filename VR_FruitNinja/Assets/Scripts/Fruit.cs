using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using System.ComponentModel;

//particle type
public enum particleType
{
    Explosion,  // for bomb
    Ice,        // for frozen fruits
    Red,        // red regular fruits
    Orange,     // Orange regular fruits
    Yellow      // Yellow regular fruits

}

public class Fruit : MonoBehaviour
{
    //particle type
    public particleType particleTyp;
    Rigidbody fruitRigidbody;
    GameController gameController;
    Pooler pooler;
    Rigidbody rb;

    private void Start()
    {
        fruitRigidbody = transform.GetComponent<Rigidbody>();
        gameController = GameManager.gm_Instance.gcInstance;
        pooler = Pooler.instance;
        rb = GetComponent<Rigidbody>();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("player swapped");
            Weapon weapon = other.transform.GetComponentInParent<Weapon>();
            if (weapon.canSlice)
            {
                Debug.Log("velocity " + weapon.SwordVelocity);
                if (weapon.SwordVelocity > 3f || particleTyp == particleType.Explosion)
                {
                    Debug.Log("gameObject" + gameObject);
                    gameController.Slice(gameObject, weapon);
                    StoringData(weapon);
                }
            }
            else
            {
                fruitRigidbody.interpolation = RigidbodyInterpolation.Extrapolate;
                Bounce(weapon.direct, weapon.SwordVelocity);
            }
        }

        //for reycyle
        else if (other.transform.CompareTag("ground"))
        {
            StoringData();
            pooler.ReycleFruit(this);
        }
    }
    private void Bounce(Vector3 collisionNormal, float velocity)
    {
        float speed = rb.velocity.magnitude;
        rb.velocity = collisionNormal * Mathf.Max(speed, velocity / 4);
    }

    //when our fruits respawn again, it has old velocity
    //before reycyle our fruit, reset our force 
    public void ResetVelocity()
    {
        gameObject.SetActive(false);
        fruitRigidbody.velocity = Vector3.zero;
        fruitRigidbody.angularVelocity = Vector3.zero;
        transform.rotation = Quaternion.identity;
        fruitRigidbody.interpolation = RigidbodyInterpolation.None;
    }

    #region  Gomathi
    public float FindingGameObjectAngle(GameObject selectedObj)
    {
        Vector3 rot = selectedObj.transform.rotation.eulerAngles;
        float y = 0f;

        if (rot.y > 55 && rot.y < 65)
            y = 60;
        if (rot.y > 115 && rot.y < 125)
            y = 120;
        if (rot.y > 175 && rot.y < 185)
            y = 180;
        if (rot.y > 235 && rot.y < 245)
            y = 240;
        if (rot.y > 295 && rot.y < 305)
            y = 300;
        if (rot.y > 355 && rot.y < 5)
            y = 0;

        return y;
    }

    public void StoringData(Weapon weapon = null)
    {
        SpawnedObejectsInfo _objectType = SpawnedObejectsInfo.Default;
        string _objectTypes = "";
        string _objectName = "";
        string _slicedTime = "";
        bool _isSlied = false;
        string _velocityOfSword = "";
        float _swordAngle = 0f;


        if (weapon != null)
        {
            if (gameObject.name != "Bomb(Clone)" && gameObject.tag == "fruit")
            {
                Debug.Log("Fruit cutted");
                _objectType = SpawnedObejectsInfo.Fruit;
                _objectTypes = _objectType.GetDescription();
                /* GameManager.gm_Instance.scoreController.SwardVelocity.Add(weapon.SwordVelocity);
                GameManager.gm_Instance.scoreController.FruitSlicedTime.Add(GameManager.gm_Instance.uiManager.timeText.text); */
            }
            else if (gameObject.name == "Bomb(Clone)")
            {
                _objectType = SpawnedObejectsInfo.Bomb;
                _objectTypes = _objectType.GetDescription();
                Debug.Log("Bomb cutted");
            }
            _slicedTime = GameManager.gm_Instance.uiManager.timeText.text;
            _velocityOfSword = weapon.SwordVelocity.ToString("F2");
            _isSlied = true;
            Debug.Log("Sliced Time " + _slicedTime);

            //_swordAngle = FindingGameObjectAngle(gameObject);

        }
        else
        {
            _objectType = SpawnedObejectsInfo.Missed;
            _objectTypes = _objectType.GetDescription();
            _isSlied = false;
        }
        _objectName = gameObject.name;

        Debug.Log(_objectName);

        FruitSpawnInfo fruitSpawnInfo = new FruitSpawnInfo()
        {
            ObjectType = _objectType,
            ObjectTypes = _objectTypes,
            ObjectName = _objectName,
            SlicedTime = _slicedTime,
            isSlied = _isSlied,
            velocityOfSword = _velocityOfSword,
            //swordAngle = _swordAngle
        };
        Debug.Log(fruitSpawnInfo);

        GameManager.gm_Instance.jsonController.FruitsArr.Add(fruitSpawnInfo);
    }

    #endregion
}