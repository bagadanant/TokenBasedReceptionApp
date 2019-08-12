using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TokenBasedReceptionApp.Helpers
{
    public class WaitingQueueHelper
    {
        private static WaitingQueueHelper instance;
        private static object syncRoot = new object();

        private Queue<int> queue;
        private int lastToken = 0;
        private WaitingQueueHelper()
        {
            queue = new Queue<int>();
        }
        public static WaitingQueueHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new WaitingQueueHelper();
                        }
                    }
                }
                return instance;
            }
        }


        public void Arrival(int token)
        {
            if (!queue.Contains(token))
            {
                queue.Enqueue(token);
                lastToken++;
            }
        }

        public int Attended()
        {
           return queue.Dequeue();
        }

        public int Unattended()
        {
            int token = queue.Dequeue();
            queue.Enqueue(token);

            return token;
        }

        public int InActionToken { get { return queue.Count() > 0 ? queue.Peek() : 0; } private set { } }

        public int LastToken { get { return lastToken; } private set { } }
        public int[] GetAll()
        {
            return queue.ToArray();
        }
    }
}