using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Data;

namespace KomMee
{
    public class SIM
    {
        public static SIM simInstance = null;
        private SerialPort port = null;
        private string dataToRecieve = string.Empty;

        private SIM(string pPortName, int pBaudRate, string pParity, int pDataBits, string pStopBits, string pPin)
        {
            Parity parity;
            StopBits stopBits;
            switch (pParity)
            {
                case "None":
                    parity = Parity.None;
                    break;
                case "Odd":
                    parity = Parity.Odd;
                    break;
                case "Even":
                    parity = Parity.Even;
                    break;
                case "Mark":
                    parity = Parity.Mark;
                    break;
                case "Space":
                    parity = Parity.Space;
                    break;
                default:
                    throw new Exception("Unknown Parity!");                 
            }
            switch(pStopBits)
            {
                case "None":
                    stopBits = StopBits.None;
                    break;
                case "One":
                    stopBits = StopBits.One;
                    break;
                case "Two":
                    stopBits = StopBits.Two;
                    break;
                case "OnePointFive":
                    stopBits = StopBits.OnePointFive;
                    break;
                default:
                    throw new Exception("Unknown StopBits");
            }
            this.port = new SerialPort(pPortName, pBaudRate, parity, pDataBits, stopBits);
            port.Open();

            port.DiscardOutBuffer();
            port.DiscardInBuffer();

            if (this.executeATCommand("AT", 300).Contains("OK"))
            {
                string phoneUnlocked = this.executeATCommand(("AT+CPIN=" + pPin), 300);
                if(phoneUnlocked.Contains("CME ERROR: incorrect password"))
                {
                    throw new Exception("Phone still locked. Wrong PIN!");
                }
            }
            else
            {
                throw new Exception("Phone not connected or AT-Commands not allowed.");
            }


        }

        public static SIM getInstance()
        {
            if (SIM.simInstance == null)
            {
                //string portName, parity, stopBits, pin;
                //int baudRate, dataBits;

                /*portName = Settings.getValue("simPortName");
                parity = Settings.getValue("simParity");
                stopBits = Settings.getValue("simStopBits");
                baudRate = Convert.ToInt32(Settings.getValue("simBaudRate"));
                dataBits = Convert.ToInt32(Settings.getValue("simDataBits"));
                pin = Settings.getValue("simPin");
                SIM.simInstance = new SIM(portName, baudRate, parity, dataBits, stopBits, pin);*/
                SIM.simInstance = new SIM("COM256", 9600, "None", 8, "One", "9876");
            }
            return SIM.simInstance;
        }

        private string executeATCommand(string command, int timeout)
        {
            this.port.Write(command + Environment.NewLine);
            Thread.Sleep(timeout);
            string readMessage = this.port.ReadExisting();
            return readMessage;
        }

        public bool sendMessage(string receiverNumber, string message)
        {
            this.executeATCommand("AT+CMGF=1", 300);
            if (this.executeATCommand("AT+CMGS=\"" + receiverNumber + "\"", 300).EndsWith("> "))
            {
                if(this.executeATCommand(message + char.ConvertFromUtf32(26), 3000).EndsWith("OK\r\n"))
                {
                    return true;
                }
            }
            return false;
        }

        public DataTable readMessages()
        {
            this.executeATCommand("AT+CMGF=1", 300);
            string unreadMessages = this.executeATCommand("AT+CMGL=\"REC UNREAD\"", 3000);
            List<string> extractedMessages = this.extractMessages(unreadMessages);
            DataTable messages = this.parseMessages(extractedMessages);
            return messages;
        }

        private List<string> extractMessages(string messageString)
        {
            messageString = messageString.Replace("\r", "");
            string[] withoutLineFeeds = messageString.Split('\n');
            List<string> extractedMessages = new List<string>();
            foreach (string item in withoutLineFeeds)
            {
                extractedMessages.Add(item);
            }

            extractedMessages.RemoveAt(0);
            extractedMessages.RemoveAt(extractedMessages.Count - 1);
            extractedMessages.RemoveAt(extractedMessages.Count - 1);
            bool abort = extractedMessages.Count > 0 ? false : true;
            while (!abort)
            {
                if (extractedMessages[extractedMessages.Count - 1] == "")
                {
                    extractedMessages.RemoveAt(extractedMessages.Count - 1);
                }
                else
                {
                    abort = true;
                }
            }

            int index = 0;
            while (extractedMessages.Count > index)
            {
                if (extractedMessages[index].StartsWith("+CMGL: "))
                {
                    index++;
                }
                else
                {
                    extractedMessages[index - 1] += extractedMessages[index];
                    extractedMessages.RemoveAt(index);
                }
            }


            return extractedMessages;
        }

        private DataTable parseMessages(List<string> extractedMessages)
        {
            DataTable messages = new DataTable("Messages");
            messages.Columns.Add("sender", typeof(string));
            messages.Columns.Add("receiveTime", typeof(string));
            messages.Columns.Add("message", typeof(string));

            foreach (string messageString in extractedMessages)
            {
                DataRow row = messages.NewRow();
                string[] splittedMessageString = messageString.Split(',');
                row["sender"] = parseSenderNumber(splittedMessageString[2]);
                row["receiveTime"] = parseReceiveTime(splittedMessageString[4], splittedMessageString[5]);
                row["message"] = splittedMessageString[6];
                messages.Rows.Add(row);
            }

            return messages;
        }

        private string parseSenderNumber(string unparsedNumber)
        {
            string parsedNumber = string.Empty;
            unparsedNumber = unparsedNumber.Replace("\"", "");
            if (unparsedNumber.StartsWith("+49"))
            {
                parsedNumber = unparsedNumber.Replace("+49", "0");
            }
            else if (unparsedNumber.StartsWith("0049"))
            {
                parsedNumber = unparsedNumber.Replace("0049", "0");
            }
            else
            {
                parsedNumber = unparsedNumber;
            }

            return parsedNumber;
        }

        private string parseReceiveTime(string unparsedReceiveDate, string unparsedReceiveTime)
        {
            string parsedReceiveTime = string.Empty;
            unparsedReceiveDate = unparsedReceiveDate.Replace("\"", "");
            unparsedReceiveTime = unparsedReceiveTime.Replace("\"", "");
            unparsedReceiveTime = unparsedReceiveTime.Remove(5);
            string[] splittedReceiveDate = unparsedReceiveDate.Split('/');
            string[] splittedReceiveTime = unparsedReceiveTime.Split(':');

            parsedReceiveTime = splittedReceiveDate[2] + "-" +
                                splittedReceiveDate[1] + "-20" +
                                splittedReceiveDate[0] + " " +
                                splittedReceiveTime[0] + ":" +
                                splittedReceiveTime[1];

            return parsedReceiveTime;
        }
    }
}
