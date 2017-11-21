using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Priority_Queue
{
    // just a node to store strings inside the priority queue
    public class StringNode : PriorityQueueNode
    {
        private string  _text;

        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        public StringNode()
        {
            this._text = "";
        }

        public StringNode(string text)
        {
            this._text = text;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
