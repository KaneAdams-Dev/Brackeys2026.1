using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace KabejaDevTools
{
    [CustomEditor(typeof(BaseSO), true)]
    public class SOEntityEditor : Editor
    {
        private BaseSO Item => target as BaseSO;

        public override Texture2D RenderStaticPreview(string assetPath, Object[] subAssets, int width, int height) {
            if (Item.Icon != null) {
                Type t = GetType("UnityEditor.SpriteUtility");
                if (t != null) {
                    MethodInfo method = t.GetMethod("RenderStaticPreview", new[] { typeof(Sprite), typeof(Color), typeof(int), typeof(int) });
                    if (method != null) {
                        object ret = method.Invoke("RenderStaticPreview", new object[] { Item.Icon, Color.white, width, height });
                        if (ret is Texture2D) {
                            return ret as Texture2D;
                        }
                    }
                }
            }

            return base.RenderStaticPreview(assetPath, subAssets, width, height);
        }

        private static Type GetType(string a_typeName) {
            Type type = Type.GetType(a_typeName);
            if (type != null) {
                return type;
            }

            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            AssemblyName[] referencedAssemblies = currentAssembly.GetReferencedAssemblies();
            foreach (AssemblyName assemblyName in referencedAssemblies) {
                Assembly assembly = Assembly.Load(assemblyName);
                if (assembly != null) {
                    type = assembly.GetType(a_typeName);
                    if (type != null) {
                        return type;
                    }
                }
            }

            return null;
        }
    }
}
