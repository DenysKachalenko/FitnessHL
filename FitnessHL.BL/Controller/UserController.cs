using FitnessHL.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessHL.BL.Controller
{
    /// <summary>
    /// Controller user.
    /// </summary>
    public class UserController : ControllerBass
    {
        /// <summary>
        /// List Users program.
        /// </summary>
        public List<User> Users { get; }
        /// <summary>
        /// Active user program.
        /// </summary>
        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Create new controller user.
        /// </summary>
        /// <param name="user"> User program. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Null or empty!", nameof(userName));
            }

            Users = GetUserData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1 )
        {
            //Test

            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Load saved list user.
        /// </summary>
        /// <returns> User program. </returns>
        private List<User> GetUserData()
        {
            return Load<User>() ?? new List<User>();          
        }

        /// <summary>
        /// Save data user.
        /// </summary>
        public void Save()
        {
            Save<User>(Users);
        }
    }
}
