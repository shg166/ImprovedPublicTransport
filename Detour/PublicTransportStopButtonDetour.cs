﻿using ColossalFramework;
using ColossalFramework.UI;
using ImprovedPublicTransport.Redirection.Attributes;
using UnityEngine;

namespace ImprovedPublicTransport.Detour
{
    [TargetType(typeof(PublicTransportStopButton))]
    public class PublicTransportStopButtonDetour
    {
        [RedirectMethod]
        private void OnMouseDown(UIComponent component, UIMouseEventParameter eventParam)
        {
            ushort objectUserData = (ushort)(component as UIButton).objectUserData;
            Vector3 position = Singleton<NetManager>.instance.m_nodes.m_buffer[(int)objectUserData].m_position;
            InstanceID empty = InstanceID.Empty;
            empty.NetNode = objectUserData;
            if ((Object)PublicTransportStopButton.cameraController != (Object)null)
                //begin mod: zoom on shift pressed
                ToolsModifierControl.cameraController.SetTarget(empty, position, Input.GetKey(KeyCode.LeftShift) | Input.GetKey(KeyCode.RightShift));
                //end mod

//TODO(earalov): restore?
//            PublicTransportWorldInfoPanel.ResetScrollPosition();
//            UIView.SetFocus((UIComponent)null);

            //begin mod: show PublicTransportStopWorldInfoPanel
            PublicTransportStopWorldInfoPanel.instance.Show(position, empty);
            //end mod
        }
    }
}