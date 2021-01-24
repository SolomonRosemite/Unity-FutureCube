using UnityEngine;
using System.Collections.Generic;

namespace EZCameraShake
{
    [AddComponentMenu("EZ Camera Shake/Camera Shaker")]
    public class CameraShaker : MonoBehaviour
    {
        public float x = 7.088366f;
        public float y = -9.34324f;
        public float z = -5f;

        /// <summary>
        /// <summary>
        /// The single instance of the CameraShaker in the current scene. Do not use if you have multiple instances.
        /// </summary>
        public static CameraShaker Instance;
        private static Dictionary<string, CameraShaker> instanceList = new Dictionary<string, CameraShaker>();

        [Space]

        /// <summary>
        /// The default position influcence of all shakes created by this shaker.
        /// </summary>
        public Vector3 PositionalInfluence = new Vector3(0.15f, 0.15f, 0.15f);
        /// <summary>
        /// The default rotation influcence of all shakes created by this shaker.
        /// </summary>
        public Vector3 RotationalInfluence = new Vector3(1, 1, 1);
        /// Offset that will be applied to the camera's default (0,0,0) rest position
        /// </summary>
        private Vector3 RestPositionOffset = new Vector3(0, 0, 0);
        /// <summary>
        /// Offset that will be applied to the camera's default (0,0,0) rest rotation
        /// </summary>
        private Vector3 RestRotationOffset = new Vector3(0, 0, 0);

        Vector3 posAddShake, rotAddShake;

        List<CameraShakeInstance> cameraShakeInstances = new List<CameraShakeInstance>();

        void Awake()
        {
            Instance = this;
            instanceList.Add(gameObject.name, this);
        }

        void Update()
        {
            if (PcOrPhoneDetect.ins.Platform == 1)
            {
                RestPositionOffset.x = PlayerMovement.playerMovement.rb.position.x + x;
                RestPositionOffset.y = PlayerMovement.playerMovement.rb.position.y + y;
                RestPositionOffset.z = PlayerMovement.playerMovement.rb.position.z + z;
            }
            if (PcOrPhoneDetect.ins.Platform == 2)
            {
                RestPositionOffset.x = PlayerMovePhone.playerMovement.rb.position.x + x;
                RestPositionOffset.y = PlayerMovePhone.playerMovement.rb.position.y + y;
                RestPositionOffset.z = PlayerMovePhone.playerMovement.rb.position.z + z;
            }

            /*
            try
            {
                if (PcOrPhoneDetect.ins.Platform == 1)
                {
                    RestPositionOffset.x = PlayerMovement.playerMovement.rb.position.x + x;
                    RestPositionOffset.y = PlayerMovement.playerMovement.rb.position.y + y;
                    RestPositionOffset.z = PlayerMovement.playerMovement.rb.position.z + z;
                }
                if (PcOrPhoneDetect.ins.Platform == 2)
                {
                    RestPositionOffset.x = PlayerMovePhone.playerMovement.rb.position.x + x;
                    RestPositionOffset.y = PlayerMovePhone.playerMovement.rb.position.y + y;
                    RestPositionOffset.z = PlayerMovePhone.playerMovement.rb.position.z + z;
                }
            }
            catch
            {
                RestPositionOffset.x = PlayerMovement.playerMovement.rb.position.x + x;
                RestPositionOffset.y = PlayerMovement.playerMovement.rb.position.y + y;
                RestPositionOffset.z = PlayerMovement.playerMovement.rb.position.z + z;
            }
            */

            posAddShake = Vector3.zero;
            rotAddShake = Vector3.zero;

            for (int i = 0; i < cameraShakeInstances.Count; i++)
            {
                if (i >= cameraShakeInstances.Count)
                    break;

                CameraShakeInstance c = cameraShakeInstances[i];

                if (c.CurrentState == CameraShakeState.Inactive && c.DeleteOnInactive)
                {
                    cameraShakeInstances.RemoveAt(i);
                    i--;
                }
                else if (c.CurrentState != CameraShakeState.Inactive)
                {
                    posAddShake += CameraUtilities.MultiplyVectors(c.UpdateShake(), c.PositionInfluence);
                    rotAddShake += CameraUtilities.MultiplyVectors(c.UpdateShake(), c.RotationInfluence);
                }
            }

            transform.localPosition = posAddShake + RestPositionOffset;
            transform.localEulerAngles = rotAddShake + RestRotationOffset;
        }

        /// <summary>
        /// Gets the CameraShaker with the given name, if it exists.
        /// </summary>
        /// <param name="name">The name of the camera shaker instance.</param>
        /// <returns></returns>
        public static CameraShaker GetInstance(string name)
        {
            CameraShaker c;

            if (instanceList.TryGetValue(name, out c))
                return c;

            Debug.LogError("CameraShake " + name + " not found!");

            return null;
        }

