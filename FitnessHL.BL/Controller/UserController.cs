using FitnessHL.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessHL.BL.Controller
{
    /// <summary>
    /// Controller user.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User program.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Create new controller user.
        /// </summary>
        /// <param name="user"> User program. </param>
        public UserController(string userName, string genderName, DateTime birthData, double weight, double height)
        {
            // TODO
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthData, weight, height);       
        }

        /// <summary>
        /// Load data user.
        /// </summary>
        /// <returns> User program. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO
            }
        }

        /// <summary>
        /// Save data user.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
    }
}
