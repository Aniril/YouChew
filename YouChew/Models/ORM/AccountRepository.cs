using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouChew.Models;

namespace YouChew.Models.ORM
{
	public class AccountRepository
	{
		UnitOfWork uow = new UnitOfWork();

		private const string MissingRole = "Role does not exist";
		private const string MissingUser = "User does not exist";
		private const string TooManyUser = "User already exists";
		private const string TooManyRole = "Role already exists";
		private const string AssignedRole = "Cannot delete a role with assigned users";

		public int NumberOfRoles { get { return uow.RoleRepository.Get().Count(); }}
		public int NumberOfUsers { get { return uow.UserRepository.Get().Count(); }}

		public User GetUser(Guid id)
		{
			return uow.UserRepository.GetByID(id);
		}

		public IEnumerable<User> GetUsersForRole(int id)
		{
			return uow.UserRepository.Get().Where(x => x.Role == id);
		}
		
		public IEnumerable<User> GetUsersForRole(string role)
		{
			IEnumerable<User> usersbyrole = new List<User>();
			var roles = uow.RoleRepository.Get().Where(x => x.name == role);
			if(roles.Any())
			{
				usersbyrole = uow.UserRepository.Get().Where(x => x.Role == roles.First().Id);
			}

			return usersbyrole;
		}

		private void AddUserToRole(User user,int id)
		{
			if(!UserExistsInRole(user, id))
			{
				uow.UserRepository.GetByID(user.Id).Role = id;
				uow.UserRepository.Update(user);
				uow.Save();
			}
		}

		public void CreateUser(User user)
		{
			if (string.IsNullOrEmpty(user.username.Trim()))
				throw new ArgumentException("User name provided is invalid. Please check the value again.");
			if (string.IsNullOrEmpty(user.password.Trim()))
				throw new ArgumentException("The password provided is invalid. Please enter a valid password value.");
			if(string.IsNullOrEmpty(user.email.Trim()))
                throw new ArgumentException("The e-mail address provided is invalid. Please check the value and try again.");
		}

		public bool UserExistsInRole(User user, int id)
		{
			User usertocheck = uow.UserRepository.GetByID(user.Id);

			return (usertocheck.Role == id);
		}
	}
}