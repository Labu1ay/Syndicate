using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

    public static class Messenger 
    {
        public delegate void BroadcastBundleHandler(Bundle bundle);
        public delegate void BroadcastHandler();

        private static SortedList<string, BroadcastHandler> BROADCAST_HANDLERS = new SortedList<string, BroadcastHandler>();
        private static SortedList<string, BroadcastBundleHandler> BROADCAST_BUNDLE_HANDLERS = new SortedList<string, BroadcastBundleHandler>();
        private static readonly Bundle EMPTY_BUNDLE = new Bundle();

        public static void AddListener(string eventType, BroadcastHandler callback) {
            if (!BROADCAST_HANDLERS.ContainsKey(eventType)) {
                BROADCAST_HANDLERS.Add(eventType, null);
            }
            BROADCAST_HANDLERS[eventType] += callback;
        }

        public static void AddListener(string eventType, BroadcastBundleHandler callback) {
            if (!BROADCAST_BUNDLE_HANDLERS.ContainsKey(eventType)) {
                BROADCAST_BUNDLE_HANDLERS.Add(eventType, null);
            }
            BROADCAST_BUNDLE_HANDLERS[eventType] += callback;
        }

        public static void RemoveListener(string eventType, BroadcastHandler callback) {
            if (BROADCAST_HANDLERS.ContainsKey(eventType)) {
                BROADCAST_HANDLERS[eventType] -= callback;
                if (BROADCAST_HANDLERS[eventType] == null) {
                    BROADCAST_HANDLERS.Remove(eventType);
                }
            }
        }

        public static void RemoveListener(string eventType, BroadcastBundleHandler callback) {
            if (callback != null) BROADCAST_BUNDLE_HANDLERS[eventType] -= callback;
            if (BROADCAST_BUNDLE_HANDLERS[eventType] == null) {
                BROADCAST_BUNDLE_HANDLERS.Remove(eventType);
            }
        }
        
        public static void Broadcast(string eventType, Bundle? bundle = null)
        { 
            if(BROADCAST_HANDLERS.TryGetValue(eventType, out var broadcastHandler))
                broadcastHandler();
            
            if (BROADCAST_BUNDLE_HANDLERS.TryGetValue(eventType, out var broadcastBundleHandler))
                broadcastBundleHandler(bundle ?? EMPTY_BUNDLE);
        }
    }

    public struct Bundle
    {
        private Dictionary<string, object> _data;

        public T Get<T>(string key)
        {
            InitData();
            return (T) (_data.ContainsKey(key) ? _data[key] : default(T));
        }

        private void InitData()
        {
            if(_data == null)
                _data = new Dictionary<string, object>();
        }

        public Bundle Set(string key, object value)
        {
            InitData();
            _data[key] = value;
            return this;
        }
        
        public void Clear()
        {
            _data?.Clear();
        }
    }
