using System;
using UnityEngine;

namespace Model.ScriptableObjects
{
	[CreateAssetMenu]
	public class SkinSO : ScriptableObject
	{
		[field: SerializeField]
		public Sprite Sprite { get; set; }

		public Guid Id { get; }

		public SkinSO()
		{
			Id = new Guid();
		}
	}
}