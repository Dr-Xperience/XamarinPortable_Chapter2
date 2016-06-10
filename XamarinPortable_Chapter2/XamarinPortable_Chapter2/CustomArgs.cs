using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinPortable_Chapter2
{
    public class CustomArgs : EventArgs
    {

        public CustomArgs()
        {
        
        }

        private String labelArg;

        public String LabelArgs
        {
            get { return labelArg; }
            set { labelArg = value; }
        }

        private String msg;
        public String Message
        {
            get
            {
                return msg;
            }
            set
            {
                msg = value;
            }
        }
        private long counter;
        public long Counter
        {
            get
            {
                return counter+1 / 1000;
            }
            set
            {
                counter = value;
            }
        }

        public CancellationTokenSource CancelTokenSource
        {
            get
            {
                return cancelTokenSource;
            }

            set
            {
                cancelTokenSource = value;
            }
        }

        private CancellationTokenSource cancelTokenSource;
    }
}
