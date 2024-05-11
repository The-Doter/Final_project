    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Protein : MonoBehaviour
    {

        void OnTriggerEnter(Collider other)
        {
            var PlayerController = other.gameObject.GetComponent<PlayerController>();
            if(PlayerController != null)
            {
                PlayerController.AddProtein();
                Destroy(gameObject);
            }
        }
    }
