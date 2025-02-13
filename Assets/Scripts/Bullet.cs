using Photon.Pun;
using UnityEngine;

public class Bullet : MonoBehaviourPun
{
    public float speed = 5f;
    public float lifeTime = 5f;
    private Photon.Realtime.Player owner;

    public void Initialize(float bulletSpeed, Photon.Realtime.Player bulletOwner)
    {
        speed = bulletSpeed;
        owner = bulletOwner;
    }

    void Start()
    {
        //Destuir el projectil despues de un tiempo
        if(photonView.IsMine)
        {
            Invoke("DestroyBullet", 1f);
        }
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            //Mover el objeto
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(photonView.IsMine)
        {
            if(!other.CompareTag("Player"))
            {
                DestroyBullet();
            }
        }
    }

    void DestroyBullet()
    {
        // Solo el dueño del PhotonView ejecuta esta logico
        if(photonView.IsMine)
        {
            //Destuye la bala en la red
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
