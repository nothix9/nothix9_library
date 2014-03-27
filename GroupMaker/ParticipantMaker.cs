using System;
using System.Collections.Generic;

namespace GroupCreator
{
    public class ParticipantMaker
    {
        public IList<Participant> ParseParticipants(string participantText)
        {
            string[] participantsSplitByLine = participantText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            IList<Participant> participantList = new List<Participant>();
         
            foreach (var participantLine in participantsSplitByLine)
            {
                participantList.Add(new Participant(){Name = participantLine});
            }

            return participantList;

        }
    }
}