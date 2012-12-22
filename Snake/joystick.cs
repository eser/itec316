﻿/*
 * Created by SharpDevelop.
 * User: garnett
 * Date: 12.12.2010
 * Time: 15:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using Microsoft.DirectX.DirectInput;

namespace Snake
{
	/// <summary>
	/// Description of device.
	/// </summary>
	class joysticks
	{
		
		public static Device joystick;
		public static JoystickState state;
		
		public static void InitDevices()     //Function of initialize device
		{	
			//create joystick device.
			foreach (DeviceInstance di in Manager.GetDevices(
				DeviceClass.GameControl,
				EnumDevicesFlags.AttachedOnly))
			{
				joystick = new Device(di.InstanceGuid);
				break;
			}
			if (joystick == null)
			{
				//Throw exception if joystick not found.
			}
			//Set joystick axis ranges.
			else {
				foreach (DeviceObjectInstance doi in joystick.Objects)
				{
					if ((doi.ObjectId & (int)DeviceObjectTypeFlags.Axis) != 0)
					{
						joystick.Properties.SetRange(
							ParameterHow.ById,
							doi.ObjectId,
							new InputRange(-5000, 5000));
					}
					
				}
				joystick.Properties.AxisModeAbsolute = true;
				
				joystick.SetCooperativeLevel(null,CooperativeLevelFlags.NonExclusive | CooperativeLevelFlags.Background);
				//Acquire devices for capturing.
				joystick.Acquire();
				state = joystick.CurrentJoystickState;
			}
		}
		
		
		
		public static void UpdateJoystick()   // Capturing from device joystick
		{
			//Get Joystick State.
			if(joystick!=null)
				state = joystick.CurrentJoystickState;
		}
		
		/*public static byte[] deneme()
        {
        	byte[] jsButtons = state.GetButtons();
            buttons = new bool[jsButtons.Length];

            int i = 0;
            foreach (byte button in jsButtons)
            {
                buttons[i] = button >= 128;
                i++;
            }
            
           return jsButtons;
        }*/
		
		
		
		
		

	}
}
