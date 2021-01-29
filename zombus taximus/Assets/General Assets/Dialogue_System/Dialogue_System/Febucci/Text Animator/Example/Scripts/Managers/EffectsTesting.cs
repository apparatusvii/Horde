﻿using UnityEngine;

namespace Febucci.UI.Examples
{
    [AddComponentMenu("")]
    public class EffectsTesting : MonoBehaviour
    {
        public TextAnimatorPlayer textAnimatorPlayer;

        public static readonly string[] defaulTags = new string[]
        {
            TextAnimator.bh_Shake,
            TextAnimator.bh_Rot,
            TextAnimator.bh_Wiggle,
            TextAnimator.bh_Wave,
            TextAnimator.bh_Swing, 
            TextAnimator.bh_Incr,
            TextAnimator.bh_Slide,
            TextAnimator.bh_Bounce,
            TextAnimator.bh_Fade,
            TextAnimator.bh_Rainb,
        };

        public bool showDefaultTags = true;

        public string[] customTags = new string[0];

        private void Awake()
        {
            UnityEngine.Assertions.Assert.IsNotNull(textAnimatorPlayer, $"Text Animator Player component is null in {gameObject.name}");
        }

        private void Start()
        {
            ShowText();
        }

        public static string AddEffect(string tag)
        {
            return $"<{tag}>{tag}</{tag}>, ";
        }

        public void ShowText()
        {
            string builtText = "Built-in tags:\n";

            if (showDefaultTags)
            {
                for (int i = 0; i < defaulTags.Length; i++)
                {
                    builtText += AddEffect(defaulTags[i]);
                }

                builtText += "\n";
            }

            for (int i = 0; i < customTags.Length; i++)
            {
                builtText += AddEffect(customTags[i]);
            }

            if (builtText.Length > 0)
            {
                textAnimatorPlayer.ShowText(builtText);
            }
            else
            {
                Debug.LogError("No tags are showed. Try adding custom tags or set showDefaultTags to true in the inspector");
            }
        }

    }
}