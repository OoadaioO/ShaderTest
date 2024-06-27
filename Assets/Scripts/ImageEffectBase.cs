using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Camera))]
public class ImageEffectBase : MonoBehaviour {

    [SerializeField] protected Shader shader;

    protected Material material;


    protected void CheckResources() {
        bool isSupported = CheckSupport();
        if (isSupported == false) {
            NotSupported();
        } else {
            material = CreateMaterial(shader);
        }
    }

    protected void NotSupported() {
        enabled = false;
    }

    protected bool CheckSupport() {
        if (SystemInfo.supportsSparseTextures == false) {
            Debug.LogWarning("This platform does not support image effects or render textures");
            return false;
        }
        return true;
    }

    private void Start() {
        CheckResources();
    }


    protected Material CreateMaterial(Shader shader) {
        if (shader == null) {
            return null;
        }

        if (shader.isSupported && material && material.shader == shader) {
            return material;
        }
        if (!shader.isSupported) {
            return null;
        } else {
            Material material = new(shader);
            material.hideFlags = HideFlags.DontSave;
            return material;
        }
    }

    protected virtual void OnRenderImage(RenderTexture src, RenderTexture dest) {
        if (material) {
            Graphics.Blit(src, dest, material);
        }
    }


}
