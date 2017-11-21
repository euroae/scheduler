using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShiftObjects;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataObjects
{
    [Serializable()]
    public class Conflict : ISerializable
    {
        public string   _conflictType;
        public Shift    _conflict1;
        public Shift    _conflict2;

        #region serialization functions

        public Conflict(SerializationInfo info, StreamingContext ctxt)
        {
            this._conflictType = (string)info.GetValue("conflictType", typeof(string));
            this._conflict1 = (Shift)info.GetValue("conflict1", typeof(Shift));
            this._conflict2 = (Shift)info.GetValue("conflict2", typeof(Shift));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("conflictType", this._conflictType);
            info.AddValue("conflict1", this._conflict1);
            info.AddValue("conflict2", this._conflict2);
        }

        #endregion

        public Conflict()
        {
            this._conflict1 = new Shift();
            this._conflict2 = new Shift();
            this._conflictType = "";
        }

        public bool Contains(Shift target)
        {
            if (this._conflict1.Equals(target) || this._conflict2.Equals(target))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///  overridden ToString class. Format internal data into a string for your reading pleasure
        /// </summary>
        /// <returns>The eye pleasing string</returns>
        public override string ToString()
        {
            string output = " - " + _conflictType + " between: ";
            output += Environment.NewLine;
            if (this._conflict1.ShiftNumber >= this._conflict2.ShiftNumber)
            {
                output += "" + this._conflict2.ShiftNumber + " " + this._conflict2.ToString();
                output += Environment.NewLine;
                output += "" + this._conflict1.ShiftNumber + " " + this._conflict1.ToString();
            }
            else
            {
                output += "" + this._conflict1.ShiftNumber + " " + this._conflict1.ToString();
                output += Environment.NewLine;
                output += "" + this._conflict2.ShiftNumber + " " + this._conflict2.ToString();
            }
            
            return output;
        }

        public bool Equals(Conflict obj)
        {
            if (this._conflictType == obj._conflictType)
            {
                if ((this._conflict1.Equals(obj._conflict1) && this._conflict2.Equals(obj._conflict2))
                    || (this._conflict1.Equals(obj._conflict2) && this._conflict2.Equals(obj._conflict1)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
