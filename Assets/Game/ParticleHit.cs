
using UnityEngine;

public class ParticleHit: MonoBehaviour
{
    public GameObject _particleSystem;
    

    [SerializeField] private Material _material;
    [SerializeField] [Min(0.1f)] private float _sizeConst = 1f;
    private float _size;
    private float _duration;
    private IDamagable _bodyDamagable;
    



    private void Awake()
    {
        _bodyDamagable = GetComponent<IDamagable>();
    }
    void Start()
    {
      if(_material == null)
        {
            _material = GetComponent<MeshRenderer>().material;
        }
       
        _duration = _particleSystem.GetComponent<ParticleSystem>().main.duration;
        _size = transform.localScale.x / _sizeConst;
        
    }
    private void OnEnable()
    {
        _bodyDamagable.OnGetDamage += Particle;
    }
    private void OnDisable()
    {
        _bodyDamagable.OnGetDamage -= Particle;
    }
    private void Particle(float damage) {
        var particle = Instantiate(_particleSystem, transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystemRenderer>().material = _material;
        particle.GetComponent<ParticleSystem>().startSize = _size;
        Destroy(particle, _duration);
    }
   
}
