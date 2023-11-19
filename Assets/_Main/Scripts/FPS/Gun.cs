using UnityEngine;


namespace Scripts.FPS
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private float damage = 10.0f;
        [SerializeField] private float range = 100.0f;
        [SerializeField] private float fireRate = 15.0f;
        [SerializeField] private ParticleSystem _muzzleParticle;
        [SerializeField] private GameObject _impactEffect;
        [SerializeField] private GameObject _bloodEffect;

        private GameManager gameManager;
        private Camera _fpsCam;
        private float nextFire = 0.0f;

        // Start is called before the first frame update
        void Start()
        {
            _fpsCam = Camera.main;
            gameManager = GameManager.GetInstance();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButton("Fire1") && Time.time >= nextFire)
            {
                Shoot();
                nextFire = Time.time + 1f / fireRate;
            }
        }

        private void Shoot()
        {
            gameManager.UpdateTotalShots();
            gameManager.CalculateOverallAccuracy();
            _muzzleParticle.Play();

            bool cast = Physics.Raycast(_fpsCam.transform.position, _fpsCam.transform.forward, out RaycastHit hit, range);

            if (!cast) return;

            if (hit.collider.TryGetComponent(out Damagable damagable))
            {
                damagable.ApplyDamage(damage);

                PlayEffect(_bloodEffect, hit);
            }
            else
            {
                PlayEffect(_impactEffect, hit);
            }
        }

        private void PlayEffect(GameObject _effect, RaycastHit hit)
        {
            GameObject impactGO = Instantiate(_effect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 2f);
        }
    }
}
