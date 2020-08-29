using System.Collections;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public static CollectCoin ins;

    public GameObject Coin;

    [Space]

    public MeshRenderer CoinMesh;
    public Transform CoinPosition;
    public AudioSource CoinSound;

    [Space]

    public ParticleSystem CoinParticle;

    [Space]

    public float Boost;

    public bool Shake = true;

    void Start()
    {
        Coin.SetActive(true);
        ins = this;
    }

    public IEnumerator CoinCollected(int CoinPoints)
    {
        // Play Sound FX
        CoinSound.Play();

        // Create Coin Particles
        CoinParticle.Play();

        // Calls CoinPoints Func.
        PointSystem.pointSystem.CoinCollected(CoinPoints);

        if (PcOrPhoneDetect.ins.Platform == 1)
        {
            PlayerMovement.playerMovement.CoinBoost(Boost, Shake);
        }
        else if (PcOrPhoneDetect.ins.Platform == 2)
        {
            PlayerMovePhone.playerMovement.CoinBoost(Boost);
        }

        yield return new WaitForSeconds(1.2f);

        // DestroyCoin();
    }

    private void DestroyCoin()
    {
        // Destroys Coin
        Destroy(gameObject);
    }
}
