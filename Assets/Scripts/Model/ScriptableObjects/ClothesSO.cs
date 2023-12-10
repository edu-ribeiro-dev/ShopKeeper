using System;
using UnityEngine;

namespace Model
{
	[CreateAssetMenu]
	public class ClothesSO : ScriptableObject
	{
		[field: SerializeField]
		public Sprite Sprite { get; set; }

		public Guid Id { get; }

		public ClothesSO()
		{
			Id = new Guid();
		}
	}
}