using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pagesTest.Backend
{
    public class Agent
    {
        //i think this is private
        public string firstName;
        public string lastName;
        public string code;
        public Time startTime;
        public Time endTime;
        public string extension;
        public string extraHours;
        public string specialty;

        public Agent(string firstName, string lastName, string code, Time startTime, Time endTime, string extension, string extraHours, string specialty)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.code = code;
            this.startTime = startTime;
            this.endTime = endTime;
            this.extension = extension;
            this.specialty = specialty;
            this.extraHours = extraHours;
        }
        public Agent()
        {
            firstName = "";
            lastName = "";
            code = "";
            startTime = new Time();
            endTime = new Time();
            extension = "";
            specialty = "";
            extraHours = "";
        }

        public string toString()
        {
            string result;

            result = firstName;
            result += "|";
            result += lastName;
            result += "|";
            result += code;
            result += "|";
            result += startTime.toString();

            return result;
        }

        public static bool operator ==(Agent left, Agent right)
        {
            return left.code == right.code;
        }

        public static bool operator !=(Agent left, Agent right)
        {
            return left.code != right.code;
        }
    }
}
