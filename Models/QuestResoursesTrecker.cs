using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace editor.Models
{
    public class QuestResoursesTrecker
    {
        private readonly Timer timer;

        private readonly object locker;
        private bool isChenged;

        public event Action<bool> OnChenged;
        public bool HasChenged
        {
            get
            {
                lock(locker)
                {
                    return isChenged;
                }
            }
            set
            {
                lock(locker)
                {
                    if(isChenged != value) OnChenged?.Invoke(value);
                    isChenged = value;
                }    
            }
        }
        private readonly ObjectTrecker[] treckers;

        public QuestResoursesTrecker(QuestResourses questResourses)
        { 
            /*
            locker = new object();
            treckers = new ObjectTrecker[] {
                new ObjectTrecker(() => questResourses.Variables),
                new ObjectTrecker(() => questResourses.Dialogs),
                new ObjectTrecker(() => questResourses.Images)
            };
            timer = new Timer((o) => {
                Console.WriteLine("run check has chenged");
                var isChanged = treckers.Any(t => t.IsChanged);
                HasChenged = isChanged || HasChenged;
                Console.WriteLine("check has chenged");
            }, null, 1000, 1000);
            */
        }
    }
}