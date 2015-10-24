using System;
using UnityEngine;


namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(PlatformerCharacter2D))]
    public class Platformer2DUserControlP2 : Platformer2DUserControl
    {

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
                m_Jump = Input.GetButtonDown("JumpP2");
            }
            if (Input.GetKeyDown(KeyCode.Keypad0) && combat)
            {
                combat.Attack(transform.localScale.x);
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.DownArrow);
            float h = Input.GetAxis("HorizontalP2");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }
    }
}
