using System.Collections.Generic;
using System.Text;
using GroupCreator;
using NUnit.Framework;
using Rhino.Mocks;

namespace GroupMakerTest
{
    [TestFixture]
    public class GroupMakerTest
    {
       
        [Test]
        public void ParseToGroups_WhenThereAreFourLinesOfString_ThereShouldBeFourGroups()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Group1");
            sb.AppendLine("Group2");
            sb.AppendLine("Group3");
            sb.Append("Group4");


            var groupMaker = new GroupMaker();
            IList<Group> groups = groupMaker.ParseGroups(sb.ToString());



            Assert.That(groups.Count, Is.EqualTo(4));
        }
    }
}
