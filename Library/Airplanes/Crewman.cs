using System.Runtime.Serialization;

namespace Library.Airplanes
{
    [DataContract]
    [KnownType(typeof(Crewman))]
    public struct Crewman
    {
        [DataMember]
        public string Position { get; private set; }
        [DataMember]
        public string FullName { get; private set; } 

        public Crewman(string position, string fullName)
        {
            Position = position;
            FullName = fullName;
        }

        public override string ToString()
        {
            return $"{FullName} - {Position}";
        }
    }
}
