using System.Collections.Generic;
using Model.ScriptableObjects;
using UnityEngine;

namespace Model.LayoutModel
{
	[CreateAssetMenu]
	public class SkinStockModelSO : BaseModelSO
	{
		[field: SerializeField]
		public List<SkinSO> HoodList { get; set; }
		
		[field: SerializeField]
		public List<SkinSO> TorsoList { get; set; }
	}
}