using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        protected PlatformerCharacter2D m_Character;
        protected bool m_Jump;

        protected BottleThrower combat;
		[SerializeField]
		AudioClip sound;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            combat = GetComponent<BottleThrower>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump");
            }
            if (Input.GetKeyDown(KeyCode.Space) && combat)
            {
				combat.Attack(transform.localScale.x);
				SFXManager.Instance.playSound(sound);
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.S);
            float h = Input.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
