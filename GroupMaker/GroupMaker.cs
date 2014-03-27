using System;
using System.Collections.Generic;

namespace GroupCreator
{
    public class GroupMaker
    {
        public IList<Group> ParseGroups(string groupText)
        {
            string[] groupsSplitByLine = groupText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            IList<Group> groupList = new List<Group>();

            foreach (var groupLine in groupsSplitByLine)
            {
                groupList.Add(new Group() { Name = groupLine });
            }

            return groupList;
        }
    }
}