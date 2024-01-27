using UnityEngine;

namespace RegularDuck._Core.Helpers
{
	[DisallowMultipleComponent]
	public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		private static T _i;

		public static T I
		{
			get
			{
#if UNITY_EDITOR
				if (Application.isPlaying == false)
					if (_i == null)
						_i = (T) FindObjectOfType(typeof(T));
#endif
				return _i;
			}

			protected set { _i = value; }
		}

		protected virtual void Awake()
		{
			// If there is an instance, and it's not me, delete myself.
			if (I != null && I != this)
			{
				Destroy(this);
			}
			else
			{
				I = this as T;
			}
		}
	}
}