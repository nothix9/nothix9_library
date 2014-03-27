using System;

namespace GroupCreator
{
    public class GroupCoordinator
    {
        public string ParticipantText { get; set; }
        public string GroupText { get; set; }

        public void SetPartipantText(string participantText)
        {
            if(string.IsNullOrEmpty(participantText)) throw new ArgumentNullException();
            ParticipantText = participantText;
        }

        public void SetGroupText(string groupText)
        {
            if (string.IsNullOrEmpty(groupText)) throw new ArgumentNullException();
            GroupText = groupText;
        }
    }
}