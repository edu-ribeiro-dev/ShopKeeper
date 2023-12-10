using System.Collections.Generic;
using UnityEngine;

namespace Model.LayoutModel
{
	[CreateAssetMenu]
	public class ClothesStockModelSO : BaseModelSO
	{
		[field: SerializeField]
		public List<ClothesSO> HoodList { get; set; }
		
		[field: SerializeField]
		public List<ClothesSO> TorsoList { get; set; }
	}
}