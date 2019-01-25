using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ICKX {

	public abstract class ManagerBase<T> : MonoBehaviour where T : ManagerBase<T> {

		private static T s_instance = null;
		public static T instance {
			get {
				if (s_instance == null) {
					s_instance = new GameObject (typeof (T).Name).AddComponent<T> ();
					DontDestroyOnLoad (s_instance.gameObject);
					if (!s_instance.isInitialized) {
						s_instance.Initialize ();
					}
				}
				return s_instance;
			}
		}

		protected bool isInitialized = false;

		public virtual void Initialize () {
			isInitialized = true;
		}
	}
}