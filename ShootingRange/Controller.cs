﻿using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShootingRange {
	class Controller {
		public static byte MAX_SPEED = 100;
		public static float MAX_SPEED_VOLTAGE = 5.0f / 2;

		private static byte distance;
		private static byte targetDistance;
		private static byte speed;

		public static void Update() {
			distance = NIController.GetRotations();

			NIController.SetMotorControl(CalculateVrefVoltage());
		}

		public static void SetTargetDistance(byte distance) {
			targetDistance = distance;
		}

		public static void SetSpeed(byte speed) {
			Controller.speed = speed;
		}

		public static sbyte GetDirection() {
			if (distance == targetDistance) return 0;		//If distance is at target, then don't move
			else if (distance < targetDistance) return 1;	//If distance is less than target, then move forward (1)
			else return -1;									//If distance is greater than target, then move backwards (-1)
		}

		public static byte GetDistance() {
			return distance;
		}

		private static float CalculateVrefVoltage() {
			//direction * (speed in %) * (max voltage / 2) + (max voltage / 2)
			return 1.0f * GetDirection() * speed / MAX_SPEED * MAX_SPEED_VOLTAGE + MAX_SPEED_VOLTAGE;
		}

		public static void Initialize() {
			NIController.InitializeInstrument();
		}
	}
}
