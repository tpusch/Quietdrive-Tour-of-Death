using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        protected PlatformerCharacter2D m_Character;
        protected bool m_Jump;

        protected Combat combat;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
            combat = GetComponent<Combat>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = Input.GetButtonDown("Jump");
            }

        }


        private void FixedUpdate()
        {
            // Read the inputs.
            //bool crouch = Input.GetKey(KeyCode.S);
            float h = Input.GetAxis("Horizontal");
			bool attack = false;
			if (Input.GetKeyDown(KeyCode.Space))
			{
				attack = true;
				//combat.Attack(transform.localScale.x);
				//SFXManager.Instance.playSound(sound);
			}
            // Pass all parameters to the character control script.
            m_Character.Move(h, attack, m_Jump);
            m_Jump = false;
        }
    }
}
