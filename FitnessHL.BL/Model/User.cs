using System;

namespace FitnessHL.BL.Model
{
    /// <summary>
    /// User.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Properties
        /// <summary>
        /// Name user.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender user.
        /// </summary>
        public Gender Gender { get; }
        /// <summary>
        /// Birth date user.
        /// </summary>
        public DateTime BirthDate { get; }
        /// <summary>
        /// Weight user.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Growth user.
        /// </summary>
        public double Height { get; set; }
        #endregion

        /// <summary>
        /// Create new user.
        /// </summary>
        /// <param name="name"> Name user. </param>
        /// <param name="gender"> Gender user. </param>
        /// <param name="birthDate"> Birth date user. </param>
        /// <param name="weight"> Weight user. </param>
        /// <param name="height"> Growth user. </param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Checking conditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name null or empty!", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Gender cannot be null!", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1930") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Birth date is impossible!", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("The weight cannot be less than zero or equal to zero!", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("The growth cannot be less than zero or equal to zero!", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
