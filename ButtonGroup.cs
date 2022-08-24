using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace emmVRC.Utils
{
	// Token: 0x0200002F RID: 47
	public class ButtonGroup
	{
		// Token: 0x0600015A RID: 346 RVA: 0x0000A9A8 File Offset: 0x00008BA8
		public ButtonGroup(Transform parent, string text)
		{
			this.headerGameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.buttonGroupHeaderBase, parent);
			this.headerText = this.headerGameObject.GetComponentInChildren<TextMeshProUGUI>(true);
			this.headerText.text = text;
			this.gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.buttonGroupBase, parent);
			this.gameObject.transform.DestroyChildren();
			this.parentMenuMask = parent.parent.GetComponent<RectMask2D>();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00003073 File Offset: 0x00001273
		

		// Token: 0x0600015C RID: 348 RVA: 0x00003082 File Offset: 0x00001282
		public void SetText(string newText)
		{
			this.headerText.text = newText;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00003090 File Offset: 0x00001290
		public void Destroy()
		{
			UnityEngine.Object.Destroy(this.headerText.gameObject);
			UnityEngine.Object.Destroy(this.gameObject);
		}

		// Token: 0x0600015E RID: 350 RVA: 0x000030AD File Offset: 0x000012AD
		public void SetActive(bool state)
		{
			if (this.headerGameObject != null)
			{
				this.headerGameObject.SetActive(state);
			}
			this.gameObject.SetActive(state);
		}

		// Token: 0x04000098 RID: 152
		private readonly TextMeshProUGUI headerText;

		// Token: 0x04000099 RID: 153
		public readonly GameObject gameObject;

		// Token: 0x0400009A RID: 154
		private readonly GameObject headerGameObject;

		// Token: 0x0400009B RID: 155
		public readonly RectMask2D parentMenuMask;
	}
}
