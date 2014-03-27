using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Console
{
    public class Game
    {
        private List<Child> _childrenParticipants;
        private List<Child> _childrenOut = new List<Child>();
        private List<Child> _childrenCounted = new List<Child>();
        private int _outCount;
        private int _outCounter;

        private Stopwatch _stopWatch = new Stopwatch();



        public Game(List<Child> childrenOnCircle, int outCount)
        {
            _childrenParticipants = childrenOnCircle;
            _outCount = outCount;
        }

        public void StartGame()
        {
            _stopWatch.Start();
            DoTheCount();
           
            _stopWatch.Stop();
            System.Console.WriteLine(string.Format("game time total is {0}", _stopWatch.Elapsed));
        }

        private void DoTheCount()
        {
            foreach (Child child in _childrenParticipants)
            {
                _outCounter += 1;
                child.Count(_outCounter);

                if (_outCounter == _outCount)
                {
                    child.AnnounceOut();
                    _childrenOut.Add(child);
                    _outCounter = 0;
                }

                _childrenCounted.Add(child);
            }

             _childrenParticipants = _childrenParticipants.Except(_childrenOut).ToList();
            _childrenCounted = new List<Child>();

            if(_childrenParticipants.Count > 1)
                DoTheCount();
            else
            {
                _childrenParticipants[0].AnnounceWinner();
            }
        }
    }
}
