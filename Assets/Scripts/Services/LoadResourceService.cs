using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace AssetLoad
{
    public sealed class LoadResourceService
    {
        private readonly Dictionary<string, Object> _resourceCached = new();

        private readonly Dictionary<string, ScriptableObject> _csvCached = new();

        #region API

        public T LoadCsv<T>() where T : ScriptableObject
        {
            var resourcePath = typeof(T).FullName;

            var asset = LoadAsset<T>(resourcePath);
            return asset;
        }


        public T LoadAsset<T>(string resourcePath) where T : Object
        {
            if (resourcePath == null)
                throw new ArgumentNullException(nameof(resourcePath));

            var asset = LoadResourceFromAddressable<T>(resourcePath);
            if (asset == null)
                asset = LoadResourceFromResource<T>(resourcePath);

            return asset;
        }

        #endregion

        #region Helper

        private T LoadResourceFromAddressable<T>(string resourcePath) where T : Object
        {
            if (resourcePath == null)
                throw new ArgumentNullException(nameof(resourcePath));

            if (_resourceCached.TryGetValue(resourcePath, out Object value))
            {
                return value as T;
            }

            try
            {
                var handler = Addressables.LoadAssetAsync<T>(resourcePath);
                handler.WaitForCompletion();

                var result = handler.Result;
                if (result == null)
                {
                    return null;
                }

                _resourceCached.TryAdd(resourcePath, result);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        private T LoadResourceFromResource<T>(string resourcePath) where T : Object
        {
            if (resourcePath == null)
                throw new ArgumentNullException(nameof(resourcePath));

            if (_resourceCached.TryGetValue(resourcePath, out Object value))
            {
                return value as T;
            }

            var result = Resources.Load<T>(resourcePath);
            if (result == null)
                return null;

            _resourceCached.TryAdd(resourcePath, result);
            return result;
        }

        public async UniTask PreloadCsv<T>() where T : ScriptableObject
        {
            var resourcePath = typeof(T).FullName;
            
            if (resourcePath == null)
                throw new ArgumentNullException(nameof(resourcePath));

            AsyncOperationHandle<T> loadHandle = Addressables.LoadAssetAsync<T>(resourcePath);

            var result = await loadHandle.ToUniTask();
            if (result == null)
                return;
            
            _resourceCached.TryAdd(resourcePath, result);
        }

        #endregion
    }
}