        /// <summary>
        /// Starts a shake using the given preset.
        /// </summary>
        /// <param name="shake">The preset to use.</param>
        /// <returns>A CameraShakeInstance that can be used to alter the shake's properties.</returns>
        public CameraShakeInstance Shake(CameraShakeInstance shake)
        {
            cameraShakeInstances.Add(shake);
            return shake;
        }

        /// <summary>
        /// Shake the camera once, fading in and out  over a specified durations.
        /// </summary>
        /// <param name="magnitude">The intensity of the shake.</param>
        /// <param name="roughness">Roughness of the shake. Lower values are smoother, higher values are more jarring.</param>
        /// <param name="fadeInTime">How long to fade in the shake, in seconds.</param>
        /// <param name="fadeOutTime">How long to fade out the shake, in seconds.</param>
        /// <returns>A CameraShakeInstance that can be used to alter the shake's properties.</returns>
        public CameraShakeInstance ShakeOnce(float magnitude, float roughness, float fadeInTime, float fadeOutTime)
        {
            CameraShakeInstance shake = new CameraShakeInstance(magnitude, roughness, fadeInTime, fadeOutTime);
            shake.PositionInfluence = PositionalInfluence;
            shake.RotationInfluence = RotationalInfluence;
            cameraShakeInstances.Add(shake);

            return shake;
        }

        /// <summary>
        /// Shake the camera once, fading in and out over a specified durations.
        /// </summary>
        /// <param name="magnitude">The intensity of the shake.</param>
        /// <param name="roughness">Roughness of the shake. Lower values are smoother, higher values are more jarring.</param>
        /// <param name="fadeInTime">How long to fade in the shake, in seconds.</param>
        /// <param name="fadeOutTime">How long to fade out the shake, in seconds.</param>
        /// <param name="posInfluence">How much this shake influences position.</param>
        /// <param name="rotInfluence">How much this shake influences rotation.</param>
        /// <returns>A CameraShakeInstance that can be used to alter the shake's properties.</returns>
        public CameraShakeInstance ShakeOnce(float magnitude, float roughness, float fadeInTime, float fadeOutTime, Vector3 posInfluence, Vector3 rotInfluence)
        {
            CameraShakeInstance shake = new CameraShakeInstance(magnitude, roughness, fadeInTime, fadeOutTime);
            shake.PositionInfluence = posInfluence;
            shake.RotationInfluence = rotInfluence;
            cameraShakeInstances.Add(shake);

            return shake;
        }

        /// <summary>
        /// Start shaking the camera.
        /// </summary>
        /// <param name="magnitude">The intensity of the shake.</param>
        /// <param name="roughness">Roughness of the shake. Lower values are smoother, higher values are more jarring.</param>
        /// <param name="fadeInTime">How long to fade in the shake, in seconds.</param>
        /// <returns>A CameraShakeInstance that can be used to alter the shake's properties.</returns>
        public CameraShakeInstance StartShake(float magnitude, float roughness, float fadeInTime)
        {
            CameraShakeInstance shake = new CameraShakeInstance(magnitude, roughness);
            shake.PositionInfluence = PositionalInfluence;
            shake.RotationInfluence = RotationalInfluence;
            shake.StartFadeIn(fadeInTime);
            cameraShakeInstances.Add(shake);
            return shake;
        }

        /// <summary>
        /// Start shaking the camera.
        /// </summary>
        /// <param name="magnitude">The intensity of the shake.</param>
        /// <param name="roughness">Roughness of the shake. Lower values are smoother, higher values are more jarring.</param>
        /// <param name="fadeInTime">How long to fade in the shake, in seconds.</param>
        /// <param name="posInfluence">How much this shake influences position.</param>
        /// <param name="rotInfluence">How much this shake influences rotation.</param>
        /// <returns>A CameraShakeInstance that can be used to alter the shake's properties.</returns>
        public CameraShakeInstance StartShake(float magnitude, float roughness, float fadeInTime, Vector3 posInfluence, Vector3 rotInfluence)
        {
            CameraShakeInstance shake = new CameraShakeInstance(magnitude, roughness);
            shake.PositionInfluence = posInfluence;
            shake.RotationInfluence = rotInfluence;
            shake.StartFadeIn(fadeInTime);
            cameraShakeInstances.Add(shake);
            return shake;
        }

        /// <summary>
        /// Gets a copy of the list of current camera shake instances.
        /// </summary>
        public List<CameraShakeInstance> ShakeInstances
        { get { return new List<CameraShakeInstance>(cameraShakeInstances); } }

        void OnDestroy()
        {
            instanceList.Remove(gameObject.name);
        }
    }
}