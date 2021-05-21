using UnityEngine;
using UnityEngine.UI;

namespace Worms
{
    public class Wormy : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D bulletPrefab;
        [SerializeField] private  Transform currentGun;
        [SerializeField] private Text txtHealth;

        [SerializeField] private int maxHealth;
        [SerializeField] private float wormySpeed = 1;
        [SerializeField] private float maxRelativeVelocity;
        [SerializeField] private float misileForce = 5;

        public bool IsTurn
        {
            get { return WormyManager.singleton.IsMyTurn(wormId); }
        }

        public int wormId;
        private WormyHealth wormyHealth;
        SpriteRenderer ren;

        private void Start()
        {
            wormyHealth = new WormyHealth(maxHealth);
            txtHealth.text = wormyHealth.Health.ToString();
            ren = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            if (!IsTurn)
                return;

            RotateGun();

            var hor = Input.GetAxis("Horizontal");
            if (hor == 0)
            {
                currentGun.gameObject.SetActive(true);

                ren.flipX = currentGun.eulerAngles.z < 180;

                if (Input.GetKeyDown(KeyCode.Q))
                {
                    var p = Instantiate(bulletPrefab,
                        currentGun.position - currentGun.right,
                        currentGun.rotation);

                    p.AddForce(-currentGun.right * misileForce, ForceMode2D.Impulse);

                    if (IsTurn)
                        WormyManager.singleton.NextWorm();
                }
            }
            else
            {
                currentGun.gameObject.SetActive(false);
                transform.position += Vector3.right *
                                      hor *
                                      Time.deltaTime *
                                      wormySpeed;
                ren.flipX = Input.GetAxis("Horizontal") > 0;
            }
        }

        void RotateGun()
        {
            var diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            currentGun.rotation = Quaternion.Euler(0f, 0f, rot_z + 180);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.relativeVelocity.magnitude > maxRelativeVelocity)
            {
                wormyHealth.ChangeHealth(-3);
                txtHealth.text = wormyHealth.Health.ToString();
                if (IsTurn)
                    WormyManager.singleton.NextWorm();
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Explosion"))
            {
                wormyHealth.ChangeHealth(-10);
                if (IsTurn)
                    WormyManager.singleton.NextWorm();
            }
        }
    }
}