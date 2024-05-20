    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Protein : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            var PlayerController = other.gameObject.GetComponent<PlayerController>();
            if(PlayerController != null && other.gameObject.tag == "Player")
            {
                PlayerController.AddProtein();
                Destroy(gameObject);
            }
        }
    }
