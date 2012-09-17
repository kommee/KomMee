using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace KomMee
{
	public static class Input
	{
		private static Dictionary<int, string> keymapping;
		private static MenuState menuState;
		private static View view;
		private static IViewContainer currentIViewContaier;
		private static Message message;

		public static MenuState MenuState
		{
			get { return Input.menuState; }
		}

		public static void init(View view)
		{
			Input.view = view;
			Input.keymapping = new Dictionary<int, string>();
			Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Up")), "Keymapping_Up");
			Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Down")), "Keymapping_Down");
			Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Left")), "Keymapping_Left");
			Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Right")), "Keymapping_Right");
			Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Apply")), "Keymapping_Apply");
			Input.keymapping.Add(Convert.ToInt16(Settings.getValue("Keymapping_Cancel")), "Keymapping_Cancel");
			Input.menuState = MenuState.ViewMessage;
		}

		public static void showMessage(Message message)
		{
			Input.currentIViewContaier = message.ViewContainer;
			Input.currentIViewContaier.createViewForReading(Input.view.MessageViewContainer);
		}

		public static void setNewMenuState(MenuState menuState)
		{
			switch (menuState)
			{
				case MenuState.None:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { KeyboardButtons.ApplicationClose, KeyboardButtons.MenuContactDelete, KeyboardButtons.MenuContactEdit,
						KeyboardButtons.MenuContactNew, KeyboardButtons.MenuMessageNew, KeyboardButtons.MenuMessageRecv, KeyboardButtons.MenuMessageSent});
					break;
				case MenuState.ViewMessage:
                    SMSMessage.receive();
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
					MessageList messageList = MessageList.getInstance();
					Input.view.UpperLeftControl.DataSource = messageList.getDatasource();
					Input.view.UpperLeftControl.ValueMember = "MessageID";
					Input.view.UpperLeftControl.DisplayMember = "Name";
					Input.clearViewContainer();
					Input.currentIViewContaier = new SMSViewContainer();
					Input.currentIViewContaier.createViewForReading(Input.view.MessageViewContainer);
					MessageList messages = MessageList.getInstance();
					Input.currentIViewContaier.setReadInput(messages[0].Text);
					Input.view.UpperLeftControl.LbChoice.BackColor = Color.MistyRose;
					break;
				case MenuState.AnswerMessage:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
					Input.currentIViewContaier.createViewForAnswer(Input.view.MessageViewContainer);
					break;
				case MenuState.DeleteMessage:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
					messageList = MessageList.getInstance();
					Input.view.UpperLeftControl.DataSource = messageList.getDatasource();
					Input.view.UpperLeftControl.ValueMember = "MessageID";
					Input.view.UpperLeftControl.DisplayMember = "Name";
					break;
				case MenuState.NewMessage:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { KeyboardButtons.AlphaA, KeyboardButtons.AlphaB, KeyboardButtons.AlphaC, KeyboardButtons.AlphaD, 
					KeyboardButtons.AlphaE, KeyboardButtons.AlphaF, KeyboardButtons.AlphaG, KeyboardButtons.AlphaH, KeyboardButtons.AlphaI, KeyboardButtons.AlphaJ, KeyboardButtons.AlphaK, 
					KeyboardButtons.AlphaL, KeyboardButtons.AlphaM, KeyboardButtons.AlphaN, KeyboardButtons.AlphaO, KeyboardButtons.AlphaP, KeyboardButtons.AlphaQ, KeyboardButtons.AlphaR, 
					KeyboardButtons.AlphaS, KeyboardButtons.AlphaT, KeyboardButtons.AlphaU, KeyboardButtons.AlphaV, KeyboardButtons.AlphaW, KeyboardButtons.AlphaX, KeyboardButtons.AlphaY, 
					KeyboardButtons.AlphaZ, KeyboardButtons.NumericZero, KeyboardButtons.NumericOne, KeyboardButtons.NumericTwo, KeyboardButtons.NumericThree, KeyboardButtons.NumericFour, 
					KeyboardButtons.NumericFive, KeyboardButtons.NumericSix, KeyboardButtons.NumericSeven, KeyboardButtons.NumericEight, KeyboardButtons.NumericNine, KeyboardButtons.PunctationComma,
					KeyboardButtons.PunctationDot, KeyboardButtons.PunctationExclamation, KeyboardButtons.PunctationQuestion, KeyboardButtons.SpecialCharAt, KeyboardButtons.SpecialCharAt,
					KeyboardButtons.SpecialCharBackspace,KeyboardButtons.SpecialCharReturn,KeyboardButtons.SpecialCharSpace,KeyboardButtons.TextSend, KeyboardButtons.UmlautA, 
					KeyboardButtons.UmlautO, KeyboardButtons.UmlautU, KeyboardButtons.UmlautS,});
					Input.clearViewContainer();
					Input.currentIViewContaier = new SMSViewContainer();
					Input.currentIViewContaier.createViewForNew(Input.view.MessageViewContainer);
					break;
				case MenuState.ChoseReceiver:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
					AddressBook addressBook = AddressBook.getInstance();
					Input.view.UpperLeftControl.DataSource = addressBook.getDatasource();
					Input.view.UpperLeftControl.ValueMember = "ContactID";
					Input.view.UpperLeftControl.DisplayMember = "Name";
					Input.view.UpperLeftControl.LbChoice.BackColor = Color.MistyRose;
					break;
				case MenuState.ChoseMessageType:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
					break;
				case MenuState.AddNewContact:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { KeyboardButtons.AlphaA, KeyboardButtons.AlphaB, KeyboardButtons.AlphaC, KeyboardButtons.AlphaD, 
					KeyboardButtons.AlphaE, KeyboardButtons.AlphaF, KeyboardButtons.AlphaG, KeyboardButtons.AlphaH, KeyboardButtons.AlphaI, KeyboardButtons.AlphaJ, KeyboardButtons.AlphaK, 
					KeyboardButtons.AlphaL, KeyboardButtons.AlphaM, KeyboardButtons.AlphaN, KeyboardButtons.AlphaO, KeyboardButtons.AlphaP, KeyboardButtons.AlphaQ, KeyboardButtons.AlphaR, 
					KeyboardButtons.AlphaS, KeyboardButtons.AlphaT, KeyboardButtons.AlphaU, KeyboardButtons.AlphaV, KeyboardButtons.AlphaW, KeyboardButtons.AlphaX, KeyboardButtons.AlphaY, 
					KeyboardButtons.AlphaZ, KeyboardButtons.NumericZero, KeyboardButtons.NumericOne, KeyboardButtons.NumericTwo, KeyboardButtons.NumericThree, KeyboardButtons.NumericFour, 
					KeyboardButtons.NumericFive, KeyboardButtons.NumericSix, KeyboardButtons.NumericSeven, KeyboardButtons.NumericEight, KeyboardButtons.NumericNine, KeyboardButtons.PunctationComma,
					KeyboardButtons.PunctationDot, KeyboardButtons.PunctationExclamation, KeyboardButtons.PunctationQuestion, KeyboardButtons.SpecialCharAt, KeyboardButtons.SpecialCharAt,
					KeyboardButtons.SpecialCharBackspace,KeyboardButtons.SpecialCharReturn,KeyboardButtons.SpecialCharSpace, KeyboardButtons.UmlautA, 
					KeyboardButtons.UmlautO, KeyboardButtons.UmlautU, KeyboardButtons.UmlautS, });
					Input.clearViewContainer();
					Input.currentIViewContaier = new ContactViewContainer();
					Input.currentIViewContaier.createViewForNew(Input.view.MessageViewContainer);
					break;
				case MenuState.EditContact:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
					addressBook = AddressBook.getInstance();
					Input.view.UpperLeftControl.DataSource = addressBook.getDatasource();
					Input.view.UpperLeftControl.ValueMember = "MessageID";
					Input.view.UpperLeftControl.DisplayMember = "Name";
					Input.view.UpperLeftControl.LbChoice.BackColor = Color.MistyRose;
					break;
				case MenuState.DeleteContact:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
					addressBook = AddressBook.getInstance();
					Input.view.UpperLeftControl.DataSource = addressBook.getDatasource();
					Input.view.UpperLeftControl.ValueMember = "ContactID";
					Input.view.UpperLeftControl.DisplayMember = "Name";
					Input.view.UpperLeftControl.LbChoice.BackColor = Color.MistyRose;
					break;
				case MenuState.AddMessageTypeToContact:
					Input.view.KeyboardView.setAllowedButtons(new KeyboardButtons[] { });
					break;
				default:
					break;
			}
			Input.menuState = menuState;
		}

		public static void clearViewContainer()
		{
			Panel MessageViewContainer = Input.view.MessageViewContainer;
			while (MessageViewContainer.Controls.Count > 0)
			{
				Control ctrl = MessageViewContainer.Controls[0];
				MessageViewContainer.Controls.Remove(ctrl);
				ctrl.Dispose();
			}
			MessageViewContainer.Refresh();
		}

		public static void userInputUp()
		{
			Console.WriteLine("Input: Up-Event");
			if (Input.MenuState == KomMee.MenuState.ViewMessage)
			{
				int index = view.UpperLeftControl.up();
				MessageList messages = MessageList.getInstance();
				Input.currentIViewContaier.setReadInput(messages[index].Text);
			}
			else if (Input.MenuState == KomMee.MenuState.ChoseReceiver || Input.MenuState == KomMee.MenuState.DeleteContact)
			{
				view.UpperLeftControl.up();
			}
			else
				view.KeyboardView.up();
		}

		public static void userInputDown()
		{
			Console.WriteLine("Input: Down-Event");
			if (Input.MenuState == KomMee.MenuState.ViewMessage)
			{
				int index = view.UpperLeftControl.down();
				MessageList messages = MessageList.getInstance();
				Input.currentIViewContaier.setReadInput(messages[index].Text);
			}
			else if (Input.MenuState == KomMee.MenuState.ChoseReceiver || Input.MenuState == KomMee.MenuState.DeleteContact)
			{
				view.UpperLeftControl.down();
			}
			
			else
				view.KeyboardView.down();
		}

		public static void userInputLeft()
		{
			Console.WriteLine("Input: Left-Event");
			view.KeyboardView.left();
		}

		public static void userInputRight()
		{
			Console.WriteLine("Input: Right-Event");
			view.KeyboardView.right();
		}

		public static void userInputApply()
		{
			Console.WriteLine("Input: Apply-Event");
			AddressBook addressbook = null;
			int index, id;
			switch (Input.menuState)
			{
				case MenuState.None:
				case MenuState.NewMessage:
				case MenuState.AddNewContact:
					view.KeyboardView.apply();
					break;
				case MenuState.ChoseReceiver:
					index = view.UpperLeftControl.apply();
					addressbook = AddressBook.getInstance();
					id = (int)addressbook.getDatasource().Rows[index]["ContactID"];
					Input.message.Contact = addressbook.ListOfContacts[id];
					List<string> list = new List<string>(addressbook.ListOfContacts[id].ContactTypes.Keys);
					Input.message.Sender = list[0];
					if (!Input.message.send())
					{
						System.Windows.Forms.MessageBox.Show("FEHLER!");
					}
					Input.view.UpperLeftControl.LbChoice.BackColor = Color.White;
					Input.view.UpperLeftControl.DataSource = null;
					Input.view.UpperLeftControl.ValueMember = "";
					Input.view.UpperLeftControl.DisplayMember = "";
					Input.clearViewContainer();
					Input.setNewMenuState(MenuState.None);
					break;
				case MenuState.ViewMessage:
					// Do Nothing
					break;
				case MenuState.DeleteContact:
					addressbook = AddressBook.getInstance();
					DataTable dt = (DataTable)Input.view.UpperLeftControl.DataSource;
					index = view.UpperLeftControl.apply();
					id = (int)dt.Rows[index]["ContactID"];
					addressbook.removeContact(id);

					Input.view.UpperLeftControl.DataSource = null;
					Input.view.UpperLeftControl.ValueMember = "";
					Input.view.UpperLeftControl.DisplayMember = "";
					Input.setNewMenuState(MenuState.None);
					break;
				case MenuState.AnswerMessage:
				case MenuState.DeleteMessage:
				case MenuState.ChoseMessageType:
				case MenuState.EditContact:
				case MenuState.AddMessageTypeToContact:
					Input.setNewMenuState(MenuState.None);
					break;
				default:
					break;
			}
		}

		public static void userInputCancel()
		{
			Console.WriteLine("Input: Cancel-Event");
			switch (Input.menuState)
			{
				case MenuState.None:
					break;
				case MenuState.ViewMessage:
				case MenuState.DeleteContact:
					Input.view.UpperLeftControl.DataSource = null;
					Input.view.UpperLeftControl.ValueMember = "";
					Input.view.UpperLeftControl.DisplayMember = "";
					Input.clearViewContainer();
					Input.view.UpperLeftControl.LbChoice.BackColor = Color.White;
					Input.setNewMenuState(MenuState.None);
					break;
				case MenuState.NewMessage:
					Input.clearViewContainer();
					Input.setNewMenuState(MenuState.None);
					break;
				case MenuState.ChoseReceiver:
					Input.view.UpperLeftControl.LbChoice.BackColor = Color.White;
					Input.clearViewContainer();
					Input.setNewMenuState(MenuState.None);
					break;
				case MenuState.AddNewContact:
					if (((ContactViewContainer)Input.currentIViewContaier).cancel())
					{
						Input.clearViewContainer();
						Input.setNewMenuState(MenuState.None);
					}
					break;
				case MenuState.AnswerMessage:
				case MenuState.DeleteMessage:
				case MenuState.ChoseMessageType:
				case MenuState.EditContact:
				case MenuState.AddMessageTypeToContact:
					Input.setNewMenuState(MenuState.None);
					break;
				default:
					break;
			}
		}

		public static void handleUserInput(int keyValue)
		{
			if (Input.keymapping.ContainsKey(keyValue))
			{
				string keymappingValue = Input.keymapping[keyValue];
				switch (keymappingValue)
				{
					case "Keymapping_Up":
						Input.userInputUp();
						break;
					case "Keymapping_Down":
						Input.userInputDown();
						break;
					case "Keymapping_Left":
						Input.userInputLeft();
						break;
					case "Keymapping_Right":
						Input.userInputRight();
						break;
					case "Keymapping_Apply":
						Input.userInputApply();
						break;
					case "Keymapping_Cancel":
						Input.userInputCancel();
						break;
					default:
						break;
				}
			}
		}

		internal static void handleKeyboardEvent(KeyboardViewEventArgs keyboardViewEventArgs)
		{
			switch (Input.MenuState)
			{
				case MenuState.None:
					switch (keyboardViewEventArgs.Value)
					{
						case KeyboardButtons.MenuMessageNew:
							Input.setNewMenuState(MenuState.NewMessage);
							break;
						case KeyboardButtons.MenuMessageRecv:
							Input.setNewMenuState(MenuState.ViewMessage);
							break;
						case KeyboardButtons.MenuContactNew:
							Input.setNewMenuState(MenuState.AddNewContact);
							break;
						case KeyboardButtons.MenuContactEdit:
							Input.setNewMenuState(MenuState.EditContact);
							break;
						case KeyboardButtons.MenuContactDelete:
							Input.setNewMenuState(MenuState.DeleteContact);
							break;
						case KeyboardButtons.ApplicationClose:
							Application.Exit();
							break;
					}
					break;
				case MenuState.ViewMessage:
					break;
				case MenuState.AnswerMessage:
					break;
				case MenuState.DeleteMessage:
					break;
				case MenuState.NewMessage:
					if (keyboardViewEventArgs.Value == KeyboardButtons.TextSend)
					{
						object data = Input.currentIViewContaier.getData();
						Input.message = new SMSMessage(data);
						((SMSViewContainer)(Input.currentIViewContaier)).setColor(Color.White);
						Input.setNewMenuState(MenuState.ChoseReceiver);
					}
					else
						Input.currentIViewContaier.addWriteInput(keyboardViewEventArgs);
					break;
				case MenuState.ChoseReceiver:
					break;
				case MenuState.ChoseMessageType:
					break;
				case MenuState.AddNewContact:
					if (keyboardViewEventArgs.Value == KeyboardButtons.SpecialCharReturn)
					{
						if (((ContactViewContainer)Input.currentIViewContaier).apply())
						{
							String[] data = (String[])Input.currentIViewContaier.getData();
							String firstname, lastname, phonenumber;
							firstname = data[0];
							lastname= data[1];
							phonenumber = data[2];

							Contact newContact = new Contact(firstname, lastname);
							SMSAddress newAddress = new SMSAddress(phonenumber);
							newContact.ContactTypes.Add(phonenumber, newAddress);
							newContact.DefaultAddress = newAddress;
							newContact.saveContact();
                            AddressBook addressBook = AddressBook.getInstance();
                            addressBook.addContact(newContact);

							Input.clearViewContainer();
							Input.setNewMenuState(MenuState.None);
						}
					}
					else
						Input.currentIViewContaier.addWriteInput(keyboardViewEventArgs);
					break;
				case MenuState.EditContact:
					break;
				case MenuState.DeleteContact:
					break;
				case MenuState.AddMessageTypeToContact:
					break;
				default:
					break;
			}
		}
	}
}
