using System;
using UnityEngine;

namespace Controller
{
	public abstract class BaseController : MonoBehaviour
	{
		private bool IsInitialized { get; set; }

		protected void SetInitialized()
		{
			IsInitialized = true;
		}
		
		protected bool CheckInitialized()
		{
			if (!IsInitialized)
				throw new InvalidOperationException(
					$"Trying to use controller {gameObject.name} functionality without initializing it");

			return true;
		}
	}
}