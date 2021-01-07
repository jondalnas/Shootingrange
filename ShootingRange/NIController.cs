﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NationalInstruments.DAQmx;

namespace ShootingRange {
	class NIController {
		private static NationalInstruments.DAQmx.Task motorLoadTask;
		private static NationalInstruments.DAQmx.Task motorControlTask;
		private static NationalInstruments.DAQmx.Task motorRotationsTask;
		private static AIChannel motorLoadChannel;
		private static AOChannel motorControlChannel;
		private static DOChannel motorRotationsChannel;

		public static void InitializeInstrument() {
			//Initializing Task
			motorLoadTask = new Task();
			motorControlTask = new Task();
			motorRotationsTask = new Task();

			//Initializing channels
			//Voltage analog in
			motorLoadChannel = motorLoadTask.AIChannels.CreateVoltageChannel("dev1/ai0", "Motor Load Channel", AITerminalConfiguration.Rse, 0, 10, AIVoltageUnits.Volts);

			//Voltage analog out
			motorControlChannel = motorControlTask.AOChannels.CreateVoltageChannel("dev1/ao0", "Motor Control Channel", -10, 10, AOVoltageUnits.Volts);

			//Voltage digital in
			motorRotationsChannel = motorRotationsTask.DOChannels.CreateChannel("dev1/port0", "Motor Rotation Channel", ChannelLineGrouping.OneChannelForAllLines);
		}

		public static void SetMotorControl(double voltage) {
			WriteAnalog(motorControlTask, voltage);
		}

		public static double GetMotorLoad() {
			return ReadAnalog(motorLoadTask);
		}

		public static byte GetRotations() {
			return ReadDigital(motorRotationsTask);
		}

		private static double ReadAnalog(Task task) {
			AnalogSingleChannelReader reader = new AnalogSingleChannelReader(task.Stream);
			double sample = reader.ReadSingleSample();
			return sample;
		}

		public static byte ReadDigital(Task task) {
			DigitalSingleChannelReader reader = new DigitalSingleChannelReader(task.Stream);
			byte sample = reader.ReadSingleSamplePortByte();
			return sample;
		}

		private static void WriteAnalog(Task task, double voltage) {
			AnalogSingleChannelWriter write = new AnalogSingleChannelWriter(task.Stream);
			write.BeginWriteSingleSample(true, voltage, null, null);
		}

		private static void WriteDigital(Task task, byte data) {
			//Convert byte into bool array
			bool[] boolData = new bool[sizeof(byte)];
			for (var i = 0; i < sizeof(byte); i++) {
				boolData[i] = (data & 1) == 1;
				data >>= 1;
			}

			WriteDigital(task, boolData);
		}

		private static void WriteDigital(Task task, bool[] data) {
			DigitalSingleChannelWriter write = new DigitalSingleChannelWriter(task.Stream);
			write.BeginWriteSingleSampleMultiLine(true, data, null, null);
		}

		public static void Dispose() {
			motorControlChannel.Dispose();
			motorLoadChannel.Dispose();
			motorRotationsChannel.Dispose();
			motorControlTask.Dispose();
			motorLoadTask.Dispose();
			motorRotationsTask.Dispose();
		}
	}
}
