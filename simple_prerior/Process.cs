using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace simple_prerior
{
    class Process
    {
        private int step;
        private string symbol;
        private string relation;
        private string input;
        private string generator;

        public int Step
        {
            get { return step; }
            set { step = value; }
        }
        
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }
        
        public string Relation
        {
            get { return relation; }
            set { relation = value; }
        }

        public string Input
        {
            get { return input; }
            set { input = value; }
        }

        public string Generator
        {
            get { return generator; }
            set { generator = value; }
        }

    }
}
