using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using VRC.UI.Elements.Tooltips;

namespace emmVRC.Utils
{
	// Token: 0x02000027 RID: 39
	public class SimpleSingleButton
	{
		// Token: 0x0600012D RID: 301 RVA: 0x0000A218 File Offset: 0x00008418
		public SimpleSingleButton(Transform parent, string text, Action click, string tooltip)
		{
			this.gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.singleButtonBase, parent);
			this.buttonText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
			this.buttonText.text = text;
			this.buttonText.fontSize = 28f;
			this.buttonText.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, -25f, 0f);
			this.buttonButton = this.gameObject.GetComponentInChildren<Button>(true);
			this.buttonButton.onClick = new Button.ButtonClickedEvent();
			this.buttonButton.onClick.AddListener(click);
			this.buttonTooltip = this.gameObject.GetComponentInChildren<VRC.UI.Elements.Tooltips.UiTooltip>(true);
			this.buttonTooltip.field_Public_String_0 = tooltip;
			UnityEngine.Object.Destroy(this.gameObject.transform.Find("Icon").gameObject);
			UnityEngine.Object.Destroy(this.gameObject.transform.Find("Icon_Secondary").gameObject);
			this.buttonText.color = new Color(0.9f, 0.9f, 0.9f);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00002E46 File Offset: 0x00001046
		
		// Token: 0x0600012F RID: 303 RVA: 0x00002E58 File Offset: 0x00001058
		public SimpleSingleButton(ButtonGroup grp, string text, Action click, string tooltip) : this(grp.gameObject.transform, text, click, tooltip)
		{
		}



        // Token: 0x06000130 RID: 304 RVA: 0x00002E6F File Offset: 0x0000106F
        public void SetAction(Action newAction)
		{
			this.buttonButton.onClick = new Button.ButtonClickedEvent();
			this.buttonButton.onClick.AddListener(newAction);
		}

		// Token: 0x06000131 RID: 305 RVA: 0x00002E97 File Offset: 0x00001097
		public void SetText(string newText)
		{
			this.buttonText.text = newText;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00002EA5 File Offset: 0x000010A5
		public void SetTooltip(string newTooltip)
		{
			this.buttonTooltip.field_Public_String_0 = newTooltip;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00002EB3 File Offset: 0x000010B3
		public void SetInteractable(bool val)
		{
			this.buttonButton.interactable = val;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00002EC1 File Offset: 0x000010C1
		public void SetActive(bool state)
		{
			this.gameObject.SetActive(state);
		}

		// Token: 0x04000079 RID: 121
		private readonly TextMeshProUGUI buttonText;

		// Token: 0x0400007A RID: 122
		private readonly Button buttonButton;

		// Token: 0x0400007B RID: 123
		private readonly VRC.UI.Elements.Tooltips.UiTooltip buttonTooltip;

		// Token: 0x0400007C RID: 124
		public readonly GameObject gameObject;
        private ButtonGroup selectedUserGroup;
        private string v;
        private Action p;
    }
}
