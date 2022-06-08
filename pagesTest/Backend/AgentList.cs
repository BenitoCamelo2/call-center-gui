using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pagesTest.Backend
{
    public class AgentList
    {
        //AGENT NODE //
        public class AgentNode
        {
            public Agent data = new Agent();
            public AgentNode prev;
            public AgentNode next;

            public AgentNode(Agent data) { this.data = data; }
            public AgentNode() { this.data = new Agent(); this.next = null; this.prev = null; }
        }

        AgentNode head;

        // AGENT NODE //

        // FUNCTIONS //

        private bool isValidPos(AgentNode agentNode)
        {
            AgentNode temp = head;

            while (temp != null)
            {
                if (temp.data == agentNode.data)
                {
                    return true;
                }

                temp = temp.next;
            }
            return false;
        }

        public bool isEmpty()
        {
            return head == null;
        }

        public void insertData(AgentNode agentNode, Agent data)
        {
            if (agentNode != null && !isValidPos(agentNode))
            {
                throw new Exception("Invalid position, restart and try again");
            }

            if (agentNode == null)
            {
                agentNode = head;
            }

            AgentNode newOne = new AgentNode();

            if (newOne == null)
            {
                throw new Exception("No more ram available");
            }

            newOne.next = head;
            newOne.prev = null;

            if (head != null)
            {
                head.prev = newOne;
            }

            head = newOne;
        }

        public void deleteData(AgentNode agentNode)
        {
            AgentNode temp = head;

            if (agentNode == null)
            {
                throw new Exception("Agent doesn't exist");
            }
            else if (temp == null)
            {
                throw new Exception("No agents in list");
            }

            if (temp == agentNode)
            {
                head = head.next;
                return;
            }

            if (agentNode == getLastPos())
            {
                temp = agentNode;
                temp = temp.prev;
                temp.next = null;
                return;
            }

            if (agentNode != head && agentNode != getLastPos())
            {
                while (temp != agentNode)
                {
                    temp = temp.next;
                }

                if (temp == agentNode)
                {
                    temp.next.prev = temp.prev;
                    temp.prev.next = temp.next;
                }
                else
                {
                    throw new Exception("Couldn't find agent");
                }
            }
        }

        public AgentNode getFirstPos()
        {
            return head;
        }

        public AgentNode getLastPos()
        {
            AgentNode temp = head;

            if (!isEmpty())
            {
                while (temp != null)
                {
                    temp = temp.next;
                }

                return temp;
            }
            else
            {
                return null;
            }
        }

        public AgentNode getNext(AgentNode agentNode)
        {
            return agentNode.next;
        }

        public AgentNode getPrev(AgentNode agentNode)
        {
            return agentNode.prev;
        }

        public AgentNode retrievePos(Agent agent)
        {
            AgentNode temp = head;

            while (temp != null)
            {
                if (temp.data == agent)
                {
                    return temp;
                }
            }

            return null;
        }

        public Agent findData(AgentNode agentNode)
        {
            if (!isValidPos(agentNode))
            {
                return new Agent();
            }

            return agentNode.data;
        }

        public string toString()
        {
            AgentNode temp = head;
            string result = "";

            while (temp != null)
            {
                result += temp.data.toString();
                result += "\n";
            }

            return result;
        }
    }
}
