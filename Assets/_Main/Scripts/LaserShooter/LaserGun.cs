using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private LineRenderer beam;
    [SerializeField] private Transform muzzlePoint;
    [SerializeField] private float maxLength;

    [SerializeField] private ParticleSystem _muzzleParticle;
    [SerializeField] private ParticleSystem _hitParticle;

    [SerializeField] private float damage;

    private void Awake()
    {
        beam.enabled = false;
    }

    private void Activate()
    {
        beam.enabled = true;

        _muzzleParticle.Play();
        _hitParticle.Play();
    }

    private void Deactivate()
    {
        beam.enabled = false;

        beam.SetPosition(0, muzzlePoint.position);
        beam.SetPosition(1, muzzlePoint.position);

        _muzzleParticle.Stop();
        _hitParticle.Stop();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) Activate();
        else if (Input.GetMouseButtonUp(0)) Deactivate();

        if (!beam.enabled) return;

        Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);
        bool cast = Physics.Raycast(ray, out RaycastHit hit, maxLength);
        Vector3 hitPosition = cast ? hit.point : muzzlePoint.position + muzzlePoint.forward * maxLength;

        beam.SetPosition(0, muzzlePoint.position);
        beam.SetPosition(1, hitPosition);

        _hitParticle.transform.position = hitPosition;

        if (cast && hit.collider.TryGetComponent(out Damagable damagable))
        {
            damagable.ApplyDamage(damage * Time.deltaTime);
        }
    }
}
