using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XamarinPortable
{
    class Looper
    {

        public Looper()
        {
            //this.loop = startInfiniteLoop;
        }

        private String styleID;

        public String StyleID
        {
            get
            {
                if (styleID != null)
                    return styleID;
                else
                    throw new Exception("No Looper Label");
            }

            set
            {
                styleID = value;
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


        public event EventHandler<CustomArgs> Notification;

        //public Action loop;

        public void startInfiniteLoop()
        {
            try
            {
                for (long i = 1; ; ++i)
                {
                    if (i / 1000 == 0)
                    {
                        cancelTokenSource.Token.ThrowIfCancellationRequested();
                        Notification(this, new CustomArgs()
                        {
                            Message = "Iterated 1000 x" + i + 1 / 1000 + " times ",
                            LabelArgs = StyleID,
                            Counter = i,
                            CancelTokenSource = CancelTokenSource
                        });
                    }
                }
            }
            catch(OperationCanceledException e)
            {
                System.Diagnostics.Debug.WriteLine("Interupted");
            }
        }
    }
}
