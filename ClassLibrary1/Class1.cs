using System;
using System.Net.Mail;

namespace ClassLibrary1
{
	public enum Gender
	{
		Male,
		Female
	}

	public class Person
	{

		private string firstName;
		public string FirstName
		{
			get
			{
				return firstName;
			}
			set
			{
				if (string.IsNullOrEmpty(value) == false)
				{
					firstName = value;
				}
			}
		}
		public string LastName { get; private set; }

		public string EmailAddress { get; private set; }

		public DateTime BirthDate { get; private set; }

		// default value is first enum value
		public Gender Gender { get; private set; }

		public Person(string firstName, string lastName, DateTime birthDate, string email)
		{
			this.FirstName = firstName;
			this.LastName = lastName;
			this.BirthDate = birthDate;
			this.EmailAddress = email;
		}

	}



	public class Login
	{

		public bool IsValid(string emailaddress)
		{
			try
			{
				MailAddress m = new MailAddress(emailaddress);

				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}


		//public void PostMessage(string text, string username = null, string msgBox = null)
		//{





		//}



		//declare user and pass
		public string Username { get; set; }
		public string Userpassword { get; set; }

		//init 
		public Login(string user, string pass)
		{
			this.Username = user;
			this.Userpassword = pass;
		}
		//validate string 
		private bool StringValidator(string input)
		{
			string pattern = "[^a-zA-Z]";
			if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		//validate integer 
		private bool IntegerValidator(string input)
		{
			string pattern = "[^0-9]";
			if (System.Text.RegularExpressions.Regex.IsMatch(input, pattern))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		//clear user inputs 
		private void ClearTexts(string user, string pass)
		{
			user = String.Empty;
			pass = String.Empty;
		}
		//check user to see if eligible for auth/has account
		internal bool IsLoggedIn(string user, string pass)
		{
			//check user name empty 
			if (string.IsNullOrEmpty(user))
			{
				Console.WriteLine("Please enter your username!");
				return false;

			}
			//check user name is valid
			else if (StringValidator(user) == true)
			{
				Console.WriteLine("Only text input here!");
				ClearTexts(user, pass);
				return false;
			}
			//check user name is correct 
			else
			{
				if (Username != user)
				{
					Console.WriteLine("User name is incorrect!");
					ClearTexts(user, pass);
					return false;
				}
				//check password is empty 
				else
				{
					if (string.IsNullOrEmpty(pass))
					{
						Console.WriteLine("Enter the passowrd!");
						return false;
					}
					//check password is valid 
					else if (IntegerValidator(pass) == true)
					{
						Console.WriteLine("The password should contain only numbers!");
						return false;
					}
					//check password is correct 
					else if (Userpassword != pass)
					{
						Console.WriteLine("Password is incorrect");
						return false;
					}
					else
					{
						return true;
					}
				}
			}
		}
	}
}
