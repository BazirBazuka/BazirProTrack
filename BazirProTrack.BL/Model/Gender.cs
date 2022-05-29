using System;


namespace BazirProTrack.BL.Model
{
    [Serializable]
    /// <summary>
    /// Пол|Gender
    /// </summary>

    public class Gender
    {
        /// <summary>
        /// Название | Title
        /// </summary>
        
        public string Name { get; }

        /// <summary>
        /// Создать новый пол | Create New Gender
        /// </summary>
        /// <param name="name">Имя пола | Gender Name</param>

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Gender value could not be empty or null. ", nameof(name));
            }
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
